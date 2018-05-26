using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Maticsoft.Common;
using Maticsoft.Model;

namespace StuIDCardMSYS
{
    /// <summary>
    /// xueyuan 的摘要说明
    /// </summary>
    public class xueyuan : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            
            //得到操作标识  0 学院查专业  1专业查班级  2班级查学生
            string optionType = context.Request.QueryString["option"]; //得到操作标识  0 学院查专业

            int optionTypeInt = int.Parse(optionType);
            String json = "";
            var data = new List<object>();
            if (optionTypeInt == 0)  //学院信息
            {
                data = GetInstuteInfo();
                int total = data.ToArray().Length;

                String ReturnJson = JsonConvert.SerializeObject(data);

                 json = "{\"total\":" + total + ",\"rows\":" + ReturnJson + "}";
            }
            if (optionTypeInt == 1) //专业信息
            {
                string xueyuan = context.Request.QueryString["xueyuan"];
                data = GetProfessionalInfo(xueyuan);
                int total = data.ToArray().Length;

                String ReturnJson = JsonConvert.SerializeObject(data);

                 json = "{\"total\":" + total + ",\"rows\":" + ReturnJson + "}";
            }
            if (optionTypeInt == 2)  //班级信息
            {
                string xueyuan = context.Request.QueryString["xueyuan"];
                string zhuanye = context.Request.QueryString["zhuanye"];
                data = GetClassInfo(xueyuan,zhuanye);
                int total = data.ToArray().Length;

                String ReturnJson = JsonConvert.SerializeObject(data);

                 json = "{\"total\":" + total + ",\"rows\":" + ReturnJson + "}";
            }
            if (optionTypeInt == 3) //学生信息
            {
                string banji = context.Request.QueryString["banji"];
                data = GetStuInfo(banji);
                int total = data.ToArray().Length;

                String ReturnJson = JsonConvert.SerializeObject(data);

                 json = "{\"total\":" + total + ",\"rows\":" + ReturnJson + "}";
            }
            if (optionTypeInt == 4) //新增学院
            {
                string xueyuanId = context.Request.QueryString["xueyuanid"];
                string xueyuanName = context.Request.QueryString["xueyuanName"];
                data = ADDxueyuan(xueyuanId, xueyuanName);
                String ReturnJson = JsonConvert.SerializeObject(data);
                json = ReturnJson;
            }

            if (optionTypeInt == 5) //新增专业
            {
                string zhuanyeId = context.Request.QueryString["zhuanyeId"];
                string zhuanyeName = context.Request.QueryString["zhuanyeName"];
                string xueyuanName = context.Request.QueryString["XueyuanName"];
                data = ADDzhuanye(zhuanyeId, zhuanyeName, xueyuanName);
                String ReturnJson = JsonConvert.SerializeObject(data);
                json = ReturnJson;
            
            }
            if (optionTypeInt == 6) //新增班级
            {
                string banjiId = context.Request.QueryString["banjiId"];
                string zhuanyeName = context.Request.QueryString["zhuanyeName"];
                string xueyuanName = context.Request.QueryString["XueyuanName"];
                data = ADDbanji(banjiId, zhuanyeName, xueyuanName);
                String ReturnJson = JsonConvert.SerializeObject(data);
                json = ReturnJson;
            
            
            }
            //删除学院
            if (optionTypeInt == 7)
            {

                string xueyuanName = context.Request.QueryString["xueyuanName"];
                data = DeletXueyuan(xueyuanName);
                String ReturnJson = JsonConvert.SerializeObject(data);
                json = ReturnJson;
            
            }

            //删除专业
            if (optionTypeInt == 8)
            {

                string zhuanyeName = context.Request.QueryString["zhuanyeName"];
                data = DeletZhuanye(zhuanyeName);
                String ReturnJson = JsonConvert.SerializeObject(data);
                json = ReturnJson;

            }
            //删除班级
            if (optionTypeInt == 9)
            {

                string banjiName = context.Request.QueryString["banjiName"];
                data = DeletBanji(banjiName);
                String ReturnJson = JsonConvert.SerializeObject(data);
                json = ReturnJson;

            }

