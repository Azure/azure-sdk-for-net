// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Expressions;

public static class BicepValueReferenceExtensions
{
    /// <summary>
    /// Converts a BicepValueReference to a BicepValue.
    /// </summary>
    /// <param name="value">The BicepValueReference to convert.</param>
    /// <returns>A BicepValue representing the same value.</returns>
    public static BicepExpression ToBicepExpression(this IBicepValue value)
    {
        if (value.Self is not null)
        {
            return value.Self.GetReference();
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
