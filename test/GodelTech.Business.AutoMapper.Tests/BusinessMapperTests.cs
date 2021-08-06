using AutoMapper;
using GodelTech.Business.AutoMapper.Tests.Fakes;
using Moq;
using Xunit;

namespace GodelTech.Business.AutoMapper.Tests
{
    public class BusinessMapperTests
    {
        private readonly Mock<IMapper> _mockMapper;

        private readonly BusinessMapper _businessMapper;

        public BusinessMapperTests()
        {
            _mockMapper = new Mock<IMapper>(MockBehavior.Strict);

            _businessMapper = new BusinessMapper(_mockMapper.Object);
        }

        [Fact]
        public void Constructor()
        {
            // Arrange & Act & Assert
            Assert.IsAssignableFrom<IBusinessMapper>(_businessMapper);
        }

        [Fact]
        public void Map_Success()
        {
            // Arrange
            var source = new FakeSource();
            var destination = new FakeDestination();

            _mockMapper
                .Setup(
                    x => x.Map<FakeSource, FakeDestination>(
                        source
                    )
                )
                .Returns(destination);

            // Act
            var result = _businessMapper
                .Map<FakeSource, FakeDestination>(source);

            // Assert
            _mockMapper
                .Verify(
                    x => x.Map<FakeSource, FakeDestination>(
                        source
                    ),
                    Times.Once
                );

            Assert.Equal(destination, result);
        }

        [Fact]
        public void Map_WithDestination_Success()
        {
            // Arrange
            var source = new FakeSource();
            var destination = new FakeDestination();

            _mockMapper
                .Setup(
                    x => x.Map(
                        source,
                        destination
                    )
                )
                .Returns(destination);

            // Act
            var result = _businessMapper
                .Map(source, destination);

            // Assert
            _mockMapper
                .Verify(
                    x => x.Map(
                        source,
                        destination
                    ),
                    Times.Once
                );

            Assert.Equal(destination, result);
        }
    }
}
