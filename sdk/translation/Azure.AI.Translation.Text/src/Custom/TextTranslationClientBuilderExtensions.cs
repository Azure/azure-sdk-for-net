// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Azure;
using Azure.AI.Translation.Text;
using Azure.Core;
using Azure.Core.Extensions;

//TODO: there is no way to only suppress a single member of a static class so we need to have everything custom here.
[assembly: CodeGenSuppressType("AITranslationTextClientBuilderExtensions")]

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="TextTranslationClient"/> to client builder. </summary>
    public static partial class TextTranslationClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="TextTranslationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential">Azure Credentials</param>
        public static IAzureClientBuilder<TextTranslationClient, TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TextTranslationClient, TextTranslationClientOptions>((options) => new TextTranslationClient(credential, options: options));
        }

        /// <summary> Registers a <see cref="TextTranslationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential">Azure Credentials</param>
        /// <param name="region">Region of Azure Resource</param>
        public static IAzureClientBuilder<TextTranslationClient, TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, string region)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TextTranslationClient, TextTranslationClientOptions>((options) => new TextTranslationClient(credential, region, options));
        }

        /// <summary> Registers a <see cref="TextTranslationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential">Azure Credentials</param>
        /// <param name="endpoint">Endpoint of the translation service</param>
        public static IAzureClientBuilder<TextTranslationClient, TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TextTranslationClient, TextTranslationClientOptions>((options) => new TextTranslationClient(credential, endpoint, options: options));
        }

        /// <summary> Registers a <see cref="TextTranslationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential">Azure Credentials</param>
        /// <param name="endpoint">Endpoint of the translation service</param>
        /// <param name="region">Region of Azure Resource</param>
        public static IAzureClientBuilder<TextTranslationClient, TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential, Uri endpoint, string region)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TextTranslationClient, TextTranslationClientOptions>((options) => new TextTranslationClient(credential, endpoint, region, options));
        }

        /// <summary> Registers a <see cref="TextTranslationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential">Cognitive Services Token</param>
        public static IAzureClientBuilder<TextTranslationClient, TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, TokenCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TextTranslationClient, TextTranslationClientOptions>((options) => new TextTranslationClient(credential, options: options));
        }

        /// <summary> Registers a <see cref="TextTranslationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential">Cognitive Services Token</param>
        /// <param name="endpoint">Endpoint of the translation service</param>
        public static IAzureClientBuilder<TextTranslationClient, TextTranslationClientOptions> AddTextTranslationClient<TBuilder>(this TBuilder builder, TokenCredential credential, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TextTranslationClient, TextTranslationClientOptions>((options) => new TextTranslationClient(credential, endpoint, options: options));
        }

        /// <summary> Registers a <see cref="TextTranslationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<TextTranslationClient, TextTranslationClientOptions> AddTextTranslationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<TextTranslationClient, TextTranslationClientOptions>(configuration);
        }
    }
}
