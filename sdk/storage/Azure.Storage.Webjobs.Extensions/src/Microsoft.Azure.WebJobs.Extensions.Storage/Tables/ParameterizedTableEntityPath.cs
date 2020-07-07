// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;

namespace Microsoft.Azure.WebJobs.Host.Tables
{
    internal class ParameterizedTableEntityPath : IBindableTableEntityPath
    {
        private readonly BindingTemplate _tableNameTemplate;
        private readonly BindingTemplate _partitionKeyTemplate;
        private readonly BindingTemplate _rowKeyTemplate;

        public ParameterizedTableEntityPath(BindingTemplate tableNameTemplate, BindingTemplate partitionKeyTemplate, 
            BindingTemplate rowKeyTemplate)
        {
            Debug.Assert(tableNameTemplate.HasParameters || partitionKeyTemplate.HasParameters
                || rowKeyTemplate.HasParameters);

            _tableNameTemplate = tableNameTemplate;
            _partitionKeyTemplate = partitionKeyTemplate;
            _rowKeyTemplate = rowKeyTemplate;
        }

        public string TableNamePattern
        {
            get { return _tableNameTemplate.Pattern; }
        }

        public string PartitionKeyPattern
        {
            get { return _partitionKeyTemplate.Pattern; }
        }

        public string RowKeyPattern
        {
            get { return _rowKeyTemplate.Pattern; }
        }

        public bool IsBound
        {
            get { return false; }
        }

        public IEnumerable<string> ParameterNames
        {
            get 
            { 
                return _tableNameTemplate.ParameterNames
                    .Concat(_partitionKeyTemplate.ParameterNames)
                    .Concat(_rowKeyTemplate.ParameterNames); 
            }
        }

        public TableEntityPath Bind(IReadOnlyDictionary<string, object> bindingData)
        {
            string tableName = _tableNameTemplate.Bind(bindingData);
            string partitionKey = _partitionKeyTemplate.Bind(bindingData);
            string rowKey = _rowKeyTemplate.Bind(bindingData);

            TableClient.ValidateAzureTableName(tableName);
            TableClient.ValidateAzureTableKeyValue(partitionKey);
            TableClient.ValidateAzureTableKeyValue(rowKey);

            return new TableEntityPath(tableName, partitionKey, rowKey);
        }

        public override string ToString()
        {
            return _tableNameTemplate.Pattern + "/" + _partitionKeyTemplate.Pattern + "/" + _rowKeyTemplate.Pattern;
        }
    }
}
