using dotnetwebsitebackend.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace api.tests
{
    public class HomeControllerUnitTests
    {
        [Fact]
        public void Index_ReturnsVirtualFileResult_WithIndexFile()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as VirtualFileResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("text/html", result.ContentType);
            Assert.Equal("~/index.html", result.FileName);
        }
    }
}
