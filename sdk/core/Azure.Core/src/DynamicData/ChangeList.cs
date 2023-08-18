// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ChangeList
    {
        private readonly List<ChangeListChange> _changes;
        private readonly ChangeListElement _rootElement;

        public ChangeList()
        {
            // TODO: allocate lazily
            _changes = new List<ChangeListChange>();

            // TODO: allocate lazily
            _rootElement = new ChangeListElement(this, string.Empty);
        }

        public ChangeListElement RootElement { get => _rootElement; }

        public void AddChange(ChangeListChange change)
        {
            _changes.Add(change);
        }

        public void WriteMergePatch()
        {
            // TODO
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
