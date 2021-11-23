using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieExam3Sem.FileTools
{
	public static class Path
	{
		private static readonly string _filePath = @"..\CharlieExam3Sem\Export\runners.json";

		public static string FilePath
		{
			get { return _filePath; }
		}

	}
}
