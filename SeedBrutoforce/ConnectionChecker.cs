using System;
using System.IO;
using System.Net;

namespace SeedBrutoforce
{
	// Token: 0x0200000D RID: 13
	public static class ConnectionChecker
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00004258 File Offset: 0x00002458
		public static ConnectionChecker.ConnectionStatus CheckInternet()
		{
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry("dns.msftncsi.com");
				if (hostEntry.AddressList.Length == 0)
				{
					return ConnectionChecker.ConnectionStatus.NotConnected;
				}
				if (!hostEntry.AddressList[0].ToString().Equals("131.107.255.255"))
				{
					return ConnectionChecker.ConnectionStatus.LimitedAccess;
				}
			}
			catch
			{
				return ConnectionChecker.ConnectionStatus.NotConnected;
			}
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.msftncsi.com/ncsi.txt");
			ConnectionChecker.ConnectionStatus result;
			try
			{
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
					{
						if (streamReader.ReadToEnd().Equals("Microsoft NCSI"))
						{
							return ConnectionChecker.ConnectionStatus.Connected;
						}
						return ConnectionChecker.ConnectionStatus.LimitedAccess;
					}
				}
				result = ConnectionChecker.ConnectionStatus.LimitedAccess;
			}
			catch
			{
				result = ConnectionChecker.ConnectionStatus.NotConnected;
			}
			return result;
		}

		// Token: 0x0200000E RID: 14
		public enum ConnectionStatus
		{
			// Token: 0x0400004D RID: 77
			NotConnected,
			// Token: 0x0400004E RID: 78
			LimitedAccess,
			// Token: 0x0400004F RID: 79
			Connected
		}
	}
}
