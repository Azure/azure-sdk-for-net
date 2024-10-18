// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Represents a reference to a resource.  This is a helper for implementing
/// resources and not something to be used directly.
/// </summary>
public class ResourceReference<T>(BicepValue<string> reference) where T : Resource
{
    private readonly BicepValue<string> _reference = reference;
    private T? _value;

    public T? Value
    {
        get => _value;
        set
        {
            // TODO: Decide if we want to optimize by peeking for expressions
            // and copying them vs. creating a new reference based on the name.
            _value = value;
            _reference.Kind = BicepValueKind.Expression;
            _reference.Expression = _value is null ?
                BicepSyntax.Null() :
                // TODO: Consider tracking the source like we do for
                // BicepValue<T> if that'll improve the overall experience
                // (debugging/errors/etc.)
                BicepSyntax.Var(_value.BicepIdentifier);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ResourceReference<T> DefineResource(
        Resource construct,
        string propertyName,
        string[]? bicepPath,
        bool isOutput = false,
        bool isRequired = false,
        T? defaultValue = null)
    {
        ResourceReference<T> resource = new(
            BicepValue<string>.DefineProperty(construct, propertyName, bicepPath, isOutput: isOutput, isRequired: isRequired));
        if (defaultValue is not null) { resource.Value = defaultValue; }
        return resource;
    }
}
