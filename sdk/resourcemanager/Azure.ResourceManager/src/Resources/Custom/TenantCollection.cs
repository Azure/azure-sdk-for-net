// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing collection of TenantResource and their operations over their parent.
    /// </summary>
    [CodeGenSuppress("Get", typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(CancellationToken))]
    [CodeGenSuppress("Exists", typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(CancellationToken))]
    public partial class TenantCollection : ArmCollection, IEnumerable<TenantResource>, IAsyncEnumerable<TenantResource>
    {
        /// <summary> Initializes a new instance of the <see cref="TenantCollection"/> class. </summary>
        /// <param name="client"> The resource representing the parent resource. </param>
        internal TenantCollection(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }
    }
}
