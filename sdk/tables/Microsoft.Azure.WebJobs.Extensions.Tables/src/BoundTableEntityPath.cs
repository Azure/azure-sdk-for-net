// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Host.Tables
{
    internal class BoundTableEntityPath : IBindableTableEntityPath
    {
        private readonly TableEntityPath _innerPath;

        public BoundTableEntityPath(TableEntityPath innerPath)
        {
            _innerPath = innerPath;
        }

        public string TableNamePattern
        {
            get { return _innerPath.TableName; }
        }

        public string PartitionKeyPattern
        {
            get { return _innerPath.PartitionKey; }
        }

        public string RowKeyPattern
        {
            get { return _innerPath.RowKey; }
        }

        public bool IsBound
        {
            get { return true; }
        }

        public IEnumerable<string> ParameterNames
        {
            get { return Enumerable.Empty<string>(); }
        }

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
