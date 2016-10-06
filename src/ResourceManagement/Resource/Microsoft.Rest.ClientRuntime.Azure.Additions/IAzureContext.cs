// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Rest.Azure
{
    /// Interface capturing the current Http state needed to communicate with Azure
    public interface IAzureContext
    {
        /// <summary>
        /// The Azure subscription to target. The value should be in the form of a globally-unique identifier (GUID).
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// The Azure tenant id to target.  The value should be in the form of a globally-unique identifier (GUID).
        /// </summary>
        string TenantId { get; set; }

        /// <summary>
        /// The credentials to use when authenticationg with Azure endpoints.
        /// </summary>
        ServiceClientCredentials Credentials { get; }

        /// <summary>
        /// The HttpClient used for communicating with Azure.
        /// </summary>
        HttpClient HttpClient { get; }

        /// <summary>
        /// The maximum time to spend in retrying transient HTTP errors.
        /// </summary>
        int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// Determines whether clients should automatically generate a client request id.  This id can be used to 
        /// retrieve logs for operations.
        /// </summary>
        bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// The message handler stack used in Http communication with Azure.
        /// </summary>
        HttpMessageHandler Handler { get; }

        /// <summary>
        /// The HttpClientHandler used to communicate with Azure.
        /// </summary>
        HttpClientHandler RootHandler { get; }

        /// <summary>
        /// Extended properties to set on created clients.  Clients created from this context will have access to these properties.
        /// </summary>
        IDictionary<string, string> ExtendedProperties { get; }

        /// <summary>
        /// Initialize a ServiceClient with the properties of this context.  This will set the SubscriptionId, ClientId, 
        /// and any extended properties used by the client
        /// </summary>
        /// <typeparam name="T">The type of the client to initialize</typeparam>
        /// <param name="clientCreator">The client to initialize.</param>
        T InitializeServiceClient<T>(Func<T> clientCreator) where T : ServiceClient<T>;
    }
}
