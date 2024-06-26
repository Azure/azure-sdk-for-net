// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel;

#pragma warning disable CS1591

public abstract class ClientToken
{
    protected ClientToken() { }

    //// Do we need this property?
    //protected abstract PageToken FirstPageToken { get; }

    // Does it need to be public?
    public abstract BinaryData ToBytes();
}

#pragma warning restore CS1591
