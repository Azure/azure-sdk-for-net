// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;

// TODO: Remove when prototyping complete
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.Core.Dynamic
{
#pragma warning disable CA1720 // Identifier contains type name
    public enum ObjectValueKind
    {
        Undefined,
        Object,
        Array,
        String,
        Integer,
        FloatingPoint,
        Boolean,
        Null
    }
#pragma warning restore CA1720 // Identifier contains type name
}
