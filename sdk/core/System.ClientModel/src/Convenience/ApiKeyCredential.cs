// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel;

/// <summary>
/// API key credential used to authenticate to a service.
/// This credential type provides the ability to update the key's value without
/// creating a new client.
/// </summary>
public class ApiKeyCredential
{
    private string _key;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiKeyCredential"/> class.
    /// </summary>
    /// <param name="key">Key to use to authenticate with the service.</param>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown when the <paramref name="key"/> is null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// Thrown when the <paramref name="key"/> is empty.
    /// </exception>
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public ApiKeyCredential(string key) => Update(key);
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

    // This type uses a method instead of a Key property so that, if an instance
    // of the type were passed to a serializer that serializes public properties
    // by default, it doesn't inadvertently expose a secret. The method has the
    // name Deconstruct to allow consistent naming across credential types.  For
    // example, a corresponding NamedKeyCredential type will have a Deconstruct
    // method with two out params to make reading multiple credential values an
    // atomic operation.

    /// <summary>
    /// Deconstructs the credential into component values.
    /// </summary>
    /// <param name="key">When this method returns, contains the value of the
    /// API key this instance represents.</param>
    public void Deconstruct(out string key) => key = Volatile.Read(ref _key);

    /// <summary>
    /// Updates the service key.
    /// This is intended to be used when a service key has been regenerated
    /// and long-lived clients need to use the new value.
    /// </summary>
    /// <param name="key">Key to authenticate the service against.</param>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown when the <paramref name="key"/> is null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// Thrown when the <paramref name="key"/> is empty.
    /// </exception>
    public void Update(string key)
    {
        Argument.AssertNotNullOrEmpty(key, nameof(key));

        Volatile.Write(ref _key, key);
    }

    /// <summary> Converts a string to an <see cref="ApiKeyCredential"/>. </summary>
    public static implicit operator ApiKeyCredential(string key) => new(key);
}
