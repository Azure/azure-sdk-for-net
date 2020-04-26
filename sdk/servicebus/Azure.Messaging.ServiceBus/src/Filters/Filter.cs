// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Filters
{
    /// <summary>
    /// Describes a filter expression that is evaluated against a Message.
    /// </summary>
    /// <remarks>
    /// Filter is an abstract class with the following concrete implementations:
    /// <list type="bullet">
    /// <item><b>SqlFilter</b> that represents a filter using SQL syntax. </item>
    /// <item><b>CorrelationFilter</b> that provides an optimization for correlation equality expressions.</item>
    /// </list>
    /// </remarks>
    /// <seealso cref="SqlFilter"/>
    /// <seealso cref="TrueFilter"/>
    /// <seealso cref="CorrelationFilter "/>
    /// <seealso cref="FalseFilter"/>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Filter : IEquatable<Filter>
#pragma warning restore AZC0012 // Avoid single word type names
    {
        internal Filter()
        {
            // This is intentionally left blank. This constructor exists
            // only to prevent external assemblies inheriting from it.
        }
        /// <inheritdoc/>
        public abstract bool Equals(Filter other);
    }
}
