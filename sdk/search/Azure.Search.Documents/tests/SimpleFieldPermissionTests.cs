// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public partial class SimpleFieldPermissionTests
    {
        [TestCase("userIds")]
        [TestCase("groupIds")]
        [TestCase("rbacScope")]
        public void SimpleFieldSetsPermissionFilter(string permissionFilter)
        {
            var simpleField = new SimpleField("myField", SearchFieldDataType.String)
            {
                PermissionFilter = permissionFilter,
            };

            SearchField field = simpleField;
            Assert.AreEqual(new PermissionFilter(permissionFilter), field.PermissionFilter);
        }

        [TestCase("userIds")]
        [TestCase("groupIds")]
        [TestCase("rbacScope")]
        public void SimpleFieldAttributeSetsPermissionFilter(string permissionFilter)
        {
            var attribute = new SimpleFieldAttribute
            {
                PermissionFilter = permissionFilter,
            };

            SearchField field = new SearchField("myField", SearchFieldDataType.String);
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.AreEqual(new PermissionFilter(permissionFilter), field.PermissionFilter);
        }

        [Test]
        public void SimpleFieldAttributeDoesNotSetPermissionFilterWhenNull()
        {
            SearchField field = new SearchField("myField", SearchFieldDataType.String)
            {
                PermissionFilter = PermissionFilter.RbacScope,
            };

            ((ISearchFieldAttribute)new SimpleFieldAttribute()).SetField(field);

            Assert.AreEqual(PermissionFilter.RbacScope, field.PermissionFilter);
        }

        [Test]
        public void SimpleFieldDefaultsPermissionFilterToNull()
        {
            SearchField field = new SimpleField("myField", SearchFieldDataType.String);

            Assert.IsNull(field.PermissionFilter);
        }

        [TestCase("userIds")]
        [TestCase("groupIds")]
        [TestCase("rbacScope")]
        public void SearchableFieldSetsPermissionFilter(string permissionFilter)
        {
            SearchField field = new SearchableField("myField")
            {
                PermissionFilter = permissionFilter,
            };

            Assert.AreEqual(new PermissionFilter(permissionFilter), field.PermissionFilter);
            Assert.IsTrue(field.IsSearchable);
        }

        [TestCase("userIds")]
        [TestCase("groupIds")]
        [TestCase("rbacScope")]
        public void SearchableFieldAttributeInheritsPermissionFilter(string permissionFilter)
        {
            var attribute = new SearchableFieldAttribute
            {
                PermissionFilter = permissionFilter,
            };

            SearchField field = new SearchField("myField", SearchFieldDataType.String);
            ((ISearchFieldAttribute)attribute).SetField(field);

            Assert.AreEqual(new PermissionFilter(permissionFilter), field.PermissionFilter);
            Assert.IsTrue(field.IsSearchable);
        }

        [Test]
        public void FieldBuilderCopiesPermissionFilter()
        {
            SearchField field = new FieldBuilder().Build(typeof(PermissionFilteredDocument)).Single();

            Assert.AreEqual(PermissionFilter.GroupIds, field.PermissionFilter);
        }

        private class PermissionFilteredDocument
        {
            [SimpleField(PermissionFilter = "groupIds")]
            public string GroupIds { get; set; }
        }
    }
}
