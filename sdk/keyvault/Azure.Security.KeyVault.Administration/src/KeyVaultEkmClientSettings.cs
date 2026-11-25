// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.KeyVault.Administration
{
    [CodeGenSuppress("BindCore", typeof(IConfigurationSection))]
    public partial class KeyVaultEkmClientSettings
    {
        /// <summary> Gets or sets the <see cref="Uri"/> of the vault on which the client operates. </summary>
        [CodeGenMember("VaultBaseUrl")]
        public Uri VaultUri { get; set; }

        /// <inheritdoc/>
        protected override void BindCore(IConfigurationSection section)
        {
            if (Uri.TryCreate(section["VaultUri"], UriKind.Absolute, out Uri vaultUri))
            {
                VaultUri = vaultUri;
            }

            IConfigurationSection optionsSection = section.GetSection("Options");
            if (optionsSection.Exists())
            {
                Options = new KeyVaultAdministrationClientOptions(optionsSection);
            }
        }
    }
}