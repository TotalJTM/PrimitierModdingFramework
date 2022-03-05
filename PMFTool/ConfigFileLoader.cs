﻿using BetterConsole.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMFTool
{
	public static class ConfigFileLoader
	{

		public static void SaveConfig(string path, ConfigFile config)
		{
			try
			{
				File.WriteAllText(path, JsonConvert.SerializeObject(config));

			}catch(Exception e)
			{
				ConsoleWriter.WriteLineError("Could not save config file", e);
			}
			
		}


		public static ConfigFile? Load(string path)
		{
			if (!File.Exists(path))
			{
				ConsoleWriter.WriteLineError($"Can not find config file '{path}'");
				bool awnser= ConsoleDrawer.DrawYesOrNo(31, "Would you like to generate it", CancellationToken.None);
				if (awnser)
				{
					var config = new ConfigFile();
					File.WriteAllText(path, JsonConvert.SerializeObject(config));
				}

				return null;
			}

			try
			{
				var config = JsonConvert.DeserializeObject<ConfigFile>(File.ReadAllText(path));

				string oldPrimitierPath = config?.PrimitierPath;
				if (config == null || !File.Exists(config.PrimitierPath))
				{

					ConsoleWriter.WriteLineError("Primitier path was invalid. please enter a valid one");
					config.PrimitierPath = ConsoleDrawer.DrawTextInput(oldPrimitierPath, CancellationToken.None);

					SaveConfig(path, config);
				}

				return config;

			}
			catch (JsonException e)
			{
				ConsoleWriter.WriteLineError($"Invalid config file '{path}'", e);
				return null;
			}



		}

	}
}
