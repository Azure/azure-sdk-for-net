// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class Direction : ExpandableStringEnum<Direction>
    {
        public static readonly Direction Inbound = Parse("Inbound");
        public static readonly Direction Outbound = Parse("Outbound");
    }
}
