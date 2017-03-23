// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for ProbeProtocol.
    /// </summary>
    public class ProbeProtocol : ExpandableStringEnum<ProbeProtocol>
    {
        public static readonly ProbeProtocol Http = Parse("Http");
        public static readonly ProbeProtocol Tcp = Parse("Tcp");
    }
}
