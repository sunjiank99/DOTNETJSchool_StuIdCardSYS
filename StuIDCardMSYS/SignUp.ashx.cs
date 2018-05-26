using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace StuIDCardMSYS
{
    /// <summary>
    /// SignUp 的摘要说明
    /// </summary>
    public class SignUp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            //GET方式获取传递的数据
            //string username = context.Request.QueryString["username"];
            //string password = context.Request.QueryString["password"];

            //POST方式获取传递的数据
            string option = context.Request.Form["option"];
            int optionInt = int.Parse(option);
           // string password = context.Request.Form["password"];

            if (optionInt == 0)
            {
                context.Response.Write(getInstatuteInfo());
            }
            if (optionInt == 1)
            {
                string Pro = context.Request.Form["zhuanye"];
                int ProInt = int.Parse(Pro);

                context.Response.Write(getProInfo(ProInt));

            }
            if (optionInt == 2)
            {
                string CLass = context.Request.Form["banji"];
                string Insti = context.Request.Form["xueyuan"];


                context.Response.Write(getClassInfo(CLass,Insti));
            }

            if (optionInt == 3)
            {
                var stuinfo = context.Request.Form["stuInfo"];

                 JObject jo = (JObject)JsonConvert.DeserializeObject(stuinfo); //反序列化解析json字符串


                   String json = JsonConvert.SerializeObject(SingupInfo(jo));
                   context.Response.Write(json);//此JSON格式非常重要，否则会执行jquery的的error函数
               
               
               
                 
              

             
                
            }

            context.Response.End();

        }

        //得到学院信息
        public String getInstatuteInfo()
        {  
            System.Data.DataSet newinfo = new System.Data.DataSet();
            Maticsoft.BLL.学院表 SQLOption = new Maticsoft.BLL.学院表();

            newinfo = SQLOption.GetAllList();

            String ReturnJson = JsonConvert.SerializeObject(newinfo);







            return ReturnJson;

        }


        //得到专业信息

        public String getProInfo(int Pro)
        {
            System.Data.DataSet newinfo = new System.Data.DataSet();
            Maticsoft.DAL.学院表 SQLOption = new Maticsoft.DAL.学院表();

            Maticsoft.BLL.专业表 zhuanyeSQL = new Maticsoft.BLL.专业表();
            System.Data.DataSet zhuanyeinfo = new System.Data.DataSet();

           

            newinfo = SQLOption.GetList("学院编号='" +Pro+"'");

            String xueyuan = newinfo.Tables["ds"].Rows[0]["学院"].ToString() ;
            

            zhuanyeinfo = zhuanyeSQL.GetList("学院='" + xueyuan + "'");


            // zhuanyeinfo=zhuanyeSQL.GetList("学院='"+ +"'")



            String ReturnJson = JsonConvert.SerializeObject(zhuanyeinfo);







            return ReturnJson;
        
        }



        //得到班级信息
        public String getClassInfo(String ClassInt,String Inst)
        {

          

            Maticsoft.BLL.班级表 banjiSQL = new Maticsoft.BLL.班级表();
            System.Data.DataSet banjiinfo = new System.Data.DataSet();



            banjiinfo = banjiSQL.GetList("专业='" + ClassInt + "'and 学院='" + Inst + "'");

            


            // zhuanyeinfo=zhuanyeSQL.GetList("学院='"+ +"'")



            String ReturnJson = JsonConvert.SerializeObject(banjiinfo);

            return ReturnJson;
        }


        //学生注册信息

        public JObject SingupInfo(JObject info)
        {
            JObject reV=new JObject();
            bool StuAdd=false;
            bool SignUpExit=true;
            Maticsoft.BLL.学生表 StuSQL = new Maticsoft.BLL.学生表();
            Maticsoft.Model.学生表 newStu = new Maticsoft.Model.学生表();

            Maticsoft.BLL.登录表 SignupSQL = new Maticsoft.BLL.登录表();
            Maticsoft.Model.登录表 newSign = new Maticsoft.Model.登录表();
            newStu.班级 = info["banji"].ToString();
            newStu.生日 = DateTime.ParseExact(info["stuBirth"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture);
            newStu.性别 = info["stuGender"].ToString();
            newStu.姓名 = info["stuName"].ToString();
            newStu.学号 = info["stuId"].ToString();
            newStu.学院 = info["xueyuan"].ToString();
            newStu.专业 = info["zhuanye"].ToString();
            newStu.邮箱 = info["stuEmail"].ToString();


            newSign.账号 = info["stuId"].ToString();
            newSign.密码 = info["stuPs"].ToString();
            newSign.职务 = "学生";

            SignupSQL.Add(newSign);
            if (SignupSQL.Exists(newSign.账号))
            {
                if (!StuSQL.Exists(newStu.学号,newStu.邮箱))
                {

                     StuAdd= StuSQL.Add(newStu); //添加学生信息状态
                    
                }
                else
                {
                    reV.Add("success", "false");
                    reV.Add("message", "学号已经注册");
                    return reV;
                }
            }
            else
            {

                SignUpExit = false; //登录表不存在信息

                reV.Add("success", "false");
                reV.Add("message", "学号尚未录入无法注册");

                return reV;

            }

            if (StuAdd)
            {
                reV.Add("success", "true");
                reV.Add("message", "注册成功");
            }
            else
            {
                reV.Add("success", "false");
                reV.Add("message", "注册失败");
            }

            return reV;
        
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

     public class SignUpInfo
    {
         public String stuName;
         public String stuEmail;
         public String xueyuan;
         public String zhuanye;
         public String banji;
         public String stuBirth;
         public String stuGender;
         public String stuId;
         public String stuPs;
        
    
    }
}