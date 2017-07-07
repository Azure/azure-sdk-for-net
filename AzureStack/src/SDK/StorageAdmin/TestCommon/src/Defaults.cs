// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestCommon
{
    public class Defaults
    {

        // This is just default values stored in a central location
        
        public const string DefaultSubnetPrefix = "10.0.0.0/24";

        public static IReadOnlyList<string> DefaultVNetPrefixs = new ReadOnlyCollection<string>(new List<string>() {
                        "10.0.0.0/16"
                    });

        public static IReadOnlyList<string> DefaultDNSServers = new ReadOnlyCollection<string>(new List<string>() {
                        "10.1.1.1",
                        "10.1.2.4"
                    });

    }
}
