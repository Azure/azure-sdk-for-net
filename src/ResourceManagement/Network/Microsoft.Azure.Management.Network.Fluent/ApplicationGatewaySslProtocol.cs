// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Application gateway SSL protocol.
    /// </summary>
    public class ApplicationGatewaySslProtocol : ExpandableStringEnum<ApplicationGatewaySslProtocol>
    {
        public static readonly ApplicationGatewaySslProtocol TlsV1_0 = Parse("TLSv1_0");
        public static readonly ApplicationGatewaySslProtocol TlsV1_1 = Parse("TLSv1_1");
        public static readonly ApplicationGatewaySslProtocol TlsV1_2 = Parse("TLSv1_2");
    }
}
