using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.BLL;
using Maticsoft.Model;

namespace StuIDCardMSYS
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            //GET方式获取传递的数据
            //string username = context.Request.QueryString["username"];
            //string password = context.Request.QueryString["password"];

            //POST方式获取传递的数据
            string username = context.Request.Form["username"];
            string password = context.Request.Form["password"];
            String certainPS = "";
            String zhiwu="";
            string message = null;
            if (string.IsNullOrEmpty(username))
            {
                message = "用户名不能为空";
                context.Response.Write("{\"success\":0,\"message\":\"" + message + "\"}");//此JSON格式非常重要，否则会执行jquery的的error函数
                context.Response.End();
            }
            if (string.IsNullOrEmpty(password))
            {
                message = "密码不能为空";
                context.Response.Write("{\"success\":1,\"message\":\"" + message + "\"}");
                context.Response.End();
            }
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {

                Maticsoft.BLL.登录表 SQLConect = new Maticsoft.BLL.登录表();
                bool IdOrPsCertain=false;
                

                IdOrPsCertain = SQLConect.Exists(username);
                if (IdOrPsCertain)
                {
                    Maticsoft.Model.登录表 loginModel = SQLConect.GetModel(username);
                    certainPS = loginModel.密码;
                      
                      if (certainPS == password)
                      {
                          message = "登录成功";
                          zhiwu = loginModel.职务;
                          String reV = "{\"success\":2,\"message\":\"" + message + "\",\"zhiwu\":\"" + zhiwu + "\"}";
                          context.Response.Write(reV);

                      }
                      else
                      {
                          message = "用户名或密码错误";
                          context.Response.Write("{\"success\":3,\"message\":\"" + message + "\"}");
                      }
                      

                }
                else
                {
                    message = "用户名或密码错误";
                    context.Response.Write("{\"success\":3,\"message\":\"" + message + "\"}");
                
                }


                //if (username.ToUpper() == "ADMIN" && password == "123")
                //{
                //    message = "登录成功";
                //    context.Response.Write("{\"success\":2,\"message\":\"" + message + "\"}");
                //}
                //else
                //{
                //    message = "用户名或密码错误";
                //    context.Response.Write("{\"success\":3,\"message\":\"" + message + "\"}");
                //}
            }
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}