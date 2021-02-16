﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure
    /// Cognitive Search.
    /// </summary>
    public class SearchClientOptions : ClientOptions
    {
        /// <summary>
        /// The versions of Azure Cognitive Search supported by this client
        /// library.  For more, see
        /// <see href="https://docs.microsoft.com/azure/search/search-api-versions">
        /// API versions in Azure Cognitive Search</see>.
        /// </summary>
        public enum ServiceVersion
        {
            #pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The 2020_06_30 version of the Azure Cognitive Search
            /// service.
            /// </summary>
            V2020_06_30 = 1
            #pragma warning restore CA1707
        }

        /// <summary>
        /// The Latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2020_06_30;

        /// <summary>
        /// The service version to use when creating continuation tokens that
        /// can be passed between different client libraries.  Changing this
        /// value requires updating <see cref="Azure.Search.Documents.Models.SearchContinuationToken"/>.
        /// </summary>
        internal const ServiceVersion ContinuationTokenVersion = ServiceVersion.V2020_06_30;

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.  For more, see
        /// <see href="https://docs.microsoft.com/azure/search/search-api-versions">
        /// API versions in Azure Cognitive Search</see>.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Gets or sets an <see cref="ObjectSerializer"/> that can be used to
        /// customize the serialization of strongly typed models.  The
        /// serializer needs to support JSON and <see cref="JsonObjectSerializer"/>
        /// will be used if no value is provided.
        /// </summary>
        public ObjectSerializer Serializer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// An optional <see cref="ServiceVersion"/> to specify the version of
        /// the REST API to use.  For more, see
        /// <see href="https://docs.microsoft.com/azure/search/search-api-versions">
        /// API versions in Azure Cognitive Search</see>.
        ///
        /// If not provided, the <paramref name="version"/> will default to the
        /// latest supported by this client library.  It is recommended that
        /// application authors allow the version to float to the latest and
        /// library authors pin to a specific version.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="version"/> is not supported by this
        /// client library.
        /// </exception>
        public SearchClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version.Validate();
            AddLoggingHeaders();
            AddLoggingQueryParameters();
        }

        /// <summary>
        /// Create an <see cref="HttpPipeline"/> to send requests to the Search
        /// Service.
        /// </summary>
        /// <param name="credential">
        /// The <see cref="AzureKeyCredential"/> to authenticate requests.
        /// </param>
        /// <returns>An <see cref="HttpPipeline"/> to send requests.</returns>
        internal HttpPipeline Build(AzureKeyCredential credential)
        {
            Debug.Assert(credential != null);
            return HttpPipelineBuilder.Build(
                options: this,
                perCallPolicies: new[] { new AzureKeyCredentialPolicy(credential, Constants.ApiKeyHeaderName) },
                perRetryPolicies: Array.Empty<HttpPipelinePolicy>(),
                responseClassifier: null);
        }

        /// <summary>
        /// Add the allow list headers to the <see cref="DiagnosticsOptions"/>
        /// that are considered safe for logging/exceptions by default.
        /// </summary>
        private void AddLoggingHeaders()
        {
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Allow-Credentials");
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Allow-Headers");
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Allow-Methods");
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Allow-Origin");
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Expose-Headers");
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Max-Age");
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Request-Headers");
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Request-Method");
            Diagnostics.LoggedHeaderNames.Add("client-request-id");
            Diagnostics.LoggedHeaderNames.Add("elapsed-time");
            Diagnostics.LoggedHeaderNames.Add("Location");
            Diagnostics.LoggedHeaderNames.Add("OData-MaxVersion");
            Diagnostics.LoggedHeaderNames.Add("OData-Version");
            Diagnostics.LoggedHeaderNames.Add("Origin");
            Diagnostics.LoggedHeaderNames.Add("Prefer");
            Diagnostics.LoggedHeaderNames.Add("request-id");
            Diagnostics.LoggedHeaderNames.Add("return-client-request-id");
            Diagnostics.LoggedHeaderNames.Add("throttle-reason");
        }

        /// <summary>
        /// Add the allow list query parameters to the
        /// <see cref="DiagnosticsOptions"/> that  are considered safe for
        /// logging/exceptions by default.
        /// </summary>
        private void AddLoggingQueryParameters()
        {
            Diagnostics.LoggedQueryParameters.Add("api-version");
            Diagnostics.LoggedQueryParameters.Add("allowIndexDowntime");
        }
    }

    /// <summary>
    /// Search extension methods.
    /// </summary>
    internal static partial class SearchExtensions
    {
        /// <summary>
        /// Validate a <see cref="SearchClientOptions.ServiceVersion"/>.
        /// </summary>
        /// <param name="version">
        /// The <see cref="SearchClientOptions.ServiceVersion"/> to validate.
        /// </param>
        /// <returns>
        /// The validated version.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="version"/> is not supported by this
        /// client library.
        /// </exception>
        public static SearchClientOptions.ServiceVersion Validate(this SearchClientOptions.ServiceVersion version) =>
            version switch
            {
                SearchClientOptions.ServiceVersion.V2020_06_30 => version,
                _ => throw CreateInvalidVersionException(version)
            };

        /// <summary>
        /// Get a version string, like "2019-05-06", corresponding to a given
        /// <see cref="SearchClientOptions.ServiceVersion"/> value.
        /// </summary>
        /// <param name="version">
        /// The <see cref="SearchClientOptions.ServiceVersion"/> value to
        /// convert into a version string.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="version"/> is not supported by this
        /// client library.
        /// </exception>
        public static string ToVersionString(this SearchClientOptions.ServiceVersion version) =>
            version switch
            {
                SearchClientOptions.ServiceVersion.V2020_06_30 => "2020-06-30",
                _ => throw CreateInvalidVersionException(version)
            };

        /// <summary>
        /// Create an <see cref="ArgumentOutOfRangeException"/> to throw when
        /// an invalid <see cref="SearchClientOptions.ServiceVersion"/> value
        /// is provided.
        /// </summary>
        /// <param name="version">The invalid version value.</param>
        /// <returns>An exception to throw.</returns>
        private static ArgumentOutOfRangeException CreateInvalidVersionException(SearchClientOptions.ServiceVersion version) =>
            new ArgumentOutOfRangeException(
                nameof(version),
                version,
                $"The {nameof(SearchClientOptions)}.{nameof(SearchClientOptions.ServiceVersion)} specified is not supported by this library.");
    }
}
