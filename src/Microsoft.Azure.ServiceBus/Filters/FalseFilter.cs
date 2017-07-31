// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    /// <summary>
    /// Matches none the messages arriving to be selected for the subscription.
    /// </summary>
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