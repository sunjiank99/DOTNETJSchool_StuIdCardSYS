/**  版本信息模板在安装目录下，可自行修改。
* 学生表.cs
*
* 功 能： N/A
* 类 名： 学生表
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
	/// 学生表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 学生表
	{
		public 学生表()
		{}
		#region Model
		private string _姓名;
		private string _性别;
		private DateTime _生日;
		private string _学院;
		private string _专业;
		private string _班级;
		private string _学号;
		private string _邮箱;
		private string _头像地址;
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
		public string 性别
		{
			set{ _性别=value;}
			get{return _性别;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime 生日
		{
			set{ _生日=value;}
			get{return _生日;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 学院
		{
			set{ _学院=value;}
			get{return _学院;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 专业
		{
			set{ _专业=value;}
			get{return _专业;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 班级
		{
			set{ _班级=value;}
			get{return _班级;}
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
		public string 邮箱
		{
			set{ _邮箱=value;}
			get{return _邮箱;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 头像地址
		{
			set{ _头像地址=value;}
			get{return _头像地址;}
		}
		#endregion Model

	}
}

