// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Generic ARM long running operation class for operations with no returned value
    /// </summary>
    internal sealed class VoidArmOperation : ArmOperation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoidArmOperation"/> class.
        /// </summary>
        /// <param name="response"> The response which has no body. </param>
        internal VoidArmOperation(Response response)
            : base(response)
        {
        }
    }
}
