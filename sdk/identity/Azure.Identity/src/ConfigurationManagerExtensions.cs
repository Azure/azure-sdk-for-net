// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static T GetAzureClientSettings<T>(this IConfiguration configuration, string sectionName)
            where T : ClientSettingsBase, new()
        {
            IConfigurationSection section = configuration.GetRequiredSection(sectionName);
            T t = new();
            t.Read(section);
            t.CredentialObject = new ConfigurableCredential(section);
            return t;
        }
    }
}
