// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;

namespace Azure.Generator.Management.Utilities;

/// <summary>
/// Detects the synthetic <c>Azure.ResourceManager.@hasClientNameOverride</c> decorator
/// stamped by the mgmt emitter on inputs whose underlying TypeSpec entity carries a
/// user-supplied <c>@@clientName</c> override (csharp scope or unscoped). The emitter
/// pre-resolves the override via TCGC's <c>getClientNameOverride</c>, so generator
/// code can simply check for the marker without re-running TCGC logic.
/// </summary>
internal static class ClientNameOverrideHelper
{
    internal const string DecoratorName = "Azure.ResourceManager.@hasClientNameOverride";

    internal static bool HasUserProvidedClientName(InputModelType model)
        => HasMarker(model.Decorators);

    /// <summary>
    /// Detects the marker on the underlying <see cref="InputOperation"/>: the
    /// upstream C# emitter copies `SdkServiceMethod.decorators` onto
    /// `InputOperation.decorators` (operation-converter.js line ~95). The mgmt
    /// emitter mutates the shared SdkServiceMethod decorator array, so the marker
    /// surfaces on <c>InputServiceMethod.Operation.Decorators</c> here.
    /// <see cref="InputServiceMethod"/> itself has no <c>Decorators</c> property.
    /// </summary>
    internal static bool HasUserProvidedClientName(InputServiceMethod method)
        => HasMarker(method.Operation.Decorators);

    private static bool HasMarker(IReadOnlyList<InputDecoratorInfo>? decorators)
    {
        if (decorators is null)
        {
            return false;
        }

        foreach (var decorator in decorators)
        {
            if (string.Equals(decorator.Name, DecoratorName, StringComparison.Ordinal))
            {
                return true;
            }
        }
        return false;
    }
}
