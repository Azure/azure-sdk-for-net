// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;

namespace Azure.Communication.Administration
{
    /// <summary>
    /// Represent a long-running phone number search purchase operation.
    /// </summary>
    public class PhoneNumberSearchPurchaseOperation : Operation<PhoneNumberSearch>
    {
        private PhoneNumberSearchOperation _searchOperation;

        /// <summary>
        /// Initializes a new <see cref="PhoneNumberSearchPurchaseOperation"/> instance
        /// </summary>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="phoneNumberSearchId">The search ID of this operation.</param>
        /// <param name="initialResponse">The original server response on start operation request.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        internal PhoneNumberSearchPurchaseOperation(
            PhoneNumberAdministrationClient client,
            string phoneNumberSearchId,
            Response initialResponse,
            CancellationToken cancellationToken = default)
        {
            var terminateStatuses = new SearchStatus []
            {
                SearchStatus.Success,
                SearchStatus.Expired,
                SearchStatus.Cancelled,
                SearchStatus.Error
            };
            _searchOperation = new PhoneNumberSearchOperation(client, phoneNumberSearchId, initialResponse, terminateStatuses, cancellationToken);
        }

        /// <inheritdocs />
        public override string Id => _searchOperation.Id;

        /// <inheritdocs />
        public override PhoneNumberSearch Value => _searchOperation.Value;

        /// <inheritdocs />
        public override bool HasCompleted => _searchOperation.HasCompleted;

        /// <inheritdocs />
        public override bool HasValue => _searchOperation.HasValue;

        /// <inheritdocs />
        public override Response GetRawResponse()
        {
            return _searchOperation.GetRawResponse();
        }

        /// <inheritdocs />
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _searchOperation.UpdateStatus(cancellationToken);
        }

        /// <inheritdocs />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return _searchOperation.UpdateStatusAsync(cancellationToken);
        }

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberSearch>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            return _searchOperation.WaitForCompletionAsync(cancellationToken);
        }

        /// <inheritdocs />
        public override ValueTask<Response<PhoneNumberSearch>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            return _searchOperation.WaitForCompletionAsync(pollingInterval, cancellationToken);
        }
    }
}
