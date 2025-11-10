using DigitalLibrary.WebApi.Dtos;
using DigitalLibrary.WebApi.Models;
using DigitalLibrary.WebApi.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;

namespace DigitalLibrary.WebApi.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DigitalLibraryAppDbContext  _context;
        private readonly UserManager<IdentityUser> _userManager;
        public UserRepository(DigitalLibraryAppDbContext context, UserManager<IdentityUser> userManager) 
        {
            _context = context;
            _userManager = userManager;
        }
        public Task<IdentityResult> AddUser(RegisterRequetDto request)
        {
            var user = new IdentityUser
            {
                UserName = request.email,
                Email = request.email
            };

            var result = await _userManager.CreateAsync(user, model.password);
        }
    }
}
