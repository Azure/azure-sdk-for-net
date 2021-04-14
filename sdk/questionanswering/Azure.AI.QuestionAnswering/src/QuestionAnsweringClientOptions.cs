// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.QuestionAnswering
{
    /// <summary>
    /// Options to configure requests send to Azure Question Answering.
    /// </summary>
    public class QuestionAnsweringClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest <see cref="ServiceVersion"/> supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V5_0_Preview_2;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnsweringClientOptions"/> class.
        /// </summary>
        /// <param name="version">The <see cref="ServiceVersion"/> of the service API to use for requests.</param>
        public QuestionAnsweringClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;

            Diagnostics.LoggedQueryParameters.Add("api-version");
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the sevice API to use for requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Gets the actual service API version from <see cref="Version"/>.
        /// </summary>
        /// <returns></returns>
        internal string GetVersionString() => Version switch
        {
            ServiceVersion.V5_0_Preview_2 => "v5.0-preview.2",
            _ => throw new NotSupportedException($"{Version} is not supported"),
        };

        /// <summary>
        /// The versions of Azure Question Answering supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The Question Answering API version 5.0-preview.2.
            /// </summary>
            V5_0_Preview_2 = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
