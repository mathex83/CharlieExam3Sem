using CharlieExam3Sem.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CharlieExam3Sem.FileTools
{
	///Udviklet af: Martin Nørholm
	public class UploadRunners
	{
		public List<Runner> Runners { get; set; }
		public UploadRunners()
		{
			StreamReader reader = new StreamReader(Path.FilePath);
			string fileContent = reader.ReadToEnd();
			Runners = JsonConvert.DeserializeObject<List<Runner>>(fileContent);			
		}
	}
}
