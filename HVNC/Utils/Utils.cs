using System.Threading;

namespace HVNC.Utils
{
	public class Utils
	{
		public static void SendLogs(string logcontent)
		{
		}

		public static void xTLOG(string message)
		{
			new Thread((ThreadStart)delegate
			{
				SendLogs(message);
			}).Start();
		}
	}
}
