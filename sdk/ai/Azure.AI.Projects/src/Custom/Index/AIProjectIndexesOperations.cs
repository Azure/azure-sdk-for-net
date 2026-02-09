// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    public partial class AIProjectIndexesOperations
    {
        /// <summary>
        /// Create a new or update an existing Index
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the Index to create or update. </param>
        /// <param name="index"> The index to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="index"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult<AIProjectIndex> CreateOrUpdate(string name, string version, AIProjectIndex index, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(index, nameof(index));

            RequestOptions options = cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null;
            BinaryContent content = BinaryContent.Create(index);

            ClientResult result = CreateOrUpdate(name, version, content, options);
            return ClientResult.FromValue((AIProjectIndex)result, result.GetRawResponse());
        }

        /// <summary>
        /// Create a new or update an existing Index
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the Index to create or update. </param>
        /// <param name="index"> The index to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="index"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult<AIProjectIndex>> CreateOrUpdateAsync(string name, string version, AIProjectIndex index, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(index, nameof(index));

            RequestOptions options = cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null;
            BinaryContent content = BinaryContent.Create(index);

            ClientResult result = await CreateOrUpdateAsync(name, version, content, options).ConfigureAwait(false);
            return ClientResult.FromValue((AIProjectIndex)result, result.GetRawResponse());
        }
    }
}
