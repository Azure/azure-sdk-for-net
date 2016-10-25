// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using Newtonsoft.Json;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// Interface for all Microsoft Azure clients.
    /// </summary>
    public interface IAzureClient
    {
        /// <summary>
        /// Gets Azure subscription credentials.
        /// </summary>
        ServiceClientCredentials Credentials { get; }

        /// <summary>
        /// Gets the HttpClient used for making HTTP requests.
        /// </summary>
        HttpClient HttpClient { get; }
        
        /// <summary>
        /// Gets or sets the retry timeout for Long Running Operations.
        /// </summary>
        int? LongRunningOperationRetryTimeout { get; set; }
        
        /// <summary>
        /// Gets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// When set to true a unique x-ms-client-request-id value
        /// is generated and included in each request. Default is true.
        /// </summary>
        bool? GenerateClientRequestId { get; set; }        
    }
}
