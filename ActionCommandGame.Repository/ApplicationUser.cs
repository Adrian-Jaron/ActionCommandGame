using Microsoft.AspNetCore.Identity;
using System.Numerics;
using ActionCommandGame.Model;

namespace ActionCommandGame.Model
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Player> Players { get; set; } = new List<Player>();
    }
}