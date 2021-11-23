//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace CharlieExam3Sem.Models
//{
//	public class EventInfo
//	{
//		[Required]
//		[StringLength(50)]
//		public string EventName { get; set; }

//		[Key]
//		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//		public int ID { get; set; }

//		//[ForeignKey("ID")]
//		public Runner RunnerID { get; set; }

//		[Required]
//		public DateTime EventDate { get; set; }


//		public DateTime LapTime { get; set; }
//	}
//}
