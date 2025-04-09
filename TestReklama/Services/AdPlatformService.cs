using TestReklama.Models;
namespace TestReklama.Services
{
    public class AdPlatformService
    {
        private List<AdvertisingPlatform> _platforms = new();

        public void LoadFromFile(string[] lines)
        {
            var newList = new List<AdvertisingPlatform>();
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length != 2) continue;

                var name = parts[0].Trim();
                var locations = parts[1].Split(',')
                    .Select(l => l.Trim())
                    .Where(l => l.StartsWith("/"))
                    .ToList();

                newList.Add(new AdvertisingPlatform { Name = name, Locations = locations });
            }
            _platforms = newList;
        }

        public List<string> FindPlatforms(string location)
        {
            var result = new List<string>();
            foreach (var platform in _platforms)
            {
                foreach (var loc in platform.Locations)
                {
                    if (location.StartsWith(loc))
                    {
                        result.Add(platform.Name);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
