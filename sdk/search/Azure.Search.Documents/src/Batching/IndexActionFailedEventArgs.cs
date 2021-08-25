// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Provides data for <see cref="SearchIndexingBufferedSender{T}.ActionCompleted"/>
    /// event.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema.  Instances of this type
    /// can be retrieved as documents from the index.  You can use
    /// <see cref="SearchDocument"/> for dynamic documents.
    /// </typeparam>
    public class IndexActionFailedEventArgs<T> : IndexActionEventArgs<T>
    {
        /// <summary>
        /// Gets the <see cref="IndexingResult"/> of an action that failed to
        /// complete.  The value might be null.
        /// </summary>
        public IndexingResult Result { get; }

        /// <summary>
        /// Gets the <see cref="Exception"/> caused by an action that failed to
        /// complete.  The value might be null.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="IndexActionCompletedEventArgs{T}"/> class.
        /// </summary>
        /// <param name="sender">
        /// The <see cref="SearchIndexingBufferedSender{T}"/> raising the event.
        /// </param>
        /// <param name="action">
        /// The <see cref="IndexDocumentsAction{T}"/> that failed.
        /// </param>
        /// <param name="result">
        /// The <see cref="IndexingResult"/> of an action that failed to
        /// complete.
        /// </param>
        /// <param name="exception">
        /// the <see cref="Exception"/> caused by an action that failed to
        /// complete.
        /// </param>
        /// <param name="isRunningSynchronously">
        /// A value indicating whether the event handler was invoked
        /// synchronously or asynchronously.  Please see
        /// <see cref="Azure.Core.SyncAsyncEventHandler{T}"/> for more details.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token related to the original operation that raised
        /// the event.  It's important for your handler to pass this token
        /// along to any asynchronous or long-running synchronous operations
        /// that take a token so cancellation will correctly propagate.  The
        /// default value is <see cref="CancellationToken.None"/>.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="sender"/> or <paramref name="action"/>
        /// are null.
        /// </exception>
        public IndexActionFailedEventArgs(
            SearchIndexingBufferedSender<T> sender,
            IndexDocumentsAction<T> action,
            IndexingResult result,
            Exception exception,
            bool isRunningSynchronously,
            CancellationToken cancellationToken = default)
            : base(sender, action, isRunningSynchronously, cancellationToken)
        {
            // Do not validate - either might be null
            Result = result;
            Exception = exception;
        }
    }
}
