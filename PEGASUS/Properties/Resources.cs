using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;

namespace PEGASUS.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					resourceMan = new ResourceManager("PEGASUS.Properties.Resources", typeof(Resources).Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		public static string config => ResourceManager.GetString("config", resourceCulture);

		public static byte[] ConfuserEx => (byte[])ResourceManager.GetObject("ConfuserEx", resourceCulture);

		public static byte[] ip2region => (byte[])ResourceManager.GetObject("ip2region", resourceCulture);

		public static UnmanagedMemoryStream Online => ResourceManager.GetStream("Online", resourceCulture);

		public static UnmanagedMemoryStream Online1 => ResourceManager.GetStream("Online1", resourceCulture);

		public static Icon PEGASUS => (Icon)ResourceManager.GetObject("PEGASUS", resourceCulture);

		public static string RK => ResourceManager.GetString("RK", resourceCulture);

		public static string ShellcodeLoader => ResourceManager.GetString("ShellcodeLoader", resourceCulture);

		public static byte[] tsimpouki => (byte[])ResourceManager.GetObject("tsimpouki", resourceCulture);

		public static string vbs => ResourceManager.GetString("vbs", resourceCulture);

		internal Resources()
		{
		}
	}
}
