// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ProvisioningState : ExpandableStringEnum<ProvisioningState>
    {
        public static readonly ProvisioningState Succeeded = Parse("Succeeded");
        public static readonly ProvisioningState Updating = Parse("Updating");
        public static readonly ProvisioningState Deleting = Parse("Deleting");
        public static readonly ProvisioningState Failed = Parse("Failed");
    }
}
