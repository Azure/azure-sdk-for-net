// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel;

public class KeyCredential
{
    private string _key;

    public KeyCredential(string key)
    {
        _key = key;
    }

    public bool TryGetKey(out string key)
    {
        key = _key;
        return true;
    }

    public void Update(string key)
    {
        _key = key;
    }
}
