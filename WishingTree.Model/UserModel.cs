using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibraries;
using DataLibraries.DBModelAttribute;

namespace WishingTree.Model
{
    [SqlTable("User")]
    public class UserModel : BaseModel
    {
        [SqlColumn("Id", true, true)]
        public string Id { get; set; }

        [SqlColumn("Email")]
        public string Email { get; set; }

        [SqlColumn("NikeName", true)]
        public string NikeName { get; set; }

        [SqlColumn("PassWorld", true)]
        public string PassWorld { get; set; }

        [SqlColumn("Sex")]
        public char Sex { get; set; }

        [SqlColumn("CreateTime")]
        public DateTime CreateTime { get; set; }

        [SqlColumn("LastLoginTime")]
        public DateTime LastLoginTime { get; set; }
    }
}
