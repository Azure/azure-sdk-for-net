// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// The collection values may be delivered over one or more service responses.
/// </summary>
public abstract class AsyncCollectionResult<T> : AsyncCollectionResult, IAsyncEnumerable<T>
{
    /// <summary>
    /// Creates a new instance of <see cref="AsyncCollectionResult{T}"/>.
    /// </summary>
    protected internal AsyncCollectionResult()
    {
    }

    /// <summary>
    /// Creates an instance of <see cref="AsyncCollectionResult{T}"/> using the
    /// provided pages of values.
    /// </summary>
    /// <param name="pages">The pages of values to include in the collection.
    /// Each element in <paramref name="pages"/> represents a single page of
    /// values.</param>
    /// <returns>A new instance of <see cref="AsyncCollectionResult{T}"/>.</returns>
#pragma warning disable CA1000 // Do not declare static members on generic types
    public static AsyncCollectionResult<T> FromPages(IEnumerable<IEnumerable<T>> pages)
#pragma warning restore CA1000 // Do not declare static members on generic types
    {
        Argument.AssertNotNull(pages, nameof(pages));

        return new StaticAsyncCollectionResult(pages);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        await foreach (ClientResult page in GetRawPagesAsync().ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            await foreach (T value in GetValuesFromPageAsync(page).ConfigureAwait(false).WithCancellation(cancellationToken))
            {
                yield return value;
            }
        }
    }

    /// <summary>
    /// Gets a collection of the values returned in a page response.
    /// </summary>
    /// <param name="page">The service response to obtain the values from.
    /// </param>
    /// <returns>A collection of <typeparamref name="T"/> values read from the
    ///response content in <paramref name="page"/>.</returns>
    /// <remarks>This method does not take a <see cref="CancellationToken"/>
    /// parameter.  <see cref="AsyncCollectionResult{T}"/> implementations must
    /// store the <see cref="CancellationToken"/> passed to the service method
    /// that creates them and pass that token to any <c>async</c> methods
    /// called from this method.</remarks>
    protected abstract IAsyncEnumerable<T> GetValuesFromPageAsync(ClientResult page);

    private class StaticAsyncCollectionResult : AsyncCollectionResult<T>
    {
        private readonly IReadOnlyList<IReadOnlyList<T>> _pages;

        public StaticAsyncCollectionResult(IEnumerable<IEnumerable<T>> pages)
        {
            _pages = pages.Select(p => (IReadOnlyList<T>)p.ToList()).ToList();
        }

#pragma warning disable 1998 // async method lacks await
        public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
#pragma warning restore 1998
        {
            for (int i = 0; i < _pages.Count; i++)
            {
                PipelineResponse response = new StaticPipelineResponse(pageIndex: i);
                yield return ClientResult.FromResponse(response);
            }
        }

        public override ContinuationToken? GetContinuationToken(ClientResult page)
        {
            int pageIndex = GetPageIndex(page);

            if (pageIndex < _pages.Count - 1)
            {
                BinaryData tokenData = BinaryData.FromString(
                    (pageIndex + 1).ToString());
                return ContinuationToken.FromBytes(tokenData);
            }

            return null;
        }

#pragma warning disable 1998 // async method lacks await
        protected override async IAsyncEnumerable<T> GetValuesFromPageAsync(ClientResult page)
#pragma warning restore 1998
        {
            int pageIndex = GetPageIndex(page);

            foreach (T value in _pages[pageIndex])
            {
                yield return value;
            }
        }

        private static int GetPageIndex(ClientResult page)
        {
            return ((StaticPipelineResponse)page.GetRawResponse()).PageIndex;
        }
    }
}
