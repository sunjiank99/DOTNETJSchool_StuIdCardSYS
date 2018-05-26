/**  版本信息模板在安装目录下，可自行修改。
* 登录表.cs
*
* 功 能： N/A
* 类 名： 登录表
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
	/// 数据访问类:登录表
	/// </summary>
	public partial class 登录表
	{
		public 登录表()
        { DbHelperSQL.connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=studentdataNew;Data Source=PC-20170822IYZM\\SQLEXPRESS"; }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 账号)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 登录表");
			strSql.Append(" where 账号=@账号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@账号", SqlDbType.Char,12)			};
			parameters[0].Value = 账号;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.登录表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 登录表(");
			strSql.Append("账号,密码,职务)");
			strSql.Append(" values (");
			strSql.Append("@账号,@密码,@职务)");
			SqlParameter[] parameters = {
					new SqlParameter("@账号", SqlDbType.Char,12),
					new SqlParameter("@密码", SqlDbType.VarChar,16),
					new SqlParameter("@职务", SqlDbType.Char,4)};
			parameters[0].Value = model.账号;
			parameters[1].Value = model.密码;
			parameters[2].Value = model.职务;

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
		public bool Update(Maticsoft.Model.登录表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update 登录表 set ");
			strSql.Append("密码=@密码,");
			strSql.Append("职务=@职务");
			strSql.Append(" where 账号=@账号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@密码", SqlDbType.VarChar,16),
					new SqlParameter("@职务", SqlDbType.Char,4),
					new SqlParameter("@账号", SqlDbType.Char,12)};
			parameters[0].Value = model.密码;
			parameters[1].Value = model.职务;
			parameters[2].Value = model.账号;

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
		public bool Delete(string 账号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 登录表 ");
			strSql.Append(" where 账号=@账号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@账号", SqlDbType.Char,12)			};
			parameters[0].Value = 账号;

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
		public bool DeleteList(string 账号list )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 登录表 ");
			strSql.Append(" where 账号 in ("+账号list + ")  ");
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
		public Maticsoft.Model.登录表 GetModel(string 账号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 账号,密码,职务 from 登录表 ");
			strSql.Append(" where 账号=@账号 ");
			SqlParameter[] parameters = {
					new SqlParameter("@账号", SqlDbType.Char,12)			};
			parameters[0].Value = 账号;

			Maticsoft.Model.登录表 model=new Maticsoft.Model.登录表();
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
		public Maticsoft.Model.登录表 DataRowToModel(DataRow row)
		{
			Maticsoft.Model.登录表 model=new Maticsoft.Model.登录表();
			if (row != null)
			{
				if(row["账号"]!=null)
				{
					model.账号=row["账号"].ToString();
				}
				if(row["密码"]!=null)
				{
					model.密码=row["密码"].ToString();
				}
				if(row["职务"]!=null)
				{
					model.职务=row["职务"].ToString();
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
			strSql.Append("select 账号,密码,职务 ");
			strSql.Append(" FROM 登录表 ");
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
			strSql.Append(" 账号,密码,职务 ");
			strSql.Append(" FROM 登录表 ");
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
			strSql.Append("select count(1) FROM 登录表 ");
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
				strSql.Append("order by T.账号 desc");
			}
			strSql.Append(")AS Row, T.*  from 登录表 T ");
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
			parameters[0].Value = "登录表";
			parameters[1].Value = "账号";
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

