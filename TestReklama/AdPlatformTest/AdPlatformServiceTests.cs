using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestReklama.Services;
using Xunit;

public class AdPlatformServiceTests
{
    [Fact]
    public void TestFindPlatforms()
    {
        var service = new AdPlatformService();
        var data = new[]
        {
            "Яндекс.Директ:/ru",
            "Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik",
            "Крутая реклама:/ru/svrd"
        };

        service.LoadFromFile(data);
        var result = service.FindPlatforms("/ru/svrd/revda");

        Assert.Contains("Яндекс.Директ", result);
        Assert.Contains("Ревдинский рабочий", result);
        Assert.Contains("Крутая реклама", result);
    }
}