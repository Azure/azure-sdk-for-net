// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Represents a filter which is a composition of an expression and an action that is executed in the pub/sub pipeline.
    /// </summary>
    /// <remarks>
    /// A <see cref="SqlRuleFilter"/> holds a SQL-like condition expression that is evaluated in the broker against the arriving messages'
    /// user-defined properties and system properties. All system properties (which are all properties explicitly listed
    /// on the <see cref="ServiceBusMessage"/> class) must be prefixed with <code>sys.</code> in the condition expression. The SQL subset implements
    /// testing for existence of properties (EXISTS), testing for null-values (IS NULL), logical NOT/AND/OR, relational operators,
    /// numeric arithmetic, and simple text pattern matching with LIKE.
    /// </remarks>
    public class SqlRuleFilter : RuleFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlRuleFilter" /> class using the specified SQL expression.
        /// </summary>
        /// <remarks>Max allowed length of sql expression is 1024 chars.</remarks>
        public SqlRuleFilter(string sqlExpression)
        {
            Argument.AssertNotNullOrEmpty(sqlExpression, nameof(sqlExpression));
            Argument.AssertNotTooLong(sqlExpression, Constants.MaximumSqlRuleFilterStatementLength, nameof(sqlExpression));

            SqlExpression = sqlExpression;
        }

        internal override RuleFilter Clone() =>
            new SqlRuleFilter(SqlExpression)
            {
                Parameters = (Parameters as PropertyDictionary).Clone()
            };

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
        public IDictionary<string, object> Parameters { get; internal set; } = new PropertyDictionary();

        /// <summary>
        /// Returns a string representation of <see cref="SqlRuleFilter" />.
        /// </summary>
        /// <returns>The string representation of <see cref="SqlRuleFilter" />.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "SqlRuleFilter: {0}", SqlExpression);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return SqlExpression?.GetHashCode() ?? base.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var other = obj as RuleFilter;
            return Equals(other);
        }

        /// <inheritdoc/>
        public override bool Equals(RuleFilter other)
        {
            if (other is not SqlRuleFilter sqlRuleFilter)
            {
                return false;
            }

            if (string.Equals(SqlExpression, sqlRuleFilter.SqlExpression, StringComparison.OrdinalIgnoreCase))
            {
                if (Parameters.Count != sqlRuleFilter.Parameters.Count)
                {
                    return false;
                }

                foreach (var param in Parameters)
                {
                    if (!sqlRuleFilter.Parameters.TryGetValue(param.Key, out var otherParamValue) ||
                        (param.Value == null ^ otherParamValue == null) ||
                        (param.Value != null && !param.Value.Equals(otherParamValue)))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>Compares two <see cref="SqlRuleFilter"/> values for equality.</summary>
        public static bool operator ==(SqlRuleFilter left, SqlRuleFilter right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>Compares two <see cref="SqlRuleFilter"/> values for inequality.</summary>
        public static bool operator !=(SqlRuleFilter left, SqlRuleFilter right)
        {
            return !(left == right);
        }
    }
}
