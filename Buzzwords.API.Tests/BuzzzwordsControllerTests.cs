using Buzzwords.API.Controllers;
using Buzzwords.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace Buzzwords.API.Tests
{
    public class BuzzzwordsControllerTests
    {
        private readonly Mock<IBuzzwordsListService> _buzzListServiceMock;
        private readonly BuzzwordsController _buzzwordsController;

        public BuzzzwordsControllerTests()
        {
            _buzzListServiceMock = new Mock<IBuzzwordsListService>();
            _buzzwordsController = new BuzzwordsController(_buzzListServiceMock.Object);

        }

        [Fact]
        public void BuzzwordsController_StartIndex_Invalid_Throws_Exception()
        {
            //Arrange
            var startIndex = -1;
            var endIndex = 10;
            var index = 5;

            //Act
            var result = _buzzwordsController.GetBuzzword(startIndex, endIndex, index);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }

        [Fact]
        public void BuzzwordsController_EndIndex_Invalid_Throws_Exception()
        {
            //Arrange
            var startIndex = 1;
            var endIndex = -1;
            var index = 5;

            //Act
            var result = _buzzwordsController.GetBuzzword(startIndex, endIndex, index);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }

        [Fact]
        public void BuzzwordsController_StartIndex_EndIndex_Same_Throws_Exception()
        {
            //Arrange
            var startIndex = 10;
            var endIndex = 10;
            var index = 5;

            //Act
            var result = _buzzwordsController.GetBuzzword(startIndex, endIndex, index);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }

        [Fact]
        public void BuzzwordsController_EndIndex_LessThan_StartIndex_Throws_Exception()
        {
            //Arrange
            var startIndex = 10;
            var endIndex = 0;
            var index = 5;

            //Act
            var result = _buzzwordsController.GetBuzzword(startIndex, endIndex, index);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }

        [Fact]
        public void BuzzwordsController_Index_Out_Of_Range_Throws_Exception()
        {
            //Arrange
            var startIndex = 1;
            var endIndex = 10;
            var index = 15;

            //Act
            var result = _buzzwordsController.GetBuzzword(startIndex, endIndex, index);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }

        [Fact]
        public void BuzzwordsController_ReturnsSuccess()
        {
            //Arrange
            var startIndex = 1;
            var endIndex = 10;
            var index = 5;

            _buzzListServiceMock.Setup(x => x.GetValue(startIndex, endIndex, index)).Returns(5);

            //Act
            var result = _buzzwordsController.GetBuzzword(startIndex, endIndex, index);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var value = ((OkObjectResult)result.Result).Value;

            Assert.Equal(5, value);

        }
    }
}
