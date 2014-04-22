using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishingTree.WebUI.Models;
using WishingTree.Business;

namespace WishingTree.WebUI.Controllers
{
    public partial class UserController : Controller
    {
        //
        // GET: /User/

        public virtual ActionResult Login()
        {
            UserModel model = new UserModel();


            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Login(UserModel model)
        {
            if (LoginManage.Login(model.LoginName, model.PassWorld, model.IsKeep))
            {
                return Json(new { Res =true});
            }


            return Json(new { Res = false, Msg = "您输入的帐号或密码不正确，请重新输入。" });
        }

        public virtual ActionResult Register()
        {


            return View();
        }

        [HttpPost]
        public virtual ActionResult Register(UserModel model)
        {
            return View();
        }

    }
}
