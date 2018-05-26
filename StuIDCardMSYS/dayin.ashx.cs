using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Data;
using Maticsoft.DBUtility;
using System.Text;
namespace StuIDCardMSYS
{
    /// <summary>
    /// dayin 的摘要说明
    /// </summary>
    public class dayin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            string option = context.Request.QueryString["option"];  //操作方式 0获取学生办证信息 1获取学生详细信息
            String json="";
            var data = new List<object>();
            if (option == "0")
            {
                string userid = context.Request.QueryString["shoulirenid"];
                  data = getCardInfo(userid);
                  int total = data.ToArray().Length;

                  String ReturnJson = JsonConvert.SerializeObject(data);

                  json = "{\"total\":" + total + ",\"rows\":" + ReturnJson + "}";
            }

            if (option == "1")
            {
                string userid = context.Request.QueryString["username"];
                data = getUserCardInfoDetails(userid);
                String ReturnJson = JsonConvert.SerializeObject(data);

                json =  ReturnJson;
            
            }

            if (option == "2")
            {
                string userid = context.Request.QueryString["username"];
                data = dayinBiangeng(userid);
                String ReturnJson = JsonConvert.SerializeObject(data);

                json = ReturnJson;
                 
            }
          
            context.Response.Write(json);//此JSON格式非常重要，否则会执行jquery的的error函数
            context.Response.End();
        }

        //得到学生证信息
        public List<object> getCardInfo(string shoulirenid)
        {


            System.Data.DataSet newinfo = GetList("学生证表.学号=申请表.学号 and 受理人职工号='"+shoulirenid+"' ");






            //String ReturnJson = JsonConvert.SerializeObject(newinfo);
            //JObject jo = (JObject)JsonConvert.DeserializeObject(ReturnJson); //反序列化解析json字符串

            var data = new List<object>();


            int length = newinfo.Tables["ds"].Rows.Count;

            for (int i = 0; i < length; i++)
            {
                data.Add(new { CardId = newinfo.Tables["ds"].Rows[i]["学生证号"], CardName = newinfo.Tables["ds"].Rows[i]["姓名"],

                               StuId = newinfo.Tables["ds"].Rows[i]["学号"],
                               Status = newinfo.Tables["ds"].Rows[i]["申请状态"],
                });

            }



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





        public List<object> dayinBiangeng(string userid)
        {
            Maticsoft.Model.申请表 ModalShenqing = new Maticsoft.Model.申请表();
            Maticsoft.BLL.申请表 shouliOp = new Maticsoft.BLL.申请表();

            ModalShenqing = shouliOp.GetModel(userid);
            
            ModalShenqing.申请状态 = "已受理";
            var data = new List<object>();
            if (shouliOp.Update(ModalShenqing))//更新申请表
            {
                data.Add(new { success = "true", message = "变更成功" });



            }
            else
            {
                data.Add(new { success = "false", message = "变更失败" });
            }








            //String ReturnJson = JsonConvert.SerializeObject(newinfo);
            //JObject jo = (JObject)JsonConvert.DeserializeObject(ReturnJson); //反序列化解析json字符串





            return data;



        }
        public DataSet GetList(string strWhere)
        {
            DbHelperSQL.connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=studentdataNew;Data Source=PC-20170822IYZM\\SQLEXPRESS";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM 学生证表,申请表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());
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