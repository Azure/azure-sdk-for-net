// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Microsoft.Azure.Management.BotService.Customizations;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Management.BotService
{
    /// <summary>
    /// Azure Bot Service is a platform for creating smart conversational
    /// agents.
    /// </summary>
    public partial class AzureBotServiceClient
    {
        /// <summary>
        /// Azure Active Directory TenantId
        /// </summary>
        public string TenantId { get; set; }

        partial void CustomInitialize()
        {
            // Override the bot services operations with an augmented bot services operations,
            // which includes operations required to complete the provisioning of the bot
            this.Bots = new CustomBotsOperations(this.Bots, this);
        }
    }
}
