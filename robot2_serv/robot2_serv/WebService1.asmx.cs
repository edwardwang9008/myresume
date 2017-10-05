using robot2;
using robot2_serv.src_cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace robot2_serv
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod (Description ="注册账号")]
        public bool register(string account, string password)
        {
            return DataCache.register(account, password);
        }

        [WebMethod(Description = "登陆账号")]
        public string login(string account, string password)
        {
            return DataCache.login(account, password);
        }

        [WebMethod(Description = "获取玩家角色")]
        public Player getplayer(string key)
        {
            return DataCache.getplayer(key);
        }

        [WebMethod(Description = "创建玩家角色")]
        public Player createplayer(string key,string name,int type)
        {
            return DataCache.createplayer(key, name, type);
        }
        [WebMethod(Description = "获取已有昵称")]
        public bool getname(string name)
        {
            return DataCache.getname(name);
        }

        [WebMethod(Description = "获取物品列表")]
        public Item[] GetItems(int account_id,string key)
        {
            getData();
            return DataCache.GetItemList(account_id, key);
        }

        [WebMethod(Description = "获取机体列表")]
        public Robot[] GetRobots(int account_id, string key)
        {
            getData();
            return DataCache.GetRobotsList(account_id, key);
        }

        [WebMethod(Description = "增加一个物品")]
        public Item AddItem(int account_id, string key, int type)
        {
            getData();
            return DataCache.Additem(account_id, key,type);
        }

        [WebMethod(Description = "增加一个机体")]
        public Robot AddRobot(int account_id, string key, int type)
        {
            getData();
            return DataCache.AddRobot(account_id, key, type);
        }

        [WebMethod(Description = "卖出一个物品")]
        public int SellItem(int account_id, string key, int item_id)
        {
            getData();
            return DataCache.SellItem(account_id, key, item_id);
        }

        [WebMethod(Description = "卖出一个机体")]
        public int SellRobot(int account_id, string key, int robot_id)
        {
            getData();
            return DataCache.SellRobot(account_id, key, robot_id);
        }

        [WebMethod(Description = "强化机体")]
        public int PowerUpRobot(int account_id, string key, int obj_id, int res1_id, int res2_id, int res3_id, int res4_id)
        {
            getData();
            return DataCache.PowerUpRobot(account_id, key, obj_id, res1_id, res2_id, res3_id, res4_id);
        }
        [WebMethod(Description = "商城购买")]
        public int BuyThings(int account_id, string key, int type)
        {
            getData();
            return DataCache.BuyThings(account_id, key, type);
        }
        [WebMethod(Description = "购买水晶")]
        public int BuyCristal(int account_id, string key, int type)
        {
            getData();
            return DataCache.BuyCristal(account_id, key, type);
        }
        [WebMethod(Description = "修理机体")]
        public int RobotRepair(int account_id, string key, int robot_id)
        {
            getData();
            return DataCache.RobotRepair(account_id, key, robot_id);
        }

        [WebMethod(Description = "更换配件")]
        public int EquipChange(int account_id, string key, int robot_id, int item1, int item2, int item3,int item4)
        {
            getData();
            return DataCache.EquipChange(account_id, key, robot_id, item1, item2, item3, item4);
        }

        [WebMethod(Description = "小队整备")]
        public int RobotChange(int account_id, string key, int robot1, int robot2, int robot3, int robot4)
        {
            getData();
            return DataCache.RobotChange(account_id, key, robot1, robot2, robot3, robot4);
        }
        [WebMethod(Description = "机体补给变更")]
        public int RobotRefillChange(int account_id, string key, int robot_id, int ammo, int fuel, int hp)
        {
            getData();
            return DataCache.RobotRefillChange(account_id, key, robot_id, ammo, fuel, hp);
        }
        [WebMethod(Description = "机体经验值增加")]
        public int RobotExpAddUp(int account_id, string key, int robot_id, int exp)
        {
            getData();
            return DataCache.RobotExpAddUp(account_id, key, robot_id, exp);
        }
        [WebMethod(Description = "角色经验值增加")]
        public int RoleExpAddUp(int account_id, string key, int exp)
        {
            getData();
            return DataCache.RoleExpAddUp(account_id, key, exp);
        }
        [WebMethod(Description = "增加战利品资源")]
        public int RoleAddRewardReseource(int account_id, string key, int ammo, int fuel, int resource, int cristal)
        {
            getData();
            return DataCache.RoleAddRewardReseource(account_id, key, ammo, fuel, resource, cristal);          
        }
        [WebMethod(Description = "增加战利品装备")]
        public Item RoleAddRewardItem(int account_id, string key, int type_code)
        {
            getData();
            return DataCache.RoleAddRewardItem(account_id, key, type_code);
        }
        [WebMethod(Description = "增加战利品机体")]
        public Robot RoleAddRewardRobot(int account_id, string key, int code_id)
        {
            getData();
            return DataCache.RoleAddRewardRobot(account_id, key, code_id);
        }
        [WebMethod(Description = "战役开始")]
        public int BattleStart(int account_id, string key, int robot1,int robot2,int robot3,int robot4,int choosed_id)
        {
            getData();
            return DataCache.BattleStart(account_id, key, robot1, robot2, robot3, robot4, choosed_id);
        }
        [WebMethod(Description = "战役胜利")]
        public int BattleWin(int account_id, string key, int robot1, int robot2, int robot3, int robot4, int choosed_id,int lvl_num)
        {
            getData();
            return DataCache.BattleWin(account_id, key, robot1, robot2, robot3, robot4, choosed_id, lvl_num);
        }
        public FinalData getData()
        {
            return FinalData.Instance(Server.MapPath(""));
        }
    }
}
