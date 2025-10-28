// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Microsoft.Extensions.Configuration;

namespace Azure.ResourceManager
{
    /// <summary>
    /// .
    /// </summary>
    public static class ClientConnectionExtensions
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static ArmClient CreateArmClient(this ClientConnection connection)
        {
            ArmClientOptions options = new();
            if (connection.Configuration is not null)
            {
                ConfigureArmClientOptions(connection.Configuration, options);
            }
            ArmClient client = new ArmClient(
                (TokenCredential)connection.Credential!,
                connection.Metadata.TryGetValue("DefaultSubscriptionId", out string subscriptionId) ? subscriptionId : null,
                options);
            if (connection.Configuration is not null)
            {
                client.RegisterConfigReload(connection.Configuration);
            }
            return client;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static ArmClient CreateArmClient(this ClientConnection connection, Action<ArmClientOptions> configure)
        {
            ArmClientOptions options = new();
            if (connection.Configuration is not null)
            {
                ConfigureArmClientOptions(connection.Configuration, options);
            }
            configure(options);
            return new ArmClient(
                (TokenCredential)connection.Credential!,
                connection.Metadata.TryGetValue("DefaultSubscriptionId", out string subscriptionId) ? subscriptionId : null,
                options);
        }

        private static void ConfigureArmClientOptions(IConfiguration configuration, ArmClientOptions options)
        {
            if (configuration.GetSection("Environment").Exists())
            {
                options.Environment = new ArmEnvironment(new Uri(configuration["Environment:Endpoint"]), configuration["Environment:Audience"]);
            }
        }
    }
}
