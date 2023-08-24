// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Serialization
{
    internal readonly struct MergePatchChanges
    {
        private readonly bool[] _changed;

        public MergePatchChanges(int propertyCount)
        {
            _changed = new bool[propertyCount];
        }

        public void Change(int index) => _changed[index] = true;

        public bool HasChanged(int index) => _changed[index];
    }
}
