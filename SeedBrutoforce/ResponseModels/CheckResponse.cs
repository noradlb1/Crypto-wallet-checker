using System;
using System.Collections.Generic;

namespace SeedBrutoforce.ResponseModels
{
	// Token: 0x02000015 RID: 21
	public class CheckResponse
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002213 File Offset: 0x00000413
		// (set) Token: 0x0600005D RID: 93 RVA: 0x0000221B File Offset: 0x0000041B
		public string result { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002224 File Offset: 0x00000424
		// (set) Token: 0x0600005F RID: 95 RVA: 0x0000222C File Offset: 0x0000042C
		public string error { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002235 File Offset: 0x00000435
		// (set) Token: 0x06000061 RID: 97 RVA: 0x0000223D File Offset: 0x0000043D
		public List<Seed> seeds { get; set; }
	}
}
