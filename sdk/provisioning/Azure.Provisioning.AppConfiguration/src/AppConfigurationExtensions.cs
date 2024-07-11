// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.AppConfiguration
{
    /// <summary>
    /// Extension methods for <see cref="IConstruct"/>.
    /// </summary>
    public static class AppConfigurationExtensions
    {
        /// <summary>
        /// Adds a <see cref="AppConfigurationStore"/> to the construct.
        /// </summary>
        /// <param name="construct">The construct.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static AppConfigurationStore AddAppConfigurationStore(this IConstruct construct, string name = "store")
        {
            return new AppConfigurationStore(construct, name: name);
        }
    }
}
