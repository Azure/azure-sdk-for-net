// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Extensions;
using Azure.ResourceManager;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="ArmClientOptions"/> client to clients builder.
    /// </summary>
    public static class ArmClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="ArmClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<ArmClient, ArmClientOptions> AddArmClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ArmClient, ArmClientOptions>(configuration);
        }
    }
}
