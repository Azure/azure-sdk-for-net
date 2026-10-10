// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Provisioning.Network;

internal static class ResourceTypeCompatibility
{
    internal static BicepValue<ResourceType> FromType(BicepValue<string> type)
    {
        IBicepValue source = type;
        BicepValue<ResourceType> result;
        switch (source.Kind)
        {
            case BicepValueKind.Literal:
                result = new(type.Value is null ? default : new ResourceType(type.Value));
                break;
            case BicepValueKind.Expression:
                result = source.Expression;
                break;
            case BicepValueKind.Unset:
                result = new(default(ResourceType));
                result.ClearValue();
                break;
            default:
                throw new InvalidOperationException($"Unknown {nameof(BicepValueKind)}: {source.Kind}.");
        }

        // Preserve the reference without resolving it before the model is attached to a resource.
        IBicepValue alias = result;
        alias.Self = source.Self ?? source.Source;
        alias.SetReadOnly();
        return result;
    }
}
