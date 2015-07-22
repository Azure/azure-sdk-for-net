// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Helper class for validating <see cref="StringComparison"/> values.
    /// </summary>
    internal static class StringComparisonHelper
    {
        /// <summary>
        /// Determines whether the specified <paramref name="value"/> is defined by the <see cref="StringComparison"/>
        /// enumeration.
        /// </summary>
        /// <param name="value">The value to verify.</param>
        /// <returns>
        /// <c>true</c> if the specified options is defined; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDefined(StringComparison value)
        {
            return value == StringComparison.CurrentCulture ||
                   value == StringComparison.CurrentCultureIgnoreCase ||
#if !NETFX_CORE 
                   value == StringComparison.InvariantCulture ||
                   value == StringComparison.InvariantCultureIgnoreCase ||
#endif
                   value == StringComparison.Ordinal ||
                   value == StringComparison.OrdinalIgnoreCase;
        }

        /// <summary>
        /// Validates the specified <paramref name="value"/> and throws an <see cref="ArgumentException"/>
        /// exception if not valid.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="parameterName">Name of the parameter to use if throwing exception.</param>
        public static void Validate(StringComparison value, string parameterName)
        {
            if (!IsDefined(value))
            {
                throw Error.InvalidEnumArgument(parameterName, (int)value, typeof(StringComparison));
            }
        }
    }
}
