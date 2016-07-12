using System;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    public class ChildExistsException : Exception {
        public ChildExistsException(string parentKey, string childKey) : base("A child with key '" + childKey + "' already exists in the parent '" + parentKey + "'") {}
    }

    public class NodeExistsException : Exception {
        public NodeExistsException(string key) : base("A node with key '" + key + "' already exists in the graph") {}
    }

    public class NodeNotFoundException : Exception {
        public NodeNotFoundException(string key) : base("A node with key '" + key + "' not found in the graph") {}
    }

    public class DependentExistsException : Exception {
        public DependentExistsException(string dependencyKey, string dependentKey) : base("The node '" + dependentKey + "' is already marked as dependent of the node '" + dependencyKey + "'") {
        }
    }

    public class CircularDependencyException : Exception {
        public CircularDependencyException() : base("Found circular dependency in the graph") {}
    }
}
