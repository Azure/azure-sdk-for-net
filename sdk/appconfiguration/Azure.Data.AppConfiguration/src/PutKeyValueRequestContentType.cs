// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Internalize & convert to extensible enum since it's unused and the "application/*+json" enum member is not handled gracefully.
    internal partial struct PutKeyValueRequestContentType
    {
        public static PutKeyValueRequestContentType ApplicationJson { get; } = new PutKeyValueRequestContentType(ApplicationJsonValue);
    }
}
