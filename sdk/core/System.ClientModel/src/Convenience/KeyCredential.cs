// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel;

public class KeyCredential
{
    private string _key;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyCredential"/> class.
    /// </summary>
    /// <param name="key">Key to use to authenticate with the Azure service.</param>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown when the <paramref name="key"/> is null.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// Thrown when the <paramref name="key"/> is empty.
    /// </exception>
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public KeyCredential(string key) => Update(key);
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

    // Note: this is GetValue instead of GetKey to allow consistent naming
    // across credential types.  For example, for NamedKeyCredential, we would have
    // GetValues with two out params to enable atomicity in reading credential values.
    public string GetValue() => Volatile.Read(ref _key);

    public void Update(string key)
    {
        ClientUtilities.AssertNotNullOrEmpty(key, nameof(key));

        Volatile.Write(ref _key, key);
    }
}
