using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace WishingTree.WebUI.Models
{
    public class UserModel
    {
        [DisplayName("登陆名")]
        public string LoginName { get; set; }

        [DisplayName("密码")]
        public string PassWorld { get; set; }

        [DisplayName("记住登录状态")]
        public bool IsKeep { get; set; }
    }
}