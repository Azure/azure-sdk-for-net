// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    // Value kinds for encoding type information in byte arrays
    [Flags]
    internal enum ValueKind : short
    {
        None = 0,
        Json = 1 << 0,
        Number = 1 << 1,
        Utf8String = 1 << 2,
        Removed = 1 << 3,
        Null = 1 << 4,
        BooleanTrue = 1 << 5,
        BooleanFalse = 1 << 6,
        ArrayItemAppend = 1 << 7,
        ModelOwned = 1 << 8,
        DateTime = 1 << 9,
        Guid = 1 << 10,
        TimeSpan = 1 << 11,
    }
}
