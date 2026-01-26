// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity
{
    /// <summary>
    /// Provides extension methods for <see cref="IConfiguration"/> interface.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Creates an instance of <typeparamref name="T"/> and sets its properties from the specified <see cref="IConfiguration"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ClientSettings"/> to create.</typeparam>
        /// <param name="configuration">The <see cref="IConfiguration"/> to bind the properties of <typeparamref name="T"/> from.</param>
        /// <param name="sectionName">The section of <see cref="IConfiguration"/> to bind from.</param>
        public static T GetAzureClientSettings<T>(this IConfiguration configuration, string sectionName)
            where T : ClientSettings, new()
            => configuration.GetClientSettings<T>(sectionName).WithAzureCredential();
    }
}
