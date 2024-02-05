// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace ClientModel.Tests;

[TestFixture(true)]
[TestFixture(false)]
public class SyncAsyncTestBase
{
    public bool IsAsync { get; }

    public SyncAsyncTestBase(bool isAsync)
    {
        IsAsync = isAsync;
    }
}
