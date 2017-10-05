using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace robot2
{
    /// <summary>
    /// 类Player。
    /// </summary>
    [Serializable]
    public partial class Player
    {
        public Player()
        { }
        #region Model
        private int _id;
        private int _account_id;
        private string _name;
        private int _type;
        private int _level;
        private int _exp;
        private int _ammo;
        private int _resource;
        private int _fuel;
        private int _cristal;
        private int _robot1;
        private int _robot2;
        private int _robot3;
        private int _robot4;
        private int _battle_level;
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
        public int account_id
        {
            set { _account_id = value; }
            get { return _account_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int level
        {
            set { _level = value; }
            get { return _level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int exp
        {
            set { _exp = value; }
            get { return _exp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ammo
        {
            set { _ammo = value; }
            get { return _ammo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int resource
        {
            set { _resource = value; }
            get { return _resource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int fuel
        {
            set { _fuel = value; }
            get { return _fuel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int cristal
        {
            set { _cristal = value; }
            get { return _cristal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int robot1
        {
            set { _robot1 = value; }
            get { return _robot1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int robot2
        {
            set { _robot2 = value; }
            get { return _robot2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int robot3
        {
            set { _robot3 = value; }
            get { return _robot3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int robot4
        {
            set { _robot4 = value; }
            get { return _robot4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int battle_level
        {
            set { _battle_level = value; }
            get { return _battle_level; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Player(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,account_id,name,type,level,exp,ammo,resource,fuel,cristal,robot1,robot2,robot3,robot4,battle_level ");
            strSql.Append(" FROM player ");
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
                if (ds.Tables[0].Rows[0]["account_id"] != null && ds.Tables[0].Rows[0]["account_id"].ToString() != "")
                {
                    this.account_id = int.Parse(ds.Tables[0].Rows[0]["account_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["name"] != null)
                {
                    this.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["type"] != null && ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    this.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["level"] != null && ds.Tables[0].Rows[0]["level"].ToString() != "")
                {
                    this.level = int.Parse(ds.Tables[0].Rows[0]["level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["exp"] != null && ds.Tables[0].Rows[0]["exp"].ToString() != "")
                {
                    this.exp = int.Parse(ds.Tables[0].Rows[0]["exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ammo"] != null && ds.Tables[0].Rows[0]["ammo"].ToString() != "")
                {
                    this.ammo = int.Parse(ds.Tables[0].Rows[0]["ammo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["resource"] != null && ds.Tables[0].Rows[0]["resource"].ToString() != "")
                {
                    this.resource = int.Parse(ds.Tables[0].Rows[0]["resource"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuel"] != null && ds.Tables[0].Rows[0]["fuel"].ToString() != "")
                {
                    this.fuel = int.Parse(ds.Tables[0].Rows[0]["fuel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cristal"] != null && ds.Tables[0].Rows[0]["cristal"].ToString() != "")
                {
                    this.cristal = int.Parse(ds.Tables[0].Rows[0]["cristal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot1"] != null && ds.Tables[0].Rows[0]["robot1"].ToString() != "")
                {
                    this.robot1 = int.Parse(ds.Tables[0].Rows[0]["robot1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot2"] != null && ds.Tables[0].Rows[0]["robot2"].ToString() != "")
                {
                    this.robot2 = int.Parse(ds.Tables[0].Rows[0]["robot2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot3"] != null && ds.Tables[0].Rows[0]["robot3"].ToString() != "")
                {
                    this.robot3 = int.Parse(ds.Tables[0].Rows[0]["robot3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot4"] != null && ds.Tables[0].Rows[0]["robot4"].ToString() != "")
                {
                    this.robot4 = int.Parse(ds.Tables[0].Rows[0]["robot4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["battle_level"] != null && ds.Tables[0].Rows[0]["battle_level"].ToString() != "")
                {
                    this.battle_level = int.Parse(ds.Tables[0].Rows[0]["battle_level"].ToString());
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from player");
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
            strSql.Append("insert into player (");
            strSql.Append("account_id,name,type,level,exp,ammo,resource,fuel,cristal,robot1,robot2,robot3,robot4,battle_level)");
            strSql.Append(" values (");
            strSql.Append("@account_id,@name,@type,@level,@exp,@ammo,@resource,@fuel,@cristal,@robot1,@robot2,@robot3,@robot4,@battle_level)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@account_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@name", MySqlDbType.VarChar,255),
                    new MySqlParameter("@type", MySqlDbType.Int32,11),
                    new MySqlParameter("@level", MySqlDbType.Int32,11),
                    new MySqlParameter("@exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@ammo", MySqlDbType.Int32,11),
                    new MySqlParameter("@resource", MySqlDbType.Int32,11),
                    new MySqlParameter("@fuel", MySqlDbType.Int32,11),
                    new MySqlParameter("@cristal", MySqlDbType.Int32,11),
                    new MySqlParameter("@robot1", MySqlDbType.Int32,11),
                    new MySqlParameter("@robot2", MySqlDbType.Int32,11),
                    new MySqlParameter("@robot3", MySqlDbType.Int32,11),
                    new MySqlParameter("@robot4", MySqlDbType.Int32,11),
                    new MySqlParameter("@battle_level", MySqlDbType.Int32,11)};
            parameters[0].Value = account_id;
            parameters[1].Value = name;
            parameters[2].Value = type;
            parameters[3].Value = level;
            parameters[4].Value = exp;
            parameters[5].Value = ammo;
            parameters[6].Value = resource;
            parameters[7].Value = fuel;
            parameters[8].Value = cristal;
            parameters[9].Value = robot1;
            parameters[10].Value = robot2;
            parameters[11].Value = robot3;
            parameters[12].Value = robot4;
            parameters[13].Value = battle_level;

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
            strSql.Append("update player set ");
            strSql.Append("account_id=@account_id,");
            strSql.Append("name=@name,");
            strSql.Append("type=@type,");
            strSql.Append("level=@level,");
            strSql.Append("exp=@exp,");
            strSql.Append("ammo=@ammo,");
            strSql.Append("resource=@resource,");
            strSql.Append("fuel=@fuel,");
            strSql.Append("cristal=@cristal,");
            strSql.Append("robot1=@robot1,");
            strSql.Append("robot2=@robot2,");
            strSql.Append("robot3=@robot3,");
            strSql.Append("robot4=@robot4,");
            strSql.Append("battle_level=@battle_level");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@account_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@name", MySqlDbType.VarChar,255),
                    new MySqlParameter("@type", MySqlDbType.Int32,11),
                    new MySqlParameter("@level", MySqlDbType.Int32,11),
                    new MySqlParameter("@exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@ammo", MySqlDbType.Int32,11),
                    new MySqlParameter("@resource", MySqlDbType.Int32,11),
                    new MySqlParameter("@fuel", MySqlDbType.Int32,11),
                    new MySqlParameter("@cristal", MySqlDbType.Int32,11),
                    new MySqlParameter("@robot1", MySqlDbType.Int32,11),
                    new MySqlParameter("@robot2", MySqlDbType.Int32,11),
                    new MySqlParameter("@robot3", MySqlDbType.Int32,11),
                    new MySqlParameter("@robot4", MySqlDbType.Int32,11),
                    new MySqlParameter("@battle_level", MySqlDbType.Int32,11),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = account_id;
            parameters[1].Value = name;
            parameters[2].Value = type;
            parameters[3].Value = level;
            parameters[4].Value = exp;
            parameters[5].Value = ammo;
            parameters[6].Value = resource;
            parameters[7].Value = fuel;
            parameters[8].Value = cristal;
            parameters[9].Value = robot1;
            parameters[10].Value = robot2;
            parameters[11].Value = robot3;
            parameters[12].Value = robot4;
            parameters[13].Value = battle_level;
            parameters[14].Value = id;

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
            strSql.Append("delete from player ");
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
        public bool GetModel(int account_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,account_id,name,type,level,exp,ammo,resource,fuel,cristal,robot1,robot2,robot3,robot4,battle_level ");
            strSql.Append(" FROM player ");
            strSql.Append(" where account_id=@account_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@account_id", MySqlDbType.Int32)};
            parameters[0].Value = account_id;

            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["account_id"] != null && ds.Tables[0].Rows[0]["account_id"].ToString() != "")
                {
                    this.account_id = int.Parse(ds.Tables[0].Rows[0]["account_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["name"] != null)
                {
                    this.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["type"] != null && ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    this.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["level"] != null && ds.Tables[0].Rows[0]["level"].ToString() != "")
                {
                    this.level = int.Parse(ds.Tables[0].Rows[0]["level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["exp"] != null && ds.Tables[0].Rows[0]["exp"].ToString() != "")
                {
                    this.exp = int.Parse(ds.Tables[0].Rows[0]["exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ammo"] != null && ds.Tables[0].Rows[0]["ammo"].ToString() != "")
                {
                    this.ammo = int.Parse(ds.Tables[0].Rows[0]["ammo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["resource"] != null && ds.Tables[0].Rows[0]["resource"].ToString() != "")
                {
                    this.resource = int.Parse(ds.Tables[0].Rows[0]["resource"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuel"] != null && ds.Tables[0].Rows[0]["fuel"].ToString() != "")
                {
                    this.fuel = int.Parse(ds.Tables[0].Rows[0]["fuel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cristal"] != null && ds.Tables[0].Rows[0]["cristal"].ToString() != "")
                {
                    this.cristal = int.Parse(ds.Tables[0].Rows[0]["cristal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot1"] != null && ds.Tables[0].Rows[0]["robot1"].ToString() != "")
                {
                    this.robot1 = int.Parse(ds.Tables[0].Rows[0]["robot1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot2"] != null && ds.Tables[0].Rows[0]["robot2"].ToString() != "")
                {
                    this.robot2 = int.Parse(ds.Tables[0].Rows[0]["robot2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot3"] != null && ds.Tables[0].Rows[0]["robot3"].ToString() != "")
                {
                    this.robot3 = int.Parse(ds.Tables[0].Rows[0]["robot3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot4"] != null && ds.Tables[0].Rows[0]["robot4"].ToString() != "")
                {
                    this.robot4 = int.Parse(ds.Tables[0].Rows[0]["robot4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["battle_level"] != null && ds.Tables[0].Rows[0]["battle_level"].ToString() != "")
                {
                    this.battle_level = int.Parse(ds.Tables[0].Rows[0]["battle_level"].ToString());
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM player ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个玩家昵称
        /// </summary>
        public bool GetName(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,account_id,name,type,level,exp,ammo,resource,fuel,cristal,robot1,robot2,robot3,robot4,battle_level ");
            strSql.Append(" FROM player ");
            strSql.Append(" where name=@name ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@name", MySqlDbType.Int32)};
            parameters[0].Value = name;

            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["account_id"] != null && ds.Tables[0].Rows[0]["account_id"].ToString() != "")
                {
                    this.account_id = int.Parse(ds.Tables[0].Rows[0]["account_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["name"] != null)
                {
                    this.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["type"] != null && ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    this.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["level"] != null && ds.Tables[0].Rows[0]["level"].ToString() != "")
                {
                    this.level = int.Parse(ds.Tables[0].Rows[0]["level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["exp"] != null && ds.Tables[0].Rows[0]["exp"].ToString() != "")
                {
                    this.exp = int.Parse(ds.Tables[0].Rows[0]["exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ammo"] != null && ds.Tables[0].Rows[0]["ammo"].ToString() != "")
                {
                    this.ammo = int.Parse(ds.Tables[0].Rows[0]["ammo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["resource"] != null && ds.Tables[0].Rows[0]["resource"].ToString() != "")
                {
                    this.resource = int.Parse(ds.Tables[0].Rows[0]["resource"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuel"] != null && ds.Tables[0].Rows[0]["fuel"].ToString() != "")
                {
                    this.fuel = int.Parse(ds.Tables[0].Rows[0]["fuel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cristal"] != null && ds.Tables[0].Rows[0]["cristal"].ToString() != "")
                {
                    this.cristal = int.Parse(ds.Tables[0].Rows[0]["cristal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot1"] != null && ds.Tables[0].Rows[0]["robot1"].ToString() != "")
                {
                    this.robot1 = int.Parse(ds.Tables[0].Rows[0]["robot1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot2"] != null && ds.Tables[0].Rows[0]["robot2"].ToString() != "")
                {
                    this.robot2 = int.Parse(ds.Tables[0].Rows[0]["robot2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot3"] != null && ds.Tables[0].Rows[0]["robot3"].ToString() != "")
                {
                    this.robot3 = int.Parse(ds.Tables[0].Rows[0]["robot3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["robot4"] != null && ds.Tables[0].Rows[0]["robot4"].ToString() != "")
                {
                    this.robot4 = int.Parse(ds.Tables[0].Rows[0]["robot4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["battle_level"] != null && ds.Tables[0].Rows[0]["battle_level"].ToString() != "")
                {
                    this.battle_level = int.Parse(ds.Tables[0].Rows[0]["battle_level"].ToString());
                }
                return true;
            }
            return false;
        }
        #endregion  Method
    }
}

