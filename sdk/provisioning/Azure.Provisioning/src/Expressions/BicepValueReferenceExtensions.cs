// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public static class BicepValueReferenceExtensions
{
    /// <summary>
    /// Converts a <see cref="IBicepValue" /> to a BicepValue.
    /// </summary>
    /// <param name="value">The BicepValueReference to convert.</param>
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
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static BicepExpression ToBicepExpression<T>(this BicepValue<T> value)
    {
        if (value is BicepListIndexer<T> indexer)
        {
            return BicepSyntax.Index(((IBicepValue)indexer).Self!.GetReference(), new IntLiteralExpression(indexer.Index));
        }
        else if (value is BicepDictionaryIndexer<T> indexerDict)
        {
            return BicepSyntax.Index(((IBicepValue)indexerDict).Self!.GetReference(), new StringLiteralExpression(indexerDict.Key));
        }
        else
        {
            return ((IBicepValue)value).ToBicepExpression();
        }
    }
}
