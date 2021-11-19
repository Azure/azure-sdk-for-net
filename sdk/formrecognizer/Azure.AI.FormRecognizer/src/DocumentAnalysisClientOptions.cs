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
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_09_30_preview;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAnalysisClientOptions"/> class which allows
        /// to configure the behavior of the <see cref="DocumentAnalysisClient" /> or <see cref="DocumentModelAdministrationClient"/>.
        /// </summary>
        /// <param name="version">The version of the service to send requests to.</param>
        public DocumentAnalysisClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2021_09_30_preview => version,
                _ => throw new NotSupportedException($"The service version {version} is not supported.")
            };

            AddLoggedHeadersAndQueryParameters();
        }

        /// <summary>
        /// The service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The version 2021-09-30-preview of the service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable AZC0016 // All parts of ServiceVersion members' names must begin with a number or uppercase letter and cannot have consecutive underscores
            V2021_09_30_preview = 1,
#pragma warning restore AZC0016 // All parts of ServiceVersion members' names must begin with a number or uppercase letter and cannot have consecutive underscores
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// The service version.
        /// </summary>
        public ServiceVersion Version { get; }

        internal static string GetVersionString(ServiceVersion version)
        {
            return version switch
            {
                ServiceVersion.V2021_09_30_preview => "2021_09_30_preview",
                _ => throw new NotSupportedException($"The service version {version} is not supported."),
            };
        }

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
