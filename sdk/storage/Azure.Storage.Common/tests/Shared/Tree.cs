// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Tests
{
    /// <summary>
    /// Tree implementation where all immediate children of a node must have
    /// a unique <see cref="Value"/>.
    /// Each tree node contains <see cref="Value"/> for the node contents
    /// and is a <see cref="HashSet{T}"/> of <see cref="Tree{T}"/> children.
    /// </summary>
    /// <typeparam name="T">Type of node values.</typeparam>
    /// <remarks>
    /// The hash set compares equality of only the <see cref="Value"/>,
    /// disregarding children. However, this is only for comparisons within
    /// the tree. <see cref="object.Equals(object?)"/>
    /// and <see cref="object.GetHashCode"/> are not implemented.
    /// </remarks>
    internal class Tree<T> : HashSet<Tree<T>>
    {
        public T Value { get; set; }

        public Tree() : base(new DefaultTreeNodeEqualityComparer<T>())
        {
        }

        public Tree(IEqualityComparer<T> valueComparer) : base(new TreeNodeEqualityComparer<T>(valueComparer))
        {
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class DefaultTreeNodeEqualityComparer<T> : IEqualityComparer<Tree<T>>
#pragma warning restore SA1402 // File may only contain a single type
    {
        public bool Equals(Tree<T> x, Tree<T> y) => x.Value.Equals(y.Value);

        public int GetHashCode(Tree<T> obj) => obj.Value.GetHashCode();
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class TreeNodeEqualityComparer<T> : IEqualityComparer<Tree<T>>
#pragma warning restore SA1402 // File may only contain a single type
    {
        private readonly IEqualityComparer<T> _comparer;

        public TreeNodeEqualityComparer(IEqualityComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public bool Equals(Tree<T> x, Tree<T> y) => _comparer.Equals(x.Value, y.Value);

        public int GetHashCode(Tree<T> obj) => _comparer.GetHashCode(obj.Value);
    }
}
