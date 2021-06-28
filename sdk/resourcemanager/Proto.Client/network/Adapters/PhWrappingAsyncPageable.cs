// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Returns an AsyncPageable that transforms each page of contents  after they are retrieved from the server
    /// according to the profived transformation function
    /// </summary>
    /// <typeparam name="TModel"> The model returned by existing AsyncPageable methods. </typeparam>
    /// <typeparam name="TOperations"> The <see cref="ResourceOperationsBase"/> to convert TModel into. </typeparam>
    public class PhWrappingAsyncPageable<TModel, TOperations> : AsyncPageable<TOperations>
        where TOperations : class
        where TModel : class
    {
        private readonly Func<TModel, TOperations> _converter;
        private readonly IEnumerable<AsyncPageable<TModel>> _wrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhWrappingAsyncPageable{TModel, TOperations}"/> class for mocking.
        /// </summary>
        protected PhWrappingAsyncPageable()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhWrappingAsyncPageable{TModel, TOperations}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public PhWrappingAsyncPageable(AsyncPageable<TModel> wrapped, Func<TModel, TOperations> converter)
        {
            _wrapped = new[] { wrapped };
            _converter = converter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhWrappingAsyncPageable{TModel, TOperations}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public PhWrappingAsyncPageable(IEnumerable<AsyncPageable<TModel>> wrapped, Func<TModel, TOperations> converter)
        {
            _wrapped = wrapped;
            _converter = converter;
        }

        /// <inheritdoc/>
        public override async IAsyncEnumerable<Page<TOperations>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            foreach (var pageEnum in _wrapped)
            {
                await foreach (var page in pageEnum.AsPages().WithCancellation(CancellationToken))
                {
                    yield return new WrappingPage<TModel, TOperations>(page, _converter);
                }
            }
        }
    }
}
