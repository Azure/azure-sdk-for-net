// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.Options;

internal class LoggingOptionsTests
{
    [Test]
    public void CanDetectChangesToLoggingOptions()
    {
        ClientLoggingOptions loggingOptions = new();
        Assert.IsTrue(loggingOptions.IsDefault());

        loggingOptions.AllowedHeaderNames.Add("x-custom-header");

        Assert.IsFalse(loggingOptions.IsDefault());
    }
}
