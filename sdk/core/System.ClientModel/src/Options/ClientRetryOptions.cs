// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ClientRetryOptions
{
    // TODO: implement freezing
    private bool _frozen;

    public virtual void Freeze() => _frozen = true;

    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a ClientLoggingOptions instance after ClientPipeline has been created.");
        }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
