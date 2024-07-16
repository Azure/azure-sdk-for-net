// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public enum ReturnWhen
{
    Started,

    // TODO: validate that this works for streaming.
    StateChanged,

    // This means that Update/MoveNext on the update enumerator returned false
    // to indicate that updates aren't currently available.
    Stopped
}
#pragma warning restore CS1591 // public XML comments
