using System;
using System.Collections.Generic;

namespace SeedBrutoforce.ResponseModels
{
	// Token: 0x02000014 RID: 20
	public class ActivationResponse
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000049 RID: 73 RVA: 0x0000217A File Offset: 0x0000037A
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002182 File Offset: 0x00000382
		public string result { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600004B RID: 75 RVA: 0x0000218B File Offset: 0x0000038B
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00002193 File Offset: 0x00000393
		public string userId { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004D RID: 77 RVA: 0x0000219C File Offset: 0x0000039C
		// (set) Token: 0x0600004E RID: 78 RVA: 0x000021A4 File Offset: 0x000003A4
		public int checkScore { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000021AD File Offset: 0x000003AD
		// (set) Token: 0x06000050 RID: 80 RVA: 0x000021B5 File Offset: 0x000003B5
		public int checkStart { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000051 RID: 81 RVA: 0x000021BE File Offset: 0x000003BE
		// (set) Token: 0x06000052 RID: 82 RVA: 0x000021C6 File Offset: 0x000003C6
		public int updateInterval { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000053 RID: 83 RVA: 0x000021CF File Offset: 0x000003CF
		// (set) Token: 0x06000054 RID: 84 RVA: 0x000021D7 File Offset: 0x000003D7
		public int lockBlockchains { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000055 RID: 85 RVA: 0x000021E0 File Offset: 0x000003E0
		// (set) Token: 0x06000056 RID: 86 RVA: 0x000021E8 File Offset: 0x000003E8
		public string[] blockchains { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000021F1 File Offset: 0x000003F1
		// (set) Token: 0x06000058 RID: 88 RVA: 0x000021F9 File Offset: 0x000003F9
		public string error { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002202 File Offset: 0x00000402
		// (set) Token: 0x0600005A RID: 90 RVA: 0x0000220A File Offset: 0x0000040A
		public List<Seed> seeds { get; set; }
	}
}
