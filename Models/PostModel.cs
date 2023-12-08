namespace TigerPadG4.Models
{ 
    using System.Collections;
    using System.Collections.Generic;

    public class PostModel : IEnumerable<PostModel>
    {
        public string ProfilePhoto { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string PostContent { get; set; }


        public IEnumerator<PostModel> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
