using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text;
using Maticsoft.DBUtility;
namespace StuIDCardMSYS
{
    /// <summary>
    /// banbuzheng 的摘要说明
    /// </summary>
    public class banbuzheng : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            string option = context.Request.QueryString["option"];
            String json = "";
            if (option == "0")
            {

                var data = getYewuShenqingInfo();
                int total = data.ToArray().Length;

                String ReturnJson = JsonConvert.SerializeObject(data);

                json = "{\"total\":" + total + ",\"rows\":" + ReturnJson + "}";
            
            }
            if (option == "1")
            {
                String userid = context.Request.QueryString["username"];
                String shoulirenid = context.Request.QueryString["shouliren"];

                String ReturnJson = JsonConvert.SerializeObject(yewushouli(userid,shoulirenid));

                json = ReturnJson;
            
            }


           
            context.Response.Write(json);//此JSON格式非常重要，否则会执行jquery的的error函数
            context.Response.End();
        }



        //得到申请信息
        public List<object> getYewuShenqingInfo()
        {

            System.Data.DataSet newinfo = GetList("申请表.学号=学生表.学号  and 申请状态='未受理'");
            

            



            //String ReturnJson = JsonConvert.SerializeObject(newinfo);
            //JObject jo = (JObject)JsonConvert.DeserializeObject(ReturnJson); //反序列化解析json字符串

            var data = new List<object>();


            int length = newinfo.Tables["ds"].Rows.Count;

            for (int i = 0; i < length; i++)
            {
                data.Add(new { StuName = newinfo.Tables["ds"].Rows[i]["姓名"], StuId = newinfo.Tables["ds"].Rows[i]["学号"] });
            
            }



                return data;


         


            

        }



        //业务受理

        public List<object> yewushouli(string userid,string shoulirenid)
        {
            Maticsoft.Model.申请表 ModalShenqing = new Maticsoft.Model.申请表();
            Maticsoft.BLL.申请表 shouliOp = new Maticsoft.BLL.申请表();

            ModalShenqing = shouliOp.GetModel(userid);
            ModalShenqing.受理人职工号 = shoulirenid;
            ModalShenqing.申请状态 = "受理中";
            var data = new List<object>();
            if (shouliOp.Update(ModalShenqing))//更新申请表
            {
                data.Add(new { success = "true", message = "受理成功" });



            }
            else 
            {
                data.Add(new { success = "false", message = "受理失败" });
            }

            






            //String ReturnJson = JsonConvert.SerializeObject(newinfo);
            //JObject jo = (JObject)JsonConvert.DeserializeObject(ReturnJson); //反序列化解析json字符串

           



            return data;
        
        
        
        }
        public DataSet GetList(string strWhere)
        {
            DbHelperSQL.connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=studentdataNew;Data Source=PC-20170822IYZM\\SQLEXPRESS";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 申请表.学号,姓名,申请状态 ");
            strSql.Append(" FROM 申请表,学生表 ");
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