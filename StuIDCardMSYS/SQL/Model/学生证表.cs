/**  版本信息模板在安装目录下，可自行修改。
* 学生证表.cs
*
* 功 能： N/A
* 类 名： 学生证表
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/1/15 14:47:45   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 学生证表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 学生证表
	{
		public 学生证表()
		{}
		#region Model
		private string _姓名;
		private string _学号;
		private string _学生证号;
		private DateTime _发证日期;
		private DateTime _有效期;
		private string _学校地址;
		private string _家庭地址;
		/// <summary>
		/// 
		/// </summary>
		public string 姓名
		{
			set{ _姓名=value;}
			get{return _姓名;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 学号
		{
			set{ _学号=value;}
			get{return _学号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 学生证号
		{
			set{ _学生证号=value;}
			get{return _学生证号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime 发证日期
		{
			set{ _发证日期=value;}
			get{return _发证日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime 有效期
		{
			set{ _有效期=value;}
			get{return _有效期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 学校地址
		{
			set{ _学校地址=value;}
			get{return _学校地址;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 家庭地址
		{
			set{ _家庭地址=value;}
			get{return _家庭地址;}
		}
		#endregion Model

	}
}

