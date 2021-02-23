// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core.Adapters
{
    /// <summary>
    /// A class repreesnting an AsyncPageable that executes a given task before retrieving the first page of results
    /// </summary>
    /// <typeparam name="TOperations"> The type of <see cref="ResourceOperationsBase"/> that will be returned. </typeparam>
    public class PhTaskDeferringAsyncPageable<TOperations> : AsyncPageable<TOperations>
        where TOperations : notnull
    {
        private readonly Func<Task<AsyncPageable<TOperations>>> _task;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhTaskDeferringAsyncPageable{TOperations}"/> class.
        /// </summary>
        /// <param name="task"> The function to execute returning the AsyncPageable task. </param>
        public PhTaskDeferringAsyncPageable(Func<Task<AsyncPageable<TOperations>>> task)
        {
            _task = task;
        }

        /// <inheritdoc/>
        public override async IAsyncEnumerable<Page<TOperations>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            await foreach (var page in (await _task().ConfigureAwait(false)).AsPages().ConfigureAwait(false))
            {
                yield return page;
            }
        }
    }
}
