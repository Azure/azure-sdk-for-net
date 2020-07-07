// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    /// <summary>
    /// An object converter that encapsulates a set of inner converters.
    /// </summary>
    /// <typeparam name="T">The output <see cref="Type"/></typeparam>
    internal class CompositeObjectToTypeConverter<T> : IObjectToTypeConverter<T>
    {
        private readonly IEnumerable<IObjectToTypeConverter<T>> _converters;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="converters">The set of converters to encapsulate.</param>
        public CompositeObjectToTypeConverter(IEnumerable<IObjectToTypeConverter<T>> converters)
        {
            if (converters == null)
            {
                throw new ArgumentNullException("converters");
            }
            _converters = converters;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="converters">The set of converters to encapsulate.</param>
        public CompositeObjectToTypeConverter(params IObjectToTypeConverter<T>[] converters)
            : this((IEnumerable<IObjectToTypeConverter<T>>)converters)
        {
        }

        /// <summary>
        /// Try to perform a conversion by attempting each inner converter in order
        /// until one succeeds, or all fail.
        /// </summary>
        /// <param name="input">The value to convert.</param>
        /// <param name="output">The converted value if successful.</param>
        /// <returns>True if the conversion was successful, false otherwise.</returns>
        public bool TryConvert(object input, out T output)
        {
            foreach (IObjectToTypeConverter<T> converter in _converters)
            {
                T possibleConverted;

                if (converter.TryConvert(input, out possibleConverted))
                {
                    output = possibleConverted;
                    return true;
                }
            }

            output = default(T);
            return false;
        }
    }
}
