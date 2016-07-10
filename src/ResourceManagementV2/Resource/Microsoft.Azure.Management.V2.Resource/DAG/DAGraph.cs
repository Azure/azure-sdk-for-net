using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.DAG
{
    public class DAGraph<T, U> : Graph<T, U> where U : DAGNode<T> 
    {
        private Queue<string> queue;
        private U rootNode;

        public DAGraph(U rootNode)
        {
            this.rootNode = rootNode;
            queue = new Queue<string>();
            this.rootNode.SetPreparer(true);
            this.AddNode(rootNode);
        }

        public bool IsRootNode(U node)
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

        public void Merge(DAGraph<T, U> parent)
        {
            parent.rootNode.AddDependency(rootNode.Key);
            foreach(KeyValuePair<string, U> item in this.graph) {
                if (!parent.graph.ContainsKey(item.Key))
                {
                    parent.graph.Add(item.Key, item.Value);
                }
            }
        }

        public void Prepare()
        {
            if (IsPreparer)
            {
                foreach(U node in graph.Values)
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

        public U GetNext()
        {
            U nextNode;
            graph.TryGetValue(queue.Dequeue(), out nextNode);
            return nextNode;
        }

        public T GetNodeData(string key)
        {
            U node;
            graph.TryGetValue(key, out node);
            return node.Data;
        }

        public void ReportCompleted(U dependency)
        {
            dependency.SetPreparer(true);
            foreach (string dependentKey in dependency.DependentKeys)
            {
                U dependent = GetNode(dependentKey);
                dependent.ReportCompleted(dependency.Key);
                if (dependent.HasAllResolved)
                {
                    queue.Enqueue(dependent.Key);
                }
            }
        }

        private void InitializeDependentKeys()
        {
            Visit((U node) =>
            {
                if (!node.HasDependencies)
                {
                    return;
                }

                string dependentKey = node.Key;
                foreach (string dependencyKey in node.DependencyKeys)
                {
                    GetNode(dependencyKey).AddDependent(dependentKey);
                }
            });
        }

        private void InitializeQueue()
        {
            queue.Clear();
            foreach(KeyValuePair<string ,U> item in graph)
            {
                if (!item.Value.HasDependencies)
                {
                    queue.Enqueue(item.Key);
                }
            }

            if (queue.Count == 0)
            {
                throw new CircularDependencyException();
            }
        }
    }
}
