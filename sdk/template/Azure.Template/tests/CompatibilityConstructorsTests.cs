// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    [TestFixture]
    public class CompatibilityConstructorsTests
    {
        [Test]
        public void PreviouslyRequiredModelConstructorsInitializeValues()
        {
            var createdOn = DateTimeOffset.UtcNow;
            var sharedModel = new FakedSharedModel("tag", createdOn);
            var widget = new WidgetSuite("manufacturer-id");

            Assert.That(sharedModel.Tag, Is.EqualTo("tag"));
            Assert.That(sharedModel.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(widget.ManufacturerId, Is.EqualTo("manufacturer-id"));
        }
    }
}
