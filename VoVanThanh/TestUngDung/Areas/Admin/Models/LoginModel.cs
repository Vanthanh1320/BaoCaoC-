using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}