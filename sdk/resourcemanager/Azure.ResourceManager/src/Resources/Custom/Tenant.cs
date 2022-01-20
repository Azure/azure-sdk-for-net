// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;

[assembly: CodeGenSuppressType("TenantExtensions")]
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
    // [CodeGenSuppress("_tenantsRestClient")] // TODO: not working for private member
    public partial class Tenant : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref = "Tenant"/> class. </summary>
        /// <param name="options"> The resource object to copy the client parameters from. </param>
        /// <param name="tenantData"> The data model representing the generic azure resource. </param>
        internal Tenant(ArmResource options, TenantData tenantData) : base(options, ResourceIdentifier.Root)
        {
            HasData = true;
            _data = tenantData;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(Provider.ResourceType, out var apiVersion);
            _tenantsRestClient = new TenantsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
            _providersRestClient = new ProvidersRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        internal Tenant(ArmClient client)
            : base(client, ResourceIdentifier.Root)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(Provider.ResourceType, out var apiVersion);
            _tenantsRestClient = new TenantsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
            _providersRestClient = new ProvidersRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
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

        /// <summary> Gets an object representing a ManagementGroupCollection along with the instance operations that can be performed on it. </summary>
        /// <returns> Returns a <see cref="ManagementGroupCollection" /> object. </returns>
        public virtual ManagementGroupCollection GetManagementGroups()
        {
            return new ManagementGroupCollection(this);
        }
    }
}
