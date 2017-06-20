// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for IPVersion.
    /// </summary>
    public class IPVersion : ExpandableStringEnum<IPVersion>
    {
        public static readonly IPVersion IPv4 = Parse("IPv4");
        public static readonly IPVersion IPv6 = Parse("IPv6");
    }
}
