// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity
{
    /// <summary>
    /// .
    /// </summary>
    public static class ConfigurationManagerExtensions
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static ClientConnection GetAzureConnection(this IConfigurationManager configuration, string sectionName)
        {
            IConfigurationSection section = configuration.GetSection(sectionName);
            var credential = CreateCredentials(section.GetSection("Credential"));
            return new ClientConnection(section.Key, section["Endpoint"], credential.Credential, credential.Kind, section);
        }

        private static (object Credential, CredentialKind Kind) CreateCredentials(IConfigurationSection credentialSection)
        {
            CredentialKind credentialKind;
            object credential = default;
            if (credentialSection["CredentialSource"] is null)
            {
                credentialKind = CredentialKind.None;
            }
            else if (credentialSection["CredentialSource"].Equals("ApiKey", StringComparison.Ordinal))
            {
                credentialKind = CredentialKind.ApiKeyString;
                credential = credentialSection["Key"];
            }
            else
            {
                credentialKind = CredentialKind.TokenCredential;
                DefaultAzureCredentialOptions dacOptions = new();
                ConfigureDefaultAzureCredentialOptions(credentialSection, dacOptions);
                credential = new DefaultAzureCredential(dacOptions);
            }

            return (credential, credentialKind);
        }

        internal static void ConfigureDefaultAzureCredentialOptions(IConfigurationSection section, DefaultAzureCredentialOptions options)
        {
            if (section["CredentialSource"] is string credentialSource)
            {
                options.CredentialSource = credentialSource;
            }
        }
    }
}
