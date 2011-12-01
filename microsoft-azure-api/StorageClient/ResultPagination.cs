//-----------------------------------------------------------------------
// <copyright file="ResultPagination.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the ResultPagination class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Represents a class which manages pagination of results.
    /// </summary>
    internal class ResultPagination
    {
        /// <summary>
        /// Stores the results remaining in the current page.
        /// </summary>
        private int? remainingResultsInPage;

        /// <summary>
        /// Stores the page size.
        /// </summary>
        private int maxResults;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultPagination"/> class.
        /// </summary>
        /// <param name="maxResults">Number of results to be returned as a page.
        /// maxResults of 0 or less means no paging.</param>
        public ResultPagination(int maxResults)
        {
            CommonUtils.AssertInBounds("maxResults", maxResults, 0, Int32.MaxValue);

            this.maxResults = maxResults <= 0 ? 0 : maxResults;
            if (this.maxResults > 0)
            {
                this.remainingResultsInPage = this.maxResults;
            }
        }

        /// <summary>
        /// Gets the maxResults in use for the current Pagination instance
        /// Returns zero if paging is not in use.
        /// </summary>
        /// <value>The size of the effective page.</value>
        internal int EffectivePageSize
        {
            get
            {
                return this.maxResults;
            }
        }

        /// <summary>
        /// Gets a value indicating whether paging is enabled with a valid postive page size. 
        /// An instance with a non positive page size will return false.
        /// </summary>
        internal bool IsPagingEnabled
        {
            get
            {
                return this.maxResults > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether there are no more remaining results in the current page.
        /// Will return false if paging is not enabled.
        /// </summary>
        internal bool IsPageCompleted
        {
            get
            {
                return this.remainingResultsInPage == 0;
            }
        }

        /// <summary>
        /// Gets the size for next request to pass in parameter like MaxResults.
        /// </summary>
        /// <returns>Postive value indicating size of a result page if using paging. 
        /// Else null is returned.</returns>
        internal int? GetNextRequestPageSize()
        {
            if (this.maxResults > 0)
            {
                this.remainingResultsInPage = this.remainingResultsInPage.GetValueOrDefault() == 0 ?
                    this.maxResults : this.remainingResultsInPage;
            }
            else
            {
                this.remainingResultsInPage = null;
            }

            return this.remainingResultsInPage;
        }

        /// <summary>
        /// Update pagination paramters for new result set returned.
        /// </summary>
        /// <param name="currentResultCount">The current result count.</param>
        internal void UpdatePaginationForResult(int currentResultCount)
        {
            if (this.maxResults > 0)
            {
                // We are using paging
                this.remainingResultsInPage = this.remainingResultsInPage.Value - currentResultCount;

                if (this.remainingResultsInPage < 0)
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.ServerReturnedMoreThanMaxResults);
                    throw new InvalidOperationException(errorMessage);
                }
            }
        }
    }
}
