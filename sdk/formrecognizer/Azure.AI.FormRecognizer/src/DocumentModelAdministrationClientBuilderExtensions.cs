// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add the <see cref="DocumentModelAdministrationClient"/> to clients builder.
    /// </summary>
    public static class DocumentModelAdministrationClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="DocumentModelAdministrationClient"/> instance with the provided <paramref name="endpoint"/>.
        /// </summary>
        public static IAzureClientBuilder<DocumentModelAdministrationClient, DocumentAnalysisClientOptions> AddDocumentModelAdministrationClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<DocumentModelAdministrationClient, DocumentAnalysisClientOptions>((options, credential) => new DocumentModelAdministrationClient(endpoint, credential, options));
        }

        /// <summary>
        /// Registers a <see cref="DocumentModelAdministrationClient"/> instance with the provided <paramref name="endpoint"/> and <paramref name="credential"/>.
        /// </summary>
        public static IAzureClientBuilder<DocumentModelAdministrationClient, DocumentAnalysisClientOptions> AddDocumentModelAdministrationClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<DocumentModelAdministrationClient, DocumentAnalysisClientOptions>(options => new DocumentModelAdministrationClient(endpoint, credential, options));
        }

        /// <summary>
        /// Registers a <see cref="DocumentModelAdministrationClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<DocumentModelAdministrationClient, DocumentAnalysisClientOptions> AddDocumentModelAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DocumentModelAdministrationClient, DocumentAnalysisClientOptions>(configuration);
        }
    }
}
