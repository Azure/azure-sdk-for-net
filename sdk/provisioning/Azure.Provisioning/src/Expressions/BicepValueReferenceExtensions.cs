// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public static class BicepValueReferenceExtensions
{
    /// <summary>
    /// Converts a <see cref="IBicepValue" /> to a BicepValue.
    /// </summary>
    /// <param name="value">The bicep value to convert.</param>
    /// <returns>A BicepValue representing the same value.</returns>
    public static BicepExpression ToBicepExpression(this IBicepValue value)
    {
        if (value is IBicepValue { Self: { } self })
        {
            return self.GetReference();
        }
        else
        {
            return value.Compile();
        }
    }

    /// <summary>
    /// Convert a <see cref="BicepValue{T}" /> to a BicepExpression.
    /// </summary>
    /// <param name="value">The bicep value to convert.</param>
    /// <returns>A BicepValue representing the same value.</returns>
    /// <returns></returns>
    public static BicepExpression ToBicepExpression<T>(this BicepValue<T> value)
    {
        return value switch
        {
            BicepListIndexer<T> listIndexer => BicepSyntax.Index(((IBicepValue)listIndexer).Self!.GetReference(), new IntLiteralExpression(listIndexer.Index)),
            BicepDictionaryIndexer<T> dictIndexer => BicepSyntax.Index(((IBicepValue)dictIndexer).Self!.GetReference(), new StringLiteralExpression(dictIndexer.Key)),
            _ => ((IBicepValue)value).ToBicepExpression()
        };
    }
}
