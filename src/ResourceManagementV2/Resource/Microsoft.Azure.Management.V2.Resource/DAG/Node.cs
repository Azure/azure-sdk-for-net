using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Management.V2.Resource.DAG
{
    public class Node<T>
    {
        private List<string> children;

        public Node(string key, T data)
        {
            Key = key;
            Data = data;
            children = new List<string>();
        }

        public string Key
        {
            get; private set;
        }

        public T Data
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
                return new ReadOnlyCollection<string>(children);
            }
        }

        public void AddChild(string childKey)
        {
            children.Add(childKey);
        }
    }
}
