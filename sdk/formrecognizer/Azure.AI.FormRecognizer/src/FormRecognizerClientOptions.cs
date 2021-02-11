// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.FormRecognizer.Training;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// The set of options that can be specified when creating a <see cref="FormRecognizerClient" />
    /// or a <see cref="FormTrainingClient"/> to configure its behavior.
    /// </summary>
    public class FormRecognizerClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2_1_Preview_2;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClientOptions"/> class which allows
        /// to configure the behavior of the <see cref="FormRecognizerClient" /> or <see cref="FormTrainingClient"/>.
        /// </summary>
        /// <param name="version">The version of the service to send requests to.</param>
        public FormRecognizerClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
            AddLoggedHeadersAndQueryParameters();
        }

        /// <summary>
        /// The service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V2.0 of the service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2_0 = 1,

            /// <summary>
            /// Version 2.1-preview.2
            /// </summary>
            V2_1_Preview_2 = 2,
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
                ServiceVersion.V2_0 => "v2.0",
                ServiceVersion.V2_1_Preview_2 => "v2.1-preview.2",
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
            Diagnostics.LoggedHeaderNames.Add("Location");
            Diagnostics.LoggedHeaderNames.Add("Strict-Transport-Security");
            Diagnostics.LoggedHeaderNames.Add("X-Content-Type-Options");
            Diagnostics.LoggedHeaderNames.Add("x-envoy-upstream-service-time");

            Diagnostics.LoggedQueryParameters.Add("includeKeys");
            Diagnostics.LoggedQueryParameters.Add("includeTextDetails");
            Diagnostics.LoggedQueryParameters.Add("op");
        }
    }
}
