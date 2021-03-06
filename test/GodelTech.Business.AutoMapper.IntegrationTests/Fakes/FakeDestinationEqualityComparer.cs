using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GodelTech.Business.AutoMapper.IntegrationTests.Fakes
{
    public class FakeDestinationEqualityComparer : IEqualityComparer<FakeDestination>
    {
        public bool Equals(FakeDestination x, FakeDestination y)
        {
            // Check whether the compared objects reference the same data
            if (ReferenceEquals(x, y)) return true;

            // Check whether any of the compared objects is null
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

            // Check whether the objects' properties are equal.
            return x.Id == y.Id
                   && x.Name == y.Name
                   && x.DestinationName == y.DestinationName;
        }

        public int GetHashCode([DisallowNull] FakeDestination obj)
        {
            // Check whether the object is null
            if (ReferenceEquals(obj, null)) return 0;

            // Calculate the hash code for the object.
            return obj.Id.GetHashCode()
                   ^ obj.Name.GetHashCode(StringComparison.InvariantCulture)
                   ^ obj.DestinationName.GetHashCode(StringComparison.InvariantCulture);
        }
    }
}
