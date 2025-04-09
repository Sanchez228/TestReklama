using Xunit;
using System.Collections.Generic;
using global::TestReklama.Services;

namespace TestReklama.Tests
{
    public class AdPlatformServiceTests
    {
        [Fact]
        public void FindPlatforms_ShouldReturnCorrectPlatforms()
        {
            // Arrange
            var service = new AdPlatformService();
            var data = new[]
            {
                "Яндекс.Директ:/ru",
                "Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik",
                "Газета уральских москвичей:/ru/msk,/ru/permobl,/ru/chelobl",
                "Крутая реклама:/ru/svrd"
            };

            service.LoadFromFile(data);

            // Act
            var result = service.FindPlatforms("/ru/svrd/revda");

            // Assert
            Assert.Contains("Яндекс.Директ", result);
            Assert.Contains("Ревдинский рабочий", result);
            Assert.Contains("Крутая реклама", result);
            Assert.DoesNotContain("Газета уральских москвичей", result);
        }
    }
}