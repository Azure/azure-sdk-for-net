// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Search.Documents.Indexes;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Provides the configuration options for
    /// <see cref="SearchIndexingBufferedSender{T}"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type
    /// can be retrieved as documents from the index.
    /// </typeparam>
    public class SearchIndexingBufferedSenderOptions<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the sender should
        /// automatically flush any indexing actions that have been added.
        /// This will happen when the batch is full or when the
        /// <see cref="AutoFlushInterval"/> has elapsed.  The default value is
        /// <see langword="true"/>.
        /// </summary>
        public bool AutoFlush { get; set; } = true;

        /// <summary>
        /// Gets or sets an optional amount of time to wait before
        /// automatically flushing any remaining indexing actions.  The default
        /// value is 60 seconds.
        /// </summary>
        public TimeSpan? AutoFlushInterval { get; set; } = TimeSpan.FromSeconds(60);

        /// <summary>
        /// Gets or sets a <see cref="CancellationToken"/> to use when
        /// submitting indexing actions.
        /// </summary>
        public CancellationToken FlushCancellationToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the initial number of actions to
        /// group into a batch when tuning the behavior of the sender.  The
        /// default value will be 512 if unset.  The current service maximum is
        /// 32000.
        /// </summary>
        public int? InitialBatchActionCount { get; set; }
        internal const int DefaultInitialBatchActionCount = 512;

        /// <summary>
        /// Gets or sets a value indicating the number of bytes to use when
        /// tuning the behavior of the sender.  The default value is 512.  The
        /// current service maximum is 32000.
        /// </summary>
        internal int? BatchPayloadSize { get; set; } = DefaultBatchPayloadSize;
        internal const int DefaultBatchPayloadSize = 500 * 1024;

        /// <summary>
        /// Gets or sets the number of times to retry a failed document.  Note
        /// that this is different than <see cref="Azure.Core.RetryOptions.MaxRetries"/>
        /// which will try to resend the same request.  This property is used
        /// to control the number of attempts we will make to submit an indexing
        /// action.
        /// </summary>
        public int MaxRetries { get; set; } = 3;

        /// <summary>
        /// The initial retry delay. The delay will increase exponentially with
        /// subsequent retries and add random jitter.  Note that this is
        /// different than <see cref="Azure.Core.RetryOptions.Delay"/> which
        /// will only delay before resending the same request.  This property
        /// is used to add delay between additional batch submissions when our
        /// requests are being throttled by the service.
        /// </summary>
        public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(0.8);

        /// <summary>
        /// The maximum permissible delay between retry attempts.  Note that
        /// this is different than <see cref="Azure.Core.RetryOptions.MaxDelay"/>
        /// which will only delay before resending the same request.  This
        /// property is used to add delay between additional batch
        /// submissions when our requests are being throttled by the service.
        /// </summary>
        public TimeSpan MaxRetryDelay { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Gets or sets a function that can be used to access the index key
        /// value of a document.  Any indexing errors are identified by key and
        /// you can use this function to provide that mapping.  Otherwise we
        /// will look for <see cref="SimpleFieldAttribute.IsKey"/> or call
        /// <see cref="SearchIndexClient.GetIndex(string, CancellationToken)"/>
        /// to help automatically determine the key.
        /// </summary>
        public Func<T, string> KeyFieldAccessor { get; set; }
    }
}
