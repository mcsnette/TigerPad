namespace TigerPadG4.Data
{
    using System.Collections;
    using System.Collections.Generic;

    public class UserPosts
    {
        public int Id { get; set; } 

        /*public string ProfilePhoto { get; set; }*/

        public string Name { get; set; }
        public string Username { get; set; }
        public string PostContent { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsInquiry { get; set; } 

    }

}
