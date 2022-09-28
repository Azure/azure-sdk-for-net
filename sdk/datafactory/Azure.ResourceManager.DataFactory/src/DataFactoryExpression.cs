// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//string vs expression that evaluates to a string
//array vs expression
//boolean vs expression that evaluates to a bool
//integer vs expression
//object vs expression

//securestring??
//float??

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.DataFactory
{
    /// <summary>
    /// .
    /// </summary>
    public static class DataFactoryExpression
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static DataFactoryExpression<T> FromExpression<T>(string expression)
        {
            return new DataFactoryExpression<T>(expression);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataFactoryExpression<T> FromValue<T>(T value)
        {
            return new DataFactoryExpression<T>(value);
        }
    }
}
