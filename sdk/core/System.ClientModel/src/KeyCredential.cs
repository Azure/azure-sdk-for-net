// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel;

public class KeyCredential
{
    private string _key;

    public string Key => _key;

    public KeyCredential(string key)
    {
        _key = key;
    }

    public void Update(string key)
    {
        _key = key;
    }
}
