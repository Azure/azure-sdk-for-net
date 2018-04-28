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