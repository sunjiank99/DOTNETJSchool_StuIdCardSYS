/**  版本信息模板在安装目录下，可自行修改。
* 职工表.cs
*
* 功 能： N/A
* 类 名： 职工表
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
	/// 职工表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class 职工表
	{
		public 职工表()
		{}
		#region Model
		private string _职工号;
		private string _职工名;
		/// <summary>
		/// 
		/// </summary>
		public string 职工号
		{
			set{ _职工号=value;}
			get{return _职工号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 职工名
		{
			set{ _职工名=value;}
			get{return _职工名;}
		}
		#endregion Model

	}
}

