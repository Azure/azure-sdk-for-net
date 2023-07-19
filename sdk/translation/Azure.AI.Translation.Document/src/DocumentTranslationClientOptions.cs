// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Options that allow to configure the management of the request sent to the service.
    /// </summary>
    public class DocumentTranslationClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V1_0;

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when making requests
        /// </summary>
        internal ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when making requests.
        /// </param>
        public DocumentTranslationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
            AddLoggedHeadersAndQueryParameters();
        }

        internal string GetVersionString()
        {
            return Version switch
            {
                ServiceVersion.V1_0 => "1.0",
                _ => throw new ArgumentException(Version.ToString()),
            };
        }

        /// <summary>
        /// The versions of the Translator service supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Version 1.0 .
            /// </summary>
            V1_0 = 1
        }

        /// <summary>
        /// Gets or sets the Audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="DocumentTranslationAudience.AzurePublicCloud" /> will be assumed.</value>
        public DocumentTranslationAudience? Audience { get; set; }

        /// <summary>
        /// Add headers and query parameters that are considered safe for logging or including in
        /// error messages by default.
        /// </summary>
        private void AddLoggedHeadersAndQueryParameters()
        {
            Diagnostics.LoggedHeaderNames.Add("Operation-Location");
            Diagnostics.LoggedHeaderNames.Add("Content-Encoding");
            Diagnostics.LoggedHeaderNames.Add("Vary");
            Diagnostics.LoggedHeaderNames.Add("apim-request-id");
            Diagnostics.LoggedHeaderNames.Add("X-RequestId");
            Diagnostics.LoggedHeaderNames.Add("Set-Cookie");
            Diagnostics.LoggedHeaderNames.Add("X-Powered-By");
            Diagnostics.LoggedHeaderNames.Add("Strict-Transport-Security");
            Diagnostics.LoggedHeaderNames.Add("x-content-type-options");

            Diagnostics.LoggedQueryParameters.Add("$top");
            Diagnostics.LoggedQueryParameters.Add("$skip");
            Diagnostics.LoggedQueryParameters.Add("$maxpagesize");
            Diagnostics.LoggedQueryParameters.Add("ids");
            Diagnostics.LoggedQueryParameters.Add("statuses");
            Diagnostics.LoggedQueryParameters.Add("createdDateTimeUtcStart");
            Diagnostics.LoggedQueryParameters.Add("createdDateTimeUtcEnd");
            Diagnostics.LoggedQueryParameters.Add("$orderBy");
        }
    }
}
