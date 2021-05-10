// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    internal class ArmValueResponse<TOperations> : ArmResponse<TOperations>
    {
        private readonly ArmResponse _response;
        
        public ArmValueResponse(ArmResponse response, TOperations value)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            if (value is null)
                throw new ArgumentNullException(nameof(value));

            _response = response;
            Value = value;
        }

        public override TOperations Value { get; }

        public override Response GetRawResponse() => _response;
    }
}
