// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class PcStatus : ExpandableStringEnum<PcStatus>
    {
        public static readonly PcStatus NotStarted = Parse("NotStarted");
        public static readonly PcStatus Running = Parse("Running");
        public static readonly PcStatus Stopped = Parse("Stopped");
        public static readonly PcStatus Error = Parse("Error");
        public static readonly PcStatus Unknown = Parse("Unknown");
    }
}
