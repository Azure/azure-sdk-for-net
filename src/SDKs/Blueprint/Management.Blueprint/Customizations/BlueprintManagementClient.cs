// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Blueprint
{
    using Microsoft.Rest;
    using System;
    using System.Net.Http;

    /// <summary>
    /// Blueprint Client
    /// </summary>
    public partial class BlueprintManagementClient
    {
        /// <summary>
        /// Initializes a new instance of the BlueprintManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials needed for the client to connect to Azure.
        /// </param>
        /// <param name="apiVersionOverride">
        /// Optional. Allows customization of what api-version value to send with requests
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public BlueprintManagementClient(
            Uri baseUri, ServiceClientCredentials credentials, string apiVersionOverride, params DelegatingHandler[] handlers) : this(baseUri, credentials, handlers)
        {
            if (!string.IsNullOrEmpty(apiVersionOverride))
            {
                this.ApiVersion = apiVersionOverride;
            }
        }
    }
}