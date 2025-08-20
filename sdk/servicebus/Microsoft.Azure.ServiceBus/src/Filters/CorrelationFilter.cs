// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Primitives;

    /// <summary>
    /// Represents the correlation filter expression.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A CorrelationFilter holds a set of conditions that are matched against one of more of an arriving message's user and system properties.
    /// A common use is a match against the <see cref="Message.CorrelationId"/> property, but the application can also choose to match against
    /// <see cref="Message.ContentType"/>, <see cref="Message.Label"/>, <see cref="Message.MessageId"/>, <see cref="Message.ReplyTo"/>,
    /// <see cref="Message.ReplyToSessionId"/>, <see cref="Message.SessionId"/>, <see cref="Message.To"/>, and any user-defined properties.
    /// A match exists when an arriving message's value for a property is equal to the value specified in the correlation filter. For string expressions,
    /// the comparison is case-sensitive. When specifying multiple match properties, the filter combines them as a logical AND condition,
    /// meaning all conditions must match for the filter to match.
    /// </para>
    /// <para>
    /// The CorrelationFilter provides an efficient shortcut for declarations of filters that deal only with correlation equality.
    /// In this case the cost of the lexigraphical analysis of the expression can be avoided.
    /// Not only will correlation filters be optimized at declaration time, but they will also be optimized at runtime.
    /// Correlation filter matching can be reduced to a hashtable lookup, which aggregates the complexity of the set of defined correlation filters to O(1).
    /// </para>
    /// </remarks>
    public sealed class CorrelationFilter : Filter
    {
        internal PropertyDictionary properties;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorrelationFilter" /> class with default values.
        /// </summary>
        public CorrelationFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorrelationFilter" /> class with the specified correlation identifier.
        /// </summary>
        /// <param name="correlationId">The identifier for the correlation.</param>
        /// <exception cref="System.ArgumentException">Thrown when the <paramref name="correlationId" /> is null or empty.</exception>
        public CorrelationFilter(string correlationId)
            : this()
        {
            if (string.IsNullOrWhiteSpace(correlationId))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(correlationId));
            }

            this.CorrelationId = correlationId;
        }

        /// <summary>
        /// Identifier of the correlation.
        /// </summary>
        /// <value>The identifier of the correlation.</value>
        public string CorrelationId
        {
            get;
            set;
        }

        /// <summary>
        /// Identifier of the message.
        /// </summary>
        /// <value>The identifier of the message.</value>
        /// <remarks>Max MessageId size is 128 chars.</remarks>
        public string MessageId
        {
            get;
            set;
        }

        /// <summary>
        /// Address to send to.
        /// </summary>
        /// <value>The address to send to.</value>
        public string To
        {
            get;
            set;
        }

        /// <summary>
        /// Address of the queue to reply to.
        /// </summary>
        /// <value>The address of the queue to reply to.</value>
        public string ReplyTo
        {
            get;
            set;
        }

        /// <summary>
        /// Application specific label.
        /// </summary>
        /// <value>The application specific label.</value>
        public string Label
        {
            get;
            set;
        }

        /// <summary>
        /// Session identifier.
        /// </summary>
        /// <value>The session identifier.</value>
        /// <remarks>Max size of sessionId is 128 chars.</remarks>
        public string SessionId
        {
            get;
            set;
        }

        /// <summary>
        /// Session identifier to reply to.
        /// </summary>
        /// <value>The session identifier to reply to.</value>
        /// <remarks>Max size of ReplyToSessionId is 128.</remarks>
        public string ReplyToSessionId
        {
            get;
            set;
        }

        /// <summary>
        /// Content type of the message.
        /// </summary>
        /// <value>The content type of the message.</value>
        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// Application specific properties of the message.
        /// </summary>
        /// <value>The application specific properties of the message.</value>
        /// <remarks>
        /// Only following value types are supported:
        /// byte, sbyte, char, short, ushort, int, uint, long, ulong, float, double, decimal,
        /// bool, Guid, string, Uri, DateTime, DateTimeOffset, TimeSpan, Stream, byte[],
        /// and IList / IDictionary of supported types
        /// </remarks>
        public IDictionary<string, object> Properties => this.properties ?? (this.properties = new PropertyDictionary());

        /// <summary>
        /// Converts the value of the current instance to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the current instance.</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("CorrelationFilter: ");

            var isFirstExpression = true;

            this.AppendPropertyExpression(ref isFirstExpression, stringBuilder, "sys.CorrelationId", this.CorrelationId);
            this.AppendPropertyExpression(ref isFirstExpression, stringBuilder, "sys.MessageId", this.MessageId);
            this.AppendPropertyExpression(ref isFirstExpression, stringBuilder, "sys.To", this.To);
            this.AppendPropertyExpression(ref isFirstExpression, stringBuilder, "sys.ReplyTo", this.ReplyTo);
            this.AppendPropertyExpression(ref isFirstExpression, stringBuilder, "sys.Label", this.Label);
            this.AppendPropertyExpression(ref isFirstExpression, stringBuilder, "sys.SessionId", this.SessionId);
            this.AppendPropertyExpression(ref isFirstExpression, stringBuilder, "sys.ReplyToSessionId", this.ReplyToSessionId);
            this.AppendPropertyExpression(ref isFirstExpression, stringBuilder, "sys.ContentType", this.ContentType);

            foreach (var pair in this.Properties)
            {
                string propertyName = pair.Key;
                object propertyValue = pair.Value;

                this.AppendPropertyExpression(ref isFirstExpression, stringBuilder, propertyName, propertyValue);
            }

            return stringBuilder.ToString();
        }

        void AppendPropertyExpression(ref bool firstExpression, StringBuilder builder, string propertyName, object value)
        {
            if (value != null)
            {
                if (firstExpression)
                {
                    firstExpression = false;
                }
                else
                {
                    builder.Append(" AND ");
                }

                builder.AppendFormat("{0} = '{1}'", propertyName, value);
            }
        }

        public override int GetHashCode()
        {
            int hash = 13;
            unchecked
            {
                hash = (hash * 7) + this.CorrelationId?.GetHashCode() ?? 0;
                hash = (hash * 7) + this.MessageId?.GetHashCode() ?? 0;
                hash = (hash * 7) + this.SessionId?.GetHashCode() ?? 0; 
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as CorrelationFilter;
            return this.Equals(other);
        }

        public override bool Equals(Filter other)
        {
            if (other is CorrelationFilter correlationFilter)
            {
                if (string.Equals(this.CorrelationId, correlationFilter.CorrelationId, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(this.MessageId, correlationFilter.MessageId, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(this.To, correlationFilter.To, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(this.ReplyTo, correlationFilter.ReplyTo, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(this.Label, correlationFilter.Label, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(this.SessionId, correlationFilter.SessionId, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(this.ReplyToSessionId, correlationFilter.ReplyToSessionId, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(this.ContentType, correlationFilter.ContentType, StringComparison.OrdinalIgnoreCase)
                    && (this.properties != null && correlationFilter.properties != null
                        || this.properties == null && correlationFilter.properties == null))
                {
                    if (this.properties != null)
                    {
                        if (this.properties.Count != correlationFilter.properties.Count)
                        {
                            return false;
                        }

                        foreach (var param in this.properties)
                        {
                            if (!correlationFilter.properties.TryGetValue(param.Key, out var otherParamValue) ||
                                (param.Value == null ^ otherParamValue == null) ||
                                (param.Value != null && !param.Value.Equals(otherParamValue)))
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        public static bool operator == (CorrelationFilter o1, CorrelationFilter o2)
        {
            if (ReferenceEquals(o1, o2))
            {
                return true;
            }

            if (ReferenceEquals(o1, null) || ReferenceEquals(o2, null))
            {
                return false;
            }

            return o1.Equals(o2);
        }

        public static bool operator != (CorrelationFilter p1, CorrelationFilter p2)
        {
            return !(p1 == p2);
        }
    }
}