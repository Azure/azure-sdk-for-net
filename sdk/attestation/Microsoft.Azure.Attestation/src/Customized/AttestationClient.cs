// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System.Net.Http;

namespace Microsoft.Azure.Attestation
{
    public partial class AttestationClient : ServiceClient<AttestationClient>, IAttestationClient, IAzureClient
    {
        /// <summary>
        /// Initializes a new instance of the AttestationClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public AttestationClient(ServiceClientCredentials credentials)
            : this(credentials, (DelegatingHandler[])null)
        {
        }

        partial void CustomInitialize()
        {
            var firstHandler = this.FirstMessageHandler as DelegatingHandler;
            if (firstHandler == null) return;

            var customHandler = new CustomDelegatingHandler
            {
                InnerHandler = firstHandler.InnerHandler,
                Client = this,
            };

            firstHandler.InnerHandler = customHandler;
        }
    }
}
