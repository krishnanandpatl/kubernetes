using Microsoft.EntityFrameworkCore;
using platformservice.Models;

namespace platformservice.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _appDbContext;

        public PlatformRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _appDbContext.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatform()
        {
            return _appDbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int Id)
        {
            return _appDbContext.Platforms.FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChanges()
        {
            return (_appDbContext.SaveChanges() >= 0);
        }
    }
}