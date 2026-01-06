// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.Identity
{
    /// <summary>
    /// .
    /// </summary>
    public static class ClientSettingsBaseExtensions
    {
        /// <summary>
        /// .
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T WithAzureCredential<T>(this T settings)
            where T : ClientSettings
        {
            settings.Credential = new ConfigurableCredential(settings.Configuration);
            return settings;
        }
    }
}
