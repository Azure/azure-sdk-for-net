// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core
{
    internal class ValueArmResponse<TOperations> : ArmResponse<TOperations>
    {
        private readonly ArmResponse _response;
        
        public ValueArmResponse(ArmResponse response, TOperations value)
        {
            _response = response;
            Value = value;
        }

        public override TOperations Value { get; }

        public override Response GetRawResponse() => _response;
    }
}
