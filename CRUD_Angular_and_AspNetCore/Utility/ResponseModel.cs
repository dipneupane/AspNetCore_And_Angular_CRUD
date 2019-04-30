using System.Collections.Generic;

namespace CRUD_Angular_and_AspNetCore.Utility
{
	public class ResponseModel
	{
		public bool success { get; set; }
		public List<string> errors { get; set; }
	}
}
