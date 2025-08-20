﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Extensions
{
    internal static class ClientProviderExtensions
    {
        public static MethodProvider GetConvenienceMethodByOperation(this ClientProvider clientProvider, InputOperation operation, bool isAsync)
        {
            var methods = clientProvider.GetMethodCollectionByOperation(operation);
            return isAsync ? methods[^1] : methods[^2];
        }
    }
}
