// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Tests
{
    /// <summary>
    /// Unit tests for our utility methods and helpers.
    /// </summary>
    public class UnitTests
    {
        [Test]
        public void InvalidGuidTest()
        {
            var invalidGuid = "Foo Bar";
            Assert.Throws<ArgumentException>(() => ClientCommon.ValidateModelId(invalidGuid, nameof(invalidGuid)));
        }

        [Test]
        public void ValidGuidTest()
        {
            var validGuid = "e78a95a6-e268-11eb-ba80-0242ac130004";
            var parsedGuid = ClientCommon.ValidateModelId(validGuid, nameof(validGuid));
            Assert.NotNull(parsedGuid);
        }
    }
}
