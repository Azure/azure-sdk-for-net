// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest;

public class KeyCredential
{
    private string _key;

    public KeyCredential(string key)
    {
        _key = key;
    }

    public string Key => _key;

    public void Update(string key)
    {
        _key = key;
    }
}
