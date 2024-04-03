using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using SeedBrutoforce.ResponseModels;

namespace SeedBrutoforce
{
	// Token: 0x0200000F RID: 15
	internal static class Program
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00004344 File Offset: 0x00002544
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (!Program.isSingle())
			{
				MessageBox.Show("You cant run second app!");
				Application.Exit();
			}
			else if (ConnectionChecker.CheckInternet() != ConnectionChecker.ConnectionStatus.Connected)
			{
				MessageBox.Show("Please connect to internet!");
				Application.Exit();
			}
			else
			{
				Program.comp_id = Program.getComputerId();
				if (Program.comp_id != null)
				{
					Task<bool> task = Program.checkActivation(Program.comp_id);
					task.Wait();
					if (task.Result)
					{
						Program.runBrutoForm();
					}
					else
					{
						Program.runActivationForm();
					}
				}
				else
				{
					Program.runActivationForm();
				}
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000212F File Offset: 0x0000032F
		public static void runBrutoForm()
		{
			Application.Run(new BrutoForm());
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000213B File Offset: 0x0000033B
		public static void runActivationForm()
		{
			Application.Run(new ActivationForm());
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000043D8 File Offset: 0x000025D8
		public static bool isSingle()
		{
			Process currentProcess = Process.GetCurrentProcess();
			Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
			foreach (Process process in processesByName)
			{
				if (process.Id != currentProcess.Id && Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == currentProcess.MainModule.FileName)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004458 File Offset: 0x00002658
		public static string getComputerId()
		{
			string result;
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software", true);
				registryKey = registryKey.OpenSubKey(Program.APP_NAME, true);
				result = (string)registryKey.GetValue("ID");
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000044B0 File Offset: 0x000026B0
		private static async Task<bool> checkActivation(string id)
		{
			try
			{
				WebRequest request = WebRequest.Create(Program.serverName + Program.checkRoute);
				request.Method = "POST";
				string data = "id=" + id + "&start=true";
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
					RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software", true);
					regKey = regKey.CreateSubKey(Program.APP_NAME, true);
					regKey.SetValue("ID", activationResponse.userId);
					Program.comp_id = activationResponse.userId;
					Program.CHECK_SCORE = activationResponse.checkScore;
					Program.updateTimeout = activationResponse.updateInterval * 1000;
					Program.lockBlockchains = (activationResponse.lockBlockchains == 1);
					Program.BLOCKCHAINS = activationResponse.blockchains.ToList<string>();
					Program.CHECK_START = activationResponse.checkStart;
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
					regKey = null;
				}
				response.Close();
				return activationResponse.result == "true";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Something went wrong..");
			}
			return false;
		}

		// Token: 0x04000050 RID: 80
		public static string APP_NAME = "SEED_BRUTOFORCE'";

		// Token: 0x04000051 RID: 81
		public static string ACTIVATED_VALUE = "ACTIVATED";

		// Token: 0x04000052 RID: 82
		public static string FOUND_SEEDS = "FOUND";

		// Token: 0x04000053 RID: 83
		public static string comp_id = null;

		// Token: 0x04000054 RID: 84
		public static int IMMEDIATELY_FIND_SEED_SCORE = -1;

		// Token: 0x04000055 RID: 85
		public static int WORDS_COUNT_IN_ROW = 12;

		// Token: 0x04000056 RID: 86
		public static int SPEED_PER_ROW = 10;

		// Token: 0x04000057 RID: 87
		public static int CHECK_START = 0;

		// Token: 0x04000058 RID: 88
		public static string MNEMONIC_TEXT = "Wallet check:";

		// Token: 0x04000059 RID: 89
		public static string SAVE_FILE = "results.txt";

		// Token: 0x0400005A RID: 90
		public static bool CAN_EDIT_FOUND = false;

		// Token: 0x0400005B RID: 91
		public static int CHECK_SCORE;

		// Token: 0x0400005C RID: 92
		public static string serverName = "http://127.0.0.1:1525";

		// Token: 0x0400005D RID: 93
		public static string checkRoute = "/api/check-activation.php";

		// Token: 0x0400005E RID: 94
		public static string activateKey = "/api/activate-key.php";

		// Token: 0x0400005F RID: 95
		public static string findSeedRoute = "/api/find-seed.php";

		// Token: 0x04000060 RID: 96
		public static int updateTimeout;

		// Token: 0x04000061 RID: 97
		public static bool lockBlockchains;

		// Token: 0x04000062 RID: 98
		public static List<string> BLOCKCHAINS;

		// Token: 0x04000063 RID: 99
		public static List<Seed> seeds;
	}
}
