// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.DataFactory
{
    /// <summary>
    /// A class representing either a primitive value or an expression.
    /// </summary>
    public abstract class DataFactoryExpression
    {
        /// <summary>
        /// Converts a string expression into a <see cref="DataFactoryExpression{T}"/>.
        /// </summary>
        /// <param name="expression"> The expression string. </param>
        public static DataFactoryExpression<T> FromExpression<T>(string expression)
        {
            Optional<T> value = default;
            return new DataFactoryExpression<T>(value, expression);
        }

        /// <summary>
        /// Converts a primitive value into a <see cref="DataFactoryExpression{T}"/>.
        /// </summary>
        /// <param name="value"> The value. </param>
        public static DataFactoryExpression<T> FromValue<T>(T value)
        {
            return new DataFactoryExpression<T>(value, null);
        }
    }
}
