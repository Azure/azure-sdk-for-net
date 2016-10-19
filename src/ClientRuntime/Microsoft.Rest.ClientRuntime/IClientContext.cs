// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Rest
{
    /// <summary>
    /// The configuration information for clients targeting a service endpoint.
    /// </summary>
    public interface IClientContext : IDisposable
    {
        /// <summary>
        /// The credentials to use when authenticationg with service endpoints.
        /// </summary>
        ServiceClientCredentials Credentials { get; set; }

        /// <summary>
        /// The HttpClient used for communicating with the service.
        /// </summary>
        HttpClient HttpClient { get; }
        /// <summary>
        /// The message handler stack used in Http communication with the service.
        /// </summary>
        HttpMessageHandler Handler { get; }

        /// <summary>
        /// The HttpClientHandler used to communicate with the service.
        /// </summary>
        HttpClientHandler RootHandler { get; }

        /// <summary>
        /// Extended properties to set on created clients.  Clients created from this context will have access to these properties.
        /// </summary>
        IDictionary<string, object> ExtendedProperties { get; }

        /// <summary>
        /// Initialize a ServiceClient with the properties of this context.  This will set the Credentials, Http client infrastructure, 
        /// and any extended properties used by the client
        /// </summary>
        /// <typeparam name="T">The type of the client to initialize</typeparam>
        /// <param name="clientCreator">The client to initialize.</param>
        T InitializeServiceClient<T>(Func<IClientContext, T> clientCreator) where T : ServiceClient<T>;
    }
}
