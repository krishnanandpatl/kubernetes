using platformservice.Models;

namespace platformservice.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatform();
        Platform GetPlatformById(int Id);
        void CreatePlatform(Platform platform);
    }
}