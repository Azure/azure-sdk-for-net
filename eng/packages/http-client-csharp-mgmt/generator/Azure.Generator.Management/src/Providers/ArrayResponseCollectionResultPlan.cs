// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;

namespace Azure.Generator.Management.Providers;

// Describes a real ARM array-wrapper placement without constructing its method body.
internal readonly record struct ArrayResponseCollectionResultPlan(
    TypeProvider EnclosingType,
    InputClient InputClient,
    InputServiceMethod Method,
    string? SyncName = null,
    string? AsyncName = null)
{
    internal static bool IsArrayResponse(InputServiceMethod method) =>
        method is not InputPagingServiceMethod && !method.IsLongRunningOperation() && method.GetResponseBodyType()?.IsList == true;

    internal IEnumerable<string> GetOriginalNames()
    {
        if (SyncName is not null && AsyncName is not null)
        {
            return [$"{EnclosingType.Name}{SyncName}CollectionResultOfT", $"{EnclosingType.Name}{AsyncName}CollectionResultOfT"];
        }

        // The upstream operation lookup builds every method on a client. Restrict this temporary,
        // uncached client to the eligible nonpaging operation so discovery cannot allocate regular
        // helpers recursively. Reuse upstream customization and final-provider back-compat naming.
        // Request visitors resolve methods through a cached input-client map. Populate it while
        // the full method list is visible; otherwise a temporary subset would poison later lookups.
        _ = ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(Method);
        var methods = InputClient.Methods;
        var methodName = Method.Name;
        var operationName = Method.Operation.Name;
        try
        {
            InputClient.Update(methods: [Method]);
            var client = new ManagementClientProvider(InputClient);
            var syncName = SyncName ?? client.GetConvenienceMethodByOperation(Method.Operation, false, EnclosingType).Signature.Name;
            var asyncName = AsyncName ?? client.GetConvenienceMethodByOperation(Method.Operation, true, EnclosingType).Signature.Name;
            return [$"{EnclosingType.Name}{syncName}CollectionResultOfT", $"{EnclosingType.Name}{asyncName}CollectionResultOfT"];
        }
        finally
        {
            InputClient.Update(methods: methods);
            Method.Update(name: methodName);
            Method.Operation.Update(name: operationName);
        }
    }
}
