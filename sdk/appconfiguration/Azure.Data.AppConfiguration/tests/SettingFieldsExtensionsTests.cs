// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class SettingFieldsExtensionsTests
    {
        [Test]
        public void SplitReturnsNullForAll()
        {
            Assert.IsNull(SettingFields.All.Split());
        }

        [Test]
        [TestCase(SettingFields.Key, "key")]
        [TestCase(SettingFields.Label, "label")]
        [TestCase(SettingFields.Value, "value")]
        [TestCase(SettingFields.ContentType, "content_type")]
        [TestCase(SettingFields.ETag, "etag")]
        [TestCase(SettingFields.LastModified, "last_modified")]
        [TestCase(SettingFields.IsReadOnly, "locked")]
        [TestCase(SettingFields.Tags, "tags")]
        public void SplitWithSingleField(SettingFields fields, string expectedFieldString)
        {
            IEnumerable<string> splitFields = fields.Split();
            string fieldString = splitFields.Single();

            Assert.AreEqual(fieldString, expectedFieldString);
        }

        [Test]
        public void SplitWithMultipleFields()
        {
            SettingFields fields = SettingFields.Key | SettingFields.ContentType | SettingFields.LastModified | SettingFields.IsReadOnly;
            IEnumerable<string> splitFields = fields.Split();

            Assert.AreEqual(splitFields.Count(), 4);
            CollectionAssert.Contains(splitFields, "key");
            CollectionAssert.Contains(splitFields, "content_type");
            CollectionAssert.Contains(splitFields, "last_modified");
            CollectionAssert.Contains(splitFields, "locked");
        }

        [Test]
        public void SplitSupportsAllPossibleSettingFields()
        {
            foreach (SettingFields fields in Enum.GetValues(typeof(SettingFields)))
            {
                if (fields == SettingFields.All)
                {
                    continue;
                }

                IEnumerable<string> splitFields = fields.Split();

                // If this assertion fails, it's likely that a new enum value has been added to SettingFields
                // but a corresponding entry has not been added to s_serviceNameMap in SettingFieldsExtensions.
                Assert.AreEqual(splitFields.Count(), 1, $"{nameof(SettingFields)} enum value {fields} could not be mapped to a string.");
            }
        }
    }
}
