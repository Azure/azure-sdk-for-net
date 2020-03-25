// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// </summary>
    public class FormRecognizerClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2_0_Preview;

        private readonly ServiceVersion _version;

        /// <summary>
        /// </summary>
        /// <param name="version"></param>
        public FormRecognizerClientOptions(ServiceVersion version = LatestVersion)
        {
            _version = version;
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

    }
}
