// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Template;
using NUnit.Framework;

namespace Microsoft.Azure.Template.Tests
{
    public class UnitTest1
    {
        [Test]
        public void Test1()
        {
            var c = new TemplateClient(new Uri("http://localhost:3000/"));

            Assert.NotNull(c);
        }
    }
}
