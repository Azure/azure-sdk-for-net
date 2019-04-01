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

#if NETSTANDARD1_4

        /// <summary>
        /// Device code authentication callback, only if MsaAppId is not provided.
        /// If an MsaAppId is not provided in the Bot payload, then a new MsaApp will be provisioned, 
        /// but first authentication needs to happen, and this callback will be called to allow
        /// users to enter the device code.
        /// </summary>
        public Action<DeviceCodeResult> DeviceCodeAuthCallback { get; set; }
#endif

        partial void CustomInitialize()
        {
            // Override the bot services operations with an augmented bot services operations,
            // which includes the creation of an msa app id and other operations required to complete
            // the provisioning of the bot
            this.Bots = new CustomBotsOperations(this.Bots, this);
        }
    }
}
