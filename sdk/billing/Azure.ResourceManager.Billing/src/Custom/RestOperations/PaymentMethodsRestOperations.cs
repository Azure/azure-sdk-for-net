// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    internal partial class PaymentMethodsRestOperations
    {
        internal HttpMessage CreateDeleteAtBillingProfileRequest(string billingAccountName, string billingProfileName, string paymentMethodName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Billing/billingAccounts/", false);
            uri.AppendPath(billingAccountName, true);
            uri.AppendPath("/billingProfiles/", false);
            uri.AppendPath(billingProfileName, true);
            uri.AppendPath("/paymentMethodLinks/", false);
            uri.AppendPath(paymentMethodName, true);
            uri.AppendQuery("api-version", "2021-10-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Deletes a payment method link and removes the payment method from a billing profile. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> DeleteAtBillingProfileAsync(string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));
            Argument.AssertNotNullOrEmpty(billingProfileName, nameof(billingProfileName));
            Argument.AssertNotNullOrEmpty(paymentMethodName, nameof(paymentMethodName));

            using var message = CreateDeleteAtBillingProfileRequest(billingAccountName, billingProfileName, paymentMethodName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Deletes a payment method link and removes the payment method from a billing profile. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response DeleteAtBillingProfile(string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));
            Argument.AssertNotNullOrEmpty(billingProfileName, nameof(billingProfileName));
            Argument.AssertNotNullOrEmpty(paymentMethodName, nameof(paymentMethodName));

            using var message = CreateDeleteAtBillingProfileRequest(billingAccountName, billingProfileName, paymentMethodName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
