// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Azure.Data.Tables;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class StringToTableEntityContextConverter : IConverter<string, TableEntityContext>
    {
        private readonly TableServiceClient _client;
        private readonly IBindableTableEntityPath _defaultPath;

        public StringToTableEntityContextConverter(TableServiceClient client, IBindableTableEntityPath defaultPath)
        {
            _client = client;
            _defaultPath = defaultPath;
        }

        public TableEntityContext Convert(string input)
        {
            TableEntityPath path;
            // For convenience, treat an an empty string as a request for the default value (when valid).
            if (String.IsNullOrEmpty(input) && _defaultPath.IsBound)
            {
                path = _defaultPath.Bind(null);
            }
            else
            {
                path = TableEntityPath.ParseAndValidate(input);
            }

            return new TableEntityContext
            {
                Table = _client.GetTableClient(path.TableName),
                PartitionKey = path.PartitionKey,
                RowKey = path.RowKey
            };
        }
    }
}