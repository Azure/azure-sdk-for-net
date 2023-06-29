// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

#nullable enable

namespace Azure.Core.Json
{
    internal class MutableJsonPatchNode
    {
        public MutableJsonPatchNode(string name, MutableJsonPatchNodeKind kind)
        {
            Name = name;
            Children = new List<MutableJsonPatchNode>();
            Kind = kind;
        }

        public MutableJsonPatchNode(string name, MutableJsonChange change)
        {
            Name = name;
            Change = change;
            Children = new List<MutableJsonPatchNode>();
            Kind = MutableJsonPatchNodeKind.Value;
        }

        public string Name { get; }

        public MutableJsonPatchNodeKind Kind { get; }

        public MutableJsonChange? Change { get; }

        public IList<MutableJsonPatchNode> Children { get; }

        public bool TryGetNode(string name, out MutableJsonPatchNode node)
        {
            foreach (MutableJsonPatchNode child in Children)
            {
                if (child.Name == name)
                {
                    node = child;
                    return true;
                }
            }

            node = this;
            return false;
        }
    }

    internal enum MutableJsonPatchNodeKind
    {
        Value,
        Object,
        Array
    }
}
