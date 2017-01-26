// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Filters
{
    /// <summary>
    /// Matches a filter expression.
    /// </summary>
    public sealed class TrueFilter : SqlFilter
    {
        internal static readonly TrueFilter Default = new TrueFilter();

        /// <summary>
        /// Initializes a new instance of the <see cref="TrueFilter" /> class.
        /// </summary>
        public TrueFilter()
            : base("1=1")
        {
        }

        /// <summary>
        /// Converts the value of the current instance to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the current instance.</returns>
        public override string ToString()
        {
            return "TrueFilter";
        }
    }
}