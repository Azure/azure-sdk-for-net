// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    internal class AvailabilitySetDataComparer : IComparer<AvailabilitySetData>, IEqualityComparer<AvailabilitySetData>
    {
        public int Compare(AvailabilitySetData? x, AvailabilitySetData? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            else
            {
                if (x.PlatformUpdateDomainCount > y.PlatformUpdateDomainCount)
                {
                    return 1;
                }
                else if (x.PlatformUpdateDomainCount < y.PlatformUpdateDomainCount)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool Equals(AvailabilitySetData? x, AvailabilitySetData? y)
        {
            if (x is null)
                return y is null;

            if (y is null)
                return false;

            return x.PlatformUpdateDomainCount == y.PlatformUpdateDomainCount;
        }

        public int GetHashCode([DisallowNull] AvailabilitySetData obj)
        {
            return obj.PlatformUpdateDomainCount.GetHashCode();
        }
    }
}
