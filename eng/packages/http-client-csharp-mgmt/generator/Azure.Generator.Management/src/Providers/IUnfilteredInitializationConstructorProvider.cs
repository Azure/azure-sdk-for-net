// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// Exposes the initialization constructor captured before custom-code filtering.
    /// </summary>
    internal interface IUnfilteredInitializationConstructorProvider
    {
        ConstructorProvider? UnfilteredInitializationConstructor { get; }
    }
}
