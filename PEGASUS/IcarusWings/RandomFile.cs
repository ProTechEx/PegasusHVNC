using System;
using System.Collections.Generic;

namespace PEGASUS.IcarusWings
{
	public class RandomFile
	{
		public class RandomFileInfo
		{
			private readonly List<PreMadeFileInfo.PremadeFileInfo> premadeFileInfoList = new List<PreMadeFileInfo.PremadeFileInfo>
			{
				new PreMadeFileInfo.PremadeFileInfo
				{
					Title = "chome_exe",
					Description = "Google Chrome",
					Product = "Google Chrome",
					Company = "Google Inc.",
					Copyright = "Copyright 2017 Google Inc. All rights reserved.",
					Trademark = "",
					MajorVersion = "67",
					MinorVersion = "0",
					BuildPart = "3396",
					PrivatePart = "99"
				},
				new PreMadeFileInfo.PremadeFileInfo
				{
					Title = "vlc",
					Description = "VLC media player",
					Product = "VLC media player",
					Company = "VideoLAN",
					Copyright = "Copyright © 1996-2018 VideoLAN and VLC Author",
					Trademark = "VLC media player, VideoLAN and x264 are registered trademarks from VideoLAN",
					MajorVersion = "3",
					MinorVersion = "0",
					BuildPart = "3",
					PrivatePart = "0"
				},
				new PreMadeFileInfo.PremadeFileInfo
				{
					Title = "HWMonitor.exe",
					Description = "HWMonitor",
					Product = "CPUID Hardware Monitor",
					Company = "CPUID",
					Copyright = "(c)2008-2018 CPUID.  All rights reserved.",
					Trademark = "",
					MajorVersion = "1",
					MinorVersion = "3",
					BuildPart = "4",
					PrivatePart = "0"
				},
				new PreMadeFileInfo.PremadeFileInfo
				{
					Title = "CamtasiaStudio.exe",
					Description = "TechSmith Camtasia 2018",
					Product = "Camtasia",
					Company = "TechSmith Corporation",
					Copyright = "Copyright © 2011-2018 TechSmith Corporation. All rights reserved.",
					Trademark = "18",
					MajorVersion = "0",
					MinorVersion = "0",
					BuildPart = "31",
					PrivatePart = "0"
				}
			};

			private readonly Random random = new Random();

			private readonly CryptUtil.RandomCharacters randomCharacters;

			private int lastIndex;

			public RandomFileInfo(CryptUtil.RandomCharacters randomCharacters)
			{
				this.randomCharacters = randomCharacters;
			}

			public PreMadeFileInfo.PremadeFileInfo getRandomFileInfo()
			{
				if (random.Next(0, 7) == 0)
				{
					return new PreMadeFileInfo.PremadeFileInfo
					{
						Title = randomWords(2),
						Description = randomWords(2),
						Product = randomWords(2),
						Company = randomWords(2),
						Copyright = randomWords(2),
						Trademark = randomWords(2),
						MajorVersion = random.Next(0, 10).ToString(),
						MinorVersion = random.Next(0, 10).ToString(),
						BuildPart = random.Next(0, 10).ToString(),
						PrivatePart = random.Next(0, 10).ToString()
					};
				}
				int num = lastIndex;
				do
				{
					num = random.Next(0, premadeFileInfoList.Count - 1);
				}
				while (num == lastIndex);
				lastIndex = num;
				return premadeFileInfoList[num];
			}

			private string randomWords(int numberOfWords)
			{
				List<string> list = new List<string>();
				for (int i = 0; i < numberOfWords; i++)
				{
					list.Add(randomCharacters.getRandomCharacters(random.Next(5, 10)));
				}
				return string.Join(" ", list);
			}
		}
	}
}
