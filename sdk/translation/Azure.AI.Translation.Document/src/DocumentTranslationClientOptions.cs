// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Options that allow to configure the management of the request sent to the service.
    /// </summary>
    [CodeGenSuppress("AzureAITranslationDocumentClientOptions", typeof(ServiceVersion))]
    [CodeGenModel("AzureAITranslationDocumentClientOptions")]
    public partial class DocumentTranslationClientOptions : ClientOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when making requests.
        /// </param>
        public DocumentTranslationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2024_05_01 => "2024-05-01",
                ServiceVersion.V2024_11_01_Preview => "2024-11-01-preview",
                _ => throw new NotSupportedException()
            };
            AddLoggedHeadersAndQueryParameters();
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
