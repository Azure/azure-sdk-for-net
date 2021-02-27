// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a wrapper over <see cref="Page{TOperations}"/>
    /// </summary>
    /// <typeparam name="TModel"> The type parameter we are wrapping. </typeparam>
    /// <typeparam name="TOperations"> The desired type parameter of the returned page. </typeparam>
    internal class WrappingPage<TModel, TOperations> : Page<TOperations>
        where TOperations : class
        where TModel : class
    {
        private readonly Func<TModel, TOperations> _converter;
        private readonly Page<TModel> _wrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="WrappingPage{TModel, TOperations}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        internal WrappingPage(Page<TModel> wrapped, Func<TModel, TOperations> converter)
        {
            _wrapped = wrapped;
            _converter = converter;
        }

        /// <inheritdoc/>
        public override IReadOnlyList<TOperations> Values => _wrapped.Values.Select(_converter).ToImmutableList();

        /// <inheritdoc/>
        public override string ContinuationToken => _wrapped.ContinuationToken;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _wrapped.GetRawResponse();
        }
    }
}
