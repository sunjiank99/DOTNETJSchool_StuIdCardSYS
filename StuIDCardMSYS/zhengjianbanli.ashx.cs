using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Maticsoft.BLL;
using Maticsoft.Model;
namespace StuIDCardMSYS
{
    /// <summary>
    /// zhengjianbanli 的摘要说明 学生证办理一般处理程序
    /// </summary>
    public class zhengjianbanli : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            //GET方式获取传递的数据
            string username = context.Request.QueryString["username"];
            string option = context.Request.QueryString["option"];  //操作方式 0获取学生办证信息 1获取学生详细信息

           

            int optionV = int.Parse(option);

            var data = new List<object>(); ;
            String json = "";
            //基本信息接口
            if (optionV == 0)
            {
                data = getUserCardInfo(username);
                int total = data.ToArray().Length;

                String ReturnJson = JsonConvert.SerializeObject(data);

                json = "{\"total\":" + total + ",\"rows\":" + ReturnJson + "}";
            
            }
            //详细信息接口
            if (optionV == 1)
            {
                data = getUserCardInfoDetails(username);
                json = JsonConvert.SerializeObject(data);

            }
            //提交办证业务
            if (optionV == 2)
            {
                data = SubmitBanzheng(username);
                json = JsonConvert.SerializeObject(data);
            }
            //提交挂失业务
            if (optionV == 3)
            {
                data = SubmitGuashi(username);
                json = JsonConvert.SerializeObject(data);
            }

            
            
            context.Response.Write(json);//此JSON格式非常重要，否则会执行jquery的的error函数
            context.Response.End();
        }

        //得到学生证基本信息
        public List<object> getUserCardInfo(string userid)
        {
            Maticsoft.Model.学生证表 newinfo = new Maticsoft.Model.学生证表();
            Maticsoft.BLL.学生证表 SQLOption = new Maticsoft.BLL.学生证表();

            Maticsoft.Model.申请表 ShenqingInfo=new  Maticsoft.Model.申请表();
            Maticsoft.BLL.申请表   SQLSHENOption =new Maticsoft.BLL.申请表();

            Maticsoft.Model.学生表 XueshengInfo = new Maticsoft.Model.学生表();
            Maticsoft.BLL.学生表 SQLXueshengInfo = new Maticsoft.BLL.学生表();

            var data = new List<object>();

            if (SQLXueshengInfo.Exists(userid, ""))
            {
                newinfo = SQLOption.GetModel(userid); //得到实体类
                ShenqingInfo = SQLSHENOption.GetModel(userid);//得到申请信息
                XueshengInfo = SQLXueshengInfo.GetModel(userid, "");//得到学生信息



                
            }

            if (newinfo == null || ShenqingInfo == null || XueshengInfo == null)
            {
                newinfo = new Maticsoft.Model.学生证表(); ShenqingInfo = new Maticsoft.Model.申请表();
                //XueshengInfo = new Maticsoft.Model.学生表();

                data = new List<object>(){
                
                new {  CardId=newinfo.学生证号, StuId=newinfo.学号,Name=XueshengInfo.姓名,Status=ShenqingInfo.申请状态,
                       
                       Option="测试",},
                     

             
               };
            }
           
                data = new List<object>(){
                
                new {  CardId=newinfo.学生证号, StuId=newinfo.学号,Name=XueshengInfo.姓名,Status=ShenqingInfo.申请状态,
                       
                       Option="测试",},
                     
             
               };
            
            
            

             


            return data;

        }


        //得到学生详细信息
        public List<object> getUserCardInfoDetails(string userid)
        {
            Maticsoft.Model.学生证表 newinfo = new Maticsoft.Model.学生证表();
            Maticsoft.BLL.学生证表 SQLOption = new Maticsoft.BLL.学生证表();

            Maticsoft.Model.学生表 XueshengInfo = new Maticsoft.Model.学生表();
            Maticsoft.BLL.学生表 SQLXueshengInfo = new Maticsoft.BLL.学生表();


            if (SQLOption.Exists(userid))
            {
                newinfo = SQLOption.GetModel(userid); //得到学生证实体类
              
                XueshengInfo = SQLXueshengInfo.GetModel(userid, "");//得到学生信息

            }

            var data = new List<object>(){
                
                new {  StuName=newinfo.姓名, StuSex=XueshengInfo.性别,StuBirth=XueshengInfo.生日,
                       StuInstitution=XueshengInfo.学院,
                       StuPro=XueshengInfo.专业,
                       StuClass=XueshengInfo.班级,
                       StuId=newinfo.学号,
                       StuFazhengTime=newinfo.发证日期,
                       StuYouxiaoTime=newinfo.有效期,
                       
                       Option="测试",},
                     

             
            };


            return data;

        }


        //办证业务提交
        public List<object> SubmitBanzheng(string userid)
        {
            Maticsoft.Model.申请表 newinfo = new Maticsoft.Model.申请表();
            Maticsoft.BLL.申请表 SQLOption = new Maticsoft.BLL.申请表();

            Maticsoft.Model.学生表 XueshengInfo = new Maticsoft.Model.学生表();
            Maticsoft.BLL.学生表 SQLXueshengInfo = new Maticsoft.BLL.学生表();

            Maticsoft.Model.学生证表 Cardinfo = new Maticsoft.Model.学生证表();
            Maticsoft.BLL.学生证表 SQLCardOp = new Maticsoft.BLL.学生证表();

            XueshengInfo = SQLXueshengInfo.GetModel(userid, "");

            Cardinfo.姓名 = XueshengInfo.姓名;
            Cardinfo.学号 = XueshengInfo.学号;

            //生成随机数
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            int iResult;
            int iUp = 100000;
            int iDown = 0;
            iResult = ran.Next(iDown, iUp);

            Cardinfo.学生证号 = "0020000021" + string.Format("{0:000000}", iResult);
            Cardinfo.学校地址 = "沈阳";
            Cardinfo.发证日期 = DateTime.Now;
            Cardinfo.家庭地址 = "";
            Cardinfo.有效期 = DateTime.Now;
            


            newinfo.学号 = userid;
            newinfo.申请状态 = "未受理";
            var data = new List<object>();

            if (SQLOption.Add(newinfo) && SQLCardOp.Add(Cardinfo))
            {
                data = new List<object>(){                
                new {success="true",message="受理成功",},                
                };


            }
            else {

                data = new List<object>(){                
                new { success="false",message="受理失败", },                     
                 };
               
            };

            return data;
        
        
        }


        //挂失业务提交


        public List<object> SubmitGuashi(string userid)
        {
           
            Maticsoft.BLL.申请表 SQLOption = new Maticsoft.BLL.申请表();
           

           
            Maticsoft.BLL.学生证表 SQLCardOp = new Maticsoft.BLL.学生证表();

           



           
            var data = new List<object>();

            if (SQLOption.Delete(userid) && SQLCardOp.Delete(userid))
            {
                data = new List<object>(){                
                new {success="true",message="受理成功",},                
                };


            }
            else
            {

                data = new List<object>(){                
                new { success="false",message="受理失败", },                     
                 };

            };

            return data;


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