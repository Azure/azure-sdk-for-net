// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    public class TenantOperations : OperationsBase
    {
        /// <summary>
        /// Gets The subscription to use for the tenant operations
        /// </summary>
        public Subscription Subscription {get; set;}
        /// <summary>
        /// The resource type for subscription
        /// </summary>
        public static readonly ResourceType ResourceType = "/tenants"; // placeholder pending on the outcome of ADO #5199

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="subscription"> The subscription to use for the tenant operations </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        internal TenantOperations(AzureResourceManagerClientOptions options, Subscription subscription, TokenCredential credential, Uri baseUri)
            : base(options, "/tenants", credential, baseUri)
        {
            Subscription = subscription;
        }

        /// <summary>
        /// Gets the valid resource type for this operation class
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;
    }
}
