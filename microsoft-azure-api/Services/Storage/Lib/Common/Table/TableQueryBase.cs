// -----------------------------------------------------------------------------------------
// <copyright file="TableQueryBase.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

#if RT    
    using System.Runtime.InteropServices.WindowsRuntime;
#endif

    /// <summary>
    /// Represents a query against a specified table.
    /// </summary>
    /// <remarks>A <see cref="TableQuery"/> instance aggregates the query parameters to use when the query is executed. One of the <code>executeQuery</code> or <code>executeQuerySegmented</code> methods 
    /// of <see cref="CloudTableClient"/> must be called to execute the query. The parameters are encoded and passed to the server when the table query is executed.</remarks>
    public sealed partial class TableQuery
    {
        #region Filter Generation

        /// <summary>
        /// Generates a property filter condition string for the string value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="givenValue">A string containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterCondition(string propertyName, string operation, string givenValue)
        {
            CommonUtils.AssertNotNullOrEmpty("givenValue", givenValue);
            return GenerateFilterCondition(propertyName, operation, givenValue, EdmType.String);
        }

        /// <summary>
        /// Generates a property filter condition string for the boolean value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="givenValue">A <code>bool</code> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForBool(string propertyName, string operation, bool givenValue)
        {
            return GenerateFilterCondition(propertyName, operation, givenValue ? "true" : "false", EdmType.Boolean);
        }

        /// <summary>
        /// Generates a property filter condition string for the binary value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="givenValue">A byte array containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Needed for Common Code preprocessor directives.")]
        public static string GenerateFilterConditionForBinary(
            string propertyName,
            string operation,
#if RT
            [ReadOnlyArray]
#endif
 byte[] givenValue)
        {
            CommonUtils.AssertNotNull("value", givenValue);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in givenValue)
            {
                sb.AppendFormat("{0:x2}", b);
            }

            return GenerateFilterCondition(propertyName, operation, sb.ToString(), EdmType.Binary);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="DateTimeOffset"/> value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="givenValue">A <see cref="DateTimeOffset"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForDate(string propertyName, string operation, DateTimeOffset givenValue)
        {
            return GenerateFilterCondition(propertyName, operation, givenValue.UtcDateTime.ToString("o"), EdmType.DateTime);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="double"/> value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="givenValue">A <see cref="double"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForDouble(string propertyName, string operation, double givenValue)
        {
            return GenerateFilterCondition(propertyName, operation, Convert.ToString(givenValue), EdmType.Double);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="int"/> value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="givenValue">A <see cref="int"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForInt(string propertyName, string operation, int givenValue)
        {
            return GenerateFilterCondition(propertyName, operation, Convert.ToString(givenValue), EdmType.Int32);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="long"/> value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="givenValue">A <see cref="long"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForLong(string propertyName, string operation, long givenValue)
        {
            return GenerateFilterCondition(propertyName, operation, Convert.ToString(givenValue), EdmType.Int64);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="Guid"/> value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="givenValue">A <see cref="Guid"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForGuid(string propertyName, string operation, Guid givenValue)
        {
            CommonUtils.AssertNotNull("value", givenValue);
            return GenerateFilterCondition(propertyName, operation, givenValue.ToString(), EdmType.Guid);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="EdmType"/> value, formatted as the specified <see cref="EdmType"/>.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="givenValue">A string containing the value to compare with the property.</param>
        /// <param name="edmType">The <see cref="EdmType"/> to format the value as.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        private static string GenerateFilterCondition(string propertyName, string operation, string givenValue, EdmType edmType)
        {
            string valueOperand = null;

            if (edmType == EdmType.Boolean || edmType == EdmType.Double || edmType == EdmType.Int32
                    || edmType == EdmType.Int64)
            {
                valueOperand = givenValue;
            }
            else if (edmType == EdmType.DateTime)
            {
                valueOperand = string.Format("datetime'{0}'", givenValue);
            }
            else if (edmType == EdmType.Guid)
            {
                valueOperand = string.Format("guid'{0}'", givenValue);
            }
            else if (edmType == EdmType.Binary)
            {
                valueOperand = string.Format("X'{0}'", givenValue);
            }
            else
            {
                valueOperand = string.Format("'{0}'", givenValue);
            }

            return string.Format("{0} {1} {2}", propertyName, operation, valueOperand);
        }

        /// <summary>
        /// Creates a filter condition using the specified logical operator on two filter conditions.
        /// </summary>
        /// <param name="filterA">A string containing the first formatted filter condition.</param>
        /// <param name="operatorString">A string containing <code>Operators.AND</code> or <code>Operators.OR</code>.</param>
        /// <param name="filterB">A string containing the second formatted filter condition.</param>
        /// <returns>A string containing the combined filter expression.</returns>
        public static string CombineFilters(string filterA, string operatorString, string filterB)
        {
            return string.Format("({0}) {1} ({2})", filterA, operatorString, filterB);
        }

        #endregion

        #region Properties

        private int? takeCount = null;

        /// <summary>
        /// Gets or sets the number of entities the table query will return. 
        /// </summary>
        /// <value>The maximum number of entities for the table query to return.</value>
        public int? TakeCount
        {
            get
            {
                return this.takeCount;
            }

            set
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new ArgumentException(SR.TakeCountNotPositive);
                }

                this.takeCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the filter expression to use in the table query.
        /// </summary>
        /// <value>A string containing the filter expression to use in the query.</value>
        public string FilterString { get; set; }

        /// <summary>
        /// Gets or sets the property names of the table entity properties to return when the table query is executed.
        /// </summary>
        /// <value>A list of strings containing the property names of the table entity properties to return when the query is executed.</value>
        public IList<string> SelectColumns { get; set; }

        /// <summary>
        /// Defines the property names of the table entity properties to return when the table query is executed. 
        /// </summary>
        /// <remarks>The select clause is optional on a table query, used to limit the table properties returned from the server. By default, a query will return all properties from the table entity.</remarks>
        /// <param name="columns">A list of string objects containing the property names of the table entity properties to return when the query is executed.</param>
        /// <returns>A <see cref="TableQuery"/> instance set with the table entity properties to return.</returns>
        public TableQuery Select(IList<string> columns)
        {
            this.SelectColumns = columns;
            return this;
        }

        /// <summary>
        /// Defines the upper bound for the number of entities the query returns.
        /// </summary>
        /// <param name="take">The maximum number of entities for the table query to return.</param>
        /// <returns>A <see cref="TableQuery"/> instance set with the number of entities to return.</returns>
        public TableQuery Take(int? take)
        {
            this.TakeCount = take;
            return this;
        }

        /// <summary>
        /// Defines a filter expression for the table query. Only entities that satisfy the specified filter expression will be returned by the query. 
        /// </summary>
        /// <remarks>Setting a filter expression is optional; by default, all entities in the table are returned if no filter expression is specified in the table query.</remarks>
        /// <param name="filter">A string containing the filter expression to apply to the table query.</param>
        /// <returns>A <see cref="TableQuery"/> instance set with the filter on entities to return.</returns>
        public TableQuery Where(string filter)
        {
            this.FilterString = filter;
            return this;
        }
        #endregion

        #region Impl

        internal UriQueryBuilder GenerateQueryBuilder()
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            // filter
            if (!string.IsNullOrEmpty(this.FilterString))
            {
                builder.Add(TableConstants.Filter, this.FilterString);
            }

            // take
            if (this.takeCount.HasValue)
            {
                builder.Add(TableConstants.Top, Convert.ToString(this.takeCount.Value));
            }

            // select
            if (this.SelectColumns != null && this.SelectColumns.Count > 0)
            {
                StringBuilder colBuilder = new StringBuilder();
                bool foundRk = false;
                bool foundPk = false;
                bool foundTs = false;

                for (int m = 0; m < this.SelectColumns.Count; m++)
                {
                    if (this.SelectColumns[m] == TableConstants.PartitionKey)
                    {
                        foundPk = true;
                    }
                    else if (this.SelectColumns[m] == TableConstants.RowKey)
                    {
                        foundRk = true;
                    }
                    else if (this.SelectColumns[m] == TableConstants.Timestamp)
                    {
                        foundTs = true;
                    }

                    colBuilder.Append(this.SelectColumns[m]);
                    if (m < this.SelectColumns.Count - 1)
                    {
                        colBuilder.Append(",");
                    }
                }

                if (!foundPk)
                {
                    colBuilder.Append(",");
                    colBuilder.Append(TableConstants.PartitionKey);
                }

                if (!foundRk)
                {
                    colBuilder.Append(",");
                    colBuilder.Append(TableConstants.RowKey);
                }

                if (!foundTs)
                {
                    colBuilder.Append(",");
                    colBuilder.Append(TableConstants.Timestamp);
                }

                builder.Add(TableConstants.Select, colBuilder.ToString());
            }

            return builder;
        }
        #endregion
    }
}