            //删除学生
            if (optionTypeInt == 10)
            {

                string xueshengName = context.Request.QueryString["xueshengName"];
                data = DeletXuesheng(xueshengName);
                String ReturnJson = JsonConvert.SerializeObject(data);
                json = ReturnJson;

            }
           


            //string password = context.Request.QueryString["password"];

            //var data = GetInstuteInfo();
            
            context.Response.Write(json);//此JSON格式非常重要，否则会执行jquery的的error函数
            context.Response.End();
        }

        //学院信息
        public List<object> GetInstuteInfo()
        {

            Maticsoft.BLL.学院表 xueyuanOption = new Maticsoft.BLL.学院表();
            System.Data.DataSet newinfo = xueyuanOption.GetAllList();






            //String ReturnJson = JsonConvert.SerializeObject(newinfo);
            //JObject jo = (JObject)JsonConvert.DeserializeObject(ReturnJson); //反序列化解析json字符串

            var data = new List<object>();


            int length = newinfo.Tables["ds"].Rows.Count;

            for (int i = 0; i < length; i++)
            {
                data.Add(new { InstituteId = newinfo.Tables["ds"].Rows[i]["学院编号"], InstituteName = newinfo.Tables["ds"].Rows[i]["学院"] });

            }



            return data;

                              
    
        }

        //得到专业信息
        public List<object> GetProfessionalInfo(string xueyuan)
        {

            System.Data.DataSet newinfo = new System.Data.DataSet();
            Maticsoft.DAL.专业表 zhuanyeOp = new Maticsoft.DAL.专业表();

            newinfo = zhuanyeOp.GetList("学院='"+xueyuan+"'");
           //ProId',
           //             title: '专业编号'
           //         }, {
           //             field: 'ProName',
           //             title: '专业名称'

            var data = new List<object>();


            int length = newinfo.Tables["ds"].Rows.Count;

            for (int i = 0; i < length; i++)
            {
                data.Add(new { ProId = newinfo.Tables["ds"].Rows[i]["专业编号"], ProName = newinfo.Tables["ds"].Rows[i]["专业"] });

            }

            return data;

        }

        //得到班级信息

        public List<object> GetClassInfo(string xueyuan,string zhuanye)
        {
            System.Data.DataSet banjiModle = new System.Data.DataSet();
            Maticsoft.BLL.班级表 banjiOp = new Maticsoft.BLL.班级表();

            banjiModle = banjiOp.GetList("专业='"+zhuanye+"'and 学院='"+xueyuan+"'");

            var data = new List<object>();
            int length = banjiModle.Tables["ds"].Rows.Count;

            for (int i = 0; i < length; i++)
            {
                 data .Add(

                new { ClassId = banjiModle.Tables["ds"].Rows[i]["班级"], ClassName =banjiModle.Tables["ds"].Rows[i]["专业"].ToString()+banjiModle.Tables["ds"].Rows[i]["班级"].ToString()+"班",}
               

             
                    );
            }

            return data;

        }



        //新增学院
        public List<object> ADDxueyuan(string xueyuanid, string xueyuanName)
        {
            Maticsoft.Model.学院表 newinfo = new 学院表();
            
            Maticsoft.BLL.学院表 banjiOp = new Maticsoft.BLL.学院表();
            newinfo.学院编号 = xueyuanid;
            newinfo.学院 = xueyuanName;
           

            var data = new List<object>();
            if (banjiOp.Add(newinfo))
            {
                data.Add(

                  new { success = "true", message = "学院添加成功", }


                   );
            }
            else
            {
                data.Add(

                  new { success = "false", message = "学院添加失败", }

                   );
            }

           

            return data;

        }



        //新增专业
        public List<object> ADDzhuanye(string zhuanyeid, string zhuanyeName,string xueyuanName)
        {
            Maticsoft.Model.专业表 newinfo = new 专业表();

            Maticsoft.BLL.专业表 zhuanyeOp = new Maticsoft.BLL.专业表();
            newinfo.专业编号 = zhuanyeid;
            newinfo.学院 = xueyuanName;
            newinfo.专业 = zhuanyeName;


            var data = new List<object>();
            if (zhuanyeOp.Add(newinfo))
            {
                data.Add(

                  new { success = "true", message = "专业添加成功", }


                   );
            }
            else
            {
                data.Add(

                  new { success = "false", message = "专业添加成功", }

                   );
            }



            return data;

        }


        //新增班级

        public List<object> ADDbanji(string banjiid, string zhuanyeName, string xueyuanName)
        {
            Maticsoft.Model.班级表 newinfo = new 班级表();

            Maticsoft.BLL.班级表 banjiOp = new Maticsoft.BLL.班级表();
            newinfo.班级 = banjiid;
            newinfo.学院 = xueyuanName;
            newinfo.专业 = zhuanyeName;


            var data = new List<object>();
            if (banjiOp.Add(newinfo))
            {
                data.Add(

                  new { success = "true", message = "班级添加成功", }


                   );
            }
            else
            {
                data.Add(

                  new { success = "false", message = "班级添加失败", }

                   );
            }



            return data;

        }
        
        
        //得到学生信息
        public List<object> GetStuInfo(string banji)
        {
            System.Data.DataSet newinfo = new System.Data.DataSet();
            Maticsoft.BLL.学生表 StuOp = new Maticsoft.BLL.学生表();

            newinfo = StuOp.GetList("班级='" + banji + "'");

            var data = new List<object>();
            int length = newinfo.Tables["ds"].Rows.Count;

            for (int i = 0; i < length; i++)
            {
                data.Add(
                new { StuId = newinfo.Tables["ds"].Rows[i]["学号"], StuName = newinfo.Tables["ds"].Rows[i]["姓名"], }               
                    );
                                
            }

            return data;

        }



        //删除学院信息
        public List<object> DeletXueyuan(string xueyuanNAme)
        {



            Maticsoft.BLL.学院表 Op = new Maticsoft.BLL.学院表();
           


            var data = new List<object>();
            if (Op.Delete(xueyuanNAme))
            {
                data.Add(

                  new { success = "true", message = "学院删除成功", }


                   );
            }
            else
            {
                data.Add(

                  new { success = "false", message = "学院删除失败", }

                   );
            }



            return data;

        }



        //删除专业信息
        public List<object> DeletZhuanye(string zhuanyeName)
        {



            Maticsoft.BLL.专业表 Op = new Maticsoft.BLL.专业表();



            var data = new List<object>();
            if (Op.Delete(zhuanyeName))
            {
                data.Add(

                  new { success = "true", message = "学院删除成功", }


                   );
            }
            else
            {
                data.Add(

                  new { success = "false", message = "学院删除失败", }

                   );
            }



            return data;

        }


        //删除班级信息
        public List<object> DeletBanji(string banjiName)
        {



            Maticsoft.BLL.班级表 Op = new Maticsoft.BLL.班级表();



            var data = new List<object>();
            if (Op.Delete(banjiName))
            {
                data.Add(

                  new { success = "true", message = "班级删除成功", }


                   );
            }
            else
            {
                data.Add(

                  new { success = "false", message = "班级删除失败", }

                   );
            }



            return data;

        }



        //删除学生信息
        public List<object> DeletXuesheng(string XueshengId)
        {



            Maticsoft.BLL.学生表 Op = new Maticsoft.BLL.学生表();



            var data = new List<object>();
            if (Op.Delete(XueshengId,""))
            {
                data.Add(

                  new { success = "true", message = "学生删除成功", }


                   );
            }
            else
            {
                data.Add(

                  new { success = "false", message = "学生删除失败", }

                   );
            }



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