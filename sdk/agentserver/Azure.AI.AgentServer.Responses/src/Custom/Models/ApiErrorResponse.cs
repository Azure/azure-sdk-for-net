// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Hand-written: declared in the Azure.AI.Projects TypeSpec namespace, which the C# emitter
// does not emit into this package, but still part of the AgentServer.Responses error contract.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Responses;

namespace Azure.AI.AgentServer.Responses.Models
{
    /// <summary> Error response for API failures. </summary>
    public partial class ApiErrorResponse
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="ApiErrorResponse"/>. </summary>
        /// <param name="error"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="error"/> is null. </exception>
        public ApiErrorResponse(ApiError error)
        {
            Argument.AssertNotNull(error, nameof(error));

            Error = error;
        }

        /// <summary> Initializes a new instance of <see cref="ApiErrorResponse"/>. </summary>
        /// <param name="error"></param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal ApiErrorResponse(ApiError error, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Error = error;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Gets or sets the Error. </summary>
        public ApiError Error { get; set; }
    }
}
