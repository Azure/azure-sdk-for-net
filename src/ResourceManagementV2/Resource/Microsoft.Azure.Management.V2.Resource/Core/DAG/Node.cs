using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
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
            if (children.Contains(childKey))
            {
                throw new ChildExistsException(Key, childKey);
            }

            children.Add(childKey);
        }
    }
}
