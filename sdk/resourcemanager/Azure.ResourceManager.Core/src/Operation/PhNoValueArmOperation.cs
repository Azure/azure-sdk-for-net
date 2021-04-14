// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A calss representing an arm operation wrapper object.
    /// </summary>
    internal class PhNoValueArmOperation : ArmOperation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrapped"></param>
        public PhNoValueArmOperation(Response wrapped)
            :base(wrapped)
        {
        }

        /// <inheritdoc/>
        public override Response CreateResult(Response response, CancellationToken cancellationToken)
        {
            return response;
        }

        /// <inheritdoc/>
        public override ValueTask<Response> CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            return new ValueTask<Response>(response);
        }
    }
}
