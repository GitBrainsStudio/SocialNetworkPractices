using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DAL.Entities
{
    public class FriendEntity
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int friend_id { get; set; }
    }
}
