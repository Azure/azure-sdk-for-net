// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.FullDuplexMessaging;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class DuplexPipelineOptions
{
    private bool _frozen;

    /// <summary>
    /// Heartbeat to move pipeline response iterator forward at a regular interval.
    /// Default is one second, but client or application may want to set it to
    /// a smaller value to make the application more responsive.
    /// </summary>
    // TODO: Question: should this go in the pipeline options or be a parameter to
    // DuplexConnectionResult?  i.e. at what abstraction layer should the hearbeat
    // be implemented?  There is an argument that it should go in the connection
    // result so that the pipeline can represent only the sent and received messages
    // between the client and the service.  There is another argument that the
    // heartbeat could be implemented as a pipeline policy, and doing so would
    // enable customization via custom heartbeat policies -- which could be a nice
    // extensibility feature.
    public int? HeartbeatMilliseconds { get; set; }

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
            throw new InvalidOperationException("Cannot change a DuplexPipelineOptions instance after it has been used to create a ClientPipeline.");
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
