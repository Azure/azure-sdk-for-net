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
        internal const ServiceVersion LatestVersion = ServiceVersion.V2_0_Preview;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version of the service to send requests to.</param>
        public FormRecognizerClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }

        /// <summary>
        /// The template service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the template service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2_0_Preview = 1
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
                ServiceVersion.V2_0_Preview => "v2.0-preview",
                _ => throw new NotSupportedException($"The service version {version} is not supported."),
            };
        }

        internal FormRecognizerClientOptions Clone() => new FormRecognizerClientOptions(Version) { };
    }
}
