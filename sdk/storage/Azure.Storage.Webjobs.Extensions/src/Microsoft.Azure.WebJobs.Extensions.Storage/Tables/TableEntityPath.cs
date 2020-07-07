// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Tables
{
    internal class TableEntityPath
    {
        private readonly string _tableName;
        private readonly string _partitionKey;
        private readonly string _rowKey;

        public TableEntityPath(string tableName, string partitionKey, string rowKey)
        {
            _tableName = tableName;
            _partitionKey = partitionKey;
            _rowKey = rowKey;
        }

        public string TableName
        {
            get { return _tableName; }
        }

        public string PartitionKey
        {
            get { return _partitionKey; }
        }

        public string RowKey
        {
            get { return _rowKey; }
        }

        public override string ToString()
        {
            return _tableName + "/" + _partitionKey + "/" + _rowKey;
        }

        public static TableEntityPath ParseAndValidate(string value)
        {
            TableEntityPath path;

            if (!TryParseAndValidate(value, out path))
            {
                throw new InvalidOperationException("Table entity identifiers must be in the format " +
                    "TableName/PartitionKey/RowKey and must meet table naming requirements.");
            }

            return path;
        }

        public static bool TryParseAndValidate(string value, out TableEntityPath path)
        {
            if (value == null)
            {
                path = null;
                return false;
            }

            string[] components = value.Split(new char[] { '/' });
            if (components.Length != 3)
            {
                path = null;
                return false;
            }

            string tableName = components[0];
            string partitionKey = components[1];
            string rowKey = components[2];

            if (!TableClient.IsValidAzureTableName(tableName))
            {
                path = null;
                return false;
            }

            if (!TableClient.IsValidAzureTableKeyValue(partitionKey))
            {
                path = null;
                return false;
            }

            if (!TableClient.IsValidAzureTableKeyValue(rowKey))
            {
                path = null;
                return false;
            }

            path = new TableEntityPath(tableName, partitionKey, rowKey);
            return true;
        }
    }
}
