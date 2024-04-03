using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SeedBrutoforce.Properties;
using SeedBrutoforce.ResponseModels;

namespace SeedBrutoforce
{
	// Token: 0x02000002 RID: 2
	public partial class BrutoForm : Form
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002294 File Offset: 0x00000494
		public BrutoForm()
		{
			this.InitializeComponent();
			this.prepareFormForBlockChains();
			this.richTextBox1.ReadOnly = !Program.CAN_EDIT_FOUND;
			this.label2.Text = string.Format("Checked:{0}", Program.CHECK_START);
			this.thread = new Thread(new ThreadStart(this.doCheck));
			this.splitedWords = this.words.Split(new char[]
			{
				' '
			});
			this.timer1.Enabled = true;
			this.timer1.Interval = Program.updateTimeout;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002360 File Offset: 0x00000560
		private void BrutoForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				if (this.thread.ThreadState == ThreadState.Suspended)
				{
					this.thread.Resume();
				}
				this.thread.Abort();
				this.thread.Join();
				Application.Exit();
			}
			catch (Exception)
			{
				Application.Exit();
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000023C0 File Offset: 0x000005C0
		private void button1_Click(object sender, EventArgs e)
		{
			bool flag = false;
			foreach (object obj in this.panel5.Controls)
			{
				Control control = (Control)obj;
				if (control is CheckBox)
				{
					CheckBox checkBox = (CheckBox)control;
					if (checkBox.Checked)
					{
						flag = true;
					}
				}
			}
			if (!flag)
			{
				MessageBox.Show("Please check blockchain!");
			}
			else
			{
				this.running = true;
				this.button2.Enabled = true;
				this.button1.Enabled = false;
				if (this.thread.ThreadState == ThreadState.Suspended)
				{
					this.thread.Resume();
				}
				else
				{
					this.thread.Start();
				}
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002052 File Offset: 0x00000252
		private void button2_Click(object sender, EventArgs e)
		{
			this.running = false;
			this.button2.Enabled = false;
			this.button1.Enabled = true;
			this.thread.Suspend();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002498 File Offset: 0x00000698
		private void doCheck()
		{
			Random random = new Random();
			while (this.count < 9223372036854775807L)
			{
				string res = "";
				for (int i = 0; i < Program.WORDS_COUNT_IN_ROW; i++)
				{
					res = res + " " + this.splitedWords[random.Next(0, this.splitedWords.Length - 1)];
				}
				this.richTextBox2.Invoke(new Action(delegate()
				{
					if (this.richTextBox2.Text.Length > 1500)
					{
						this.richTextBox2.Text = this.richTextBox2.Text.Substring(0, 1500);
					}
					this.richTextBox2.Text = string.Concat(new string[]
					{
						Program.MNEMONIC_TEXT,
						" ",
						res,
						" \n",
						this.richTextBox2.Text
					});
				}));
				this.label2.Invoke(new Action(delegate()
				{
					this.label2.Text = string.Format("Checked: {0}", this.count);
				}));
				res = "";
				long j = this.count;
				while (j >= 0L && j > this.count - (long)Program.CHECK_SCORE)
				{
					Seed seed2 = Program.seeds.Find((Seed seed) => seed.score == j);
					if (seed2 != null)
					{
						this.doFindSeed(seed2.name, seed2.id);
					}
					long k = j;
					j = k - 1L;
				}
				this.count += (long)Program.CHECK_SCORE;
				Thread.Sleep(Program.SPEED_PER_ROW);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002608 File Offset: 0x00000808
		private void doFindSeed(string name, int id)
		{
			this.richTextBox1.Invoke(new Action(delegate()
			{
				this.richTextBox1.Text = name + "\n" + this.richTextBox1.Text;
			}));
			this.label1.Invoke(new Action(delegate()
			{
				Control control = this.label1;
				string format = "Found: {0}";
				BrutoForm <>4__this = this;
				int num = this.found + 1;
				<>4__this.found = num;
				control.Text = string.Format(format, num);
			}));
			this.saveToFile(name);
			this.findSeedRequest(id);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002050 File Offset: 0x00000250
		private void BrutoForm_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002670 File Offset: 0x00000870
		private void saveToFile(string word)
		{
			try
			{
				File.AppendAllText(Program.SAVE_FILE, word + "\n");
			}
			catch (Exception arg)
			{
				MessageBox.Show("error during saving in file: " + arg);
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000026BC File Offset: 0x000008BC
		private async Task<bool> findSeedRequest(int seed_id)
		{
			try
			{
				WebRequest request = WebRequest.Create(Program.serverName + Program.findSeedRoute);
				request.Method = "POST";
				string data = string.Concat(new object[]
				{
					"computer_id=",
					Program.comp_id,
					"&seed_id=",
					seed_id,
					"&found_at=",
					this.count
				});
				byte[] byteArray = Encoding.UTF8.GetBytes(data);
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = (long)byteArray.Length;
				using (Stream dataStream = request.GetRequestStream())
				{
					dataStream.Write(byteArray, 0, byteArray.Length);
				}
				Stream dataStream = null;
				WebResponse webResponse = await Task.Run<WebResponse>(() => request.GetResponseAsync());
				WebResponse response = webResponse;
				webResponse = null;
				response.Close();
				return true;
			}
			catch (Exception ex)
			{
				this.timer1.Stop();
				MessageBox.Show("Something went wrong..Perhaps theres no internet");
				if (this.thread.ThreadState == ThreadState.Suspended)
				{
					this.thread.Resume();
				}
				this.thread.Abort();
				this.thread.Join();
				Application.Exit();
			}
			return false;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000270C File Offset: 0x0000090C
		private async Task<bool> checkActivation()
		{
			try
			{
                BrutoForm.<> c__DisplayClass15_0 CS$<> 8__locals1 = new BrutoForm.<> c__DisplayClass15_0();
				CS$<>8__locals1.request = WebRequest.Create(Program.serverName + Program.checkRoute);
				CS$<>8__locals1.request.Method = "POST";
				string data = "id=" + Program.comp_id;
				byte[] byteArray = Encoding.UTF8.GetBytes(data);
				CS$<>8__locals1.request.ContentType = "application/x-www-form-urlencoded";
				CS$<>8__locals1.request.ContentLength = (long)byteArray.Length;
				using (Stream dataStream = CS$<>8__locals1.request.GetRequestStream())
				{
					dataStream.Write(byteArray, 0, byteArray.Length);
				}
				Stream dataStream = null;
				WebResponse webResponse = await Task.Run<WebResponse>(() => CS$<>8__locals1.request.GetResponseAsync());
				WebResponse response = webResponse;
				webResponse = null;
				string jsonString = "";
				using (Stream stream = response.GetResponseStream())
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						jsonString += reader.ReadToEnd();
					}
					StreamReader reader = null;
				}
				Stream stream = null;
				CheckResponse checkResponse = JsonConvert.DeserializeObject<CheckResponse>(jsonString);
				response.Close();
				if (checkResponse.result == "true")
				{
					Program.seeds = this.processNewSeeds(checkResponse.seeds);
					return true;
				}
				if (this.thread.ThreadState == ThreadState.Suspended)
				{
					this.thread.Resume();
				}
				this.thread.Abort();
				this.thread.Join();
				this.timer1.Stop();
				MessageBox.Show(checkResponse.error);
				Application.Exit();
				CS$<>8__locals1 = null;
				data = null;
				byteArray = null;
				response = null;
				jsonString = null;
				checkResponse = null;
			}
			catch (Exception ex)
			{
				this.timer1.Stop();
				MessageBox.Show("Something went wrong..Perhaps theres no internet");
				if (this.thread.ThreadState == ThreadState.Suspended)
				{
					this.thread.Resume();
				}
				this.thread.Abort();
				this.thread.Join();
				Application.Exit();
			}
			return false;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002754 File Offset: 0x00000954
		private List<Seed> processNewSeeds(List<Seed> newSeeds)
		{
			List<Seed> result;
			if (newSeeds != null && newSeeds.Count != 0)
			{
				foreach (Seed seed in newSeeds)
				{
					if (seed.score == (long)Program.IMMEDIATELY_FIND_SEED_SCORE)
					{
						this.doFindSeed(seed.name, seed.id);
					}
					else
					{
						seed.score = this.count + seed.score;
					}
				}
				result = Program.seeds.Union(newSeeds).ToList<Seed>();
			}
			else
			{
				result = Program.seeds;
			}
			return result;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002800 File Offset: 0x00000A00
		private void prepareFormForBlockChains()
		{
			int num = Program.BLOCKCHAINS.Count;
			int num2 = 53;
			int num3 = 15;
			int num4 = 40;
			int num5 = 25;
			Size size = new Size(53, 53);
			this.panel5.Height = 80 * (num / 3 + ((num % 3 > 0) ? 1 : 0));
			base.Height += this.panel5.Height;
			this.button1.Location = new Point(this.button1.Location.X, this.button1.Location.Y + this.panel5.Height);
			this.button2.Location = new Point(this.button2.Location.X, this.button2.Location.Y + this.panel5.Height);
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			foreach (string name in Program.BLOCKCHAINS)
			{
				int num10 = 0;
				num8++;
				num9++;
				if (num9 == 3)
				{
					num9 = 0;
				}
				if (num9 == 1 && num8 == num)
				{
					num10 = this.panel5.Width / 2 - num2 / 2;
				}
				else if (num9 == 1 && num8 == num - 1)
				{
					num10 = this.panel5.Width / 3 - num2 / 2;
				}
				else if (num9 == 2 && num8 == num)
				{
					num10 = this.panel5.Width / 3 - num2 / 2;
				}
				CheckBox checkBox = new CheckBox();
				checkBox.Width = num3;
				checkBox.Height = num3;
				checkBox.Location = new Point(num6 + (num2 / 2 - num3 / 3) + num10, num7 + num2 + 5);
				checkBox.Visible = true;
				if (Program.lockBlockchains)
				{
					checkBox.Checked = true;
					checkBox.Enabled = false;
				}
				Panel panel = new Panel();
				panel.BackgroundImage = this.getBitmapForBlockchain(name, size);
				panel.Width = num2;
				panel.Height = num2;
				panel.Location = new Point(num6 + num10, num7);
				panel.Visible = true;
				num6 += num4 + num2;
				if (num6 + num2 > this.panel5.Width)
				{
					num6 = 0;
					num7 += num2 + num5;
				}
				this.panel5.Controls.Add(checkBox);
				this.panel5.Controls.Add(panel);
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002AAC File Offset: 0x00000CAC
		private Bitmap getBitmapForBlockchain(string name, Size size)
		{
			Bitmap result;
			if (!(name == "Bitcoin"))
			{
				if (!(name == "Ethereum"))
				{
					if (!(name == "Litecoin"))
					{
						if (!(name == "Binance Coin"))
						{
							if (!(name == "Solana"))
							{
								if (!(name == "USDT"))
								{
									result = new Bitmap(Resources.BitCoin, size);
								}
								else
								{
									result = new Bitmap(Resources.USDTCoin, size);
								}
							}
							else
							{
								result = new Bitmap(Resources.SolanaCoin, size);
							}
						}
						else
						{
							result = new Bitmap(Resources.BinanceCoin, size);
						}
					}
					else
					{
						result = new Bitmap(Resources.LiteCoin, size);
					}
				}
				else
				{
					result = new Bitmap(Resources.EthCoin, size);
				}
			}
			else
			{
				result = new Bitmap(Resources.BitCoin, size);
			}
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000207E File Offset: 0x0000027E
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.checkActivation();
		}

		// Token: 0x04000001 RID: 1
		private string words = "abandon ability able about above absent absorb abstract absurd abuse access accident account accuse achieve acid acoustic acquire across act action actor actress actual adapt add addict address adjust admit adult advance advice aerobic affair afford afraid again age agent agree ahead aim air airport aisle alarm album alcohol alert alien all alley allow almost alone alpha already also alter always amateur amazing among amount amused analyst anchor ancient anger angle angry animal ankle announce annual another answer antenna antique anxiety any apart apology appear apple approve april arch arctic area arena argue arm armed armor army around arrange arrest arrive arrow art artefact artist artwork ask aspect assault asset assist assume asthma athlete atom attack attend attitude attract auction audit august aunt author auto autumn average avocado avoid awake aware away awesome awful awkward axis baby bachelor bacon badge bag balance balcony ball bamboo banana banner bar barely bargain barrel base basic basket battle beach bean beauty because become beef before begin behave behind believe below belt bench benefit best betray better between beyond bicycle bid bike bind biology bird birth bitter black blade blame blanket blast bleak bless blind blood blossom blouse blue blur blush board boat body boil bomb bone bonus book boost border boring borrow boss bottom bounce box boy bracket brain brand brass brave bread breeze brick bridge brief bright bring brisk broccoli broken bronze broom brother brown brush bubble buddy budget buffalo build bulb bulk bullet bundle bunker burden burger burst bus business busy butter buyer buzz cabbage cabin cable cactus cage cake call calm camera camp can canal cancel candy cannon canoe canvas canyon capable capital captain car carbon card cargo carpet carry cart case cash casino castle casual cat catalog catch category cattle caught cause caution cave ceiling celery cement census century cereal certain chair chalk champion change chaos chapter charge chase chat cheap check cheese chef cherry chest chicken chief child chimney choice choose chronic chuckle chunk churn cigar cinnamon circle citizen city civil claim clap clarify claw clay clean clerk clever click client cliff climb clinic clip clock clog close cloth cloud clown club clump cluster clutch coach coast coconut code coffee coil coin collect color column combine come comfort comic common company concert conduct confirm congress connect consider control convince cook cool copper copy coral core corn correct cost cotton couch country couple course cousin cover coyote crack cradle craft cram crane crash crater crawl crazy cream credit creek crew cricket crime crisp critic crop cross crouch crowd crucial cruel cruise crumble crunch crush cry crystal cube culture cup cupboard curious current curtain curve cushion custom cute cycle dad damage damp dance danger daring dash daughter dawn day deal debate debris decade december decide decline decorate decrease deer defense define defy degree delay deliver demand demise denial dentist deny depart depend deposit depth deputy derive describe desert design desk despair destroy detail detect develop device devote diagram dial diamond diary dice diesel diet differ digital dignity dilemma dinner dinosaur direct dirt disagree discover disease dish dismiss disorder display distance divert divide divorce dizzy doctor document dog doll dolphin domain donate donkey donor door dose double dove draft dragon drama drastic draw dream dress drift drill drink drip drive drop drum dry duck dumb dune during dust dutch duty dwarf dynamic eager eagle early earn earth easily east easy echo ecology economy edge edit educate effort egg eight either elbow elder electric elegant element elephant elevator elite else embark embody embrace emerge emotion employ empower empty enable enact end endless endorse enemy energy enforce engage engine enhance enjoy enlist enough enrich enroll ensure enter entire entry envelope episode equal equip era erase erode erosion error erupt escape essay essence estate eternal ethics evidence evil evoke evolve exact example excess exchange excite exclude excuse execute exercise exhaust exhibit exile exist exit exotic expand expect expire explain expose express extend extra eye eyebrow fabric face faculty fade faint faith fall false fame family famous fan fancy fantasy farm fashion fat fatal father fatigue fault favorite feature february federal fee feed feel female fence festival fetch fever few fiber fiction field figure file film filter final find fine finger finish fire firm first fiscal fish fit fitness fix flag flame flash flat flavor flee flight flip float flock floor flower fluid flush fly foam focus fog foil fold follow food foot force forest forget fork fortune forum forward fossil foster found fox fragile frame frequent fresh friend fringe frog front frost frown frozen fruit fuel fun funny furnace fury future gadget gain galaxy gallery game gap garage garbage garden garlic garment gas gasp gate gather gauge gaze general genius genre gentle genuine gesture ghost giant gift giggle ginger giraffe girl give glad glance glare glass glide glimpse globe gloom glory glove glow glue goat goddess gold good goose gorilla gospel gossip govern gown grab grace grain grant grape grass gravity great green grid grief grit grocery group grow grunt guard guess guide guilt guitar gun gym habit hair half hammer hamster hand happy harbor hard harsh harvest hat have hawk hazard head health heart heavy hedgehog height hello helmet help hen hero hidden high hill hint hip hire history hobby hockey hold hole holiday hollow home honey hood hope horn horror horse hospital host hotel hour hover hub huge human humble humor hundred hungry hunt hurdle hurry hurt husband hybrid ice icon idea identify idle ignore ill illegal illness image imitate immense immune impact impose improve impulse inch include income increase index indicate indoor industry infant inflict inform inhale inherit initial inject injury inmate inner innocent input inquiry insane insect inside inspire install intact interest into invest invite involve iron island isolate issue item ivory jacket jaguar jar jazz jealous jeans jelly jewel job join joke journey joy judge juice jump jungle junior junk just kangaroo keen keep ketchup key kick kid kidney kind kingdom kiss kit kitchen kite kitten kiwi knee knife knock know lab label labor ladder lady lake lamp language laptop large later latin laugh laundry lava law lawn lawsuit layer lazy leader leaf learn leave lecture left leg legal legend leisure lemon lend length lens leopard lesson letter level liar liberty library license life lift light like limb limit link lion liquid list little live lizard load loan lobster local lock logic lonely long loop lottery loud lounge love loyal lucky luggage lumber lunar lunch luxury lyrics machine mad magic magnet maid mail main major make mammal man manage mandate mango mansion manual maple marble march margin marine market marriage mask mass master match material math matrix matter maximum maze meadow mean measure meat mechanic medal media melody melt member memory mention menu mercy merge merit merry mesh message metal method middle midnight milk million mimic mind minimum minor minute miracle mirror misery miss mistake mix mixed mixture mobile model modify mom moment monitor monkey monster month moon moral more morning mosquito mother motion motor mountain mouse move movie much muffin mule multiply muscle museum mushroom music must mutual myself mystery myth naive name napkin narrow nasty nation nature near neck need negative neglect neither nephew nerve nest net network neutral never news next nice night noble noise nominee noodle normal north nose notable note nothing notice novel now nuclear number nurse nut oak obey object oblige obscure observe obtain obvious occur ocean october odor off offer office often oil okay old olive olympic omit once one onion online only open opera opinion oppose option orange orbit orchard order ordinary organ orient original orphan ostrich other outdoor outer output outside oval oven over own owner oxygen oyster ozone pact paddle page pair palace palm panda panel panic panther paper parade parent park parrot party pass patch path patient patrol pattern pause pave payment peace peanut pear peasant pelican pen penalty pencil people pepper perfect permit person pet phone photo phrase physical piano picnic picture piece pig pigeon pill pilot pink pioneer pipe pistol pitch pizza place planet plastic plate play please pledge pluck plug plunge poem poet point polar pole police pond pony pool popular portion position possible post potato pottery poverty powder power practice praise predict prefer prepare present pretty prevent price pride primary print priority prison private prize problem process produce profit program project promote proof property prosper protect proud provide public pudding pull pulp pulse pumpkin punch pupil puppy purchase purity purpose purse push put puzzle pyramid quality quantum quarter question quick quit quiz quote rabbit raccoon race rack radar radio rail rain raise rally ramp ranch random range rapid rare rate rather raven raw razor ready real reason rebel rebuild recall receive recipe record recycle reduce reflect reform refuse region regret regular reject relax release relief rely remain remember remind remove render renew rent reopen repair repeat replace report require rescue resemble resist resource response result retire retreat return reunion reveal review reward rhythm rib ribbon rice rich ride ridge rifle right rigid ring riot ripple risk ritual rival river road roast robot robust rocket romance roof rookie room rose rotate rough round route royal rubber rude rug rule run runway rural sad saddle sadness safe sail salad salmon salon salt salute same sample sand satisfy satoshi sauce sausage save say scale scan scare scatter scene scheme school science scissors scorpion scout scrap screen script scrub sea search season seat second secret section security seed seek segment select sell seminar senior sense sentence series service session settle setup seven shadow shaft shallow share shed shell sheriff shield shift shine ship shiver shock shoe shoot shop short shoulder shove shrimp shrug shuffle shy sibling sick side siege sight sign silent silk silly silver similar simple since sing siren sister situate six size skate sketch ski skill skin skirt skull slab slam sleep slender slice slide slight slim slogan slot slow slush small smart smile smoke smooth snack snake snap sniff snow soap soccer social sock soda soft solar soldier solid solution solve someone song soon sorry sort soul sound soup source south space spare spatial spawn speak special speed spell spend sphere spice spider spike spin spirit split spoil sponsor spoon sport spot spray spread spring spy square squeeze squirrel stable stadium staff stage stairs stamp stand start state stay steak steel stem step stereo stick still sting stock stomach stone stool story stove strategy street strike strong struggle student stuff stumble style subject submit subway success such sudden suffer sugar suggest suit summer sun sunny sunset super supply supreme sure surface surge surprise surround survey suspect sustain swallow swamp swap swarm swear sweet swift swim swing switch sword symbol symptom syrup system table tackle tag tail talent talk tank tape target task taste tattoo taxi teach team tell ten tenant tennis tent term test text thank that theme then theory there they thing this thought three thrive throw thumb thunder ticket tide tiger tilt timber time tiny tip tired tissue title toast tobacco today toddler toe together toilet token tomato tomorrow tone tongue tonight tool tooth top topic topple torch tornado tortoise toss total tourist toward tower town toy track trade traffic tragic train transfer trap trash travel tray treat tree trend trial tribe trick trigger trim trip trophy trouble truck true truly trumpet trust truth try tube tuition tumble tuna tunnel turkey turn turtle twelve twenty twice twin twist two type typical ugly umbrella unable unaware uncle uncover under undo unfair unfold unhappy uniform unique unit universe unknown unlock until unusual unveil update upgrade uphold upon upper upset urban urge usage use used useful useless usual utility vacant vacuum vague valid valley valve van vanish vapor various vast vault vehicle velvet vendor venture venue verb verify version very vessel veteran viable vibrant vicious victory video view village vintage violin virtual virus visa visit visual vital vivid vocal voice void volcano volume vote voyage wage wagon wait walk wall walnut want warfare warm warrior wash wasp waste water wave way wealth weapon wear weasel weather web wedding weekend weird welcome west wet whale what wheat wheel when where whip whisper wide width wife wild will win window wine wing wink winner winter wire wisdom wise wish witness wolf woman wonder wood wool word work world worry worth wrap wreck wrestle wrist write wrong yard year yellow you young youth zebra zero zone zoo";

		// Token: 0x04000002 RID: 2
		private string[] splitedWords;

		// Token: 0x04000003 RID: 3
		private bool running = false;

		// Token: 0x04000004 RID: 4
		private Thread thread;

		// Token: 0x04000005 RID: 5
		private long count = (long)Program.CHECK_START;

		// Token: 0x04000006 RID: 6
		private int found = 0;
	}
}
