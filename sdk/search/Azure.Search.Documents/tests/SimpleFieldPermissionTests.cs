// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

using System.Linq;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SimpleFieldPermissionTests
    {
        [Test]
        public void SimpleFieldSetsPermissionFilter()
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String)
            {
                PermissionFilter = PermissionFilter.GroupIds,
            };

            SearchField field = simpleField;
            Assert.AreEqual(PermissionFilter.GroupIds, field.PermissionFilter);
        }

        [Test]
        public void SimpleFieldSetsSensitivityLabelId()
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String)
            {
                SensitivityLabelId = true,
            };

            SearchField field = simpleField;
            Assert.IsTrue(field.SensitivityLabelId);
        }

        [Test]
        public void SimpleFieldSetsSensitivityLabelName()
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String)
            {
                SensitivityLabelName = true,
            };

            SearchField field = simpleField;
            Assert.IsTrue(field.SensitivityLabelName);
        }

        [Test]
        public void SimpleFieldDefaultsPermissionPropertiesToNull()
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String);

            SearchField field = simpleField;
            Assert.IsNull(field.PermissionFilter);
            Assert.IsNull(field.SensitivityLabelId);
            Assert.IsNull(field.SensitivityLabelName);
        }

        [Test]
        public void SimpleFieldSetsAllPermissionProperties()
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String)
            {
                PermissionFilter = PermissionFilter.UserIds,
                SensitivityLabelId = true,
                SensitivityLabelName = true,
            };

            SearchField field = simpleField;
            Assert.AreEqual(PermissionFilter.UserIds, field.PermissionFilter);
            Assert.IsTrue(field.SensitivityLabelId);
            Assert.IsTrue(field.SensitivityLabelName);
        }

        [Test]
        public void SimpleFieldAttributeSetsPermissionFilter()
        {
            var attribute = new SimpleFieldAttribute
            {
                PermissionFilter = "groupIds",
            };

            SearchField field = new SearchField("myField", SearchFieldDataType.String);
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.AreEqual(PermissionFilter.GroupIds, field.PermissionFilter);
        }

        [Test]
        public void SimpleFieldAttributeSetsSensitivityLabels()
        {
            var attribute = new SimpleFieldAttribute
            {
                SensitivityLabelId = true,
                SensitivityLabelName = true,
            };

            SearchField field = new SearchField("myField", SearchFieldDataType.String);
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.IsTrue(field.SensitivityLabelId);
            Assert.IsTrue(field.SensitivityLabelName);
        }

        [Test]
        public void SimpleFieldAttributeSupportsDecoratedModel()
        {
            SearchField field = new FieldBuilder().Build(typeof(PermissionModel)).Single();

            Assert.AreEqual(PermissionFilter.GroupIds, field.PermissionFilter);
            Assert.IsTrue(field.SensitivityLabelId);
            Assert.IsFalse(field.SensitivityLabelName);
        }

        [Test]
        public void SimpleFieldAttributeSetsSensitivityLabelsToFalse()
        {
            var attribute = new SimpleFieldAttribute
            {
                SensitivityLabelId = false,
                SensitivityLabelName = false,
            };
            SearchField field = new SearchField("myField", SearchFieldDataType.String)
            {
                SensitivityLabelId = true,
                SensitivityLabelName = true,
            };

            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.IsFalse(field.SensitivityLabelId);
            Assert.IsFalse(field.SensitivityLabelName);
        }

        [Test]
        public void SimpleFieldAttributeDoesNotSetPermissionFilterWhenNull()
        {
            SearchField field = new SearchField("myField", SearchFieldDataType.String)
            {
                PermissionFilter = PermissionFilter.RbacScope,
            };

            var attribute = new SimpleFieldAttribute();
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.AreEqual(PermissionFilter.RbacScope, field.PermissionFilter);
        }

        [Test]
        public void SimpleFieldAttributeDoesNotSetSensitivityLabelIdWhenNull()
        {
            SearchField field = new SearchField("myField", SearchFieldDataType.String)
            {
                SensitivityLabelId = true,
            };

            var attribute = new SimpleFieldAttribute();
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.IsTrue(field.SensitivityLabelId);
        }

        [Test]
        public void SimpleFieldAttributeDoesNotSetSensitivityLabelNameWhenUnset()
        {
            SearchField field = new SearchField("myField", SearchFieldDataType.String)
            {
                SensitivityLabelName = true,
            };

            var attribute = new SimpleFieldAttribute();
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.IsTrue(field.SensitivityLabelName);
        }

        [Test]
        public void SearchableFieldInheritsPermissionProperties()
        {
            var attribute = new SearchableFieldAttribute
            {
                PermissionFilter = "userIds",
                SensitivityLabelId = true,
                SensitivityLabelName = true,
            };

            SearchField field = new SearchField("myField", SearchFieldDataType.String);
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.AreEqual(PermissionFilter.UserIds, field.PermissionFilter);
            Assert.IsTrue(field.SensitivityLabelId);
            Assert.IsTrue(field.SensitivityLabelName);
        }

        [Test]
        public void SearchableFieldSetsPermissionProperties()
        {
            var searchableField = new SearchableField("myField")
            {
                PermissionFilter = PermissionFilter.GroupIds,
                SensitivityLabelId = true,
                SensitivityLabelName = true,
            };

            SearchField field = searchableField;
            Assert.AreEqual(PermissionFilter.GroupIds, field.PermissionFilter);
            Assert.IsTrue(field.SensitivityLabelId);
            Assert.IsTrue(field.SensitivityLabelName);
        }

        private class PermissionModel
        {
            [SimpleField(PermissionFilter = "groupIds", SensitivityLabelId = true, SensitivityLabelName = false)]
            public string AllowedPrincipals { get; set; }
        }
    }
}

#endif
