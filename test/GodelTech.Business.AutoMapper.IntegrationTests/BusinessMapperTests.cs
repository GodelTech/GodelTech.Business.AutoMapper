using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GodelTech.Business.AutoMapper.IntegrationTests.Fakes;
using AutoMapper;
using Xunit;

namespace GodelTech.Business.AutoMapper.IntegrationTests
{
    public class BusinessMapperTests
    {
        private readonly BusinessMapper _businessMapper;

        public BusinessMapperTests()
        {
            var mapper = new MapperConfiguration(
                cfg => cfg.CreateMap<FakeSource, FakeDestination>()
                )
                .CreateMapper();

            _businessMapper = new BusinessMapper(mapper);
        }

        public static IEnumerable<object[]> MapMemberData =>
            new Collection<object[]>
            {
                new object[] 
                {
                    new FakeSource(),
                    new FakeDestination()
                },
                new object[]
                {
                    new FakeSource
                    {
                        Id = 1,
                        Name = "Test Name",
                        SourceName = "Test SourceName"
                    },
                    new FakeDestination
                    {
                        Id = 1,
                        Name = "Test Name",
                        DestinationName = null
                    }
                }
            };

        [Theory]
        [MemberData(nameof(MapMemberData))]
        public void Map_Success(
            FakeSource source,
            FakeDestination expectedResult)
        {
            // Arrange & Act
            var result = _businessMapper
                .Map<FakeSource, FakeDestination>(source);

            // Assert
            Assert.Equal(expectedResult, result, new FakeDestinationEqualityComparer());
        }

        public static IEnumerable<object[]> MapWithDestinationMemberData =>
            new Collection<object[]>
            {
                new object[]
                {
                    new FakeSource(),
                    new FakeDestination(),
                    new FakeDestination()
                },
                new object[]
                {
                    new FakeSource(),
                    new FakeDestination
                    {
                        Id = 1,
                        Name = "Test Name",
                        DestinationName = "Test DestinationName"
                    },
                    new FakeDestination
                    {
                        Id = 0,
                        Name = null,
                        DestinationName = "Test DestinationName"
                    },
                },
                new object[]
                {
                    new FakeSource
                    {
                        Id = 2,
                        Name = "Test Name New",
                        SourceName = "Test SourceName"
                    },
                    new FakeDestination
                    {
                        Id = 1,
                        Name = "Test Name Current",
                        DestinationName = "Test DestinationName"
                    },
                    new FakeDestination
                    {
                        Id = 2,
                        Name = "Test Name New",
                        DestinationName = "Test DestinationName"
                    }
                }
            };

        [Theory]
        [MemberData(nameof(MapWithDestinationMemberData))]
        public void Map_WithDestination_Success(
            FakeSource source,
            FakeDestination destination,
            FakeDestination expectedResult)
        {
            // Arrange & Act
            var result = _businessMapper
                .Map(source, destination);

            // Assert
            Assert.Equal(expectedResult, result, new FakeDestinationEqualityComparer());
        }
    }
}