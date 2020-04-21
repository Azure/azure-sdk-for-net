// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus.Filters
{
    /// <summary>
    /// Represents set of actions written in SQL language-based syntax that is performed against a <see cref="ServiceBusMessage" />.
    /// </summary>
    public sealed class SqlRuleAction : RuleAction
    {
        internal PropertyDictionary parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlRuleAction" /> class with the specified SQL expression.
        /// </summary>
        /// <param name="sqlExpression">The SQL expression.</param>
        /// <remarks>Max allowed length of sql expression is 1024 chars.</remarks>
        public SqlRuleAction(string sqlExpression)
        {
            if (string.IsNullOrEmpty(sqlExpression))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(sqlExpression));
            }

            if (sqlExpression.Length > Constants.MaximumSqlRuleActionStatementLength)
            {
                throw Fx.Exception.Argument(
                    nameof(sqlExpression),
                    Resources.SqlFilterActionStatmentTooLong.FormatForUser(
                        sqlExpression.Length,
                        Constants.MaximumSqlRuleActionStatementLength));
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
        /// Sets the value of a rule action.
        /// </summary>
        /// <value>The value of a rule action.</value>
        public IDictionary<string, object> Parameters => parameters ?? (parameters = new PropertyDictionary());

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
            if (other is SqlRuleAction sqlAction)
            {
                if (string.Equals(SqlExpression, sqlAction.SqlExpression, StringComparison.OrdinalIgnoreCase)
                    && (parameters != null && sqlAction.parameters != null
                        || parameters == null && sqlAction.parameters == null))
                {
                    if (parameters != null)
                    {
                        if (parameters.Count != sqlAction.parameters.Count)
                        {
                            return false;
                        }

                        foreach (var param in parameters)
                        {
                            if (!sqlAction.parameters.TryGetValue(param.Key, out var otherParamValue) ||
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
        public static bool operator ==(SqlRuleAction o1, SqlRuleAction o2)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
        public static bool operator !=(SqlRuleAction o1, SqlRuleAction o2)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return !(o1 == o2);
        }
    }
}
