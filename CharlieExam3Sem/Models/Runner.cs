using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharlieExam3Sem.Models
{
	public class Runner
	{
		[Required]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required]
		public DateTime BirthDate { get; set; }

		[Required]
		public string Address { get; set; }

		[ForeignKey("Zip")]
		public City ZipCode { get; set; }

		[Required]
		public int PhoneNumber { get; set; }

		public bool? AssignCaptain { get; set; }

		[Required]
		[StringLength(100)]
		public string EmailAddress { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		private int runnerNumber;

		public int RunnerNumber
		{
			get { return runnerNumber; }
			set { runnerNumber = value; }
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		private DateTime memberSince;

		public DateTime MemberSince
		{
			get { return memberSince; }
			set { memberSince = DateTime.Now.Date; }
		}
	}
}
