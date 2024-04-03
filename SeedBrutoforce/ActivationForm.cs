using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using SeedBrutoforce.ResponseModels;

namespace SeedBrutoforce
{
	// Token: 0x0200000A RID: 10
	public partial class ActivationForm : Form
	{
		// Token: 0x06000024 RID: 36 RVA: 0x0000210D File Offset: 0x0000030D
		public ActivationForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002050 File Offset: 0x00000250
		private void Form1_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003A14 File Offset: 0x00001C14
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.Enabled = false;
			ActivationForm.activateKey(this.textBox1.Text, this);
			this.button1.Enabled = true;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003A4C File Offset: 0x00001C4C
		private static async Task<bool> activateKey(string key, Form actForm)
		{
			try
			{
				WebRequest request = WebRequest.Create(Program.serverName + Program.activateKey);
				request.Method = "POST";
				string data = "key=" + key;
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
				ActivationResponse activationResponse = JsonConvert.DeserializeObject<ActivationResponse>(jsonString);
				if (activationResponse.result == "true")
				{
					MessageBox.Show("Success! Enjoy");
					RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software", true);
					regKey = regKey.CreateSubKey(Program.APP_NAME, true);
					regKey.SetValue("ID", activationResponse.userId);
					Program.comp_id = activationResponse.userId;
					Program.CHECK_SCORE = activationResponse.checkScore;
					Program.CHECK_START = activationResponse.checkStart;
					Program.updateTimeout = activationResponse.updateInterval * 1000;
					Program.lockBlockchains = (activationResponse.lockBlockchains == 1);
					Program.BLOCKCHAINS = activationResponse.blockchains.ToList<string>();
					int counter = Program.CHECK_START;
					foreach (Seed s in activationResponse.seeds)
					{
						if (s.score == -1L)
						{
							counter += Program.CHECK_SCORE;
							s.score = (long)counter;
						}
						else
						{
							s.score += (long)counter;
						}
						s = null;
					}
					List<Seed>.Enumerator enumerator = default(List<Seed>.Enumerator);
					Program.seeds = activationResponse.seeds;
					BrutoForm bf = new BrutoForm();
					actForm.Hide();
					bf.Show();
					regKey = null;
					bf = null;
				}
				else
				{
					MessageBox.Show(activationResponse.error);
				}
				response.Close();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Something went wrong..");
			}
			return false;
		}
	}
}
