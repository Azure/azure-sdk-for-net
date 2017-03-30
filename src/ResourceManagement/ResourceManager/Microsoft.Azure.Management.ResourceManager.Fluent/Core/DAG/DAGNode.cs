// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.DAG
{
    public class DAGNode<DataT> : Node<DataT>
    {
        private HashSet<string> dependentKeys;
        private int toBeResolved;
        internal object LockObject = new object();

        public DAGNode(string key, DataT data) 
            : base(key, data)
        {
            dependentKeys = new HashSet<string>();
        }

        public IReadOnlyCollection<string> DependentKeys
        {
            get
            {
                return new ReadOnlyCollection<string>(dependentKeys.ToList());
            }
        }

        public void AddDependent(string dependentKey)
        {
            dependentKeys.Add(dependentKey.ToLowerInvariant());
        }

        public IReadOnlyCollection<string> DependencyKeys
        {
            get
            {
                return Children;
            }
        }

        public void AddDependency(string dependencyKey)
        {
            AddChild(dependencyKey);
        }

        public bool HasDependencies
        {
            get
            {
                return HasChildren;
            }
        }

        public bool IsPreparer { get; private set; }

        public void SetPreparer(bool isPreparer)
        {
            IsPreparer = isPreparer;
        }

        public bool HasAllResolved
        {
            get
            {
                return toBeResolved == 0;
            }
        }

        public void ReportCompleted(string dependencyKey)
        {
            if (toBeResolved == 0)
            {
                throw new InvalidOperationException("invalid state - " + Key + ": The dependency '" + dependencyKey + "' is already reported or there is no such dependencyKey");
            }
            toBeResolved--;
        }

        public void Initialize()
        {
            toBeResolved = DependencyKeys.Count;
            dependentKeys.Clear();
        }
    }
}
