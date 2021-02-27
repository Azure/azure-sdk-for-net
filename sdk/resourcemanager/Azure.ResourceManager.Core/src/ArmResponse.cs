// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public ArmResponse(Response response)
        {
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
}
