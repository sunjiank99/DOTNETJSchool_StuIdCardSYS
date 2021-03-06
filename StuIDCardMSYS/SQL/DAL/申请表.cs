﻿/**  版本信息模板在安装目录下，可自行修改。
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:申请表
	/// </summary>
	public partial class 申请表
	{
		public 申请表()
        { DbHelperSQL.connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=studentdataNew;Data Source=PC-20170822IYZM\\SQLEXPRESS"; }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 学号)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 申请表");
			strSql.Append(" where 学号=@学号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@学号", SqlDbType.Char,12)			};
			parameters[0].Value = 学号;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.申请表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 申请表(");
			strSql.Append("学号,申请状态,批准日期,受理人职工号)");
			strSql.Append(" values (");
			strSql.Append("@学号,@申请状态,@批准日期,@受理人职工号)");
			SqlParameter[] parameters = {
					new SqlParameter("@学号", SqlDbType.Char,12),
					new SqlParameter("@申请状态", SqlDbType.Char,6),
					new SqlParameter("@批准日期", SqlDbType.Date,3),
					new SqlParameter("@受理人职工号", SqlDbType.Char,12)};
			parameters[0].Value = model.学号;
			parameters[1].Value = model.申请状态;
			parameters[2].Value = model.批准日期;
			parameters[3].Value = model.受理人职工号;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.申请表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update 申请表 set ");
			strSql.Append("申请状态=@申请状态,");
			strSql.Append("批准日期=@批准日期,");
			strSql.Append("受理人职工号=@受理人职工号");
			strSql.Append(" where 学号=@学号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@申请状态", SqlDbType.Char,6),
					new SqlParameter("@批准日期", SqlDbType.Date,3),
					new SqlParameter("@受理人职工号", SqlDbType.Char,12),
					new SqlParameter("@学号", SqlDbType.Char,12)};
			parameters[0].Value = model.申请状态;
			parameters[1].Value = model.批准日期;
			parameters[2].Value = model.受理人职工号;
			parameters[3].Value = model.学号;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string 学号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 申请表 ");
			strSql.Append(" where 学号=@学号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@学号", SqlDbType.Char,12)			};
			parameters[0].Value = 学号;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string 学号list )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 申请表 ");
			strSql.Append(" where 学号 in ("+学号list + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.申请表 GetModel(string 学号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 学号,申请状态,批准日期,受理人职工号 from 申请表 ");
			strSql.Append(" where 学号=@学号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@学号", SqlDbType.Char,12)			};
			parameters[0].Value = 学号;

			Maticsoft.Model.申请表 model=new Maticsoft.Model.申请表();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.申请表 DataRowToModel(DataRow row)
		{
			Maticsoft.Model.申请表 model=new Maticsoft.Model.申请表();
			if (row != null)
			{
				if(row["学号"]!=null)
				{
					model.学号=row["学号"].ToString();
				}
				if(row["申请状态"]!=null)
				{
					model.申请状态=row["申请状态"].ToString();
				}
				if(row["批准日期"]!=null && row["批准日期"].ToString()!="")
				{
					model.批准日期=DateTime.Parse(row["批准日期"].ToString());
				}
				if(row["受理人职工号"]!=null)
				{
					model.受理人职工号=row["受理人职工号"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select 学号,申请状态,批准日期,受理人职工号 ");
			strSql.Append(" FROM 申请表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" 学号,申请状态,批准日期,受理人职工号 ");
			strSql.Append(" FROM 申请表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM 申请表 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.学号 desc");
			}
			strSql.Append(")AS Row, T.*  from 申请表 T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "申请表";
			parameters[1].Value = "学号";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

