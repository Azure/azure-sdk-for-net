// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing collection of Tenant and their operations over their parent.
    /// </summary>
    [CodeGenSuppress("TenantCollection", typeof(ArmResource))]
    [CodeGenSuppress("Get", typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("Exists", typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(CancellationToken))]
    public partial class TenantCollection : ArmCollection, IEnumerable<Tenant>, IAsyncEnumerable<Tenant>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantCollection"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        internal TenantCollection(ClientContext clientContext)
            : base(clientContext)
        {
        }
    }
}