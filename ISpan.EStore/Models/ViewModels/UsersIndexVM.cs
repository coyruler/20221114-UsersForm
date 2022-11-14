using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.EStore.Models.ViewModels
{
	public class UsersIndexVM
	{
		public int Index { get; set; }
		public string Account { get; set; }
		public int Password { get; set; }
		public string Name { get; set; }
	}

	public class UserVM
	{
		public int Index { get; set; }

		[Required(ErrorMessage ="帳號必填")]
		public string Account { get; set; }


		[Required(ErrorMessage = "密碼必填")]
		public int Password { get; set; }


		[Required(ErrorMessage = "姓名必填")]
		public string Name { get; set; }
	}
}
