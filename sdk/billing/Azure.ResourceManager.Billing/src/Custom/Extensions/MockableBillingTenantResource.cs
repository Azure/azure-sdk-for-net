// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Billing.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Mocking
{
    // Workaround for MPG generator bug that emits invalid
    //   IEnumerable<T>.ToRequestContent(parameters)  — https://github.com/Azure/azure-sdk-for-net/issues/57716
    // for body parameter types that are not models. The [CodeGenSuppress]-ed methods below
    // are replaced by hand-written equivalents that call BillingRequestContentHelper.
    // TODO: remove the [CodeGenSuppress] attributes + replacement methods once the upstream
    //       generator fix ships and the next regen no longer emits the broken calls.
    [CodeGenSuppress("DownloadDocumentsByBillingSubscriptionAsync", typeof(WaitUntil), typeof(string), typeof(IEnumerable<BillingDocumentDownloadRequestContent>), typeof(CancellationToken))]
    [CodeGenSuppress("DownloadDocumentsByBillingSubscription", typeof(WaitUntil), typeof(string), typeof(IEnumerable<BillingDocumentDownloadRequestContent>), typeof(CancellationToken))]
    public partial class MockableBillingTenantResource
    {
        /// <summary> Downloads multiple invoice documents as a zip file for a billing subscription. </summary>
        public virtual async Task<ArmOperation<BillingDocumentDownloadResult>> DownloadDocumentsByBillingSubscriptionAsync(WaitUntil waitUntil, string subscriptionId, IEnumerable<BillingDocumentDownloadRequestContent> parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = InvoicesClientDiagnostics.CreateScope("MockableBillingTenantResource.DownloadDocumentsByBillingSubscription");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = InvoicesRestClient.CreateDownloadDocumentsByBillingSubscriptionRequest(subscriptionId, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                BillingArmOperation<BillingDocumentDownloadResult> operation = new BillingArmOperation<BillingDocumentDownloadResult>(
                    new BillingDocumentDownloadResultOperationSource(),
                    InvoicesClientDiagnostics,
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

        /// <summary> Downloads multiple invoice documents as a zip file for a billing subscription. </summary>
        public virtual ArmOperation<BillingDocumentDownloadResult> DownloadDocumentsByBillingSubscription(WaitUntil waitUntil, string subscriptionId, IEnumerable<BillingDocumentDownloadRequestContent> parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = InvoicesClientDiagnostics.CreateScope("MockableBillingTenantResource.DownloadDocumentsByBillingSubscription");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = InvoicesRestClient.CreateDownloadDocumentsByBillingSubscriptionRequest(subscriptionId, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response response = Pipeline.ProcessMessage(message, context);
                BillingArmOperation<BillingDocumentDownloadResult> operation = new BillingArmOperation<BillingDocumentDownloadResult>(
                    new BillingDocumentDownloadResultOperationSource(),
                    InvoicesClientDiagnostics,
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
