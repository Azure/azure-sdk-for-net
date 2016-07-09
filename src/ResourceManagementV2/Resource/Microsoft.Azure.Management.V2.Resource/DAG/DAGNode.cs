using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Management.V2.Resource.DAG
{
    public class DAGNode<T> : Node<T>
    {
        private List<string> dependentKeys;
        private int toBeResolved;

        public DAGNode(string key, T data) : base(key, data)
        {
            dependentKeys = new List<string>();
        }

        public IReadOnlyCollection<string> DependentKeys
        {
            get
            {
                return new ReadOnlyCollection<string>(dependentKeys);
            }
        }

        public void AddDependent(string key)
        {
            this.dependentKeys.Add(key);
        }

        public IReadOnlyCollection<string> DependencyKeys
        {
            get
            {
                return Children;
            }
        }

        public bool IsPreparer { get; private set; }

        public void AddDependency(string dependencyKey)
        {
            AddChild(dependencyKey);
        }

        public bool hasDependencies()
        {
            return HasChildren;
        }

        public void SetPreparer(bool isPreparer)
        {
            this.IsPreparer = isPreparer;
        }

        public void Initialize()
        {
            toBeResolved = DependencyKeys.Count;
            dependentKeys.Clear();
        }

        public bool HasAllResolved()
        {
            return toBeResolved == 0;
        }

        public void ReportCompleted(string dependencyKey)
        {
            if (toBeResolved == 0)
            {
                throw new InvalidOperationException("invalid state - " + Key + ": The dependency '" + dependencyKey + "' is already reported or there is no such dependencyKey");
            }
            toBeResolved--;
        }
    }
}
