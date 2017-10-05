using robot2;
using robot2_serv.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot2_serv.src_cache
{
    public class DataCache
    {
        //用以存储账号account和账号信息的对应关系
        public static Dictionary<string, Account> accountMap = new Dictionary<string, Account>();
        //用以存储key和id之间的对应关系
        public static Dictionary<int, string> session1 = new Dictionary<int, string>();
        //用以存储id和key之间的对应关系
        public static Dictionary<string, int> session = new Dictionary<string, int>();

        private static PlayerCache playerCache;
        private static RobotCache robotCache;
        private static ItemCache itemCache;

        static DataCache()
        {
            playerCache = new PlayerCache();
            robotCache = new RobotCache();
            itemCache = new ItemCache();
        }

        //获取账号，检测是否存在
        public static Account getAccount(string account)
        {        
            if (!accountMap.ContainsKey(account))
            {
                Account acc = new Account();
                if (acc.GetModel(account))
                {
                    accountMap.Add(account, acc);
                }
            }
            if (accountMap.ContainsKey(account))
            { return accountMap[account]; }
            return null;   
        }
        //注册账号
        public static bool register(string account,string password)
        {
            //账号是否存在
            Account acc = getAccount(account);
            if (acc != null) return false;
            acc = new Account();
            acc.account = account;
            acc.password = password;
            acc.Add();
            accountMap.Add(account, acc);
            return true;
        }
        //检查角色是否合法
        private static bool Player_key_OK(int account_id, string key)
        {
            if (DataCache.session1.ContainsKey(account_id))
            {
                string value = "";
                DataCache.session1.TryGetValue(account_id, out value);
                if (value.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        //增加一个物品
        public static Item Additem(int account_id, string key, int type)
        {
            if (!Player_key_OK(account_id, key)) return null;
            int type_code = 0;
            int ammo = 0;
            int resource = 0;
            int fuel = 0;
            Random ran = new Random();
            int star = ran.Next(1, 5);
            int typeX = ran.Next(1, 4);
            //211001
            switch (type)
            {
                case 1:
                    ammo = 50;
                    resource = 35;
                    fuel = 35;
                    switch (typeX)
                    {
                        case 1:
                            type_code = 210001 + star * 1000;
                            break;
                        case 2:
                            type_code = 240001 + star * 1000;
                            break;
                        case 3:
                            type_code = 250001 + star * 1000;
                            break;
                    }
                    
                    break;
                case 2:
                    ammo = 35;
                    resource = 50;
                    fuel = 35;
                    switch (typeX)
                    {
                        case 1:
                            type_code = 220001 + star * 1000;
                            break;
                        case 2:
                            type_code = 240001 + star * 1000;
                            break;
                        case 3:
                            type_code = 250001 + star * 1000;
                            break;
                    }
                    break;
                case 3:
                    ammo = 35;
                    resource = 35;
                    fuel = 50;
                    switch (typeX)
                    {
                        case 1:
                            type_code = 230001 + star * 1000;
                            break;
                        case 2:
                            type_code = 240001 + star * 1000;
                            break;
                        case 3:
                            type_code = 250001 + star * 1000;
                            break;
                    }
                    break;
                case 4:
                    ammo = 40;
                    resource = 40;
                    fuel = 40;
                    int types = ran.Next(1, 6);
                    type_code = 200001 + star * 1000+ types*10000;
                    break;
            }
            if (!FinalData.Instance().HasItem(type_code)) return null;
            Player player = getplayer(key);
            if (player.ammo < ammo || player.resource < resource || player.fuel < fuel) return null;
            player.ammo -= ammo;
            player.resource -= resource;
            player.fuel -= fuel;
            player.Update();
           Item item = itemCache.AddItem(account_id, type_code);
            return item;
        }


        //增加角色经验及升级
        public static int RoleExpAddUp(int account_id, string key, int exp)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Player player = getplayer(key);

            player.exp += exp;
            if (player.exp >= player.level * 100)
            {
                do
                {
                    player.exp -= player.level * 100;
                    player.level++;
                }
                while (player.exp<player.level*100);
            }
            player.Update();
            return 1;
        }

        //使用具体code给玩家添加战利品装备
        public static Item RoleAddRewardItem(int account_id, string key, int type_code)
        {
            if (!Player_key_OK(account_id, key)) return null;

           Item item = itemCache.AddItem(account_id, type_code);

            return item;


        }
        //开始作战
        public static int BattleStart(int account_id, string key, int robot1, int robot2, int robot3, int robot4,int choosed_id)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            if (robot1 != 0)
            {
                Robot robot_1 = robotCache.GetRobot(account_id, robot1);
                if (robot_1 == null) return -2;
                if (robot_1.fuel <= 0 || robot_1.ammo <= 0) return -3;
                if (robot_1.hp <= 0) return -4;
                RobotData data_1 = FinalData.Instance().GetRobot(robot_1.code_id);
                int fuel1 = (data_1.fuel / data_1.rng)+1;
                robot_1.fuel -= fuel1;
                if (robot_1.fuel < 0) robot_1.fuel = 0;
                robot_1.Update();
            }
            if (robot2 != 0)
            {
                Robot robot_2 = robotCache.GetRobot(account_id, robot2);
                if (robot_2 == null) return -2;
                if (robot_2.fuel <= 0 || robot_2.ammo <= 0) return -3;
                if (robot_2.hp <= 0) return -4;
                RobotData data_2 = FinalData.Instance().GetRobot(robot_2.code_id);
                int fuel2 = (data_2.fuel / data_2.rng) + 1;
                robot_2.fuel -= fuel2;
                if (robot_2.fuel < 0) robot_2.fuel = 0;
                robot_2.Update();
            }
            if (robot3 != 0)
            {
                Robot robot_3 = robotCache.GetRobot(account_id, robot3);
                if (robot_3 == null) return -2;
                if (robot_3.fuel <= 0 || robot_3.ammo <= 0) return -3;
                if (robot_3.hp <= 0) return -4;
                RobotData data_3 = FinalData.Instance().GetRobot(robot_3.code_id);
                int fuel3 = (data_3.fuel / data_3.rng) + 1;
                robot_3.fuel -= fuel3;
                if (robot_3.fuel < 0) robot_3.fuel = 0;
                robot_3.Update();
            }
            if (robot4 != 0)
            {
                Robot robot_4 = robotCache.GetRobot(account_id, robot4);
                if (robot_4 == null) return -2;
                if (robot_4.fuel <= 0 || robot_4.ammo <= 0) return -3;
                if (robot_4.hp <= 0) return -4;
                RobotData data_4 = FinalData.Instance().GetRobot(robot_4.code_id);
                int fuel4 = (data_4.fuel / data_4.rng) + 1;
                robot_4.fuel -= fuel4;
                if (robot_4.fuel < 0) robot_4.fuel = 0;
                robot_4.Update();
            }

            Robot choosed_robot = robotCache.GetRobot(account_id, choosed_id);
            if (choosed_robot.hp <= 0) return -4;
            RobotData choosed_data = FinalData.Instance().GetRobot(choosed_robot.code_id);
            int ammo_chossed = (choosed_data.ammo / choosed_data.rng) + 1;
            choosed_robot.ammo -= ammo_chossed;
            if (choosed_robot.ammo < 0) choosed_robot.ammo = 0;
            choosed_robot.Update();

            return 1;
        }
        //作战胜利
        public static int BattleWin(int account_id, string key, int robot1, int robot2, int robot3, int robot4, int choosed_id, int lvl_num)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Player player = getplayer(key);
            int exp = 0;
            switch (lvl_num)
            {
                #region c1_b1
                case 10101:
                    exp = 100;
                    break;
                case 10102:
                    exp = 150;
                    if(player.battle_level<=1)
                    {
                        player.battle_level = 1;
                    }
                    break;
                #endregion
                #region c1_b2
                case 20101:
                    exp = 100;
                    break;
                case 20102:
                    exp = 150;
                    break;
                case 20103:
                    exp = 150;
                    break;
                case 20104:
                    exp = 200;
                    if (player.battle_level <= 2)
                    {
                        player.battle_level = 2;
                    }
                    break;
                #endregion
                #region c1_b3
                case 30101:
                    exp = 100;
                    break;
                case 30102:
                    exp = 150;
                    break;
                case 30103:
                    exp = 150;
                    break;
                case 30104:
                    exp = 200;
                    if (player.battle_level <= 3)
                    {
                        player.battle_level = 3;
                    }
                    break;
                    #endregion
            }
            #region robot1
            if (robot1 != 0)
            {
                Robot robot_1 = robotCache.GetRobot(account_id, robot1);
                if (robot1 == choosed_id)
                {
                    robot_1.exp += exp;
                }
                else
                {
                    robot_1.exp += exp * 4 / 5;
                }
                if (robot_1.exp >= robot_1.lvl * 100)
                {
                    do
                    {
                        robot_1.exp -= robot_1.lvl * 100;
                        robot_1.lvl++;
                    }
                    while (robot_1.exp >= robot_1.lvl * 100) ;
                }
                robot_1.Update();
            }
            #endregion
            #region robot2
            if (robot2 != 0)
            {
                Robot robot_2 = robotCache.GetRobot(account_id, robot2);
                if (robot2 == choosed_id)
                {
                    robot_2.exp += exp;
                }
                else
                {
                    robot_2.exp += exp * 4 / 5;
                }
                if (robot_2.exp >= robot_2.lvl * 100)
                {
                    do
                    {
                        robot_2.exp -= robot_2.lvl * 100;
                        robot_2.lvl++;
                    }
                    while (robot_2.exp >= robot_2.lvl * 100);
                }
                robot_2.Update();
            }
            #endregion
            #region robot3
            if (robot3 != 0)
            {
                Robot robot_3 = robotCache.GetRobot(account_id, robot3);
                if (robot3 == choosed_id)
                {
                    robot_3.exp += exp;
                }
                else
                {
                    robot_3.exp += exp * 4 / 5;
                }
                if (robot_3.exp >= robot_3.lvl * 100)
                {
                    do
                    {
                        robot_3.exp -= robot_3.lvl * 100;
                        robot_3.lvl++;
                    }
                    while (robot_3.exp >= robot_3.lvl * 100);
                }
                robot_3.Update();
            }
            #endregion
            #region robot4
            if (robot4 != 0)
            {
                Robot robot_4 = robotCache.GetRobot(account_id, robot4);
                if (robot4 == choosed_id)
                {
                    robot_4.exp += exp;
                }
                else
                {
                    robot_4.exp += exp * 4 / 5;
                }
                if (robot_4.exp >= robot_4.lvl * 100)
                {
                    do
                    {
                        robot_4.exp -= robot_4.lvl * 100;
                        robot_4.lvl++;
                    }
                    while (robot_4.exp >= robot_4.lvl * 100);
                }
                robot_4.Update();
            }
            #endregion
            player.exp += exp;
            if (player.exp >= player.level * 100)
            {
                do
                {
                    player.exp -= player.level * 100;
                    player.level++;
                }
                while (player.exp >= player.level * 100);
            }
            player.Update();
            return 1;
        }

        //使用具体的code给玩家添加战利品机体
        public static Robot RoleAddRewardRobot(int account_id, string key, int code_id)
        {
            if (!Player_key_OK(account_id, key)) return null;

            Robot robot = robotCache.AddRobot(account_id, code_id);

            return robot;
        }

        //增加玩家战利品资源
        public static int RoleAddRewardReseource(int account_id, string key, int ammo, int fuel, int resource, int cristal)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Player player = getplayer(key);

            player.ammo += ammo;
            player.fuel += fuel;
            player.resource += resource;
            player.cristal += cristal;
            player.Update();

            return 1;
        }

        //增加机体经验及升级
        public static int RobotExpAddUp(int account_id, string key, int robot_id, int exp)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Robot robot = robotCache.GetRobot(account_id, robot_id);
            if (robot == null) return -2;

            robot.exp += exp;
            if (robot.exp >= robot.lvl * 100)
            {
                do
                {
                    robot.exp -= robot.lvl * 100;
                    robot.lvl++;
                }
                while (robot.exp < robot.lvl * 100);
            }
            robot.Update();
            return 1;

        }

        //机体损耗:ammo损耗弹药，fuel损耗燃料，hp损耗生命
        public static int RobotRefillChange(int account_id, string key, int robot_id, int ammo, int fuel, int hp)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Robot robot = robotCache.GetRobot(account_id, robot_id);
            if (robot == null) return -2;
            if (robot.ammo == 0 || robot.fuel == 0) return -3;
            if (robot.hp == 0) return -4;
            robot.ammo -= ammo;
            if (robot.ammo < 0)
            {
                robot.ammo = 0;
            }
            robot.fuel -= fuel;
            if (robot.fuel < 0)
            {
                robot.fuel = 0;
            }
            robot.hp -= fuel;
            if (robot.hp < 0)
            {
                robot.hp = 0;
            }
            robot.Update();
            return 1;
        }

        //小队整备
        public static int RobotChange(int account_id, string key, int robot1, int robot2, int robot3, int robot4)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Player player = getplayer(key);
            #region 撤除原有机体
            if (player.robot1 != 0)
            {
                Robot robot_1 = robotCache.GetRobot(account_id, player.robot1);
                robot_1.useable = 0;
                robot_1.Update();
            }
            if (player.robot2 != 0)
            {
                Robot robot_2 = robotCache.GetRobot(account_id, player.robot2);
                robot_2.useable = 0;
                robot_2.Update();
            }
            if (player.robot3 != 0)
            {
                Robot robot_3 = robotCache.GetRobot(account_id, player.robot3);
                robot_3.useable = 0;
                robot_3.Update();
            }
            if (player.robot4 != 0)
            {
                Robot robot_4 = robotCache.GetRobot(account_id, player.robot4);
                robot_4.useable = 0;
                robot_4.Update();
            }
            #endregion
            if (robot1 != 0)
            {
                Robot robot_1 = robotCache.GetRobot(account_id, robot1);
                robot_1.useable = 1;
                robot_1.Update();
            }
            if (robot2 != 0)
            {
                Robot robot_2 = robotCache.GetRobot(account_id, robot2);
                robot_2.useable = 1;
                robot_2.Update();
            }
            if (robot3 != 0)
            {
                Robot robot_3 = robotCache.GetRobot(account_id, robot3);
                robot_3.useable = 1;
                robot_3.Update();
            }
            if (robot4 != 0)
            {
                Robot robot_4 = robotCache.GetRobot(account_id, robot4);
                robot_4.useable = 1;
                robot_4.Update();
            }
            player.robot1 = robot1;
            player.robot2 = robot2;
            player.robot3 = robot3;
            player.robot4 = robot4;
            player.Update();
            return 1;
        }

        //装配切换
        public static int EquipChange(int account_id, string key, int robot_id, int item1, int item2,int item3,int item4)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Robot robot = robotCache.GetRobot(account_id, robot_id);
            if (robot == null) return -2;
            #region 脱去原有装备
            if (robot.item1 != 0 && robot.item1 != -1)
            {
                Item item_1 = itemCache.GetItem(account_id,robot.item1);
                item_1.equiped = 0;
                item_1.Update();
            }
            if (robot.item2 != 0 && robot.item2 != -1)
            {
                Item item_2 = itemCache.GetItem(account_id, robot.item2);
                item_2.equiped = 0;
                item_2.Update();
            }
            if (robot.item3 != 0 && robot.item3 != -1)
            {
                Item item_3 = itemCache.GetItem(account_id, robot.item3);
                item_3.equiped = 0;
                item_3.Update();
            }
            if (robot.item4 != 0 && robot.item4 != -1)
            {
                Item item_4 = itemCache.GetItem(account_id, robot.item4);
                item_4.equiped = 0;
                item_4.Update();
            }
            #endregion
            if (item1 != 0&&item1!=-1)
            {
                Item item_1 = itemCache.GetItem(account_id, item1);
                item_1.equiped = 1;
                item_1.Update();
            }
            if (item2 != 0 && item2 != -1)
            {
                Item item_2 = itemCache.GetItem(account_id, item2);
                item_2.equiped = 1;
                item_2.Update();
            }
            if (item3 != 0 && item3 != -1)
            {
                Item item_3 = itemCache.GetItem(account_id, item3);
                item_3.equiped = 1;
                item_3.Update();
            }
            if (item4 != 0 && item4 != -1)
            {
                Item item_4 = itemCache.GetItem(account_id, item4);
                item_4.equiped = 1;
                item_4.Update();
            }
            robot.item1 = item1;
            robot.item2 = item2;
            robot.item3 = item3;
            robot.item4 = item4;
            robot.Update();
            return 1;
        }

        //修理一个机体
        public static int RobotRepair(int account_id, string key, int robot_id)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Robot robot = robotCache.GetRobot(account_id, robot_id);
            if (robot == null) return -2;
            RobotData robotdata = FinalData.Instance().GetRobot(robot.code_id);
            Player player = getplayer(key);
            int star = robot.code_id % 10000 / 1000;
            float hp_max = robotdata.def;
            float hp_now = robot.hp;
            float hp_per = (hp_max - hp_now) / hp_max;
            int need = (int)(star * 50 * hp_per);
            int ammo_need = robotdata.ammo - robot.ammo;
            int fuel_need = robotdata.fuel - robot.fuel;
            if (player.fuel < need+ fuel_need) return -3;
            if (player.resource < need) return -4;
            if (player.ammo < ammo_need) return -5;
            player.fuel -= need + fuel_need;
            player.resource -= need;
            player.ammo -= ammo_need;
            player.Update();
            robot.fuel = robotdata.fuel;
            robot.ammo = robotdata.ammo;
            robot.hp = robotdata.def;
            robot.Update();
            return 1;
        }

        //用水晶购买物品
        public static int BuyThings(int account_id, string key, int type)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Player player = getplayer(key);
            switch (type)
            {
                case 1:
                    if (player.cristal < 10) return -2;
                    player.cristal -= 10;
                    player.ammo += 5000;
                    player.Update();
                    break;
                case 2:
                    if (player.cristal < 10) return -2;
                    player.cristal -= 10;
                    player.resource += 5000;
                    player.Update();
                    break;
                case 3:
                    if (player.cristal < 10) return -2;
                    player.cristal -= 10;
                    player.fuel += 5000;
                    player.Update();
                    break;
            }
            return 1;
        }

        //购买水晶
        public static int BuyCristal(int account_id, string key, int type)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Player player = getplayer(key);
            switch (type)
            {
                case 1:
                    player.cristal += 5000;
                    player.Update();
                    break;
            }
            return 1;
        }

        //卖出一个物品
        public static int SellItem(int account_id, string key, int item_id)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Item item = itemCache.GetItem(account_id, item_id);
            if (item == null) return -2;
            //211001
            int code = item.type_code;
            int type = code % 100000 / 10000;
            int star = code % 10000 / 1000;
            int ammo = 0;
            int resource = 0;
            int fuel = 0;
            float times = 0;
            switch (star)
            {
                case 1:
                    times = 0.5f;
                    break;
                case 2:
                    times = 0.75f;
                    break;
                case 3:
                    times = 1f;
                    break;
                case 4:
                    times = 1.25f;
                    break;
            }
            switch (type)
            {
                case 1:
                    ammo = 50;
                    resource = 35;
                    fuel = 35;
                    break;
                case 2:
                    ammo = 35;
                    resource = 50;
                    fuel = 35;
                    break;
                case 3:
                    ammo = 35;
                    resource = 35;
                    fuel = 50;
                    break;
                case 4:
                    ammo = 40;
                    resource = 40;
                    fuel = 40;
                    break;
                case 5:
                    ammo = 40;
                    resource = 40;
                    fuel = 40;
                    break;

            }
            Player player = getplayer(key);
            player.ammo += (int)(ammo*times);
            player.resource += (int)(resource * times);
            player.fuel += (int)(fuel * times);
            player.Update();
            itemCache.PlayerItems[account_id].Remove(item_id);
            item.Delete(item_id);
            return 1;

        }

        //增加一个已装备物品
        private static Item Additem_equiped(int account_id, int type_code)
        {
            if (!FinalData.Instance().HasItem(type_code)) return null;
            Item item = itemCache.AddItem_equiped(account_id, type_code);
            return item;
        }
        //增加一个机体
        public static Robot AddRobot(int account_id, string key, int type)
        {
            #region 进行计算
            if (!Player_key_OK(account_id, key)) return null;
            int code_id=0;
            int ammo = 0;
            int resource = 0;
            int fuel = 0;
            Random ran = new Random();
            int star = ran.Next(2, 5);
            //112001
            switch (type)
            {
                case 1:
                    ammo = 100;
                    resource = 70;
                    fuel = 70;
                    code_id = 110001 + star * 1000;
                    break;
                case 2:
                    ammo = 70;
                    resource = 100;
                    fuel = 70;
                    code_id = 120001 + star * 1000;
                    break;
                case 3:
                    ammo = 70;
                    resource = 70;
                    fuel = 100;
                    code_id = 130001 + star * 1000;
                    break;
                case 4:
                    ammo = 80;
                    resource = 80;
                    fuel = 80;
                    int type1 = ran.Next(1, 4);
                    code_id = 100001 + star * 1000+type1*10000;
                    break;
            }
            if (!FinalData.Instance().HasRobot(code_id)) return null;
            Player player = getplayer(key);
            if (player.ammo < ammo || player.resource < resource || player.fuel < fuel) return null;
            player.ammo -= ammo;
            player.resource -= resource;
            player.fuel -= fuel;
            player.Update();
            #endregion
            Robot robot = robotCache.AddRobot(account_id, code_id);
            RobotData data = FinalData.Instance().GetRobot(code_id);
            if (data.item1 != 0 && data.item1 != -1)
            {
                Item item1 = Additem_equiped(account_id, data.item1);
                robot.item1 = item1.id;
                robot.Update();
            }
            else
            {
                robot.item1 = data.item1;
                robot.Update();
            }
            if (data.item2 != 0 && data.item2 != -1)
            {
                Item item2 = Additem_equiped(account_id, data.item2);
                robot.item2 = item2.id;
                robot.Update();
            }
            else
            {
                robot.item2 = data.item2;
                robot.Update();
            }
            if (data.item3 != 0 && data.item3 != -1)
            {
                Item item3 = Additem_equiped(account_id, data.item3);
                robot.item3 = item3.id;
                robot.Update();
            }
            else
            {
                robot.item3 = data.item3;
                robot.Update();
            }
            if (data.item4 != 0 && data.item4 != -1)
            {
                Item item4 = Additem_equiped(account_id, data.item4);
                robot.item4 = item4.id;
                robot.Update();
            }
            else
            {
                robot.item4 = data.item4;
                robot.Update();
            }
            return robot;
        }

        ////删除一个机体
        public static int DelRobot(int account_id, string key, int robot_id)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Robot robot = robotCache.GetRobot(account_id, robot_id);
            if (robot == null) return -2;
            if (robot.item1 != 0 && robot.item1 != -1)
            {
                Item item = itemCache.GetItem(account_id, robot.item1);
                item.equiped = 0;
                item.Update();
            }
            if (robot.item2 != 0 && robot.item2 != -1)
            {
                Item item = itemCache.GetItem(account_id, robot.item2);
                item.equiped = 0;
                item.Update();
            }
            if (robot.item3 != 0 && robot.item3 != -1)
            {
                Item item = itemCache.GetItem(account_id, robot.item3);
                item.equiped = 0;
                item.Update();
            }
            if (robot.item4 != 0 && robot.item4 != -1)
            {
                Item item = itemCache.GetItem(account_id, robot.item4);
                item.equiped = 0;
                item.Update();
            }
            Player player = getplayer(key); 
            if (player.robot1 == robot_id) player.robot1 = 0;
            if (player.robot2 == robot_id) player.robot2 = 0;
            if (player.robot3 == robot_id) player.robot3 = 0;
            if (player.robot4 == robot_id) player.robot4 = 0;
            player.Update();
            robotCache.PlayerRobots[account_id].Remove(robot_id);
            robot.Delete(robot_id);
            return 1;
        }

        //进行强化
        public static int PowerUpRobot(int account_id, string key, int obj_id, int res1_id, int res2_id, int res3_id, int res4_id)
        {
            int exp_f = 0;
            int exp_m = 0;
            int exp_d = 0;
            int up_f = 0;
            int up_m = 0;
            int up_d = 0;
            if (!Player_key_OK(account_id, key)) return -1;
            Robot obj = robotCache.GetRobot(account_id, obj_id);
            if (obj == null) return -2;
            if (res1_id != 0)
            {
                Robot res1 = robotCache.GetRobot(account_id, res1_id);
                RobotData robotdata = FinalData.Instance().GetRobot(res1.code_id);
                if (res1 == null) return -3;
                exp_f += (res1.addition_fire + robotdata.atk);
                exp_m += (res1.addition_move + robotdata.mov);
                exp_d += (res1.addition_def + robotdata.def);
                DelRobot(account_id, key, res1_id);
            }
            if (res2_id != 0)
            {
                Robot res2 = robotCache.GetRobot(account_id, res2_id);
                RobotData robotdata = FinalData.Instance().GetRobot(res2.code_id);
                if (res2 == null) return -3;
                exp_f += (res2.addition_fire + robotdata.atk);
                exp_m += (res2.addition_move + robotdata.mov);
                exp_d += (res2.addition_def + robotdata.def);
                DelRobot(account_id, key, res2_id);
            }
            if (res3_id != 0)
            {
                Robot res3 = robotCache.GetRobot(account_id, res3_id);
                RobotData robotdata = FinalData.Instance().GetRobot(res3.code_id);
                if (res3 == null) return -3;
                exp_f += (res3.addition_fire + robotdata.atk);
                exp_m += (res3.addition_move + robotdata.mov);
                exp_d += (res3.addition_def + robotdata.def);
                DelRobot(account_id, key, res3_id);
            }
            if (res4_id != 0)
            {
                Robot res4 = robotCache.GetRobot(account_id, res4_id);
                RobotData robotdata = FinalData.Instance().GetRobot(res4.code_id);
                if (res4 == null) return -3;
                exp_f += (res4.addition_fire + robotdata.atk);
                exp_m += (res4.addition_move + robotdata.mov);
                exp_d += (res4.addition_def + robotdata.def);
                DelRobot(account_id, key, res4_id);
            }
            int max = (obj.code_id % 10000 / 1000) * 5 + 5;
            up_f = obj.addition_fire + ((obj.addition_fire_exp + exp_f)/100);
            if (up_f >= max)
            {
                obj.addition_fire = max;
            }
            else
            {
                obj.addition_fire = up_f;
            }
            up_m = obj.addition_move + ((obj.addition_move_exp + exp_m) / 100);
            if (up_m >= max)
            {
                obj.addition_move = max;
            }
            else
            {
                obj.addition_move = up_m;
            }
            up_d = obj.addition_def + ((obj.addition_def_exp + exp_d) / 100);
            if (up_d >= max)
            {
                obj.addition_def = max;
            }
            else
            {
                obj.addition_def = up_d;
            }
            obj.addition_fire_exp = (obj.addition_fire_exp+ exp_f) % 100;
            obj.addition_move_exp =(obj.addition_move_exp+ exp_m) % 100;
            obj.addition_def_exp =(obj.addition_def_exp+ exp_d) % 100;
            obj.Update();
            return 1;           
        }
        //卖出一个机体
        public static int SellRobot(int account_id, string key, int robot_id)
        {
            if (!Player_key_OK(account_id, key)) return -1;
            Robot robot = robotCache.GetRobot(account_id, robot_id);
            if (robot == null) return -2;
            //211001
            int code = robot.code_id;
            int type = code % 100000 / 10000;
            int star = code % 10000 / 1000;
            int ammo = 0;
            int resource = 0;
            int fuel = 0;
            float times = 0;
            switch (star)
            {
                case 1:
                    times = 0.5f;
                    break;
                case 2:
                    times = 0.75f;
                    break;
                case 3:
                    times = 1f;
                    break;
                case 4:
                    times = 1.25f;
                    break;
            }
            switch (type)
            {
                case 1:
                    ammo = 100;
                    resource = 70;
                    fuel = 70;
                    break;
                case 2:
                    ammo = 70;
                    resource = 100;
                    fuel = 70;
                    break;
                case 3:
                    ammo = 70;
                    resource = 70;
                    fuel = 100;
                    break;
            }
            Player player = getplayer(key);
            player.ammo += (int)(ammo * times);
            player.resource += (int)(resource * times);
            player.fuel += (int)(fuel * times);
            player.Update();
            if (robot.item1 != 0 && robot.item1 != -1)
            {
                Item item = itemCache.GetItem(account_id, robot.item1);
                item.equiped = 0;
                item.Update();
            }
            if (robot.item2 != 0 && robot.item2 != -1)
            {
                Item item = itemCache.GetItem(account_id, robot.item2);
                item.equiped = 0;
                item.Update();
            }
            if (robot.item3 != 0 && robot.item3 != -1)
            {
                Item item = itemCache.GetItem(account_id, robot.item3);
                item.equiped = 0;
                item.Update();
            }
            if (robot.item4 != 0 && robot.item4 != -1)
            {
                Item item = itemCache.GetItem(account_id, robot.item4);
                item.equiped = 0;
                item.Update();
            }
            if (player.robot1 == robot_id) player.robot1 = 0;
            if (player.robot2 == robot_id) player.robot2 = 0;
            if (player.robot3 == robot_id) player.robot3 = 0;
            if (player.robot4 == robot_id) player.robot4 = 0;
            player.Update();
            robotCache.PlayerRobots[account_id].Remove(robot_id);
            robot.Delete(robot_id);            
            return 1;
        }

        //获取角色的机体列表
        public static Robot[] GetRobotsList(int account_id, string key)
        {
            if (Player_key_OK(account_id, key))
            {
                return robotCache.GetList(account_id);
            }
            return null;
        }

        //获取角色的物品列表
        public static Item[] GetItemList(int account_id, string key)
        {
            if (Player_key_OK(account_id, key))
            {
                return itemCache.GetList(account_id);
            }
            return null;
        }
        //获取角色昵称
        public static bool getname(string name)
        {
            Player player = new Player();
            if (player.GetName(name)) return false;
            return true;
        }

        //进行玩家角色创建
        public static Player createplayer(string key, string name, int type)
        {
            if (!session.ContainsKey(key)) return null;
            Player player = playerCache.createPlayer(session[key], name, type);
            return player;

        }

        //获取玩家角色
        public static Player getplayer(string key)
        {
            if (session.ContainsKey(key))
            {
                return playerCache.getPlayer(session[key]);
            }
            return null;
        }
        //进行登陆
        public static string login(string account, string password)
        {
            Account acc = getAccount(account);
            if (acc == null) return "-1";
            if (!acc.password.Equals(password)) return "-2";
            //登陆时后登陆将取代先登录
            if (session1.ContainsKey(acc.id))
            {
                session.Remove(session1[acc.id]);
                session1.Remove(acc.id);
            }
            string key = Guid.NewGuid().ToString();
            session1.Add(acc.id, key);
            session.Add(key, acc.id);
            return key;
        }

    }
}