// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FieldBoundingBox"/> struct.
    /// </summary>
    public class FieldBoundingBoxTests
    {
        [Test]
        public void IndexerThrowsWhenFieldBoundingBoxIsDefault()
        {
            FieldBoundingBox boundingBox = default;
            Assert.Throws<IndexOutOfRangeException>(() => { var _ = boundingBox[0]; });
        }

        [Test]
        public void IndexerThrowsWhenFieldBoundingBoxIsEmpty()
        {
            FieldBoundingBox boundingBox = new FieldBoundingBox(new List<float>());
            Assert.Throws<IndexOutOfRangeException>(() => { var _ = boundingBox[0]; });
        }

        [Test]
        public void ToStringDoesNotThrowWhenFieldBoundingBoxIsDefault()
        {
            FieldBoundingBox boundingBox = default;
            Assert.DoesNotThrow(() => boundingBox.ToString());
        }

        [Test]
        public void ToStringDoesNotThrowWhenFieldBoundingBoxIsEmpty()
        {
            FieldBoundingBox boundingBox = new FieldBoundingBox(new List<float>());
            Assert.DoesNotThrow(() => boundingBox.ToString());
        }
    }
}
