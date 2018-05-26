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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:学生表
	/// </summary>
	public partial class 学生表
	{
		public 学生表()
        { DbHelperSQL.connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=studentdataNew;Data Source=PC-20170822IYZM\\SQLEXPRESS"; }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string 学号,string 邮箱)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 学生表");
			strSql.Append(" where 学号=@学号 or 邮箱=@邮箱 ");
			SqlParameter[] parameters = {
					new SqlParameter("@学号", SqlDbType.Char,12),
					new SqlParameter("@邮箱", SqlDbType.VarChar,20)			};
			parameters[0].Value = 学号;
			parameters[1].Value = 邮箱;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.学生表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 学生表(");
			strSql.Append("姓名,性别,生日,学院,专业,班级,学号,邮箱,头像地址)");
			strSql.Append(" values (");
			strSql.Append("@姓名,@性别,@生日,@学院,@专业,@班级,@学号,@邮箱,@头像地址)");
			SqlParameter[] parameters = {
					new SqlParameter("@姓名", SqlDbType.VarChar,10),
					new SqlParameter("@性别", SqlDbType.Char,2),
					new SqlParameter("@生日", SqlDbType.Date,3),
					new SqlParameter("@学院", SqlDbType.VarChar,20),
					new SqlParameter("@专业", SqlDbType.VarChar,20),
					new SqlParameter("@班级", SqlDbType.Char,10),
					new SqlParameter("@学号", SqlDbType.Char,12),
					new SqlParameter("@邮箱", SqlDbType.VarChar,20),
					new SqlParameter("@头像地址", SqlDbType.VarChar,20)};
			parameters[0].Value = model.姓名;
			parameters[1].Value = model.性别;
			parameters[2].Value = model.生日;
			parameters[3].Value = model.学院;
			parameters[4].Value = model.专业;
			parameters[5].Value = model.班级;
			parameters[6].Value = model.学号;
			parameters[7].Value = model.邮箱;
			parameters[8].Value = model.头像地址;

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
		public bool Update(Maticsoft.Model.学生表 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update 学生表 set ");
			strSql.Append("姓名=@姓名,");
			strSql.Append("性别=@性别,");
			strSql.Append("生日=@生日,");
			strSql.Append("学院=@学院,");
			strSql.Append("专业=@专业,");
			strSql.Append("班级=@班级,");
			strSql.Append("头像地址=@头像地址");
			strSql.Append(" where 学号=@学号 and 邮箱=@邮箱 ");
			SqlParameter[] parameters = {
					new SqlParameter("@姓名", SqlDbType.VarChar,10),
					new SqlParameter("@性别", SqlDbType.Char,2),
					new SqlParameter("@生日", SqlDbType.Date,3),
					new SqlParameter("@学院", SqlDbType.VarChar,20),
					new SqlParameter("@专业", SqlDbType.VarChar,20),
					new SqlParameter("@班级", SqlDbType.Char,10),
					new SqlParameter("@头像地址", SqlDbType.VarChar,20),
					new SqlParameter("@学号", SqlDbType.Char,12),
					new SqlParameter("@邮箱", SqlDbType.VarChar,20)};
			parameters[0].Value = model.姓名;
			parameters[1].Value = model.性别;
			parameters[2].Value = model.生日;
			parameters[3].Value = model.学院;
			parameters[4].Value = model.专业;
			parameters[5].Value = model.班级;
			parameters[6].Value = model.头像地址;
			parameters[7].Value = model.学号;
			parameters[8].Value = model.邮箱;

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
		public bool Delete(string 学号,string 邮箱)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 学生表 ");
			strSql.Append(" where 学号=@学号 or 邮箱=@邮箱 ");
			SqlParameter[] parameters = {
					new SqlParameter("@学号", SqlDbType.Char,12),
					new SqlParameter("@邮箱", SqlDbType.VarChar,20)			};
			parameters[0].Value = 学号;
			parameters[1].Value = 邮箱;

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.学生表 GetModel(string 学号,string 邮箱)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 姓名,性别,生日,学院,专业,班级,学号,邮箱,头像地址 from 学生表 ");
			strSql.Append(" where 学号=@学号 or 邮箱=@邮箱 ");
			SqlParameter[] parameters = {
					new SqlParameter("@学号", SqlDbType.Char,12),
					new SqlParameter("@邮箱", SqlDbType.VarChar,20)			};
			parameters[0].Value = 学号;
			parameters[1].Value = 邮箱;

			Maticsoft.Model.学生表 model=new Maticsoft.Model.学生表();
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
		public Maticsoft.Model.学生表 DataRowToModel(DataRow row)
		{
			Maticsoft.Model.学生表 model=new Maticsoft.Model.学生表();
			if (row != null)
			{
				if(row["姓名"]!=null)
				{
					model.姓名=row["姓名"].ToString();
				}
				if(row["性别"]!=null)
				{
					model.性别=row["性别"].ToString();
				}
				if(row["生日"]!=null && row["生日"].ToString()!="")
				{
					model.生日=DateTime.Parse(row["生日"].ToString());
				}
				if(row["学院"]!=null)
				{
					model.学院=row["学院"].ToString();
				}
				if(row["专业"]!=null)
				{
					model.专业=row["专业"].ToString();
				}
				if(row["班级"]!=null)
				{
					model.班级=row["班级"].ToString();
				}
				if(row["学号"]!=null)
				{
					model.学号=row["学号"].ToString();
				}
				if(row["邮箱"]!=null)
				{
					model.邮箱=row["邮箱"].ToString();
				}
				if(row["头像地址"]!=null)
				{
					model.头像地址=row["头像地址"].ToString();
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
			strSql.Append("select 姓名,性别,生日,学院,专业,班级,学号,邮箱,头像地址 ");
			strSql.Append(" FROM 学生表 ");
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
			strSql.Append(" 姓名,性别,生日,学院,专业,班级,学号,邮箱,头像地址 ");
			strSql.Append(" FROM 学生表 ");
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
			strSql.Append("select count(1) FROM 学生表 ");
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
				strSql.Append("order by T.邮箱 desc");
			}
			strSql.Append(")AS Row, T.*  from 学生表 T ");
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
			parameters[0].Value = "学生表";
			parameters[1].Value = "邮箱";
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

