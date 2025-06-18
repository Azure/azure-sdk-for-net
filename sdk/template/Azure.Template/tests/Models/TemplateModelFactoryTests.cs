// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Template.Models;
using NUnit.Framework;

namespace Azure.Template.Tests.Models
{
    public class TemplateModelFactoryTests
    {
        [Test]
        public void SecretBundle_AllProperties()
        {
            var value = "test-value";
            var id = "test-id";
            var contentType = "text/plain";
            var tags = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };
            var kid = "test-kid";
            var managed = true;

            var secretBundle = TemplateModelFactory.SecretBundle(
                value: value,
                id: id,
                contentType: contentType,
                tags: tags,
                kid: kid,
                managed: managed);

            Assert.AreEqual(value, secretBundle.Value);
            Assert.AreEqual(id, secretBundle.Id);
            Assert.AreEqual(contentType, secretBundle.ContentType);
            Assert.AreEqual(tags, secretBundle.Tags);
            Assert.AreEqual(kid, secretBundle.Kid);
            Assert.AreEqual(managed, secretBundle.Managed);
        }

        [Test]
        public void SecretBundle_DefaultValues()
        {
            var secretBundle = TemplateModelFactory.SecretBundle();

            Assert.IsNull(secretBundle.Value);
            Assert.IsNull(secretBundle.Id);
            Assert.IsNull(secretBundle.ContentType);
            Assert.IsNotNull(secretBundle.Tags);
            Assert.IsEmpty(secretBundle.Tags);
            Assert.IsNull(secretBundle.Kid);
            Assert.IsNull(secretBundle.Managed);
        }
    }
}