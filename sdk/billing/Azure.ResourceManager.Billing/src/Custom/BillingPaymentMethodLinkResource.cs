// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Billing
{
    // The 2024-04-01 TypeSpec drops PaymentMethods_DeleteAtBillingProfile, but the GA
    // surface still exposes BillingPaymentMethodLinkResource.Delete/DeleteAsync (hidden
    // via EditorBrowsable). Inline the HTTP shim here against the original 2021-10-01
    // endpoint so callers compiled against the GA library keep working.
    public partial class BillingPaymentMethodLinkResource
    {
        /// <summary>
        /// Deletes a payment method link and removes the payment method from a billing profile. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/paymentMethodLinks/{paymentMethodName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PaymentMethods_DeleteAtBillingProfile</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingPaymentMethodLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _paymentMethodsClientDiagnostics.CreateScope("BillingPaymentMethodLinkResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = CreateDeleteAtBillingProfileRequest(Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "Location", null, OperationFinalStateVia.Location.ToString());
                BillingArmOperation operation = new BillingArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
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
        /// Deletes a payment method link and removes the payment method from a billing profile. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/paymentMethodLinks/{paymentMethodName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PaymentMethods_DeleteAtBillingProfile</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingPaymentMethodLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _paymentMethodsClientDiagnostics.CreateScope("BillingPaymentMethodLinkResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = CreateDeleteAtBillingProfileRequest(Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
                Response response = Pipeline.ProcessMessage(message, context);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "Location", null, OperationFinalStateVia.Location.ToString());
                BillingArmOperation operation = new BillingArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateDeleteAtBillingProfileRequest(string billingAccountName, string billingProfileName, string paymentMethodName)
        {
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Delete;
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(Endpoint);
            uri.AppendPath("/providers/Microsoft.Billing/billingAccounts/", false);
            uri.AppendPath(billingAccountName, true);
            uri.AppendPath("/billingProfiles/", false);
            uri.AppendPath(billingProfileName, true);
            uri.AppendPath("/paymentMethodLinks/", false);
            uri.AppendPath(paymentMethodName, true);
            uri.AppendQuery("api-version", "2021-10-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }
    }
}
