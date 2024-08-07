// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests
{
    public class SapInstanceDataComparer : IEqualityComparer<SapInstanceData>
    {
        public bool Equals(SapInstanceData x, SapInstanceData y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y))
                return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the discoverySite properties are equal.
            return x.Location == y.Location
                && x.LandscapeSid == y.LandscapeSid
                && x.Name == y.Name
                && x.SystemSid == y.SystemSid
                && x.ProvisioningState == y.ProvisioningState
                && x.Environment == y.Environment;
        }

        public int GetHashCode(SapInstanceData instanceData)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(instanceData, null))
                return 0;

            int hashName = instanceData.Name == null ? 0 : instanceData.Name.GetHashCode();
            int hashLocation = instanceData.Location.GetHashCode();
            int hashLandscapeSid = instanceData.LandscapeSid.GetHashCode();
            int hashProvisioningState = instanceData.ProvisioningState == null ? 0
                : instanceData.ProvisioningState.GetHashCode();
            int hashSystemSid = instanceData.SystemSid.GetHashCode();
            int hashEnvironment = instanceData.Environment.GetHashCode();

            return hashName
                   ^ hashLocation
                   ^ hashLandscapeSid
                   ^ hashProvisioningState
                   ^ hashSystemSid
                   ^ hashEnvironment;
        }
    }
}
