// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Azure.ServiceBus.Primitives;

namespace Microsoft.Azure.ServiceBus.Filters
{
	/// <summary>
    /// Represents set of actions written in SQL language-based syntax that is performed against a <see cref="Message" />.
    /// </summary>
    public sealed class SqlRuleAction : RuleAction
    {
        internal PropertyDictionary Properties;

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
        public IDictionary<string, object> Parameters => Properties ?? (Properties = new PropertyDictionary());

        /// <summary>
        /// Returns a string representation of <see cref="SqlRuleAction" />.
        /// </summary>
        /// <returns>The string representation of <see cref="SqlRuleAction" />.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "SqlRuleAction: {0}", SqlExpression);
        }

        public override int GetHashCode()
        {
            return SqlExpression?.GetHashCode() ?? base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as RuleAction;
            return Equals(other);
        }

        public override bool Equals(RuleAction other)
        {
            if (other is SqlRuleAction sqlAction)
            {
                if (string.Equals(SqlExpression, sqlAction.SqlExpression, StringComparison.OrdinalIgnoreCase)
                    && (Properties != null && sqlAction.Properties != null
                        || Properties == null && sqlAction.Properties == null))
                {
                    if (Properties != null)
                    {
                        if (Properties.Count != sqlAction.Properties.Count)
                        {
                            return false;
                        }

                        foreach (var param in Properties)
                        {
                            if (!sqlAction.Properties.TryGetValue(param.Key, out var otherParamValue) ||
                                param.Value == null ^ otherParamValue == null ||
                                param.Value != null && !param.Value.Equals(otherParamValue))
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

        public static bool operator ==(SqlRuleAction o1, SqlRuleAction o2)
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

        public static bool operator !=(SqlRuleAction o1, SqlRuleAction o2)
        {
            return !(o1 == o2);
        }
    }
}