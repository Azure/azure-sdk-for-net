// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.TypeSpec;

/// <summary>
/// TBD.
/// </summary>
public class KeyCredential : Credential
{
    private string _key;

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="key"></param>
    public KeyCredential(string key)
    {
        _key = key;
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public string Key => _key;

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="key"></param>
    public void Update(string key)
    {
        _key = key;
    }
}
