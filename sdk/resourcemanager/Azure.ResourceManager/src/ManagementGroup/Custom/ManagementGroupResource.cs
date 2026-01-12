// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagementGroups.Models;
using Azure.ResourceManager.Resources;

[assembly:CodeGenSuppressType("SearchOptions")]
[assembly:CodeGenSuppressType("EntityViewOptions")]
[assembly:CodeGenSuppressType("TenantExtensions")] // Moved code to Custom/Tenant
[assembly:CodeGenSuppressType("AzureAsyncOperationResults")]
[assembly:CodeGenSuppressType("ErrorResponse")]
[assembly:CodeGenSuppressType("ErrorDetails")] // No target and additionalInfo properties, therefore it's not replaced by common type
[assembly:CodeGenSuppressType("ManagementGroupUpdateOperation")]
namespace Azure.ResourceManager.ManagementGroups
{
    /// <summary> A Class representing a ManagementGroup along with the instance operations that can be performed on it. </summary>
    [CodeGenSuppress("ManagementGroupResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public partial class ManagementGroupResource
    {
        private readonly ClientDiagnostics _policyDefinitionVersionsClientDiagnostics;
        private readonly ClientDiagnostics _policySetDefinitionVersionsClientDiagnostics;
        private readonly ClientDiagnostics _policyTokensClientDiagnostics;

        private readonly PolicySetDefinitionVersionsRestOperations _policySetDefinitionVersionsRestClient;
        private readonly PolicyDefinitionVersionsRestOperations _policyDefinitionVersionsRestClient;
        private readonly PolicyTokensRestOperations _policyTokensRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagementGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagementGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managementGroupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ManagementGroups", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string managementGroupApiVersion);
            _managementGroupRestClient = new ManagementGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, managementGroupApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
            _policyDefinitionVersionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, Diagnostics);
            _policySetDefinitionVersionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, Diagnostics);
            _policyTokensClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ProviderConstants.DefaultProviderNamespace, Diagnostics);

            _policyDefinitionVersionsRestClient = new PolicyDefinitionVersionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _policySetDefinitionVersionsRestClient = new PolicySetDefinitionVersionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _policyTokensRestClient = new PolicyTokensRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        }
    }
}
