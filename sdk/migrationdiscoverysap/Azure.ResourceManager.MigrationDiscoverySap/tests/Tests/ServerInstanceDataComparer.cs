// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests
{
    public class ServerInstanceDataComparer : IEqualityComparer<SapDiscoveryServerInstanceData>
    {
        public bool Equals(SapDiscoveryServerInstanceData x, SapDiscoveryServerInstanceData y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y))
                return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the discoverySite properties are equal.
            return x.Name == y.Name
                && x.ServerName == y.ServerName
                && x.InstanceSid == y.InstanceSid;
        }

        public int GetHashCode(SapDiscoveryServerInstanceData serverData)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(serverData, null))
                return 0;

            int hashName = serverData.Name == null ? 0 : serverData.Name.GetHashCode();
            int hashInstanceSid = serverData.InstanceSid.GetHashCode();
            int hashServerName = serverData.ServerName.GetHashCode();

            return hashName
                   ^ hashInstanceSid
                   ^ hashServerName;
        }
    }
}
