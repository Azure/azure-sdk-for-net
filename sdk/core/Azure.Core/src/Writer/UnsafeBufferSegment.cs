// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core;

internal struct UnsafeBufferSegment
{
    public byte[] Array;
    public int Written;
}
