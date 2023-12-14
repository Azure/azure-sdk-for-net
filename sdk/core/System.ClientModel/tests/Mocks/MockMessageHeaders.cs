// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace ClientModel.Tests.Mocks;

public class MockMessageHeaders : MessageHeaders
{
    public override void Add(string name, string value)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public override bool Remove(string name)
    {
        throw new NotImplementedException();
    }

    public override void Set(string name, string value)
    {
        throw new NotImplementedException();
    }

    public override bool TryGetValue(string name, out string? value)
    {
        throw new NotImplementedException();
    }

    public override bool TryGetValues(string name, out IEnumerable<string>? values)
    {
        throw new NotImplementedException();
    }
}
