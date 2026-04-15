// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

global using Microsoft.Extensions.Configuration;

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Communication.Messages
{
    [CodeGenSuppress("BindCore", typeof(IConfigurationSection))]
    [CodeGenSuppress("CommunicationTokenCredential")]
    public partial class ConversationThreadClientSettings
    {
        /// <summary> Gets or sets the CommunicationTokenCredential token string. </summary>
        public string CommunicationTokenCredential { get; set; }

        /// <summary> Binds configuration values from the given section. </summary>
        /// <param name="section"> The configuration section. </param>
        protected override void BindCore(IConfigurationSection section)
        {
            if (Uri.TryCreate(section["Endpoint"], UriKind.Absolute, out Uri endpoint))
            {
                Endpoint = endpoint;
            }

            IConfigurationSection communicationTokenCredentialSection = section.GetSection("CommunicationTokenCredential");
            if (communicationTokenCredentialSection.Exists())
            {
                string token = communicationTokenCredentialSection.Value;
                if (!string.IsNullOrEmpty(token))
                {
                    CommunicationTokenCredential = token;
                }
            }

            IConfigurationSection optionsSection = section.GetSection("Options");
            if (optionsSection.Exists())
            {
                Options = new CommunicationMessagesClientOptions(optionsSection);
            }
        }
    }
}
