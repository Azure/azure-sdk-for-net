// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.TwoWayClient;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TwoWayPipelineOptions
{
    private bool _frozen;

    /// <summary>
    /// Freeze this instance of <see cref="ClientPipelineOptions"/>.  After
    /// this method has been called, any attempt to set properties on the
    /// instance or call methods that would change its state will throw
    /// <see cref="InvalidOperationException"/>.
    /// </summary>
    public virtual void Freeze() => _frozen = true;

    /// <summary>
    /// Assert that <see cref="Freeze"/> has not been called on this
    /// <see cref="ClientPipelineOptions"/> instance.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when an attempt is
    /// made to change the state of this <see cref="ClientPipelineOptions"/>
    /// instance after <see cref="Freeze"/> has been called.</exception>
    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a TwoWayPipelineOptions instance after it has been used to create a ClientPipeline.");
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
