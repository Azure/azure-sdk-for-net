// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Extensions.Tables;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Table or Table entity.
    /// </summary>
    /// <remarks>
    /// When only the table name is provided, the attribute binds to a table, and the method parameter type can be one
    /// of the following:
    /// <list type="bullet">
    /// <item><description>TableClient</description></item>
    /// <item><description><see cref="IQueryable{T}"/> (where T implements ITableEntity)</description></item>
    /// </list>
    /// When the table name, partition key, and row key are provided, the attribute binds to a table entity, and the
    /// method parameter type can be one of the following:
    /// <list type="bullet">
    /// <item><description>ITableEntity</description></item>
    /// <item><description>
    /// A user-defined type not implementing ITableEntity (serialized as strings for simple types and JSON for complex
    /// types)
    /// </description></item>
    /// </list>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [ConnectionProvider(typeof(StorageAccountAttribute))]
    [Binding]
    public class TableAttribute : Attribute, IConnectionProvider
    {
        // Table Name Rules are summarized in this page https://msdn.microsoft.com/en-us/library/azure/dd179338.aspx
        // Table names may contain only alphanumeric characters, can not start with a numeric character and must be
        // 3 to 63 characters long
        private const string TableNameRegex = "^[A-Za-z][A-Za-z0-9]{2,62}$";
        private readonly string _tableName;
        private readonly string _partitionKey;
        private readonly string _rowKey;

        /// <summary>Initializes a new instance of the <see cref="TableAttribute"/> class.</summary>
        /// <param name="tableName">The name of the table to which to bind.</param>
        public TableAttribute(string tableName)
        {
            _tableName = tableName;
        }

        /// <summary>Initializes a new instance of the <see cref="TableAttribute"/> class.</summary>
        /// <param name="tableName">The name of the table containing the entity.</param>
        /// <param name="partitionKey">The partition key of the entity.</param>
        public TableAttribute(string tableName, string partitionKey)
        {
            _tableName = tableName;
            _partitionKey = partitionKey;
        }

        /// <summary>Initializes a new instance of the <see cref="TableAttribute"/> class.</summary>
        /// <param name="tableName">The name of the table containing the entity.</param>
        /// <param name="partitionKey">The partition key of the entity.</param>
        /// <param name="rowKey">The row key of the entity.</param>
        public TableAttribute(string tableName, string partitionKey, string rowKey)
        {
            _tableName = tableName;
            _partitionKey = partitionKey;
            _rowKey = rowKey;
        }

        /// <summary>Gets the name of the table to which to bind.</summary>
        /// <remarks>When binding to a table entity, gets the name of the table containing the entity.</remarks>
        [AutoResolve]
        [RegularExpression(TableNameRegex)]
        public string TableName => _tableName;

        /// <summary>When binding to a table entity, gets the partition key of the entity.</summary>
        /// <remarks>When binding to an entire table, returns <see langword="null"/>.</remarks>
        [AutoResolve]
        public string PartitionKey => _partitionKey;

        /// <summary>When binding to a table entity, gets the row key of the entity.</summary>
        /// <remarks>When binding to an entire table, returns <see langword="null"/>.</remarks>
        [AutoResolve]
        public string RowKey => _rowKey;

        /// <summary>
        /// Gets or sets an OData table filter. <see cref="RowKey"/> should be null when setting this property.
        /// For example, to filter on a LastName and FirstName property within an entity, you might set the Filter as follows:
        /// <code>Filter = "LastName%20eq%20'Smith'%20and%20FirstName%20eq%20'John'"</code>
        ///
        /// To learn more about constructing OData filter strings,
        /// see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/querying-tables-and-entities#constructing-filter-strings"/>.
        /// </summary>
        [AutoResolve(ResolutionPolicyType = typeof(ODataFilterResolutionPolicy))]
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets the number of elements to include when using the <see cref="Filter"/> property. <see cref="RowKey"/> should be null
        /// when setting this property.
        /// </summary>
        public int Take { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private string DebuggerDisplay
        {
            get
            {
                if (_rowKey == null)
                {
                    return _tableName;
                }
                else
                {
                    return string.Format(CultureInfo.InvariantCulture, "{0}(PK={1}, RK={2})",
                        _tableName, _partitionKey, _rowKey);
                }
            }
        }

        /// <summary>
        /// Gets or sets the app setting name that contains the Azure Storage or Azure Cosmos connection string.
        /// </summary>
        public string Connection { get; set; }
    }
}