﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel.Core;

public abstract class MessageRequest : IDisposable
{
    public abstract string Method { get; set; }

    public abstract Uri Uri { get; set; }

    public abstract RequestBody? Body { get; set; }

    public abstract MessageHeaders Headers { get; }

    // TODO: this is required by Azure.Core RequestAdapter constraint.  Revisit?
    public abstract void Dispose();
}