// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.Models;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FieldValue"/> struct.
    /// </summary>
    public class FieldValueTests
    {
        [Test]
        public void AsStringReturnsNullWhenFieldValueIsDefault()
        {
            FieldValue value = default;
            Assert.IsNull(value.AsString());
        }
    }
}
