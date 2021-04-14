// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A calss representing an arm operation wrapper object.
    /// </summary>
    internal class PhValueArmOperation<TOperations> : ArmOperation<TOperations>
        where TOperations : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrapped"></param>
        public PhValueArmOperation(Response<TOperations> wrapped)
            :base(wrapped)
        {
        }

        /// <inheritdoc/>
        public override TOperations CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var method = typeof(TOperations).GetMethods().FirstOrDefault(m => m.Name.StartsWith("Deserialize", StringComparison.InvariantCulture) && !m.IsPublic && m.IsStatic);
            return method.Invoke(null, new object[] { document.RootElement }) as TOperations;
        }

        /// <inheritdoc/>
        public async override ValueTask<TOperations> CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var method = typeof(TOperations).GetMethods().FirstOrDefault(m => m.Name.StartsWith("Deserialize", StringComparison.InvariantCulture) && !m.IsPublic && m.IsStatic);
            return method.Invoke(null, new object[] { document.RootElement }) as TOperations;
        }
    }
}
