// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Filters
{
    /// <summary>
    /// Represents the false filter expression.
    /// </summary>
    /// <remarks>The Match None expression should be used if you want to create
    /// a subscription that initially block all messages. Typically in this scenario is you may
    /// want to create the subscription but want to enable this subscription at a later date. This filter will enable
    /// that scenario. </remarks>
    public sealed class FalseFilter : SqlFilter
    {
        internal static readonly FalseFilter Default = new FalseFilter();

        /// <summary>
        /// Initializes a new instance of the <see cref="FalseFilter" /> class.
        /// </summary>
        public FalseFilter()
            : base("1=0")
        {
        }

        /// <summary>
        /// Converts the current instance to its string representation.
        /// </summary>
        /// <returns>A string representation of the current instance.</returns>
        public override string ToString()
        {
            return "FalseFilter";
        }
    }
}