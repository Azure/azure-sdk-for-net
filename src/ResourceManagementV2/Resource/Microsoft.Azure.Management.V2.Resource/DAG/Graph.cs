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
            graph.Add(node.Key, node);
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
        }

        private void Dfs(Action<U> visitor, U node)
        {
            visitor(node);
            foreach(string childKey in node.Children)
            {
                if (!visited.Contains(childKey))
                {
                    U childNode;
                    if (!graph.TryGetValue(childKey, out childNode))
                    {
                        // TODO
                    }
                    Dfs(visitor, childNode);
                }
            }

        }
    }
}
