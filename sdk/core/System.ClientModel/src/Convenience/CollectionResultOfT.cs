// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// The collection values may be delivered over one or more service responses.
/// </summary>
public abstract class CollectionResult<T> : CollectionResult, IEnumerable<T>
{
    /// <summary>
    /// Creates a new instance of <see cref="CollectionResult{T}"/>.
    /// </summary>
    protected internal CollectionResult()
    {
    }

    /// <summary>
    /// Creates an instance of <see cref="CollectionResult{T}"/> using the
    /// provided pages of values.
    /// </summary>
    /// <param name="pages">The pages of values to include in the collection.
    /// Each element in <paramref name="pages"/> represents a single page of
    /// values.</param>
    /// <returns>A new instance of <see cref="CollectionResult{T}"/>.</returns>
    /// <remarks>
    /// <para>
    /// This factory method eagerly materializes all of the provided pages by
    /// buffering their contents into in-memory lists. As a result, the entire
    /// sequence of values will be loaded into memory up-front. This behavior
    /// makes the method suitable for testing or mocking scenarios, or for
    /// small data sets where the additional memory usage is acceptable.
    /// </para>
    /// <para>
    /// The raw pages returned by <see cref="CollectionResult.GetRawPages"/> and the
    /// <see cref="ContinuationToken"/> instances returned by
    /// <see cref="CollectionResult.GetContinuationToken(ClientResult)"/> are synthetic and are
    /// not derived from real service responses. They are constructed from
    /// in-memory data solely to provide a paged-programming model over the
    /// supplied values.
    /// </para>
    /// </remarks>
#pragma warning disable CA1000 // Do not declare static members on generic types
    public static CollectionResult<T> FromPages(IEnumerable<IEnumerable<T>> pages)
#pragma warning restore CA1000 // Do not declare static members on generic types
    {
        Argument.AssertNotNull(pages, nameof(pages));

        return new StaticCollectionResult(pages);
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (ClientResult page in GetRawPages())
        {
            foreach (T value in GetValuesFromPage(page))
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
    /// <remarks><see cref="CollectionResult{T}"/> implementations are expected
    /// to store the <see cref="CancellationToken"/> passed to the service
    /// method that creates them and pass that token to any methods making
    /// service calls that are called from this method.</remarks>
    protected abstract IEnumerable<T> GetValuesFromPage(ClientResult page);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class StaticCollectionResult : CollectionResult<T>
    {
        private readonly IReadOnlyList<IReadOnlyList<T>> _pages;

        public StaticCollectionResult(IEnumerable<IEnumerable<T>> pages)
        {
            _pages = pages.Select(p => (IReadOnlyList<T>)p.ToList()).ToList();
        }

        public override IEnumerable<ClientResult> GetRawPages()
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

        protected override IEnumerable<T> GetValuesFromPage(ClientResult page)
        {
            int pageIndex = GetPageIndex(page);
            return _pages[pageIndex];
        }

        private static int GetPageIndex(ClientResult page)
        {
            return ((StaticPipelineResponse)page.GetRawResponse()).PageIndex;
        }
    }
}
