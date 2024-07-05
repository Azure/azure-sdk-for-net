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

    //// Note: OAI LROs can stop before completing, and user needs to resume them somehow.
    //// Generally: should this be extensible by the client to represent more
    //// states in the state machine?
    //Stopped,

    // Note: taking Stopped out b/c user can just call with ReturnWhen.Started
    // and then use client-specific LRO APIs.  We can document this.

    Completed
}
#pragma warning restore CS1591 // public XML comments
