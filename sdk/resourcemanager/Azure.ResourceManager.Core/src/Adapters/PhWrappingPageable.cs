// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// This class allows performing conversions on pages of data as they are accessed - used in the prototype to convett
    /// between underlying model types and the new model types that extend Resource,
    /// and also for returning Operations classes for those underlying objects.
    /// </summary>
    /// <typeparam name="TModel"> The type parameter of the Pageable we are wrapping. </typeparam>
    /// <typeparam name="TOperations"> The desired type parameter of the returned pageable. </typeparam>
    public class PhWrappingPageable<TModel, TOperations> : Pageable<TOperations>
        where TOperations : class
        where TModel : class
    {
        private readonly Func<TModel, TOperations> _converter;
        private readonly IEnumerable<Pageable<TModel>> _wrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhWrappingPageable{TModel, TOperations}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public PhWrappingPageable(Pageable<TModel> wrapped, Func<TModel, TOperations> converter)
        {
            _wrapped = new[] { wrapped };
            _converter = converter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhWrappingPageable{TModel, TOperations}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public PhWrappingPageable(IEnumerable<Pageable<TModel>> wrapped, Func<TModel, TOperations> converter)
        {
            _wrapped = wrapped;
            _converter = converter;
        }

        /// <inheritdoc/>
        public override IEnumerable<Page<TOperations>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            foreach (var pages in _wrapped)
            {
                foreach (var page in pages.AsPages())
                {
                    yield return new WrappingPage<TModel, TOperations>(page, _converter);
                }
            }
        }
    }
}
