using robot2;
using robot2_serv.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot2_serv.src_cache
{
    public class RobotCache
    {
        public Dictionary<int, Dictionary<int, Robot>> PlayerRobots = new Dictionary<int, Dictionary<int, Robot>>();
        public Robot AddRobot(int account_id, int code_id)
        {
            InitCache(account_id);
            RobotData robotdata = FinalData.Instance().GetRobot(code_id);
            Robot robot = new Robot();
            robot.account_id = account_id;
            robot.code_id = code_id;
            robot.lvl = 1;
            robot.hp = robotdata.def;
            ////原始装备1号
            //if (robotdata.item1 != 0 && robotdata.item1 != -1)
            //{
            //    Item i = itemCache.AddItem_equiped(account_id, robotdata.item1);
            //    robot.item1 = i.id;
            //}
            //else
            //{
            //    robot.item1 = robotdata.item1;
            //}
            ////原始装备2号
            //if (robotdata.item2 != 0 && robotdata.item2 != -1)
            //{
            //    Item i = itemCache.AddItem_equiped(account_id, robotdata.item2);
            //    robot.item2 = i.id;
                
            //}
            //else
            //{
            //    robot.item2 = robotdata.item2;
            //}
            ////原始装备3号
            //if (robotdata.item3 != 0 && robotdata.item3 != -1)
            //{
            //   Item i = itemCache.AddItem_equiped(account_id, robotdata.item3);
            //    robot.item3 = i.id;
               
            //}
            //else
            //{
            //    robot.item3 = robotdata.item3;
            //}
            ////原始装备4号
            //if (robotdata.item4 != 0 && robotdata.item4 != -1)
            //{
            //    Item i = itemCache.AddItem_equiped(account_id, robotdata.item4);
            //    robot.item4 = i.id;
            //}
            //else
            //{
            //    robot.item4 = robotdata.item4;
            //}
            robot.Add();
            int id = robot.id;
            PlayerRobots[account_id].Add(id, robot);
            return robot;
        }

        public Robot[] GetList(int account_id)
        {
            InitCache(account_id);
            return PlayerRobots[account_id].Values.ToArray<Robot>();
        }

        private void InitCache(int account_id)
        {
            if (PlayerRobots.ContainsKey(account_id))
                return;
            Robot[] robots = Robot.GetList(account_id);
            Dictionary<int, Robot> map = new Dictionary<int, Robot>();
            foreach (Robot robot in robots)
            {
                map.Add(robot.id, robot);
            }
            PlayerRobots.Add(account_id, map);
        }

        public Robot GetRobot(int account_id, int roobot_id)
        {
            InitCache(account_id);
            return PlayerRobots[account_id][roobot_id];
        }
    }
}