// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing collection of resources and their operations over their parent.
    /// </summary>
    public class ProviderContainer : ResourceContainerBase<TenantResourceIdentifier, Provider, ProviderData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderContainer"/> class for mocking.
        /// </summary>
        protected ProviderContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderContainer"/> class.
        /// </summary>
        /// <param name="clientContext"> The client context to use. </param>
        /// <param name="id"> The id for the subscription that owns this container. </param>
        internal ProviderContainer(ClientContext clientContext, SubscriptionResourceIdentifier id)
            : base(clientContext, id)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        /// <inheritdoc/>
        protected override void Validate(ResourceIdentifier identifier)
        {
        }

        private ProviderRestOperations RestClient
        {
            get
            {
                string subscription;
                if (!Id.TryGetSubscriptionId(out subscription))
                {
                    subscription = Guid.Empty.ToString();
                }

                return new ProviderRestOperations(
                    Diagnostics,
                    Pipeline,
                    subscription,
                    BaseUri);
            }
        }

        /// <summary> Gets the specified resource provider. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ProviderData> Get(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProvidersOperations.Get");
            scope.Start();
            try
            {
                return RestClient.Get(resourceProviderNamespace, expand, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
