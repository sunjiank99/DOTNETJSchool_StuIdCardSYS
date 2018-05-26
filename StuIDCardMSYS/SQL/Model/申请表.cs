/**  版本信息模板在安装目录下，可自行修改。
* 申请表.cs
*
* 功 能： N/A
* 类 名： 申请表
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
	/// 申请表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 申请表
	{
		public 申请表()
		{}
		#region Model
		private string _学号;
		private string _申请状态;
		private DateTime? _批准日期;
		private string _受理人职工号;
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
		public string 申请状态
		{
			set{ _申请状态=value;}
			get{return _申请状态;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 批准日期
		{
			set{ _批准日期=value;}
			get{return _批准日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 受理人职工号
		{
			set{ _受理人职工号=value;}
			get{return _受理人职工号;}
		}
		#endregion Model

	}
}

