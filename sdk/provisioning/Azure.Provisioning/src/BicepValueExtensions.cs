// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// Extension methods for manipulating bicep values.
/// </summary>
public static class BicepValueExtensions
{
    /// <summary>
    /// Unwrap the BicepValue from a model.
    /// </summary>
    /// <typeparam name="T">Type of the model.</typeparam>
    /// <param name="value">The value to unwrap.</param>
    /// <returns>An easily consumed model.</returns>
    public static T Unwrap<T>(this BicepValue<T> value)
        where T : ProvisionableConstruct, new()
    {
        switch (((IBicepValue)value).Kind)
        {
            case BicepValueKind.Literal:
                return value.Value!;
            case BicepValueKind.Expression:
                T wrapper = new();
                ((IBicepValue)wrapper).Expression = ((IBicepValue)value).Expression!;
                return wrapper;
            default:
                return new T(); // (i.e., model where everything is Unset)
        }
    }

    // TODO: Add more common casts

    /// <summary>
    /// Convert a IBicepValue into a BicepExpression by its reference to represent its hierarchy.
    /// </summary>
    /// <param name="bicepValue"></param>
    /// <returns></returns>
    public static BicepExpression ToBicepExpression(this IBicepValue bicepValue)
    {
        // if self is set, we could build an expression as a reference of this member
        if (bicepValue.Self is not null)
        {
            return bicepValue.Self.GetReference();
        }
        // if self is not set, but the value of this is an expression, we return that expression
        else if (bicepValue.Kind == BicepValueKind.Expression)
        {
            return bicepValue.Expression ?? BicepSyntax.Null();
        }
        // otherwise, we return whatever this compiles into
        else
        {
            return bicepValue.Compile();
        }
    }
}
