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
    /// Represents the set of actions written in SQL language-based syntax that is performed against a <see cref="ServiceBusReceivedMessage" />.
    /// </summary>
    public sealed class SqlRuleAction : RuleAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlRuleAction" /> class with the specified SQL expression.
        /// </summary>
        /// <param name="sqlExpression">The SQL expression.</param>
        /// <remarks>Max allowed length of sql expression is 1024 chars.</remarks>
        public SqlRuleAction(string sqlExpression)
        {
            Argument.AssertNotNullOrWhiteSpace(sqlExpression, nameof(sqlExpression));
            Argument.AssertNotTooLong(sqlExpression, Constants.MaximumSqlRuleActionStatementLength, nameof(sqlExpression));

            SqlExpression = sqlExpression;
        }

        internal override RuleAction Clone() =>
            new SqlRuleAction(SqlExpression)
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
        /// Gets the value of a rule action.
        /// </summary>
        /// <value>The value of a rule action.</value>
        public IDictionary<string, object> Parameters { get; internal set; } = new PropertyDictionary();

        /// <summary>
        /// Returns a string representation of <see cref="SqlRuleAction" />.
        /// </summary>
        /// <returns>The string representation of <see cref="SqlRuleAction" />.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "SqlRuleAction: {0}", SqlExpression);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return SqlExpression?.GetHashCode() ?? base.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var other = obj as RuleAction;
            return Equals(other);
        }

        /// <inheritdoc/>
        public override bool Equals(RuleAction other)
        {
            if (other is not SqlRuleAction sqlRuleAction)
            {
                return false;
            }

            if (string.Equals(SqlExpression, sqlRuleAction.SqlExpression, StringComparison.OrdinalIgnoreCase))
            {
                if (Parameters.Count != sqlRuleAction.Parameters.Count)
                {
                    return false;
                }

                foreach (var param in Parameters)
                {
                    if (!sqlRuleAction.Parameters.TryGetValue(param.Key, out var otherParamValue) ||
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

        /// <summary>Compares two <see cref="SqlRuleAction"/> values for equality.</summary>
        public static bool operator ==(SqlRuleAction left, SqlRuleAction right)
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

        /// <summary>Compares two <see cref="SqlRuleAction"/> values for inequality.</summary>
        public static bool operator !=(SqlRuleAction left, SqlRuleAction right)
        {
            return !(left == right);
        }
    }
}
