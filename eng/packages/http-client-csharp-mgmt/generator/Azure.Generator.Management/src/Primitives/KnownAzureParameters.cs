// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Threading;

namespace Azure.Generator.Management.Primitives
{
    internal class KnownAzureParameters
    {
        public static readonly ParameterProvider Response = new("response", $"The response from the service.", new CSharpType(typeof(Response)));

        public static readonly ParameterProvider WaitUntil = new("waitUntil", $"<see cref=\"WaitUntil.Completed\"/> if the method should wait to return until the long-running operation has completed on the service; <see cref=\"WaitUntil.Started\"/> if it should return after starting the operation. For more information on long-running operations, please see <see href=\"https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md\"> Azure.Core Long-Running Operation samples</see>.", new CSharpType(typeof(WaitUntil)));

        public static readonly ParameterProvider CancellationTokenWithoutDefault = new("cancellationToken", $"The cancellation token to use.", new CSharpType(typeof(CancellationToken)));
    }
}
