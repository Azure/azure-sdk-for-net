// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Administration
{
    /// <summary>
    /// The Azure Communication Services phone number administration client.
    /// </summary>
    public partial class PhoneNumbersClient
    {
        internal ClientDiagnostics ClientDiagnostics { get; private set; }

        /// <summary> Initializes a new instance of <see cref="PhoneNumbersClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public PhoneNumbersClient(Uri endpoint, AzureKeyCredential keyCredential, CommunicationIdentityClientOptions? options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)),
                options ?? new CommunicationIdentityClientOptions(),
                AssertNotNull(keyCredential, nameof(keyCredential)))
        { }

        /// <summary>
        /// <summary> Initializes a new instance of <see cref="PhoneNumbersClient"/>.</summary>
        /// </summary>
        public PhoneNumbersClient(string connectionString, PhoneNumbersClientOptions? options = default)
            : this(
                  options ?? new PhoneNumbersClientOptions(),
                  ConnectionString.Parse(AssertNotNull(connectionString, nameof(connectionString))))
        { }

        internal PhoneNumbersClient(PhoneNumbersClientOptions options, ConnectionString connectionString)
            : this(new ClientDiagnostics(options), options.BuildHttpPipeline(connectionString), connectionString.GetRequired("endpoint"))
        { }

        internal PhoneNumbersClient(Uri endpoint, CommunicationIdentityClientOptions options, AzureKeyCredential credential)
        {
            ClientDiagnostics = new ClientDiagnostics(options);
            RestClient = new PhoneNumbersRestClient(
                ClientDiagnostics,
                options.BuildHttpPipeline(credential),
                endpoint.AbsoluteUri);
        }

        private static T AssertNotNull<T>(T argument, string argumentName)
            where T : class
        {
            Argument.AssertNotNull(argument, argumentName);
            return argument;
        }

        internal virtual Task<Response<PhoneNumberSearchResult>> GetSearchResultAsync(string searchId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Response<PhoneNumberSearchResult> GetSearchResult(string searchId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Task<Response<PhoneNumberOperation>> GetOperationAsync(string operationId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Response<PhoneNumberOperation> GetOperation(string operationId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Task<Response> CancelOperationAsync(string operationId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Response CancelOperation(string operationId, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    }
}
