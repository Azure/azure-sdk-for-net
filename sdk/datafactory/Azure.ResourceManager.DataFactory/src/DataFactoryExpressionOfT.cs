// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.DataFactory
{
    /// <summary>
    /// .
    /// </summary>
    /// <typeparam name="T"></typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public class DataFactoryExpression<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// .
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// .
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// .
        /// </summary>
        public string Expression { get; }

        /// <summary>
        /// .
        /// </summary>
        protected DataFactoryExpression() { }

        internal DataFactoryExpression(string type, T value)
        {
            Type = type;
            Value = value;
        }

        internal DataFactoryExpression(string expression)
        {
            Type = "Expression";
            Expression = expression;
        }
    }
}
