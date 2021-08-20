// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.FormRecognizer.DocumentAnalysis;
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
            V2021_09_30_preview = 1,
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
    }
}
