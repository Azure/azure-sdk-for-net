// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ClientModel.Primitives.TwoWayClient;

/// <summary>
/// This is the equivalent of RequestOptions for HTTP requests
/// </summary>
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TwoWayMessageOptions
{
    // TODO: Error options?
    // TODO: Policies for the two-way pipeline?
    // TODO: method to apply options to ClientMessage?

    private bool _frozen;

    public CancellationToken CancellationToken { get; set; }

    // TODO: is this too WebSocket-specific?
    public bool? IsLastFragment {  get; set; }

    // TODO: content type?
    // Other message-specific metadata (on RequestOptions we have AddHeader)

    /// <summary>
    /// Freeze this instance of <see cref="RequestOptions"/>.  After this method
    /// has been called, any attempt to set properties on the instance or call
    /// methods that would change its state will throw <see cref="InvalidOperationException"/>.
    /// </summary>
    public virtual void Freeze() => _frozen = true;

    /// <summary>
    /// Assert that <see cref="Freeze"/> has not been called on this
    /// <see cref="RequestOptions"/> instance.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when an attempt is
    /// made to change the state of this <see cref="RequestOptions"/> instance
    /// after <see cref="Freeze"/> has been called.</exception>
    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a TwoWayMessageOptions instance after it has been passed to a client method.");
        }
    }
}
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
