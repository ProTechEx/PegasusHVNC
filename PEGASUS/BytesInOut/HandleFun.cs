using System.Windows.Forms;
using PEGASUS.Design;
using PEGASUS.Diadyktio;
using PEGASUS.Metafora_Dedomenon;

namespace PEGASUS.BytesInOut
{
	public class HandleFun
	{
		public void Fun(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				FormFun formFun = (FormFun)Application.OpenForms["fun:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
				if (formFun != null && formFun.Client == null)
				{
					formFun.Client = client;
					formFun.timer1.Enabled = true;
				}
			}
			catch
			{
			}
		}
	}
}
