// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

public class ClientTestBaseTests : ClientTestBase
{
    public ClientTestBaseTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void SyncMethodNoAsync()
    {
        TestClient client = CreateProxyFromClient(new TestClient());
        var result = client.Method2();

        Assert.That(result, Is.EqualTo("Hello"));
    }
}
