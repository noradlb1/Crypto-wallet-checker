using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SeedBrutoforce.Properties
{
	// Token: 0x02000012 RID: 18
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600003C RID: 60 RVA: 0x000020A9 File Offset: 0x000002A9
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00004A64 File Offset: 0x00002C64
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					ResourceManager resourceManager = new ResourceManager("SeedBrutoforce.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00004AA4 File Offset: 0x00002CA4
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002154 File Offset: 0x00000354
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00004AB8 File Offset: 0x00002CB8
		internal static Bitmap BinanceCoin
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("BinanceCoin", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00004AE4 File Offset: 0x00002CE4
		internal static Bitmap BitCoin
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("BitCoin", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00004B10 File Offset: 0x00002D10
		internal static Bitmap EthCoin
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("EthCoin", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00004B3C File Offset: 0x00002D3C
		internal static Bitmap LiteCoin
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("LiteCoin", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00004B68 File Offset: 0x00002D68
		internal static Bitmap SolanaCoin
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("SolanaCoin", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00004B94 File Offset: 0x00002D94
		internal static Bitmap USDTCoin
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("USDTCoin", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x04000078 RID: 120
		private static ResourceManager resourceMan;

		// Token: 0x04000079 RID: 121
		private static CultureInfo resourceCulture;
	}
}
