using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace robot2
{
    /// <summary>
    /// 类Robot。
    /// </summary>
    [Serializable]
    public partial class Robot
    {
        public Robot()
        { }
        #region Model
        private int _id;
        private int _account_id;
        private int _code_id;
        private int _lvl;
        private int _exp;
        private int _hp;
        private int _ammo;
        private int _fuel;
        private int _addition_fire;
        private int _addition_fire_exp;
        private int _addition_move;
        private int _addition_move_exp;
        private int _addition_def;
        private int _addition_def_exp;
        private int _item1;
        private int _item2;
        private int _item3;
        private int _item4;
        private int _useable;
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
        public int code_id
        {
            set { _code_id = value; }
            get { return _code_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int lvl
        {
            set { _lvl = value; }
            get { return _lvl; }
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
        public int hp
        {
            set { _hp = value; }
            get { return _hp; }
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
        public int fuel
        {
            set { _fuel = value; }
            get { return _fuel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int addition_fire
        {
            set { _addition_fire = value; }
            get { return _addition_fire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int addition_fire_exp
        {
            set { _addition_fire_exp = value; }
            get { return _addition_fire_exp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int addition_move
        {
            set { _addition_move = value; }
            get { return _addition_move; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int addition_move_exp
        {
            set { _addition_move_exp = value; }
            get { return _addition_move_exp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int addition_def
        {
            set { _addition_def = value; }
            get { return _addition_def; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int addition_def_exp
        {
            set { _addition_def_exp = value; }
            get { return _addition_def_exp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int item1
        {
            set { _item1 = value; }
            get { return _item1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int item2
        {
            set { _item2 = value; }
            get { return _item2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int item3
        {
            set { _item3 = value; }
            get { return _item3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int item4
        {
            set { _item4 = value; }
            get { return _item4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int useable
        {
            set { _useable = value; }
            get { return _useable; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Robot(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,account_id,code_id,lvl,exp,hp,ammo,fuel,addition_fire,addition_fire_exp,addition_move,addition_move_exp,addition_def,addition_def_exp,item1,item2,item3,item4,useable ");
            strSql.Append(" FROM robot ");
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
                if (ds.Tables[0].Rows[0]["code_id"] != null && ds.Tables[0].Rows[0]["code_id"].ToString() != "")
                {
                    this.code_id = int.Parse(ds.Tables[0].Rows[0]["code_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lvl"] != null && ds.Tables[0].Rows[0]["lvl"].ToString() != "")
                {
                    this.lvl = int.Parse(ds.Tables[0].Rows[0]["lvl"].ToString());
                }
                if (ds.Tables[0].Rows[0]["exp"] != null && ds.Tables[0].Rows[0]["exp"].ToString() != "")
                {
                    this.exp = int.Parse(ds.Tables[0].Rows[0]["exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hp"] != null && ds.Tables[0].Rows[0]["hp"].ToString() != "")
                {
                    this.hp = int.Parse(ds.Tables[0].Rows[0]["hp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ammo"] != null && ds.Tables[0].Rows[0]["ammo"].ToString() != "")
                {
                    this.ammo = int.Parse(ds.Tables[0].Rows[0]["ammo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuel"] != null && ds.Tables[0].Rows[0]["fuel"].ToString() != "")
                {
                    this.fuel = int.Parse(ds.Tables[0].Rows[0]["fuel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_fire"] != null && ds.Tables[0].Rows[0]["addition_fire"].ToString() != "")
                {
                    this.addition_fire = int.Parse(ds.Tables[0].Rows[0]["addition_fire"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_fire_exp"] != null && ds.Tables[0].Rows[0]["addition_fire_exp"].ToString() != "")
                {
                    this.addition_fire_exp = int.Parse(ds.Tables[0].Rows[0]["addition_fire_exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_move"] != null && ds.Tables[0].Rows[0]["addition_move"].ToString() != "")
                {
                    this.addition_move = int.Parse(ds.Tables[0].Rows[0]["addition_move"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_move_exp"] != null && ds.Tables[0].Rows[0]["addition_move_exp"].ToString() != "")
                {
                    this.addition_move_exp = int.Parse(ds.Tables[0].Rows[0]["addition_move_exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_def"] != null && ds.Tables[0].Rows[0]["addition_def"].ToString() != "")
                {
                    this.addition_def = int.Parse(ds.Tables[0].Rows[0]["addition_def"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_def_exp"] != null && ds.Tables[0].Rows[0]["addition_def_exp"].ToString() != "")
                {
                    this.addition_def_exp = int.Parse(ds.Tables[0].Rows[0]["addition_def_exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["item1"] != null && ds.Tables[0].Rows[0]["item1"].ToString() != "")
                {
                    this.item1 = int.Parse(ds.Tables[0].Rows[0]["item1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["item2"] != null && ds.Tables[0].Rows[0]["item2"].ToString() != "")
                {
                    this.item2 = int.Parse(ds.Tables[0].Rows[0]["item2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["item3"] != null && ds.Tables[0].Rows[0]["item3"].ToString() != "")
                {
                    this.item3 = int.Parse(ds.Tables[0].Rows[0]["item3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["item4"] != null && ds.Tables[0].Rows[0]["item4"].ToString() != "")
                {
                    this.item4 = int.Parse(ds.Tables[0].Rows[0]["item4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["useable"] != null && ds.Tables[0].Rows[0]["useable"].ToString() != "")
                {
                    this.useable = int.Parse(ds.Tables[0].Rows[0]["useable"].ToString());
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from robot");
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
            strSql.Append("insert into robot (");
            strSql.Append("account_id,code_id,lvl,exp,hp,ammo,fuel,addition_fire,addition_fire_exp,addition_move,addition_move_exp,addition_def,addition_def_exp,item1,item2,item3,item4,useable)");
            strSql.Append(" values (");
            strSql.Append("@account_id,@code_id,@lvl,@exp,@hp,@ammo,@fuel,@addition_fire,@addition_fire_exp,@addition_move,@addition_move_exp,@addition_def,@addition_def_exp,@item1,@item2,@item3,@item4,@useable)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@account_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@code_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@lvl", MySqlDbType.Int32,11),
                    new MySqlParameter("@exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@hp", MySqlDbType.Int32,11),
                    new MySqlParameter("@ammo", MySqlDbType.Int32,11),
                    new MySqlParameter("@fuel", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_fire", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_fire_exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_move", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_move_exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_def", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_def_exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@item1", MySqlDbType.Int32,11),
                    new MySqlParameter("@item2", MySqlDbType.Int32,11),
                    new MySqlParameter("@item3", MySqlDbType.Int32,11),
                    new MySqlParameter("@item4", MySqlDbType.Int32,11),
                    new MySqlParameter("@useable", MySqlDbType.Int32,11)};
            parameters[0].Value = account_id;
            parameters[1].Value = code_id;
            parameters[2].Value = lvl;
            parameters[3].Value = exp;
            parameters[4].Value = hp;
            parameters[5].Value = ammo;
            parameters[6].Value = fuel;
            parameters[7].Value = addition_fire;
            parameters[8].Value = addition_fire_exp;
            parameters[9].Value = addition_move;
            parameters[10].Value = addition_move_exp;
            parameters[11].Value = addition_def;
            parameters[12].Value = addition_def_exp;
            parameters[13].Value = item1;
            parameters[14].Value = item2;
            parameters[15].Value = item3;
            parameters[16].Value = item4;
            parameters[17].Value = useable;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            getkey();
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update robot set ");
            strSql.Append("account_id=@account_id,");
            strSql.Append("code_id=@code_id,");
            strSql.Append("lvl=@lvl,");
            strSql.Append("exp=@exp,");
            strSql.Append("hp=@hp,");
            strSql.Append("ammo=@ammo,");
            strSql.Append("fuel=@fuel,");
            strSql.Append("addition_fire=@addition_fire,");
            strSql.Append("addition_fire_exp=@addition_fire_exp,");
            strSql.Append("addition_move=@addition_move,");
            strSql.Append("addition_move_exp=@addition_move_exp,");
            strSql.Append("addition_def=@addition_def,");
            strSql.Append("addition_def_exp=@addition_def_exp,");
            strSql.Append("item1=@item1,");
            strSql.Append("item2=@item2,");
            strSql.Append("item3=@item3,");
            strSql.Append("item4=@item4,");
            strSql.Append("useable=@useable");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@account_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@code_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@lvl", MySqlDbType.Int32,11),
                    new MySqlParameter("@exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@hp", MySqlDbType.Int32,11),
                    new MySqlParameter("@ammo", MySqlDbType.Int32,11),
                    new MySqlParameter("@fuel", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_fire", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_fire_exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_move", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_move_exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_def", MySqlDbType.Int32,11),
                    new MySqlParameter("@addition_def_exp", MySqlDbType.Int32,11),
                    new MySqlParameter("@item1", MySqlDbType.Int32,11),
                    new MySqlParameter("@item2", MySqlDbType.Int32,11),
                    new MySqlParameter("@item3", MySqlDbType.Int32,11),
                    new MySqlParameter("@item4", MySqlDbType.Int32,11),
                    new MySqlParameter("@useable", MySqlDbType.Int32,11),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = account_id;
            parameters[1].Value = code_id;
            parameters[2].Value = lvl;
            parameters[3].Value = exp;
            parameters[4].Value = hp;
            parameters[5].Value = ammo;
            parameters[6].Value = fuel;
            parameters[7].Value = addition_fire;
            parameters[8].Value = addition_fire_exp;
            parameters[9].Value = addition_move;
            parameters[10].Value = addition_move_exp;
            parameters[11].Value = addition_def;
            parameters[12].Value = addition_def_exp;
            parameters[13].Value = item1;
            parameters[14].Value = item2;
            parameters[15].Value = item3;
            parameters[16].Value = item4;
            parameters[17].Value = useable;
            parameters[18].Value = id;

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

        void getkey()
        {
            DataSet ds = DbHelperMySQL.Query("select @@IDENTITY as id");
            if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
            {
                this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from robot ");
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
            strSql.Append("select id,account_id,code_id,lvl,exp,hp,ammo,fuel,addition_fire,addition_fire_exp,addition_move,addition_move_exp,addition_def,addition_def_exp,item1,item2,item3,item4,useable ");
            strSql.Append(" FROM robot ");
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
                if (ds.Tables[0].Rows[0]["code_id"] != null && ds.Tables[0].Rows[0]["code_id"].ToString() != "")
                {
                    this.code_id = int.Parse(ds.Tables[0].Rows[0]["code_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lvl"] != null && ds.Tables[0].Rows[0]["lvl"].ToString() != "")
                {
                    this.lvl = int.Parse(ds.Tables[0].Rows[0]["lvl"].ToString());
                }
                if (ds.Tables[0].Rows[0]["exp"] != null && ds.Tables[0].Rows[0]["exp"].ToString() != "")
                {
                    this.exp = int.Parse(ds.Tables[0].Rows[0]["exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hp"] != null && ds.Tables[0].Rows[0]["hp"].ToString() != "")
                {
                    this.hp = int.Parse(ds.Tables[0].Rows[0]["hp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ammo"] != null && ds.Tables[0].Rows[0]["ammo"].ToString() != "")
                {
                    this.ammo = int.Parse(ds.Tables[0].Rows[0]["ammo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuel"] != null && ds.Tables[0].Rows[0]["fuel"].ToString() != "")
                {
                    this.fuel = int.Parse(ds.Tables[0].Rows[0]["fuel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_fire"] != null && ds.Tables[0].Rows[0]["addition_fire"].ToString() != "")
                {
                    this.addition_fire = int.Parse(ds.Tables[0].Rows[0]["addition_fire"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_fire_exp"] != null && ds.Tables[0].Rows[0]["addition_fire_exp"].ToString() != "")
                {
                    this.addition_fire_exp = int.Parse(ds.Tables[0].Rows[0]["addition_fire_exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_move"] != null && ds.Tables[0].Rows[0]["addition_move"].ToString() != "")
                {
                    this.addition_move = int.Parse(ds.Tables[0].Rows[0]["addition_move"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_move_exp"] != null && ds.Tables[0].Rows[0]["addition_move_exp"].ToString() != "")
                {
                    this.addition_move_exp = int.Parse(ds.Tables[0].Rows[0]["addition_move_exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_def"] != null && ds.Tables[0].Rows[0]["addition_def"].ToString() != "")
                {
                    this.addition_def = int.Parse(ds.Tables[0].Rows[0]["addition_def"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addition_def_exp"] != null && ds.Tables[0].Rows[0]["addition_def_exp"].ToString() != "")
                {
                    this.addition_def_exp = int.Parse(ds.Tables[0].Rows[0]["addition_def_exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["item1"] != null && ds.Tables[0].Rows[0]["item1"].ToString() != "")
                {
                    this.item1 = int.Parse(ds.Tables[0].Rows[0]["item1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["item2"] != null && ds.Tables[0].Rows[0]["item2"].ToString() != "")
                {
                    this.item2 = int.Parse(ds.Tables[0].Rows[0]["item2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["item3"] != null && ds.Tables[0].Rows[0]["item3"].ToString() != "")
                {
                    this.item3 = int.Parse(ds.Tables[0].Rows[0]["item3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["item4"] != null && ds.Tables[0].Rows[0]["item4"].ToString() != "")
                {
                    this.item4 = int.Parse(ds.Tables[0].Rows[0]["item4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["useable"] != null && ds.Tables[0].Rows[0]["useable"].ToString() != "")
                {
                    this.useable = int.Parse(ds.Tables[0].Rows[0]["useable"].ToString());
                }
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static Robot[] GetList(int account_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,account_id,code_id,lvl,exp,hp,ammo,fuel,addition_fire,addition_fire_exp,addition_move,addition_move_exp,addition_def,addition_def_exp,item1,item2,item3,item4,useable ");
            strSql.Append(" FROM robot ");
            strSql.Append(" where account_id=@account_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@account_id", MySqlDbType.Int32)};
            parameters[0].Value = account_id;

            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            Robot[] robots = new Robot[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                robots[i] = new Robot();
                if (ds.Tables[0].Rows[i]["id"] != null && ds.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    robots[i].id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                }
                if (ds.Tables[0].Rows[i]["account_id"] != null && ds.Tables[0].Rows[i]["account_id"].ToString() != "")
                {
                    robots[i].account_id = int.Parse(ds.Tables[0].Rows[i]["account_id"].ToString());
                }
                if (ds.Tables[0].Rows[i]["code_id"] != null && ds.Tables[0].Rows[i]["code_id"].ToString() != "")
                {
                    robots[i].code_id = int.Parse(ds.Tables[0].Rows[i]["code_id"].ToString());
                }
                if (ds.Tables[0].Rows[i]["lvl"] != null && ds.Tables[0].Rows[i]["lvl"].ToString() != "")
                {
                    robots[i].lvl = int.Parse(ds.Tables[0].Rows[i]["lvl"].ToString());
                }
                if (ds.Tables[0].Rows[i]["exp"] != null && ds.Tables[0].Rows[i]["exp"].ToString() != "")
                {
                    robots[i].exp = int.Parse(ds.Tables[0].Rows[i]["exp"].ToString());
                }
                if (ds.Tables[0].Rows[i]["hp"] != null && ds.Tables[0].Rows[i]["hp"].ToString() != "")
                {
                    robots[i].hp = int.Parse(ds.Tables[0].Rows[i]["hp"].ToString());
                }
                if (ds.Tables[0].Rows[i]["ammo"] != null && ds.Tables[0].Rows[i]["ammo"].ToString() != "")
                {
                    robots[i].ammo = int.Parse(ds.Tables[0].Rows[i]["ammo"].ToString());
                }
                if (ds.Tables[0].Rows[i]["fuel"] != null && ds.Tables[0].Rows[i]["fuel"].ToString() != "")
                {
                    robots[i].fuel = int.Parse(ds.Tables[0].Rows[i]["fuel"].ToString());
                }
                if (ds.Tables[0].Rows[i]["addition_fire"] != null && ds.Tables[0].Rows[i]["addition_fire"].ToString() != "")
                {
                    robots[i].addition_fire = int.Parse(ds.Tables[0].Rows[i]["addition_fire"].ToString());
                }
                if (ds.Tables[0].Rows[i]["addition_fire_exp"] != null && ds.Tables[0].Rows[i]["addition_fire_exp"].ToString() != "")
                {
                    robots[i].addition_fire_exp = int.Parse(ds.Tables[0].Rows[i]["addition_fire_exp"].ToString());
                }
                if (ds.Tables[0].Rows[i]["addition_move"] != null && ds.Tables[0].Rows[i]["addition_move"].ToString() != "")
                {
                    robots[i].addition_move = int.Parse(ds.Tables[0].Rows[i]["addition_move"].ToString());
                }
                if (ds.Tables[0].Rows[i]["addition_move_exp"] != null && ds.Tables[0].Rows[i]["addition_move_exp"].ToString() != "")
                {
                    robots[i].addition_move_exp = int.Parse(ds.Tables[0].Rows[i]["addition_move_exp"].ToString());
                }
                if (ds.Tables[0].Rows[i]["addition_def"] != null && ds.Tables[0].Rows[i]["addition_def"].ToString() != "")
                {
                    robots[i].addition_def = int.Parse(ds.Tables[0].Rows[i]["addition_def"].ToString());
                }
                if (ds.Tables[0].Rows[i]["addition_def_exp"] != null && ds.Tables[0].Rows[i]["addition_def_exp"].ToString() != "")
                {
                    robots[i].addition_def_exp = int.Parse(ds.Tables[0].Rows[i]["addition_def_exp"].ToString());
                }
                if (ds.Tables[0].Rows[i]["item1"] != null && ds.Tables[0].Rows[i]["item1"].ToString() != "")
                {
                    robots[i].item1 = int.Parse(ds.Tables[0].Rows[i]["item1"].ToString());
                }
                if (ds.Tables[0].Rows[i]["item2"] != null && ds.Tables[0].Rows[i]["item2"].ToString() != "")
                {
                    robots[i].item2 = int.Parse(ds.Tables[0].Rows[i]["item2"].ToString());
                }
                if (ds.Tables[0].Rows[i]["item3"] != null && ds.Tables[0].Rows[i]["item3"].ToString() != "")
                {
                    robots[i].item3 = int.Parse(ds.Tables[0].Rows[i]["item3"].ToString());
                }
                if (ds.Tables[0].Rows[i]["item4"] != null && ds.Tables[0].Rows[i]["item4"].ToString() != "")
                {
                    robots[i].item4 = int.Parse(ds.Tables[0].Rows[i]["item4"].ToString());
                }
                if (ds.Tables[0].Rows[i]["useable"] != null && ds.Tables[0].Rows[i]["useable"].ToString() != "")
                {
                    robots[i].useable = int.Parse(ds.Tables[0].Rows[i]["useable"].ToString());
                }
            }
            return robots;
        }

        #endregion  Method
    }
}

