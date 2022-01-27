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
    [CodeGenSuppress("Tenant", typeof(ArmClient), typeof(TenantData))]
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
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        internal Tenant(ArmClient armClient) : this(armClient, ResourceIdentifier.Root)
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Tenant"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Tenant(ArmClient armClient, TenantData data) : this(armClient, ResourceIdentifier.Root)
        {
            HasData = true;
            _data = data;
        }

        /// <summary>
        /// Gets the management group operations object associated with the id.
        /// </summary>
        /// <param name="id"> The id of the management group operations. </param>
        /// <returns> A client to perform operations on the management group. </returns>
        internal ManagementGroup GetManagementGroup(ResourceIdentifier id)
        {
            return new ManagementGroup(ArmClient, id);
        }

        /// <summary> Gets an object representing a ManagementGroupCollection along with the instance operations that can be performed on it. </summary>
        /// <returns> Returns a <see cref="ManagementGroupCollection" /> object. </returns>
        public virtual ManagementGroupCollection GetManagementGroups()
        {
            return new ManagementGroupCollection(this);
        }
    }
}
