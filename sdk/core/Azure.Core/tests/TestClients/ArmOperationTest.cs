// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace Azure.Core.Tests
{
    public class ArmOperationTest<T> : ArmOperation<T>
        where T : class
    {
        private readonly ResourceOperationsBase _operations;

        protected ArmOperationTest()
        {
        }

        internal ArmOperationTest(ResourceOperationsBase operations, Response<T> response)
            : base(response)
        {
            _operations = operations;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateResourceGroupOperation"/> class.
        /// </summary>
        /// <param name="operations"> The arm operations object to copy from. </param>
        /// <param name="request"> The original request. </param>
        /// <param name="response"> The original response. </param>
        internal ArmOperationTest(ResourceOperationsBase operations, Request request, Response response)
            : base(operations,
                  request,
                  response,
                  OperationFinalStateVia.Location,
                  "UpdateResourceGroupOperation")
        {
            _operations = operations;
        }

        public override T CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var method = typeof(T).GetMethods().FirstOrDefault(m => m.Name.StartsWith("Deserialize", StringComparison.InvariantCulture) && !m.IsPublic && m.IsStatic);
            return method.Invoke(null, new object[] { document.RootElement }) as T;
        }

        public async override ValueTask<T> CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var method = typeof(T).GetMethods().FirstOrDefault(m => m.Name.StartsWith("Deserialize", StringComparison.InvariantCulture) && !m.IsPublic && m.IsStatic);
            return method.Invoke(null, new object[] { document.RootElement }) as T;
        }
    }
}
