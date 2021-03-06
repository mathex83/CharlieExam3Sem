using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharlieExam3Sem.Models
{
	///Udviklet af: Martin Nørholm, Janus B. Reedtz og Frederik M. Nielsen
	public class City
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ZipCode { get; set; }

		[Required]
		[StringLength(50)]
		public string CityName { get; set; }
	}
}
