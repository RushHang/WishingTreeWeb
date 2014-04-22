using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishingTree.WebUI.Models.User
{
    public class RegisterModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string NikeName { get; set; }

        public string PassWorld { get; set; }

        public string PassWorldVerification { get; set; }

        public char Sex { get; set; }
    }
}