// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    internal class ValueArmOperation<TOperations> : ArmOperation<TOperations>
    {
        internal ValueArmOperation(Response<TOperations> operation)
            : base(operation)
        {
        }
    }
}
