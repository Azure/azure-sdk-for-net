using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    public class DAGNode<DataT> : Node<DataT>
    {
        private HashSet<string> dependentKeys;
        private int toBeResolved;
        internal object LockObject = new object();

        public DAGNode(string key, DataT data) : base(key, data)
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
            dependentKey = dependentKey.ToLowerInvariant();
            if (dependentKeys.Contains(dependentKey))
            {
                throw new DependentExistsException(Key, dependentKey);
            }

            dependentKeys.Add(dependentKey);
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
