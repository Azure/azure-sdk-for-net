// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning.AppService
{
    /// <summary>
    /// Extension methods for <see cref="IConstruct"/>.
    /// </summary>
    public static class AppServicesExtensions
    {
        /// <summary>
        /// Adds an <see cref="AppServicePlan"/> to the construct.
        /// </summary>
        /// <param name="construct">The construct.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static AppServicePlan AddAppServicePlan(this IConstruct construct, ResourceGroup? parent = null, string name = "appServicePlan")
        {
            return new AppServicePlan(construct, name, parent: parent);
        }
    }
}
