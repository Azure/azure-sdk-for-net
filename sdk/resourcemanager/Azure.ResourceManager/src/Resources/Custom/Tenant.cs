// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources.Models;

[assembly:CodeGenSuppressType("TenantExtensions")]
namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    [CodeGenSuppress("Tenant", typeof(ArmResource), typeof(ResourceIdentifier))]
    [CodeGenSuppress("Tenant", typeof(ArmClientOptions), typeof(TokenCredential), typeof(Uri), typeof(HttpPipeline), typeof(ResourceIdentifier))]
    [CodeGenSuppress("Get", typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableLocations", typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableLocationsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetTenants")]
    [CodeGenSuppress("CreateResourceIdentifier")]
    public partial class Tenant : ArmResource
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="baseUri"> The base URI of the service. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        internal Tenant(ArmClientOptions options, TokenCredential credential, Uri baseUri, HttpPipeline pipeline)
            : base(new ClientContext(options, credential, baseUri, pipeline), ResourceIdentifier.Root)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _tenantsRestClient = new TenantsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
            _providersRestClient = new ProvidersRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary>
        /// Provides a way to reuse the protected client context.
        /// </summary>
        /// <typeparam name="T"> The actual type returned by the delegate. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns> Whatever the delegate returns. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual T UseClientContext<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, T> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }

        /// <summary>
        /// Gets the management group operations object associated with the id.
        /// </summary>
        /// <param name="id"> The id of the management group operations. </param>
        /// <returns> A client to perform operations on the management group. </returns>
        internal ManagementGroup GetManagementGroup(ResourceIdentifier id)
        {
            return new ManagementGroup(this, id);
        }

        // /// <summary>
        // /// Gets the subscription collection for this tenant.
        // /// </summary>
        // /// <returns> A collection of the subscriptions. </returns>
        // public virtual SubscriptionCollection GetSubscriptions()
        // {
        //     return new SubscriptionCollection(this);
        // }
    }
}
