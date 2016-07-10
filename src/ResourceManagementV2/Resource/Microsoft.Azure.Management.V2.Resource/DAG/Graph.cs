using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.DAG
{
    public class Graph<T, U> where U : Node<T>
    {
        protected IDictionary<string, U> graph;
        private HashSet<string> visited;

        public Graph()
        {
            graph = new Dictionary<string, U>();
            visited = new HashSet<string>();
        }

        public void AddNode(U node)
        {
            if (Contains(node.Key))
            {
                throw new NodeExistsException(node.Key);
            }

            graph.Add(node.Key.ToLowerInvariant(), node);
        }

        public bool Contains(string key)
        {
            U value;
            return graph.TryGetValue(key.ToLowerInvariant(), out value);
        }

        public U GetNode(string key)
        {
            U value;
            if (!graph.TryGetValue(key.ToLowerInvariant(), out value))
            {
                throw new NodeNotFoundException(key);
            }
            return value;
        }

        public void Visit(Action<U> visitor)
        {
            foreach(KeyValuePair<string, U> item in graph)
            {
                if (!visited.Contains(item.Key))
                {
                    Dfs(visitor, item.Value);
                }
            }
            visited.Clear();
        }

        private void Dfs(Action<U> visitor, U node)
        {
            visitor(node);
            visited.Add(node.Key);
            foreach(string childKey in node.Children)
            {
                if (!visited.Contains(childKey))
                {
                    U childNode;
                    if (!graph.TryGetValue(childKey, out childNode))
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
