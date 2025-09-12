// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Generator.Management.Models
{
    internal static class ResourceOperationKindExtensions
    {
        public static bool IsCrudKind(this ResourceOperationKind kind)
        {
            return kind == ResourceOperationKind.Create ||
                   kind == ResourceOperationKind.Get ||
                   kind == ResourceOperationKind.Update ||
                   kind == ResourceOperationKind.Delete;
        }
    }
}
