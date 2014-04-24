using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using DataLibraries;
using WishingTree.Model;
using System.Data;
using System.Web;

namespace WishingTree.Business
{
    public class LoginManage
    {
        private static string UserKey = "04d9449ed0774450b9da8a81139b60db";

        public static bool Login(string username, string passworld,bool iskeep)
        {
            IDBOperate oper = Factory.Da.CreateOperate();
            List<IDataParameter> param = new List<IDataParameter>();
            IDataParameter pa = oper.CreateParameter();
            pa.ParameterName = "@UserName";
            pa.Value = username;
            param.Add(pa);

            pa = oper.CreateParameter();
            pa.ParameterName = "@PassWorld";
            pa.Value = DES.Encrypt(passworld);
            param.Add(pa);

            DataTable dt = oper.QueryDt("select * from User where (NikeName=@UserName or Email=@UserName) and PassWorld=@PassWorld",param.ToArray());
            if (dt.Rows.Count > 0)
            {
                string userId = dt.Rows[0][0].ToString();
                HttpContext.Current.Session[UserKey] = userId;
                UserModel user = oper.Get<UserModel>(userId);
                user.LastLoginTime = DateTime.Now;
                oper.Update(user);

                if (iskeep)
                {
                    //保存到cookie里面
                    HttpCookie cook = new HttpCookie(UserKey, userId);
                    cook.Expires = DateTime.Now.AddDays(10);
                    HttpContext.Current.Response.Cookies.Add(cook);
                }

            }


            return false;
        }

        public static UserModel GetUser()
        {
            UserModel user=default(UserModel);
            string userKey = GetLoginId();
            if (!string.IsNullOrEmpty(userKey))
            {
                IDBOperate oper = Factory.Da.CreateOperate();
                user = oper.Get<UserModel>(userKey);
            }
            return user;
        }

        /// <summary>
        /// 用户是否已登陆
        /// </summary>
        public static bool IsLogin
        {
            get
            {
                return !string.IsNullOrEmpty(GetLoginId());
            }
        }
        private static string GetLoginId()
        {
            return Convert.ToString(HttpContext.Current.Session[UserKey]);
        }

    }
}
