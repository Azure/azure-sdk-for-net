// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Placeholder class, used to convert the gewneric type argument for a response from the underlyign rest API to the
    /// desired type argument in the response
    /// </summary>
    /// <typeparam name="TOperations"> The <see cref="ResourceOperationsBase"/> to convert the TModel into. </typeparam>
    /// <typeparam name="TModel"> The model returned by the existing serivce calls. </typeparam>
    public class PhArmResponse<TOperations, TModel> : ArmResponse<TOperations>
        where TOperations : class
        where TModel : class
    {
        private readonly Func<TModel, TOperations> _converter;
        private readonly Response<TModel> _wrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhArmResponse{TOperations, TModel}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public PhArmResponse(Response<TModel> wrapped, Func<TModel, TOperations> converter)
        {
            _wrapped = wrapped;
            _converter = converter;
        }

        /// <inheritdoc/>
        public override TOperations Value => _converter(_wrapped.Value);

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _wrapped.GetRawResponse();
        }
    }
}
