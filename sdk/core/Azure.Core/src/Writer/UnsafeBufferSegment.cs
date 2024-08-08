// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core;

internal struct UnsafeBufferSegment
{
    public byte[] Array;
    public int Written;
}
