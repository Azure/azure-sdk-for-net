// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class PcProtocol: ExpandableStringEnum<PcProtocol>
    {
        public static readonly PcProtocol TCP = Parse("TCP");
        public static readonly PcProtocol UDP = Parse("UDP");
        public static readonly PcProtocol Any = Parse("Any");
    }
}
