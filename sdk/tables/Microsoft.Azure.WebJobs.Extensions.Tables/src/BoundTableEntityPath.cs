// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class BoundTableEntityPath : IBindableTableEntityPath
    {
        private readonly TableEntityPath _innerPath;

        public BoundTableEntityPath(TableEntityPath innerPath)
        {
            _innerPath = innerPath;
        }

        public string TableNamePattern => _innerPath.TableName;

        public string PartitionKeyPattern => _innerPath.PartitionKey;

        public string RowKeyPattern => _innerPath.RowKey;

        public bool IsBound => true;

        public IEnumerable<string> ParameterNames => Enumerable.Empty<string>();

        public TableEntityPath Bind(IReadOnlyDictionary<string, object> bindingData)
        {
            return _innerPath;
        }

        public override string ToString()
        {
            return _innerPath.ToString();
        }
    }
}