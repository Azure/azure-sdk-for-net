// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Resource.Fluent.Core.DAG
{
    public class DAGraph<NodeDataT, NodeT> : Graph<NodeDataT, NodeT> where NodeT : DAGNode<NodeDataT> 
    {
        private ConcurrentQueue<string> queue;
        private NodeT rootNode;

        public DAGraph(NodeT rootNode)
        {
            this.rootNode = rootNode;
            queue = new ConcurrentQueue<string>();
            this.rootNode.SetPreparer(true);
            this.AddNode(rootNode);
        }

        public bool IsRootNode(NodeT node)
        {
            return this.rootNode == node;
        }

        public bool IsPreparer
        {
            get
            {
                return this.rootNode.IsPreparer;
            }
        }

        public void Merge(DAGraph<NodeDataT, NodeT> parent)
        {
            parent.rootNode.AddDependency(rootNode.Key.ToLowerInvariant());
            foreach(KeyValuePair<string, NodeT> item in this.graph) {
                if (!parent.graph.ContainsKey(item.Key.ToLowerInvariant()))
                {
                    parent.graph.Add(item.Key, item.Value);
                }
            }
        }

        public void Prepare()
        {
            if (IsPreparer)
            {
                foreach(NodeT node in graph.Values)
                {
                    node.Initialize(); // clear dependent and set ToBeResolved count
                    if (!this.IsRootNode(node))
                    {
                        node.SetPreparer(false);
                    }
                }
                InitializeDependentKeys();
                InitializeQueue();
            }
        }

        public NodeT GetNext()
        {
            string nodeKey;
            if (queue.TryDequeue(out nodeKey))
            {
                return GetNode(nodeKey);
            }
            return null;
        }

        public NodeDataT GetNodeData(string key)
        {
            return GetNode(key).Data;
        }

        public void ReportCompleted(NodeT dependency)
        {
            dependency.SetPreparer(true);
            foreach (string dependentKey in dependency.DependentKeys)
            {
                NodeT dependent = GetNode(dependentKey.ToLowerInvariant());
                lock (dependent.LockObject)
                {
                    dependent.ReportCompleted(dependency.Key.ToLowerInvariant());
                    if (dependent.HasAllResolved)
                    {
                        queue.Enqueue(dependent.Key.ToLowerInvariant());
                    }
                }
            }
        }

        private void InitializeDependentKeys()
        {
            Visit((NodeT node) =>
            {
                if (!node.HasDependencies)
                {
                    return;
                }

                string dependentKey = node.Key.ToLowerInvariant();
                foreach (string dependencyKey in node.DependencyKeys)
                {
                    GetNode(dependencyKey).AddDependent(dependentKey.ToLowerInvariant());
                }
            });
        }

        private void InitializeQueue()
        {
            // Clear the queue
            string s;
            while (queue.TryDequeue(out s)) { }

            // push the leaf node keys
            foreach(KeyValuePair<string ,NodeT> item in graph)
            {
                if (!item.Value.HasDependencies)
                {
                    queue.Enqueue(item.Key.ToLowerInvariant());
                }
            }

            if (queue.Count == 0)
            {
                throw new CircularDependencyException();
            }
        }
    }
}
