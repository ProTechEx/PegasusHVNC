using System;
using System.Collections.Specialized;
using System.Net;

namespace PEGASUS.Pegasus
{
	public class defender : IDisposable
	{
		private static readonly NameValueCollection discordValues = new NameValueCollection();

		private readonly WebClient dWebClient;

		public string WebHook { get; set; }

		public string UserName { get; set; }

		public string ProfilePicture { get; set; }

		public defender()
		{
			dWebClient = new WebClient();
		}

		public void Dispose()
		{
			dWebClient.Dispose();
		}

		public void SendMessage(string msgSend)
		{
			discordValues.Add("username", UserName);
			discordValues.Add("avatar_url", ProfilePicture);
			discordValues.Add("content", msgSend);
			dWebClient.UploadValues(WebHook, discordValues);
		}
	}
}
