// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The set of options that can be specified when creating a <see cref="DocumentAnalysisClient" />
    /// or a <see cref="DocumentModelAdministrationClient"/> to configure its behavior.
    /// </summary>
    public class DocumentAnalysisClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2023_07_31;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClientOptions"/> class which allows
        /// to configure the behavior of the <see cref="DocumentAnalysisClient" /> or <see cref="DocumentModelAdministrationClient"/>.
        /// </summary>
        /// <param name="version">The version of the service to send requests to.</param>
        public DocumentAnalysisClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
            VersionString = version switch
            {
                ServiceVersion.V2022_08_31 => "2022-08-31",
                ServiceVersion.V2023_07_31 => "2023-07-31",
                _ => throw new NotSupportedException($"The service version {version} is not supported by this library."),
            };

            AddLoggedHeadersAndQueryParameters();
        }

        /// <summary>
        /// The service version.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The version 2022-08-31 of the service.
            /// </summary>
            V2022_08_31 = 1,

            /// <summary>
            /// The version 2023-07-31 of the service.
            /// </summary>
            V2023_07_31
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets or sets the Audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="DocumentAnalysisAudience.AzurePublicCloud" /> will be assumed.</value>
        public DocumentAnalysisAudience? Audience { get; set; }

        /// <summary>
        /// The service version.
        /// </summary>
        public ServiceVersion Version { get; }

        internal string VersionString { get; }

        /// <summary>
        /// Add headers and query parameters that are considered safe for logging or including in
        /// error messages by default.
        /// </summary>
        private void AddLoggedHeadersAndQueryParameters()
        {
            Diagnostics.LoggedHeaderNames.Add(Constants.OperationLocationHeader);
            Diagnostics.LoggedHeaderNames.Add("apim-request-id");
            Diagnostics.LoggedHeaderNames.Add("Strict-Transport-Security");
            Diagnostics.LoggedHeaderNames.Add("x-content-type-options");
            Diagnostics.LoggedHeaderNames.Add("x-envoy-upstream-service-time");

            Diagnostics.LoggedQueryParameters.Add("locale");
            Diagnostics.LoggedQueryParameters.Add("pages");
        }
    }
}
