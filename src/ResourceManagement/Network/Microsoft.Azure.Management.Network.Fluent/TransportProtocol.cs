// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class TransportProtocol : ExpandableStringEnum<TransportProtocol>
    {
        public static readonly TransportProtocol Udp = new TransportProtocol() { Value = "Udp" };
        public static readonly TransportProtocol Tcp = new TransportProtocol() { Value = "Tcp" };
    }
}
