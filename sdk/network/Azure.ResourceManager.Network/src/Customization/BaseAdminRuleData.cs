// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class BaseAdminRuleData
    {
        private protected BaseAdminRuleData(AdminRuleKind kind)
        {
            Kind = kind;
        }
    }
}
