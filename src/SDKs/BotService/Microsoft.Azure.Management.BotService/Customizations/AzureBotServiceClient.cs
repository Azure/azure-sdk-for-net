// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.BotService.Customizations;

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
            if(BotServiceConfiguration.ShouldProvisionMsaApp)
            { 
                // If configured, override the bot services operations with an augmented bot services operations,
                // which includes the creation of an msa app id and other operations required to complete
                // the provisioning of the bot
                this.BotServices = new CustomBotServicesOperations(this.BotServices, this);
            }
        }
    }
}
