// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{

    /// <summary>
    /// Defines values for ApplicationGatewayProtocol.
    /// </summary>
    public class ApplicationGatewayProtocol : ExpandableStringEnum<ApplicationGatewayProtocol>
    {
        public static readonly ApplicationGatewayProtocol Http = Parse("Http");
        public static readonly ApplicationGatewayProtocol Https = Parse("Https");
    }
}
