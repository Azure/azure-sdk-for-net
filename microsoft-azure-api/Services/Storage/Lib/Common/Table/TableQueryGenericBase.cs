// -----------------------------------------------------------------------------------------
// <copyright file="TableQueryGenericBase.cs" company="Microsoft">
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
    using System.Globalization;
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
    public sealed partial class TableQuery<TElement> where TElement : ITableEntity, new()
    {
        #region Filter Generation

        /// <summary>
        /// Generates a property filter condition string for the string value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="value">A string containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterCondition(string propertyName, string operation, string value)
        {
            value = value ?? string.Empty;
            return GenerateFilterCondition(propertyName, operation, value, EdmType.String);
        }

        /// <summary>
        /// Generates a property filter condition string for the boolean value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="value">A <c>bool</c> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForBool(string propertyName, string operation, bool value)
        {
            return GenerateFilterCondition(propertyName, operation, value ? "true" : "false", EdmType.Boolean);
        }

        /// <summary>
        /// Generates a property filter condition string for the binary value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="value">A byte array containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Needed for Common Code preprocessor directives.")]
        public static string GenerateFilterConditionForBinary(
            string propertyName,
            string operation,
#if RT
            [ReadOnlyArray]
#endif
            byte[] value)
        {
            CommonUtils.AssertNotNull("value", value);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in value)
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
        /// <param name="value">A <see cref="DateTimeOffset"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForDate(string propertyName, string operation, DateTimeOffset value)
        {
            return GenerateFilterCondition(propertyName, operation, value.UtcDateTime.ToString("o", CultureInfo.InvariantCulture), EdmType.DateTime);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="double"/> value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="value">A <see cref="double"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForDouble(string propertyName, string operation, double value)
        {
            return GenerateFilterCondition(propertyName, operation, Convert.ToString(value, CultureInfo.InvariantCulture), EdmType.Double);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="int"/> value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="value">A <see cref="int"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForInt(string propertyName, string operation, int value)
        {
            return GenerateFilterCondition(propertyName, operation, Convert.ToString(value, CultureInfo.InvariantCulture), EdmType.Int32);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="long"/> value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="value">A <see cref="long"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForLong(string propertyName, string operation, long value)
        {
            return GenerateFilterCondition(propertyName, operation, Convert.ToString(value, CultureInfo.InvariantCulture), EdmType.Int64);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="Guid"/> value.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="value">A <see cref="Guid"/> containing the value to compare with the property.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        public static string GenerateFilterConditionForGuid(string propertyName, string operation, Guid value)
        {
            CommonUtils.AssertNotNull("value", value);
            return GenerateFilterCondition(propertyName, operation, value.ToString(), EdmType.Guid);
        }

        /// <summary>
        /// Generates a property filter condition string for the <see cref="EdmType"/> value, formatted as the specified <see cref="EdmType"/>.
        /// </summary>
        /// <param name="propertyName">A string containing the name of the property to compare.</param>
        /// <param name="operation">A string containing the comparison operator to use.</param>
        /// <param name="value">A string containing the value to compare with the property.</param>
        /// <param name="edmType">The <see cref="EdmType"/> to format the value as.</param>
        /// <returns>A string containing the formatted filter condition.</returns>
        private static string GenerateFilterCondition(string propertyName, string operation, string value, EdmType edmType)
        {
            string valueOperand = null;

            if (edmType == EdmType.Boolean || edmType == EdmType.Double || edmType == EdmType.Int32)
            {
                valueOperand = value;
            }
            else if (edmType == EdmType.Int64)
            {
                valueOperand = string.Format("{0}L", value);
            }
            else if (edmType == EdmType.DateTime)
            {
                valueOperand = string.Format("datetime'{0}'", value);
            }
            else if (edmType == EdmType.Guid)
            {
                valueOperand = string.Format("guid'{0}'", value);
            }
            else if (edmType == EdmType.Binary)
            {
                valueOperand = string.Format("X'{0}'", value);
            }
            else
            {
                valueOperand = string.Format("'{0}'", value);
            }

            return string.Format("{0} {1} {2}", propertyName, operation, valueOperand);
        }

        /// <summary>
        /// Creates a filter condition using the specified logical operator on two filter conditions.
        /// </summary>
        /// <param name="filterA">A string containing the first formatted filter condition.</param>
        /// <param name="operatorString">A string containing <c>Operators.AND</c> or <c>Operators.OR</c>.</param>
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
        /// Gets or sets the number of entities the query returns specified in the table query. 
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
        public TableQuery<TElement> Select(IList<string> columns)
        {
            this.SelectColumns = columns;
            return this;
        }

        /// <summary>
        /// Defines the upper bound for the number of entities the query returns.
        /// </summary>
        /// <param name="take">The maximum number of entities for the table query to return.</param>
        /// <returns>A <see cref="TableQuery"/> instance set with the number of entities to return.</returns>
        public TableQuery<TElement> Take(int? take)
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
        public TableQuery<TElement> Where(string filter)
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
                builder.Add(TableConstants.Top, Convert.ToString(Math.Min(this.takeCount.Value, TableConstants.TableServiceMaxResults)));
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
