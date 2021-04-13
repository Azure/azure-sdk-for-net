// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a response object from azure resource manager service.
    /// </summary>
    public sealed class ArmResponse : ArmResponse<Response>
    {
        private readonly Response _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmResponse"/> class.
        /// </summary>
        /// <param name="response"> The azure response object to wrap. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="Response"/> is null. </exception>
        public ArmResponse(Response response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            _response = response;
        }

        /// <inheritdoc/>
        public override Response Value => _response;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _response;
        }
    }

    /// <summary>
    /// A class representing a response object from azure resource manager service.
    /// </summary>
    /// <typeparam name="TOperations"> The operations object return by the api call. </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Allowed when we have a generic version of the same type")]
    public abstract class ArmResponse<TOperations> : Response<TOperations>
    {
    }

    /// <summary>
    /// Used to convert the generic type argument for a response from the underlining rest API to the
    /// desired type argument in the response
    /// </summary>
    /// <typeparam name="TOperations"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Allowed when we have a generic version of the same type")]
    public class ArmResponse<TOperations, TModel> : ArmResponse<TOperations>
    where TOperations : class
    where TModel : class
    {
        private readonly Func<TModel, TOperations> _converter;
        private readonly Response<TModel> _wrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmResponse{TOperations, TModel}"/> class for mocking.
        /// </summary>
        protected ArmResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmResponse{TOperations, TModel}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public ArmResponse(Response<TModel> wrapped, Func<TModel, TOperations> converter)
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
