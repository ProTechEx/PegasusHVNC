using System;
using System.IO;
using System.Windows.Forms;
using PEGASUS.Design;
using PEGASUS.Diadyktio;
using PEGASUS.Metafora_Dedomenon;

namespace PEGASUS.BytesInOut
{
	public class HandleInformation
	{
		public void AddToInformationList(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				string text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + unpack_msgpack.ForcePathObject("ID").AsString + "\\Information");
				string path = text + "\\Information.txt";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				File.WriteAllText(path, unpack_msgpack.ForcePathObject("InforMation").AsString);
				while (!File.Exists(path))
				{
				}
				using FrmInfo frmInfo = new FrmInfo(Path.Combine(Application.StartupPath, "ClientsFolder\\" + unpack_msgpack.ForcePathObject("ID").AsString + "\\Information\\Information.txt"));
				frmInfo.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
