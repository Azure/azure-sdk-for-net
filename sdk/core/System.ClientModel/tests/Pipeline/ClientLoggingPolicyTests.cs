// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.Identity.Client;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class ClientLoggingPolicyTests : SyncAsyncTestBase
{
    public ClientLoggingPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void MultiplePipelinesCanLog()
    {
        // TODO
    }

    [Test]
    public void MultiplePipelinesCanLogToDifferentEventSource()
    {
        // TODO
    }
}
