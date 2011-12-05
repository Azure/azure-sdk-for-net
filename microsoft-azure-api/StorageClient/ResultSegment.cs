//-----------------------------------------------------------------------
// <copyright file="ResultSegment.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the ResultSegment and ResultSegment[T] classes.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Represents a result segment that was retrieved from the total set of possible results.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Other class is a non-generic static helper with the same name.")]
    public class ResultSegment<TElement>
    {
        /// <summary>
        /// Stores the continuation token used to retrieve the next segment of results.
        /// </summary>
        private ResultContinuation continuationToken;

        /// <summary>
        /// Stores the closure used to retrieve the next set of results.
        /// </summary>
        private Func<Action<ResultSegment<TElement>>, TaskSequence> getNext;

        /// <summary>
        /// Stores the <see cref="RetryPolicy"/> used for requests.
        /// </summary>
        private RetryPolicy retryPolicy;

        /// <summary>
        /// Initializes a new instance of the ResultSegment class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="moreResults">If set to <c>true</c> there are more results.</param>
        /// <param name="getNext">The next result segment.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        internal ResultSegment(IEnumerable<TElement> result, bool moreResults, Func<Action<ResultSegment<TElement>>, TaskSequence> getNext, RetryPolicy retryPolicy)
        {
            this.Results = result;
            this.HasMoreResults = moreResults;
            this.getNext = getNext;
            this.retryPolicy = retryPolicy;
        }

        /// <summary>
        /// Gets an enumerable collection of results.
        /// </summary>
        /// <value>An enumerable collection of results.</value>
        public IEnumerable<TElement> Results { get; private set; }

        /// <summary>
        /// Gets a value indicating whether there are additional results to retrieve.
        /// </summary>
        /// <value><c>True</c> if there are additional results; otherwise, <c>false</c>.</value>
        public bool HasMoreResults { get; private set; }

        /// <summary>
        /// Gets a continuation token to use to retrieve the next set of results with a subsequent call to the operation.
        /// </summary>
        /// <value>The continuation token.</value>
        public ResultContinuation ContinuationToken
        {
            get
            {
                if (this.continuationToken != null && this.continuationToken.HasContinuation)
                {
                    return this.continuationToken;
                }

                return null;
            }

            internal set
            {
                this.continuationToken = value;
            }
        }

        /// <summary>
        /// Gets or sets the pagination information for Results.
        /// </summary>
        /// <value>The pagination.</value>
        internal ResultPagination Pagination { get; set; }

        /// <summary>
        /// Gets the retry policy.
        /// </summary>
        /// <value>The retry policy.</value>
        internal RetryPolicy RetryPolicy
        {
            get
            {
                return this.retryPolicy;
            }
        }

        /// <summary>
        /// Begins an asynchronous operation to retrieve the next result segment.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetNext(AsyncCallback callback, object state)
        {
            CommonUtils.AssertSegmentResultNotComplete<TElement>(this);

            return TaskImplHelper.BeginImplWithRetry<ResultSegment<TElement>>(this.GetNextImpl, this.retryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to retrieve the next result segment.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The next result segment.</returns>
        public ResultSegment<TElement> EndGetNext(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ResultSegment<TElement>>(asyncResult);
        }

        /// <summary>
        /// Gets the next result segment.
        /// </summary>
        /// <returns>The next result segment.</returns>
        public ResultSegment<TElement> GetNext()
        {
            CommonUtils.AssertSegmentResultNotComplete<TElement>(this);

            return TaskImplHelper.ExecuteImplWithRetry<ResultSegment<TElement>>(this.GetNextImpl, this.retryPolicy);
        }

        /// <summary>
        /// Implementation of GetNext (For symmetry with normal tasks.
        /// </summary>
        /// <param name="setResult">The action to set the results.</param>
        /// <returns>A <see cref="TaskSequence"/> representing the operation to get the next set of results.</returns>
        internal TaskSequence GetNextImpl(Action<ResultSegment<TElement>> setResult)
        {
            return this.getNext(setResult);
        }
    }

    /// <summary>
    /// Represents a helper class to support additional operations on ResultSegments 
    /// such as grouping of results into pages.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Other class is a generic class with the same name.")]
    internal static class ResultSegment
    {
        /// <summary>
        /// Checks if the result segment has more results in the current page if pagination is used.
        /// If pagination is not used, it checks if a valid continuation is present.
        /// </summary>
        /// <param name="pagination">The pagination.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <returns>
        /// Returns <c>true</c> if there are more results in the page; otherwise, <c>false</c>.
        /// </returns>
        internal static bool HasMoreResultsInPage(ResultPagination pagination, ResultContinuation continuationToken)
        {
            bool hasContinuation = HasContinuation(continuationToken);

            if (pagination.IsPagingEnabled)
            {
                return !pagination.IsPageCompleted && hasContinuation;
            }

            return hasContinuation;
        }

        /// <summary>
        /// Create a result segment from the result result.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="setResult">The set result.</param>
        /// <param name="resultList">The result list.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="pagination">The pagination.</param>
        /// <param name="retryPolicy">The retry policy.</param>
        /// <param name="continuationFunction">The continuation function.</param>
        internal static void CreateResultSegment<T>(
            Action<ResultSegment<T>> setResult,
            IEnumerable<T> resultList,
            ResultContinuation continuationToken,
            ResultPagination pagination,
            RetryPolicy retryPolicy,
            Func<ResultPagination, ResultContinuation, Action<ResultSegment<T>>, TaskSequence> continuationFunction)
        {
            pagination.UpdatePaginationForResult(resultList.Count());

            setResult(new ResultSegment<T>(
                resultList,
                HasMoreResultsInPage(pagination, continuationToken),
                (setResultInner) => continuationFunction(pagination, continuationToken, setResultInner),
                retryPolicy)
                {
                    ContinuationToken = continuationToken,
                });
        }

        /// <summary>
        /// Checks if the result segment passed in has a valid continuation token.
        /// </summary>
        /// <param name="continuation">The continuation.</param>
        /// <returns>
        /// Returns <c>true</c> if the specified continuation has continuation; otherwise, <c>false</c>.
        /// </returns>
        private static bool HasContinuation(ResultContinuation continuation)
        {
            return continuation != null && continuation.HasContinuation;
        }
    }
}
