using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace robot2
{
    /// <summary>
    /// 类Item。
    /// </summary>
    [Serializable]
    public partial class Item
    {
        public Item()
        { }
        #region Model
        private int _id;
        private int _type_code;
        private int _account_id;
        private int _equiped;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int type_code
        {
            set { _type_code = value; }
            get { return _type_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int account_id
        {
            set { _account_id = value; }
            get { return _account_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int equiped
        {
            set { _equiped = value; }
            get { return _equiped; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Item(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,type_code,account_id,equiped ");
            strSql.Append(" FROM item ");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type_code"] != null && ds.Tables[0].Rows[0]["type_code"].ToString() != "")
                {
                    this.type_code = int.Parse(ds.Tables[0].Rows[0]["type_code"].ToString());
                }
                if (ds.Tables[0].Rows[0]["account_id"] != null && ds.Tables[0].Rows[0]["account_id"].ToString() != "")
                {
                    this.account_id = int.Parse(ds.Tables[0].Rows[0]["account_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["equiped"] != null && ds.Tables[0].Rows[0]["equiped"].ToString() != "")
                {
                    this.equiped = int.Parse(ds.Tables[0].Rows[0]["equiped"].ToString());
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from item");
            strSql.Append(" where id=@id ");

            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into item (");
            strSql.Append("type_code,account_id,equiped)");
            strSql.Append(" values (");
            strSql.Append("@type_code,@account_id,@equiped)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@type_code", MySqlDbType.Int32,11),
                    new MySqlParameter("@account_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@equiped", MySqlDbType.Int32,11)};
            parameters[0].Value = type_code;
            parameters[1].Value = account_id;
            parameters[2].Value = equiped;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            getkey();
        }

        void getkey()
        {
            DataSet ds = DbHelperMySQL.Query("select @@IDENTITY as id");
            if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
            {
                this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update item set ");
            strSql.Append("type_code=@type_code,");
            strSql.Append("account_id=@account_id,");
            strSql.Append("equiped=@equiped");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@type_code", MySqlDbType.Int32,11),
                    new MySqlParameter("@account_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@equiped", MySqlDbType.Int32,11),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = type_code;
            parameters[1].Value = account_id;
            parameters[2].Value = equiped;
            parameters[3].Value = id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from item ");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public void GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,type_code,account_id,equiped ");
            strSql.Append(" FROM item ");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type_code"] != null && ds.Tables[0].Rows[0]["type_code"].ToString() != "")
                {
                    this.type_code = int.Parse(ds.Tables[0].Rows[0]["type_code"].ToString());
                }
                if (ds.Tables[0].Rows[0]["account_id"] != null && ds.Tables[0].Rows[0]["account_id"].ToString() != "")
                {
                    this.account_id = int.Parse(ds.Tables[0].Rows[0]["account_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["equiped"] != null && ds.Tables[0].Rows[0]["equiped"].ToString() != "")
                {
                    this.equiped = int.Parse(ds.Tables[0].Rows[0]["equiped"].ToString());
                }
            }
            
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static Item[] GetList(int account_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,type_code,account_id,equiped ");
            strSql.Append(" FROM item ");
            strSql.Append(" where account_id=@account_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@account_id", MySqlDbType.Int32)};
            parameters[0].Value = account_id;
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            Item[] items = new Item[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                items[i] = new Item();
                if (ds.Tables[0].Rows[i]["id"] != null && ds.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    items[i].id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                }
                if (ds.Tables[0].Rows[i]["type_code"] != null && ds.Tables[0].Rows[i]["type_code"].ToString() != "")
                {
                    items[i].type_code = int.Parse(ds.Tables[0].Rows[i]["type_code"].ToString());
                }
                if (ds.Tables[0].Rows[i]["account_id"] != null && ds.Tables[0].Rows[i]["account_id"].ToString() != "")
                {
                    items[i].account_id = int.Parse(ds.Tables[0].Rows[i]["account_id"].ToString());
                }
                if (ds.Tables[0].Rows[i]["equiped"] != null && ds.Tables[0].Rows[i]["equiped"].ToString() != "")
                {
                    items[i].equiped = int.Parse(ds.Tables[0].Rows[i]["equiped"].ToString());
                }
            }
            return items;
        }

        public Item confirm_key(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,type_code,account_id,equiped ");
            strSql.Append(" FROM item ");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            Item item = new Item();
           
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                item.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type_code"] != null && ds.Tables[0].Rows[0]["type_code"].ToString() != "")
                {
                item.type_code = int.Parse(ds.Tables[0].Rows[0]["type_code"].ToString());
                }
                if (ds.Tables[0].Rows[0]["account_id"] != null && ds.Tables[0].Rows[0]["account_id"].ToString() != "")
                {
                item.account_id = int.Parse(ds.Tables[0].Rows[0]["account_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["equiped"] != null && ds.Tables[0].Rows[0]["equiped"].ToString() != "")
                {
                item.equiped = int.Parse(ds.Tables[0].Rows[0]["equiped"].ToString());
                }
            return item;

        }


        #endregion  Method
    }
}

