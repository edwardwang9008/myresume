using robot2_serv.tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace robot2_serv.src_cache
{
    public class FinalData
    {
        private static FinalData data;
        private Dictionary<int, RobotData> robots = new Dictionary<int, RobotData>();
        private Dictionary<int, ItemData> items = new Dictionary<int, ItemData>();


        private static string pathURL;

        public static FinalData Instance(string path)
        {
            pathURL = path;
            return Instance();
        }
        public static FinalData Instance()
        {
            if (data == null)
            {
                data = new FinalData(pathURL);
            }
            return data;
        }

        FinalData(string path)
        {
            pathURL = path;
            InitRobotData();
            InitItemData();
        }
        /// <summary>
        /// 装备数据模型的初始化
        /// </summary>
        private void InitItemData()
        {
            using (FileStream fs = new FileStream(pathURL + "/data/item.json", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string result = sr.ReadToEnd();
                    ItemData[] datas = LitJson.JsonMapper.ToObject<ItemData[]>(result);
                    foreach (ItemData data in datas)
                    {
                        items.Add(data.type_code, data);
                    }
                }
            }
        }
        /// <summary>
        /// 查询物品数据是否存在
        /// </summary>
        /// <param name="type_code"></param>
        /// <returns></returns>
        public bool HasItem(int type_code)
        {
            return items.ContainsKey(type_code);
        }

        /// <summary>
        /// 获取一个物品的物品对象
        /// </summary>
        /// <returns></returns>
        public ItemData GetItem(int type_code)
        {
            if (HasItem(type_code))
                return items[type_code];
            return null;
        }


        /// <summary>
        /// 机体数据模型的初始化
        /// </summary>
        private void InitRobotData()
        {
            using (FileStream fs = new FileStream(pathURL + "/data/robot.json", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string result = sr.ReadToEnd();
                    RobotData[] datas = LitJson.JsonMapper.ToObject<RobotData[]>(result);
                    foreach (RobotData data in datas)
                    {
                        robots.Add(data.code_id, data);
                    }
                }
            }
        }
        /// <summary>
        /// 查询机体数据是否存在
        /// </summary>
        /// <param name="code_id"></param>
        /// <returns></returns>
        public bool HasRobot(int code_id)
        {
            return robots.ContainsKey(code_id);
        }

        /// <summary>
        /// 获取一个机体的机体对象
        /// </summary>
        /// <returns></returns>
        public RobotData GetRobot(int code_id)
        {
            if (HasRobot(code_id))
                return robots[code_id];
            return null;
        }
    }
}