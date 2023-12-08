using TigerPadG4.Data;

namespace TigerPadG4.ViewModel
{
    public class UserHomepageViewModel
    {
        public IEnumerable<UserPosts> UserPosts { get; set; }
        public UserProfile UserProfile { get; set; }
        public QOTD QOTD { get; set; }

    }
}
