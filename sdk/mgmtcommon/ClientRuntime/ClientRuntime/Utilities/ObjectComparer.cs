// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Utilities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Generic class to compare objects
    /// </summary>
    /// <typeparam name="T">Type for which you want to equate it against</typeparam>
    internal class ObjectComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// Type comparing delegate
        /// </summary>
        private readonly Func<T, T, bool> objectComparerDelegate;

        /// <summary>
        /// Computes Hash for the type
        /// </summary>
        private readonly Func<T, int> hashComputeDelegate;

        /// <summary>
        /// Initializes a new instance of the TypeComparer class
        /// </summary>
        /// <param name="comparisonDelegate">comparisonDelegate for comparison</param>
        public ObjectComparer(Func<T, T, bool> comparisonDelegate) :
            this(comparisonDelegate, o => 0)
        { }
        
        /// <summary>
        /// Initializes a new instance of the TypeComparer class
        /// </summary>
        /// <param name="comparisonDelegate">Comparison Delegate</param>
        /// <param name="hashComputeDelegate">Hash computing Delegate</param>
        public ObjectComparer(Func<T, T, bool> comparisonDelegate, Func<T, int> hashComputeDelegate)
        {
            this.objectComparerDelegate = comparisonDelegate;
            this.hashComputeDelegate = hashComputeDelegate;
        }

        /// <summary>
        /// Implmentation for IEualityComparer
        /// </summary>
        /// <param name="x">First Instance</param>
        /// <param name="y">Second Instance</param>
        /// <returns>Returns <see cref="bool"/> comparing two types</returns>
        public bool Equals(T x, T y)
        {
            return this.objectComparerDelegate(x, y);
        }

        /// <summary>
        /// Compare hash
        /// </summary>
        /// <param name="obj">Instance of Delegate that computes hash</param>
        /// <returns>returns <see cref="int"/> computed hash</returns>
        public int GetHashCode(T obj)
        {
            return this.hashComputeDelegate(obj);
        }
    }
}