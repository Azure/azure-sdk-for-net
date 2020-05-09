// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus.Filters
{
    /// <summary>
    /// Represents a filter which is a composition of an expression and an action that is executed in the pub/sub pipeline.
    /// </summary>
    /// <remarks>
    /// A <see cref="SqlFilter"/> holds a SQL-like condition expression that is evaluated in the broker against the arriving messages'
    /// user-defined properties and system properties. All system properties (which are all properties explicitly listed
    /// on the <see cref="ServiceBusMessage"/> class) must be prefixed with <code>sys.</code> in the condition expression. The SQL subset implements
    /// testing for existence of properties (EXISTS), testing for null-values (IS NULL), logical NOT/AND/OR, relational operators,
    /// numeric arithmetic, and simple text pattern matching with LIKE.
    /// </remarks>
    public class SqlFilter : Filter
    {
        internal PropertyDictionary parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlFilter" /> class using the specified SQL expression.
        /// </summary>
        /// <remarks>Max allowed length of sql expression is 1024 chars.</remarks>
        public SqlFilter(string sqlExpression)
        {
            if (string.IsNullOrEmpty(sqlExpression))
            {
                throw Fx.Exception.ArgumentNull(nameof(sqlExpression));
            }

            if (sqlExpression.Length > Constants.MaximumSqlFilterStatementLength)
            {
                throw Fx.Exception.Argument(
                    nameof(sqlExpression),
                    Resources.SqlFilterStatmentTooLong.FormatForUser(
                        sqlExpression.Length,
                        Constants.MaximumSqlFilterStatementLength));
            }

            SqlExpression = sqlExpression;
        }

        /// <summary>
        /// Gets the SQL expression.
        /// </summary>
        /// <value>The SQL expression.</value>
        /// <remarks>Max allowed length of sql expression is 1024 chars.</remarks>
        public string SqlExpression { get; }

        /// <summary>
        /// Sets the value of a filter expression.
        /// Allowed types: string, int, long, bool, double
        /// </summary>
        /// <value>The value of a filter expression.</value>
        public IDictionary<string, object> Parameters => parameters ?? (parameters = new PropertyDictionary());

        /// <summary>
        /// Returns a string representation of <see cref="SqlFilter" />.
        /// </summary>
        /// <returns>The string representation of <see cref="SqlFilter" />.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "SqlFilter: {0}", SqlExpression);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return SqlExpression?.GetHashCode() ?? base.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var other = obj as Filter;
            return Equals(other);
        }

        /// <inheritdoc/>
        public override bool Equals(Filter other)
        {
            if (other is SqlFilter sqlFilter)
            {
                if (string.Equals(SqlExpression, sqlFilter.SqlExpression, StringComparison.OrdinalIgnoreCase)
                    && (parameters != null && sqlFilter.parameters != null
                        || parameters == null && sqlFilter.parameters == null))
                {
                    if (parameters != null)
                    {
                        if (parameters.Count != sqlFilter.parameters.Count)
                        {
                            return false;
                        }

                        foreach (var param in parameters)
                        {
                            if (!sqlFilter.parameters.TryGetValue(param.Key, out var otherParamValue) ||
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator ==(SqlFilter o1,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
                                       SqlFilter o2)
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator !=(SqlFilter o1, SqlFilter o2)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return !(o1 == o2);
        }
    }
}
