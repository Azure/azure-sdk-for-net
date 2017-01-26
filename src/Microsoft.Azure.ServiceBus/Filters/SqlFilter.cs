// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Filters
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Represents a filter which is a composition of an expression and an action that is executed in the pub/sub pipeline.
    /// </summary>
    public class SqlFilter : Filter
    {
        PropertyDictionary parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlFilter" /> class using the specified SQL expression.
        /// </summary>
        /// <param name="sqlExpression">The SQL expression.</param>
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

            this.SqlExpression = sqlExpression;
        }

        /// <summary>
        /// Gets the SQL expression.
        /// </summary>
        /// <value>The SQL expression.</value>
        public string SqlExpression { get; private set; }

        /// <summary>
        /// Sets the value of a filter expression.
        /// </summary>
        /// <value>The value of a filter expression.</value>
        public IDictionary<string, object> Parameters => this.parameters ?? (this.parameters = new PropertyDictionary());

        /// <summary>
        /// Returns a string representation of <see cref="SqlFilter" />.
        /// </summary>
        /// <returns>The string representation of <see cref="SqlFilter" />.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "SqlFilter: {0}", this.SqlExpression);
        }
    }
}