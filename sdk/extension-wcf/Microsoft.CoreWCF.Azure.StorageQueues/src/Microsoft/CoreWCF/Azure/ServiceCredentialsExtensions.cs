// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CoreWCF;
using CoreWCF.Collections.Generic;
using CoreWCF.Configuration;
using CoreWCF.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CoreWCF.Azure
{
    /// <summary>
    /// Provides extension methods for configuring Azure credentials with a service credential.
    /// </summary>
    public static class ServiceCredentialsExtensions
    {
        /// <summary>
        /// Configures the service host to use Azure credentials.
        /// </summary>
        /// <param name="serviceHostBase">The service host.</param>
        /// <returns>The Azure service credentials.</returns>
        public static AzureServiceCredentials UseAzureCredentials(this ServiceHostBase serviceHostBase)
        {
            var creds = new AzureServiceCredentials();
            var behaviors = serviceHostBase.Description.Behaviors;
            behaviors.Remove<ServiceCredentials>();
            behaviors.Add(creds);
            return creds;
        }

        /// <summary>
        /// Configures the service type <typeparamref name="TService"/> to use Azure credentials.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="serviceBuilder">The service builder.</param>
        /// <returns>The Azure service credentials.</returns>
        public static AzureServiceCredentials UseAzureCredentials<TService>(this IServiceBuilder serviceBuilder) where TService : class
        {
            var creds = new AzureServiceCredentials();
            serviceBuilder.ConfigureServiceHostBase<TService>(serviceHostBase =>
            {
                var behaviors = serviceHostBase.Description.Behaviors;
                behaviors.Remove<ServiceCredentials>();
                behaviors.Add(creds);
            });
            return creds;
        }

        /// <summary>
        /// Configures the service type <typeparamref name="TService"/> to use Azure credentials and executes a configuration delegate to modify those credentials.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="serviceBuilder">The service builder.</param>
        /// <param name="configure">An action to configure the Azure service credentials.</param>
        public static void UseAzureCredentials<TService>(this IServiceBuilder serviceBuilder, Action<AzureServiceCredentials> configure) where TService : class
        {
            var creds = new AzureServiceCredentials();
            serviceBuilder.ConfigureServiceHostBase<TService>(serviceHostBase =>
            {
                var behaviors = serviceHostBase.Description.Behaviors;
                behaviors.Remove<ServiceCredentials>();
                behaviors.Add(creds);
                if (configure is not null)
                {
                    configure(creds);
                }
            });
        }
    }
}
