// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Json;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class PatchModelTests
    {
        [Test]
        public void CanAccessMutableJsonDocument()
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse("""
                {
                    "a": 1
                }
                """);

            Assert.AreEqual(1, mdoc.RootElement.GetProperty("a").GetInt32());
        }
    }
}
