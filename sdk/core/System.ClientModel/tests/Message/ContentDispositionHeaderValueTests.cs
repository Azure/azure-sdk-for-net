// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Message;

internal class ContentDispositionHeaderValueTests : SyncAsyncTestBase
{
    public ContentDispositionHeaderValueTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void SettingNullContentTypeFails()
    {
        Assert.Throws<ArgumentNullException>(() => new ContentDispositionHeaderValue(""));
    }
}
