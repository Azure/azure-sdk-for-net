// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Provides extension methods for the <see cref="ClientSettings"/> class.
    /// </summary>
    public static class ClientSettingsExtensions
    {
        /// <summary>
        /// Sets the <see cref="ClientSettings.CredentialObject"/> to an instance of <see cref="TokenCredential"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ClientSettings"/>.</typeparam>
        /// <param name="settings">The <see cref="ClientSettings"/> instance.</param>
        public static T WithAzureCredential<T>(this T settings)
            where T : ClientSettings
        {
            settings.CredentialObject = new ConfigurableCredential(settings.Credential);
            return settings;
        }
    }
}
