using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepo
{
    bool SaveChanges();

    IEnumerable<Platform> GetAllPlarforms();
    Platform GetPlatformById(int id);
    void CreatePlatform(Platform plat);
    
}