//using System.Linq;
using TigerPadG4.Models;

namespace TigerPadG4.Services
{
    public class UserProfileService
    {
        private readonly UserContext _context;

        public UserProfileService(UserContext context)
        {
            _context = context;
        }

        public UserProfile GetUserProfile(int id)
        {
            return _context.UserProfiles.FirstOrDefault(u => u.Id == id);
        }
    }
}
