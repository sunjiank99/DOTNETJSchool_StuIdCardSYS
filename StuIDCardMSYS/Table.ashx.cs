using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace StuIDCardMSYS
{
    /// <summary>
    /// Table 的摘要说明
    /// </summary>
    public class Table : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            

            var data = new List<object>(){new {  Name="Arbet", ParentName="男",Level="最高级",Desc="测试"},

               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="SUN", ParentName="男",Level="最高级",Desc="测试"},
               new {  Name="XUN", ParentName="男",Level="最高级",Desc="测试"}
            };
            int total = data.ToArray().Length;

            String ReturnJson = JsonConvert.SerializeObject(data);

            String json = "{\"total\":" + total + ",\"rows\":" + ReturnJson + "}";
            context.Response.Write(json);//此JSON格式非常重要，否则会执行jquery的的error函数
            context.Response.End();


        }

        public static string ToJson(object obj)
        {
            // 首先，当然是JSON序列化
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());

            // 定义一个stream用来存发序列化之后的内容
            Stream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);

            // 从头到尾将stream读取成一个字符串形式的数据，并且返回
            stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
          
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