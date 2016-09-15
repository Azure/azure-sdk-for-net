using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    public class Graph<NodeDataT, NodeT> where NodeT : Node<NodeDataT>
    {
        protected IDictionary<string, NodeT> graph;
        private HashSet<string> visited;

        public Graph()
        {
            graph = new Dictionary<string, NodeT>();
            visited = new HashSet<string>();
        }

        public void AddNode(NodeT node)
        {
            if (Contains(node.Key))
            {
                throw new NodeExistsException(node.Key);
            }

            graph.Add(node.Key.ToLowerInvariant(), node);
        }

        public bool Contains(string key)
        {
            NodeT value;
            return graph.TryGetValue(key.ToLowerInvariant(), out value);
        }

        public NodeT GetNode(string key)
        {
            NodeT value;
            if (!graph.TryGetValue(key.ToLowerInvariant(), out value))
            {
                throw new NodeNotFoundException(key);
            }
            return value;
        }

        public void Visit(Action<NodeT> visitor)
        {
            foreach (KeyValuePair<string, NodeT> item in graph)
            {
                if (!visited.Contains(item.Key))
                {
                    Dfs(visitor, item.Value);
                }
            }
            visited.Clear();
        }

        private void Dfs(Action<NodeT> visitor, NodeT node)
        {
            visitor(node);
            visited.Add(node.Key);
            foreach (string childKey in node.Children)
            {
                var lowerCaseChildKey = childKey.ToLowerInvariant();
                if (!visited.Contains(lowerCaseChildKey))
                {
                    NodeT childNode;
                    if (!graph.TryGetValue(lowerCaseChildKey, out childNode))
                    {
                        // TODO: Better exception for errors due to internal logic error
                        throw new Exception("unexpected state: the node " + childKey + " is marked as the child node of " + node.Key + ",but graph does not contain a node with key " + childKey);
                    }
                    Dfs(visitor, childNode);
                }
            }
        }
    }
}