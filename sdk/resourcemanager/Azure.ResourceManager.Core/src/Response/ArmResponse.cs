// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a response object from azure resource manager service.
    /// </summary>
    public abstract class ArmResponse : Response
    {
        /// <summary>
        /// Creates a new instance of <see cref="ArmResponse{TOperations}"/> with the provided value and HTTP response.
        /// </summary>
        /// <typeparam name="TOperations"> The type of the value. </typeparam>
        /// <param name="value"> The value. </param>
        /// <param name="response"> The HTTP response. </param>
        /// <returns> A new instance of <see cref="ArmResponse{TOperations}"/> with the provided value and HTTP response. </returns>
        /// <exception cref="ArgumentNullException"> Throws if response or value are null. </exception>
        public static new ArmResponse<TOperations> FromValue<TOperations>(TOperations value, Response response)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (response is null)
                throw new ArgumentNullException(nameof(response));

            return new ArmValueResponse<TOperations>(response, value);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ArmResponse"/> with the provided value and HTTP response.
        /// </summary>
        /// <param name="response"> The HTTP response. </param>
        /// <returns> A new instance of <see cref="ArmResponse"/> with the provided value and HTTP response. </returns>
        /// <exception cref="ArgumentNullException"> Throws if response is null. </exception>
        public static ArmResponse FromResponse(Response response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            return new ArmVoidResponse(response);
        }

        /// <summary>
        /// Gets the correlation id from x-ms-correlation-id.
        /// </summary>
        public string CorrelationId
        {
            get
            {
                string correlationId = null;
                Headers.TryGetValue("x-ms-correlation-id", out correlationId);
                return correlationId;
            }
        }
    }

    /// <summary>
    /// A class representing a response object from azure resource manager service.
    /// </summary>
    /// <typeparam name="TOperations"> The operations object return by the api call. </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Allowed when we have a generic version of the same type")]
    public abstract class ArmResponse<TOperations> : Response<TOperations>
    {
        /// <summary>
        /// Returns the value of this <see cref="ArmResponse{TOperations}"/> object.
        /// </summary>
        /// <param name="response">The <see cref="ArmResponse{TOperations}"/> instance.</param>
        public static implicit operator TOperations(ArmResponse<TOperations> response) => response.Value;

        /// <summary>
        /// Gets the correlation id from x-ms-correlation-id.
        /// </summary>
        public string CorrelationId
        {
            get
            {
                string correlationId = null;
                GetRawResponse().Headers.TryGetValue("x-ms-correlation-id", out correlationId);
                return correlationId;
            }
        }
    }
}
