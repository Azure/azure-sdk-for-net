// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagementGroups;

[assembly: CodeGenSuppressType("TenantExtensions")]
namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    [CodeGenSuppress("TenantResource", typeof(ArmClient), typeof(TenantData))]
    [CodeGenSuppress("Get", typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableLocations", typeof(CancellationToken))]
    [CodeGenSuppress("GetAvailableLocationsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetTenants")]
    [CodeGenSuppress("CreateResourceIdentifier")]
    // [CodeGenSuppress("_tenantsRestClient")] // TODO: not working for private member
    public partial class TenantResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref = "TenantResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        internal TenantResource(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TenantResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal TenantResource(ArmClient client, TenantData data) : this(client, ResourceIdentifier.Root)
        {
            HasData = true;
            _data = data;
        }
    }
}
