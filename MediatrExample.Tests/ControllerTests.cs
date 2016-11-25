using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Practices.Unity;
using MediatrExample.Queries;
using MediatrExample.Commands;

namespace MediatrExample.Tests
{
    public class ControllerTests
    {
        public class TheGetMethod
        {
            [Fact]
            public void Succeed_With_Valid_Input_Positive()
            {
                //Arrange
                var container = BootstrapApplication.Init();
                var query = new PositiveNumberQueryRequest(true);
                var sut = new Controller(container.Resolve<IMediator>());

                //Act
                var result = sut.Get(query);

                //Assert
                Assert.True(result.Number > 0);
            }

            [Fact]
            public void Succeed_With_Valid_Input_Negative()
            {
                //Arrange
                var container = BootstrapApplication.Init();
                var query = new PositiveNumberQueryRequest(false);
                var sut = new Controller(container.Resolve<IMediator>());

                //Act
                var result = sut.Get(query);

                //Assert
                Assert.True(result.Number < 0);
            }
        }

        public class ThePostMethod
        {
            [Fact]
            public void Does_Not_Throw()
            {
                //Arrange
                var container = BootstrapApplication.Init();
                var command = new CauseExceptionCommandRequest(false);
                var sut = new Controller(container.Resolve<IMediator>());

                //Act
                sut.Post(command);

                //Assert we didn't throw
            }

            [Fact]
            public void Does_Throw()
            {
                //Arrange
                var container = BootstrapApplication.Init();
                var command = new CauseExceptionCommandRequest(true);
                var sut = new Controller(container.Resolve<IMediator>());

                //Assert
                Assert.Throws<Exception>(() =>
                {
                    //Act
                    sut.Post(command);
                });
            }
        }
    }
}
