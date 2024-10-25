// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

    public static BicepValue<Uri> ToUri(this BicepValue<string> value) =>
        ((IBicepValue)value).Kind switch
        {
            BicepValueKind.Literal => (BicepValue<Uri>)new Uri(value.Value!),
            BicepValueKind.Expression => new BicepValue<Uri>(((IBicepValue)value).Expression!),
            _ => new BicepValue<Uri>(self: null),
        };

    // TODO: Add more common casts
}
