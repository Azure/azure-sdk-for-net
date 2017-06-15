// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class BgpPeerState : ExpandableStringEnum<BgpPeerState>
    {
        public static readonly BgpPeerState Unknown = Parse("Unknown");
        public static readonly BgpPeerState Stopped = Parse("Stopped");
        public static readonly BgpPeerState Idle = Parse("Idle");
        public static readonly BgpPeerState Connecting = Parse("Connecting");
        public static readonly BgpPeerState Connected = Parse("Connected");
    }
}
