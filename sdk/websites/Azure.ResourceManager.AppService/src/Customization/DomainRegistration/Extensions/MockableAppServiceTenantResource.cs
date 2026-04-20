// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService.Mocking
{
    public partial class MockableAppServiceTenantResource : ArmResource
    {
        private ClientDiagnostics _domainRegistrationProviderClientDiagnostics;
        private DomainRegistrationProviderRestOperations _domainRegistrationProviderRestClient;
        private ClientDiagnostics DomainRegistrationProviderClientDiagnostics => _domainRegistrationProviderClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.AppService", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private DomainRegistrationProviderRestOperations DomainRegistrationProviderRestClient => _domainRegistrationProviderRestClient ??= new DomainRegistrationProviderRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        /// <summary>
        /// Description for Implements Csm operations Api to exposes the list of available Csm Apis under the resource provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.DomainRegistration/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DomainRegistrationProvider_ListOperations</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CsmOperationDescription"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CsmOperationDescription> GetOperationsDomainRegistrationProvidersAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => DomainRegistrationProviderRestClient.CreateListOperationsRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DomainRegistrationProviderRestClient.CreateListOperationsNextPageRequest(nextLink);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => CsmOperationDescription.DeserializeCsmOperationDescription(e), DomainRegistrationProviderClientDiagnostics, Pipeline, "MockableAppServiceTenantResource.GetOperationsDomainRegistrationProviders", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Description for Implements Csm operations Api to exposes the list of available Csm Apis under the resource provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.DomainRegistration/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DomainRegistrationProvider_ListOperations</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CsmOperationDescription"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CsmOperationDescription> GetOperationsDomainRegistrationProviders(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => DomainRegistrationProviderRestClient.CreateListOperationsRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DomainRegistrationProviderRestClient.CreateListOperationsNextPageRequest(nextLink);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => CsmOperationDescription.DeserializeCsmOperationDescription(e), DomainRegistrationProviderClientDiagnostics, Pipeline, "MockableAppServiceTenantResource.GetOperationsDomainRegistrationProviders", "value", "nextLink", cancellationToken);
        }
    }
}
