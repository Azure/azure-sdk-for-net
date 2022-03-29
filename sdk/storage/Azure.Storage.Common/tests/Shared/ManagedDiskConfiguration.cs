// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;

namespace Azure.Storage.Test
{
    public class ManagedDiskConfiguration
    {
        public string Name { get; private set; }

        public string DiskNamePrefix { get; private set; }

        public string ResourceGroupName { get; private set; }

        public string SubsriptionId { get; private set; }

        public string ActiveDirectoryApplicationId { get; private set; }

        public string ActiveDirectoryApplicationSecret { get; private set; }

        public string ActiveDirectoryTenantId { get; private set; }

        public string Location { get; private set; }

        public static ManagedDiskConfiguration Parse(XElement tenant)
        {
            string Get(string name) => (string)tenant.Element(name);

            return new ManagedDiskConfiguration
            {
                Name = Get("Name"),
                DiskNamePrefix = Get("DiskNamePrefix"),
                ResourceGroupName = Get("ResourceGroupName"),
                SubsriptionId = Get("SubsriptionId"),
                Location = Get("Location"),
                ActiveDirectoryApplicationId = Get("ActiveDirectoryApplicationId"),
                ActiveDirectoryApplicationSecret = Get("ActiveDirectoryApplicationSecret"),
                ActiveDirectoryTenantId = Get("ActiveDirectoryTenantId"),
            };
        }
    }
}
