// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public interface IPatchModel
    {
        public bool HasChanges { get; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
