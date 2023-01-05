using Microsoft.AspNetCore.Mvc;

namespace Granito.Calculo.Api.Controllers.Tests
{
    public class ShowMeTheCodeTests
    {
        [Fact()]
        public void Get_ShowMeTheCode_Should_Return_200OK_And_LinkGitHub()
        {
            // Arrange

            var controller = new ShowMeTheCodeController();

            // Act

            var result = controller.GetGitHubLink();

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);

            var value = Assert.IsType<string>(okResult.Value);

            Assert.NotNull(value);
            Assert.NotEmpty(value);
            Assert.Equal("https://github.com/leonardo-linqcode/Granito", value);
        }
    }
}