// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Represents a reference to a resource.  This is a helper for implementing
/// resources and not something to be used directly.
/// </summary>
public class ResourceReference<T>(BicepValue<string> reference) where T : ProvisionableResource
{
    private readonly BicepValue<string> _reference = reference;
    private T? _value;

    public T? Value
    {
        get => _value;
        set
        {
            _value = value;
            ((IBicepValue)_reference).Expression = _value is null ?
                BicepSyntax.Null() :
                BicepSyntax.Var(_value.BicepIdentifier);
        }
    }
}
