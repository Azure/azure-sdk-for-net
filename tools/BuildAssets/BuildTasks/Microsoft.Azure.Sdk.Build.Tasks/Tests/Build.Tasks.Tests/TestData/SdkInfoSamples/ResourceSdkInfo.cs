// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSdkInfo.SplitInfo
{
    public static partial class ResourceSDKInfo
    {
        public static IEnumerable<Tuple<string, string, string>> ApiInfo_Resource1
        {
            get
            {
                return new Tuple<string, string, string>[]
                {
                new Tuple<string, string, string>("Resource", "AvailabilitySets", "2017-03-30"),
                new Tuple<string, string, string>("Resource", "Disks", "2017-03-30")

                };
            }
        }
    }

    public static partial class ResourceSDKInfo
    {
        public static IEnumerable<Tuple<string, string, string>> ApiInfo_Resource2
        {
            get
            {
                return new Tuple<string, string, string>[]
                {
                new Tuple<string, string, string>("Resource", "VirtualMachines", "2016-03-30"),
                new Tuple<string, string, string>("Resource", "ContainerServices", "2017-01-31"),
                };
            }
        }
    }
}

namespace TestSdkInfo.MissingProperty
{
    public static partial class PropMissing
    {
        
    }
}


namespace Build.Tasks.Tests.MultiApi.Management.Authorization.Api2017_10_01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class SdkInfo
    {
        public static IEnumerable<Tuple<string, string, string>> ApiInfo_AuthorizationManagementClient
        {
            get
            {
                return new Tuple<string, string, string>[]
                {
                new Tuple<string, string, string>("Authorization", "PolicyAssignments", "2016-12-01"),
                new Tuple<string, string, string>("Authorization", "PolicyDefinitions", "2016-12-01"),
                new Tuple<string, string, string>("Authorization", "RoleAssignments", "2017-10-01-preview"),
                new Tuple<string, string, string>("AuthorizationManagementClient", "PolicyAssignments", "2016-12-01"),
                new Tuple<string, string, string>("AuthorizationManagementClient", "RoleAssignments", "2017-10-01-preview"),
                new Tuple<string, string, string>("Management", "PolicyDefinitions", "2016-12-01"),
                }.AsEnumerable();
            }
        }
    }
}

namespace Build.Tasks.Tests.MultiApi.Management.Authorization.Api2015_07_01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class SdkInfo
    {
        public static IEnumerable<Tuple<string, string, string>> ApiInfo_AuthorizationManagementClient
        {
            get
            {
                return new Tuple<string, string, string>[]
                {
                new Tuple<string, string, string>("Authorization", "ClassicAdministrators", "2015-07-01"),
                new Tuple<string, string, string>("Authorization", "ManagementLocks", "2015-01-01"),
                new Tuple<string, string, string>("Authorization", "Permissions", "2015-07-01"),
                new Tuple<string, string, string>("Authorization", "PolicyAssignments", "2015-10-01-preview"),
                new Tuple<string, string, string>("Authorization", "PolicyDefinitions", "2015-10-01-preview"),
                new Tuple<string, string, string>("Authorization", "ProviderOperationsMetadata", "2015-07-01"),
                new Tuple<string, string, string>("Authorization", "RoleAssignments", "2015-07-01"),
                new Tuple<string, string, string>("Authorization", "RoleDefinitions", "2015-07-01"),
                new Tuple<string, string, string>("AuthorizationManagementClient", "PolicyAssignments", "2015-10-01-preview"),
                new Tuple<string, string, string>("AuthorizationManagementClient", "RoleAssignments", "2015-07-01"),
                new Tuple<string, string, string>("AuthorizationManagementClient", "RoleDefinitions", "2015-07-01"),
                }.AsEnumerable();
            }
        }
    }
}