// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core.Json
{
    internal enum MutableJsonChangeKind
    {
        PropertyUpdate,
        PropertyAddition,
        PropertyRemoval,
    }
}
