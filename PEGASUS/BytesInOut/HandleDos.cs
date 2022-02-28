using System.Windows.Forms;
using PEGASUS.Design;
using PEGASUS.Diadyktio;
using PEGASUS.Metafora_Dedomenon;

namespace PEGASUS.BytesInOut
{
	internal class HandleDos
	{
		public void Add(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				FormDOS formDOS = (FormDOS)Application.OpenForms["DOS"];
				if (formDOS != null)
				{
					lock (formDOS.sync)
					{
						formDOS.PlguinClients.Add(client);
						return;
					}
				}
			}
			catch
			{
			}
		}
	}
}
