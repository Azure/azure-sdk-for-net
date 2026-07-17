// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class SnapshotFieldsTests
    {
        [Test]
        [TestCase(nameof(SnapshotFields.Name), "name")]
        [TestCase(nameof(SnapshotFields.Status), "status")]
        [TestCase(nameof(SnapshotFields.Filters), "filters")]
        [TestCase(nameof(SnapshotFields.SnapshotComposition), "composition_type")]
        [TestCase(nameof(SnapshotFields.CreatedOn), "created")]
        [TestCase(nameof(SnapshotFields.ExpiresOn), "expires")]
        [TestCase(nameof(SnapshotFields.RetentionPeriod), "retention_period")]
        [TestCase(nameof(SnapshotFields.SizeInBytes), "size")]
        [TestCase(nameof(SnapshotFields.ItemCount), "items_count")]
        [TestCase(nameof(SnapshotFields.Tags), "tags")]
        [TestCase(nameof(SnapshotFields.Description), "description")]
        [TestCase(nameof(SnapshotFields.ETag), "etag")]
        public void FieldMapsToExpectedServiceName(string memberName, string expectedServiceName)
        {
            SnapshotFields field = memberName switch
            {
                nameof(SnapshotFields.Name) => SnapshotFields.Name,
                nameof(SnapshotFields.Status) => SnapshotFields.Status,
                nameof(SnapshotFields.Filters) => SnapshotFields.Filters,
                nameof(SnapshotFields.SnapshotComposition) => SnapshotFields.SnapshotComposition,
                nameof(SnapshotFields.CreatedOn) => SnapshotFields.CreatedOn,
                nameof(SnapshotFields.ExpiresOn) => SnapshotFields.ExpiresOn,
                nameof(SnapshotFields.RetentionPeriod) => SnapshotFields.RetentionPeriod,
                nameof(SnapshotFields.SizeInBytes) => SnapshotFields.SizeInBytes,
                nameof(SnapshotFields.ItemCount) => SnapshotFields.ItemCount,
                nameof(SnapshotFields.Tags) => SnapshotFields.Tags,
                nameof(SnapshotFields.Description) => SnapshotFields.Description,
                nameof(SnapshotFields.ETag) => SnapshotFields.ETag,
                _ => default,
            };

            Assert.That(field.ToString(), Is.EqualTo(expectedServiceName));
        }

        [Test]
        public void ImplicitConversionFromStringPreservesValue()
        {
            SnapshotFields field = "description";

            Assert.That(field.ToString(), Is.EqualTo("description"));
            Assert.That(field, Is.EqualTo(SnapshotFields.Description));
        }

        [Test]
        public void EqualityIsCaseInsensitive()
        {
            SnapshotFields lower = "description";
            SnapshotFields upper = "DESCRIPTION";

            Assert.That(lower, Is.EqualTo(upper));
            Assert.That(lower == upper, Is.True);
        }
    }
}
