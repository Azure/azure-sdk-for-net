// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Cdn.Models;

namespace Azure.ResourceManager.Cdn
{
    // Custom: Adds CreateOrUpdate/CreateOrUpdateAsync methods that are missing because
    // the TypeSpec uses ArmCreateOperation (Foundations template) instead of the standard
    // ArmResourceCreateOrReplaceAsync, causing the generator to omit these methods.
    public partial class CdnCustomDomainCollection
    {
        /// <summary>
        /// Creates a new custom domain within an endpoint.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CustomDomains_Create. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="content"> Properties required to create a new custom domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<CdnCustomDomainResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string customDomainName, CdnCustomDomainCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _customDomainsClientDiagnostics.CreateScope("CdnCustomDomainCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _customDomainsRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, CdnCustomDomainCreateOrUpdateContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                CdnArmOperation<CdnCustomDomainResource> operation = new CdnArmOperation<CdnCustomDomainResource>(
                    new CdnCustomDomainOperationSource(Client),
                    _customDomainsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a new custom domain within an endpoint.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/customDomains/{customDomainName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CustomDomains_Create. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="customDomainName"> Name of the custom domain within an endpoint. </param>
        /// <param name="content"> Properties required to create a new custom domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="customDomainName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="customDomainName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<CdnCustomDomainResource> CreateOrUpdate(WaitUntil waitUntil, string customDomainName, CdnCustomDomainCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customDomainName, nameof(customDomainName));
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _customDomainsClientDiagnostics.CreateScope("CdnCustomDomainCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _customDomainsRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, customDomainName, CdnCustomDomainCreateOrUpdateContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                CdnArmOperation<CdnCustomDomainResource> operation = new CdnArmOperation<CdnCustomDomainResource>(
                    new CdnCustomDomainOperationSource(Client),
                    _customDomainsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
