// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public readonly struct ChangeListElement
    {
        private readonly ChangeList _root;

        // TODO: implement as Memory<char>
        private readonly string _path;

        internal ChangeListElement(ChangeList root, string path)
        {
            _root = root;
            _path = path;
        }

        public readonly ChangeListElement GetElement(string path)
        {
            return new ChangeListElement(_root, _path +  path);
        }

        public readonly void Set(string path, string value)
        {
            _root.AddChange(path, value);
        }

        public readonly void Set(string path, int? value)
        {
            _root.AddChange(path, value);
        }

        public readonly void Set(string path, DateTimeOffset? value)
        {
            _root.AddChange(path, value);
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
