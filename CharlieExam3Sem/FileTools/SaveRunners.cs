using CharlieExam3Sem.Data;
using CharlieExam3Sem.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CharlieExam3Sem.FileTools
{
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
