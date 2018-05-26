using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StuIDCardMSYS
{
    public class Judgement
    {

        public class Judge_ID_PS    //验证用户名密码
        {

            private String Id;   //用户名容器
            private String Ps;   //密码容器

            //账号信息验证状态  Judge_ID： 0 用户名不存在 1用户名正确 
            //密码              Judge_PS： 0 密码错误     1 密码正确
            private int Judge_ID;    
            private int Judge_PS;

            
            

            Judge_ID_PS(String Id, String PS) //构造函数设置验证用户名和密码
            {
                this.Id = Id;   
                this.Ps = PS;
            }


            public void JudgeIDPS()  //确定用户账号密码
            { 
                                    
            }

            


        
        }


        

    }
}