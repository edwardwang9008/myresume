using robot2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot2_serv.src_cache
{
    public class PlayerCache
    {
        public Dictionary<int, Player> playerMap = new Dictionary<int, Player>();
        public Player getPlayer(int account_id)
        {
            
            if (!playerMap.ContainsKey(account_id))
            {
                Player player = new Player();
                if (player.GetModel(account_id))
                {
                    playerMap.Add(account_id, player);
                }   

            }
            if (playerMap.ContainsKey(account_id))
            {
                playerMap[account_id].GetModel(account_id);
                return playerMap[account_id];
            }
            return null;
        }
        public Player createPlayer(int account_id, string name, int type)
        {
            Player player = getPlayer(account_id);
            if (player != null) return null;
            player = new Player();
            player.account_id = account_id;
            player.name = name;
            player.type = type;
            player.level = 1;
            player.ammo = 300;
            player.resource = 300;
            player.fuel = 300;
            player.Add();
            playerMap.Add(account_id, player);
            return player;
        }


    }
}