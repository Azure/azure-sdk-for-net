// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public partial class SimpleFieldPermissionTests
    {
        [Test]
        public void SimpleFieldSetsSensitivityLabelId()
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String)
            {
                IsSensitivityLabelId = true,
            };

            SearchField field = simpleField;
            Assert.IsTrue(field.IsSensitivityLabelId);
        }

        [Test]
        public void SimpleFieldSetsSensitivityLabelName()
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String)
            {
                IsSensitivityLabelName = true,
            };

            SearchField field = simpleField;
            Assert.IsTrue(field.IsSensitivityLabelName);
        }

        [Test]
        public void SimpleFieldDefaultsPermissionPropertiesToNull()
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String);

            SearchField field = simpleField;
            Assert.IsNull(field.PermissionFilter);
            Assert.IsNull(field.IsSensitivityLabelId);
            Assert.IsNull(field.IsSensitivityLabelName);
        }

        [Test]
        public void SimpleFieldSetsAllPermissionProperties()
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String)
            {
                PermissionFilter = PermissionFilter.UserIds,
                IsSensitivityLabelId = true,
                IsSensitivityLabelName = true,
            };

            SearchField field = simpleField;
            Assert.AreEqual(PermissionFilter.UserIds, field.PermissionFilter);
            Assert.IsTrue(field.IsSensitivityLabelId);
            Assert.IsTrue(field.IsSensitivityLabelName);
        }

        [Test]
        public void SimpleFieldAttributeSetsSensitivityLabels()
        {
            var attribute = new SimpleFieldAttribute
            {
                IsSensitivityLabelId = true,
                IsSensitivityLabelName = true,
            };

            SearchField field = new SearchField("myField", SearchFieldDataType.String);
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.IsTrue(field.IsSensitivityLabelId);
            Assert.IsTrue(field.IsSensitivityLabelName);
        }

        [Test]
        public void SimpleFieldAttributeDoesNotSetSensitivityLabelIdWhenNull()
        {
            SearchField field = new SearchField("myField", SearchFieldDataType.String)
            {
                IsSensitivityLabelId = true,
            };

            var attribute = new SimpleFieldAttribute();
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.IsTrue(field.IsSensitivityLabelId);
        }

        [Test]
        public void SearchableFieldInheritsPermissionProperties()
        {
            var attribute = new SearchableFieldAttribute
            {
                PermissionFilter = "userIds",
                IsSensitivityLabelId = true,
                IsSensitivityLabelName = true,
            };

            SearchField field = new SearchField("myField", SearchFieldDataType.String);
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.AreEqual(PermissionFilter.UserIds, field.PermissionFilter);
            Assert.IsTrue(field.IsSensitivityLabelId);
            Assert.IsTrue(field.IsSensitivityLabelName);
        }

        [Test]
        public void SearchableFieldSetsPermissionProperties()
        {
            var searchableField = new SearchableField("myField")
            {
                PermissionFilter = PermissionFilter.GroupIds,
                IsSensitivityLabelId = true,
                IsSensitivityLabelName = true,
            };

            SearchField field = searchableField;
            Assert.AreEqual(PermissionFilter.GroupIds, field.PermissionFilter);
            Assert.IsTrue(field.IsSensitivityLabelId);
            Assert.IsTrue(field.IsSensitivityLabelName);
        }

        [Test]
        public void FieldBuilderCopiesSensitivityLabelsFromAttributeArguments()
        {
            var fields = new FieldBuilder().Build(typeof(SensitivityLabeledDocument)).ToDictionary(field => field.Name);
            Assert.IsTrue(fields["LabelId"].IsSensitivityLabelId);
            Assert.IsTrue(fields["LabelName"].IsSensitivityLabelName);
            Assert.IsTrue(fields["LabelName"].IsSearchable);
            Assert.IsFalse(fields["NoLabels"].IsSensitivityLabelId);
            Assert.IsFalse(fields["NoLabels"].IsSensitivityLabelName);
            Assert.IsNull(fields["Unspecified"].IsSensitivityLabelId);
            Assert.IsNull(fields["Unspecified"].IsSensitivityLabelName);

            using JsonDocument enabled = JsonDocument.Parse(
                ModelReaderWriter.Write(fields["LabelId"], new ModelReaderWriterOptions("W")));
            Assert.IsTrue(enabled.RootElement.GetProperty("sensitivityLabelId").GetBoolean());
            using JsonDocument disabled = JsonDocument.Parse(
                ModelReaderWriter.Write(fields["NoLabels"], new ModelReaderWriterOptions("W")));
            Assert.IsFalse(disabled.RootElement.GetProperty("sensitivityLabelId").GetBoolean());
            Assert.IsFalse(disabled.RootElement.GetProperty("sensitivityLabelName").GetBoolean());
            using JsonDocument unspecified = JsonDocument.Parse(
                ModelReaderWriter.Write(fields["Unspecified"], new ModelReaderWriterOptions("W")));
            Assert.IsFalse(unspecified.RootElement.TryGetProperty("sensitivityLabelId", out _));
            Assert.IsFalse(unspecified.RootElement.TryGetProperty("sensitivityLabelName", out _));
        }

        private class SensitivityLabeledDocument
        {
            [SimpleField(IsSensitivityLabelId = true)]
            public string LabelId { get; set; }

            [SearchableField(IsSensitivityLabelName = true)]
            public string LabelName { get; set; }

            [SimpleField(IsSensitivityLabelId = false, IsSensitivityLabelName = false)]
            public string NoLabels { get; set; }

            [SimpleField]
            public string Unspecified { get; set; }
        }
    }
}

#endif
