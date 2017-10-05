using robot2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot2_serv.src_cache
{
    public class ItemCache
    {

       public Dictionary<int, Dictionary<int, Item>> PlayerItems = new Dictionary<int, Dictionary<int, Item>>();
        public Item AddItem(int account_id, int type_code)
        {
            InitCache(account_id);
            Item item = new Item();
            item.account_id = account_id;
            item.type_code = type_code;
            item.equiped = 0;
            item.Add();
            int id = item.id;            
            PlayerItems[account_id].Add(id,item);
            return item;
        }

        public Item AddItem_equiped(int account_id, int type_code)
        {
            InitCache(account_id);
            Item item = new Item();
            item.account_id = account_id;
            item.type_code = type_code;
            item.equiped = 1;
            item.Add();
            int id = item.id;
            PlayerItems[account_id].Add(id, item);
            return item;
        }

        public Item[] GetList(int account_id)
        {
            InitCache(account_id);
            return PlayerItems[account_id].Values.ToArray<Item>();
        }

        private void InitCache(int account_id)
        {
            if (PlayerItems.ContainsKey(account_id)) return;
            Item[] items = Item.GetList(account_id);
            Dictionary<int, Item> map = new Dictionary<int, Item>();
            foreach (Item item in items)
            {
                map.Add(item.id, item);
            }
            PlayerItems.Add(account_id, map);
        }

        public Item GetItem(int account_id, int item_id)
        {
            InitCache(account_id);
            if (!PlayerItems[account_id].ContainsKey(item_id))
            {
                Item item = new Item();
                item = item.confirm_key(item_id);
                if (item != null)
                {
                    PlayerItems[account_id].Add(item_id, item);
                }

            }
            PlayerItems[account_id][item_id].GetModel(item_id);
            return PlayerItems[account_id][item_id];


        }
    }
}