using CharlieExam3Sem.Data;
using CharlieExam3Sem.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CharlieExam3Sem.FileTools
{
	///Udviklet af: Martin Nørholm
	public class SaveRunners
	{
		private readonly ApplicationDbContext _db;
		private List<Runner> runners;
		public SaveRunners(ApplicationDbContext db)
		{
			_db = db;
			runners = _db.Runners.ToList();
			File.WriteAllText(Path.FilePath, JsonConvert.SerializeObject(runners, Formatting.Indented));
		}
	}
}
