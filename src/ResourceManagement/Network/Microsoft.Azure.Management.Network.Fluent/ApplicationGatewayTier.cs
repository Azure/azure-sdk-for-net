// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewayTier : ExpandableStringEnum<ApplicationGatewayTier>
    {
        public static readonly ApplicationGatewayTier Standard = new ApplicationGatewayTier() { Value = "Standard" };
    }
}
