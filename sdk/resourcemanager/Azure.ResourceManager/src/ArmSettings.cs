// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.ResourceManager
{
    /// <summary>
    /// .
    /// </summary>
    public class ArmSettings : ClientSettingsBase
    {
        /// <summary>
        /// .
        /// </summary>
        public ArmSettings()
            :base(new ArmClientOptions())
        {
        }

        /// <summary>
        /// .
        /// </summary>
        public string DefaultSubscriptionId { get; set; }

        /// <inheritdoc/>
        protected override void ReadCore(IConfigurationSection section)
        {
            DefaultSubscriptionId = section["DefaultSubscriptionId"];
            // for schema should we have a layer for ClientOptions section.GetSection("ClientOptions")
            Options = new ArmClientOptions(section);
        }

        internal static ArmSettings Create(IServiceProvider serviceProvider, IConfigurationSection section, Action<ArmClientOptions> configureOptions)
        {
            ArmSettings settings = new ArmSettings();
            settings.Read(section);
            object credential;

            string credentialSource = settings.Credential.CredentialSource;
            if (credentialSource is null || !credentialSource.Equals("ApiKey", StringComparison.Ordinal))
            {
                credential = serviceProvider.GetRequiredService<TokenCredential>();
            }
            else
            {
                if (string.Equals(credentialSource, "ApiKey", StringComparison.Ordinal))
                {
                    credential = settings.Credential.Key;
                }
                else
                {
                    throw new Exception($"Unsupported credential source '{credentialSource}'.");
                }
            }
            settings.CredentialObject = credential;

            configureOptions?.Invoke((ArmClientOptions)settings.Options);
            return settings;
        }
    }
}
