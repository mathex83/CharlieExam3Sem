using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharlieExam3Sem.Models
{
	///Udviklet af: Martin Nørholm
	public class EventInfo
	{
		[Required]
		[StringLength(50)]
		public string EventName { get; set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public int RunnerID { get; set; }

		[Required]
		public DateTime EventDate { get; set; }


		public DateTime LapTime { get; set; }
	}
}
