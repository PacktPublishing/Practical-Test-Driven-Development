using SpeakerMeet.Services.Tests.Fakes;
using Xunit;

namespace SpeakerMeet.Services.Tests.SpeakerServiceTests
{
    public class Class
    {
        [Fact]
        public void ItAcceptsIRepository()
        {
            // Arrange
            var fakeRepository = new FakeRepository();

            // Act
            var service = new SpeakerService(fakeRepository);

            // Assert
            Assert.NotNull(service);
        }
    }
}
