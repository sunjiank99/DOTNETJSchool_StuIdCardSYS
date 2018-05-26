using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Maticsoft.Model;
using Maticsoft.BLL;

namespace StuIDCardMSYS
{
    public class SQLTEST
    {

        public void test()
        {
            登录表 test = new 登录表();
            bool a;
            a=test.Exists("143401010101");
            

       
        }
        
        public static void Main()
        {
            SQLTEST a = new SQLTEST();
            a.test();
        }




    }
}