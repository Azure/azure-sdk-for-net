// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel;

public class ApiKeyCredential
{
    private string _key;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiKeyCredential"/> class.
    /// </summary>
    /// <param name="key">Key to use to authenticate with the Azure service.</param>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown when the <paramref name="key"/> is null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// Thrown when the <paramref name="key"/> is empty.
    /// </exception>
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public ApiKeyCredential(string key) => Update(key);
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

    // Note: this is uses a method instead of a Key property so if an instance of
    // the type were passed to a serializer that serializes public properties
    // it doesn't inadvertently expose a secret.  We call it Deconstruct to allow
    // consistent naming across credential types.  For example, for
    // NamedKeyCredential, we expect to have a Deconstruct method with two out
    // params to enable atomicity in reading multiple credential values.
    public void Deconstruct(out string key) => key = Volatile.Read(ref _key);

    public void Update(string key)
    {
        Argument.AssertNotNullOrEmpty(key, nameof(key));

        Volatile.Write(ref _key, key);
    }
}
