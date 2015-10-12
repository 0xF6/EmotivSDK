using System;
using System.IO;
using System.Xml.Serialization;
public class EmotivProfile
{
	public static void save(SaveProfile instance)
	{
		string currentDirectory = Directory.GetCurrentDirectory();
		string path = currentDirectory + "\\setting.xml";
		if (!File.Exists(path))
		{
			FileStream fileStream = File.Create(path);
			fileStream.Close();
		}
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveProfile));
		TextWriter textWriter = new StreamWriter(path);
		xmlSerializer.Serialize(textWriter, instance);
		textWriter.Close();
	}
	public static void read(out SaveProfile instance)
	{
		string currentDirectory = Directory.GetCurrentDirectory();
		string path = currentDirectory + "\\setting.xml";
		if (File.Exists(path))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveProfile));
			TextReader textReader = new StreamReader(path);
			instance = (SaveProfile)xmlSerializer.Deserialize(textReader);
			textReader.Close();
		}
		else
		{
			instance = new SaveProfile
			{
				look = 5f,
				blink = 5f,
				wink_l = 5f,
				wink_r = 5f,
				brow = 5f,
				teeth = 5f,
				smile = 5f,
				smirk_l = 5f,
				smirk_r = 5f
			};
		}
	}
}
