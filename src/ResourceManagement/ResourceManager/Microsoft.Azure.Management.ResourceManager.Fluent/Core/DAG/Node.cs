// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.DAG
{
    public class Node<DataT>
    {
        private HashSet<string> children;

        public Node(string key, DataT data)
        {
            Key = key;
            Data = data;
            children = new HashSet<string>();
        }

        public string Key
        {
            get; private set;
        }

        public DataT Data
        {
            get; private set;
        }

        public bool HasChildren
        {
            get
            {
                return children.Count != 0;
            }
        }

        public IReadOnlyCollection<string> Children
        {
            get
            {
                return new ReadOnlyCollection<string>(children.ToList());
            }
        }

        public void AddChild(string childKey)
        {
            children.Add(childKey);
        }
    }
}
