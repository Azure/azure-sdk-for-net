// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        /// <summary>
        /// Initializes a phone number administration client with an Azure resource connection string.
        /// </summary>
        public PhoneNumbersClient(string connectionString)
            : this(new PhoneNumbersClientOptions(), ConnectionString.Parse(connectionString))
        { }

        /// <summary>
        /// Initializes a phone number administration client with an Azure resource connection string and client options.
        /// </summary>
        public PhoneNumbersClient(string connectionString, PhoneNumbersClientOptions? options = default)
            : this(
                  options ?? new PhoneNumbersClientOptions(),
                  ConnectionString.Parse(connectionString))
        { }

        internal PhoneNumbersClient(PhoneNumbersClientOptions options, ConnectionString connectionString)
            : this(new ClientDiagnostics(options), options.BuildHttpPipline(connectionString), connectionString.GetRequired("endpoint"))
        { }

        internal virtual Task<Response<PhoneNumberSearchResult>> GetSearchResultAsync(string searchId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Response<PhoneNumberSearchResult> GetSearchResult(string searchId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Task<Response<PhoneNumberOperation>> GetOperationAsync(string operationId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Response<PhoneNumberOperation> GetOperation(string operationId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Task<Response> CancelOperationAsync(string operationId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

        internal virtual Response CancelOperation(string operationId, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    }
}
