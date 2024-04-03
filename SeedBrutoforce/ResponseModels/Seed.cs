using System;

namespace SeedBrutoforce.ResponseModels
{
	// Token: 0x02000016 RID: 22
	public class Seed : IEquatable<Seed>
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002246 File Offset: 0x00000446
		// (set) Token: 0x06000064 RID: 100 RVA: 0x0000224E File Offset: 0x0000044E
		public int id { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002257 File Offset: 0x00000457
		// (set) Token: 0x06000066 RID: 102 RVA: 0x0000225F File Offset: 0x0000045F
		public string name { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002268 File Offset: 0x00000468
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00002270 File Offset: 0x00000470
		public long score { get; set; }

		// Token: 0x06000069 RID: 105 RVA: 0x00004BD4 File Offset: 0x00002DD4
		public bool Equals(Seed other)
		{
			return other != null && this.name == other.name;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002279 File Offset: 0x00000479
		public override bool Equals(object obj)
		{
			return this.Equals(obj as Seed);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002287 File Offset: 0x00000487
		public override int GetHashCode()
		{
			return this.name.GetHashCode();
		}
	}
}
