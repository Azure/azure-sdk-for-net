// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Azure.Developer.DevCenter;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="DevCenterClient"/>, <see cref="DevBoxesClient"/>, <see cref="DeploymentEnvironmentsClient"/> to client builder. </summary>
    public static partial class DevCenterClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="DevCenterClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The DevCenter-specific URI to operate on. </param>
        public static IAzureClientBuilder<DevCenterClient, DevCenterClientOptions> AddDevCenterClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<DevCenterClient, DevCenterClientOptions>((options, cred) => new DevCenterClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="DevBoxesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The DevCenter-specific URI to operate on. </param>
        public static IAzureClientBuilder<DevBoxesClient, DevCenterClientOptions> AddDevBoxesClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<DevBoxesClient, DevCenterClientOptions>((options, cred) => new DevBoxesClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="DeploymentEnvironmentsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The DevCenter-specific URI to operate on. </param>
        public static IAzureClientBuilder<DeploymentEnvironmentsClient, DevCenterClientOptions> AddDeploymentEnvironmentsClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<DeploymentEnvironmentsClient, DevCenterClientOptions>((options, cred) => new DeploymentEnvironmentsClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="DevCenterClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<DevCenterClient, DevCenterClientOptions> AddDevCenterClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DevCenterClient, DevCenterClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="DevBoxesClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<DevBoxesClient, DevCenterClientOptions> AddDevBoxesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DevBoxesClient, DevCenterClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="DeploymentEnvironmentsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<DeploymentEnvironmentsClient, DevCenterClientOptions> AddDeploymentEnvironmentsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DeploymentEnvironmentsClient, DevCenterClientOptions>(configuration);
        }
    }
}
