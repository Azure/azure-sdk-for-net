// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class PcError : ExpandableStringEnum<PcError>
    {
        public static readonly PcError InternalError = Parse("InternalError");
        public static readonly PcError AgentStopped = Parse("AgentStopped");
        public static readonly PcError CaptureFailed = Parse("CaptureFailed");
        public static readonly PcError LocalFileFailed = Parse("LocalFileFailed");
        public static readonly PcError StorageFailed = Parse("StorageFailed");
    }
}
