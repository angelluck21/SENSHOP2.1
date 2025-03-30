namespace SENSHOP2._1.Models
{
	public class ErrorViewModel
	{
		public string? RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); 
		 
		public string? message { get; set; }
		public bool ShowRequetId => !string.IsNullOrEmpty(RequestId);

	}

}
