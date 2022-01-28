// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
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
        /// <summary> Initializes a new instance of the <see cref="TenantCollection"/> class. </summary>
        /// <param name="armClient"> The resource representing the parent resource. </param>
        internal TenantCollection(ArmClient armClient) : base(armClient, ResourceIdentifier.Root)
        {
            _tenantClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", Tenant.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(Tenant.ResourceType, out string tenantApiVersion);
            _tenantRestClient = new TenantsRestOperations(_tenantClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, tenantApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }
    }
}
