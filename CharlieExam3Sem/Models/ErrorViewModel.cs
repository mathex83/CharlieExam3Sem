namespace CharlieExam3Sem.Models
{
	///Udviklet af: Martin Nørholm, Janus B. Reedtz og Frederik M. Nielsen
	public class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}
