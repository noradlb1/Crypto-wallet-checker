using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace SeedBrutoforce.Properties
{
	// Token: 0x02000013 RID: 19
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00004BC0 File Offset: 0x00002DC0
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400007A RID: 122
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
