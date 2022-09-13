// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class DictionaryTableExtensionsTests
    {
        private ExplicitInterfaceModel sourceModel;
        private Dictionary<string, object> sourceDictionary;

        [SetUp]
        public void Setup()
        {
            sourceModel = new ExplicitInterfaceModel
            {
                Category = "cat",
                Name = "name",
                Priority = 1234
            };

            sourceDictionary = new Dictionary<string, object> {
                {"Category", "cat"},
                {"Name", "name"},
                {"Priority", 1234},
                {"PartitionKey", "cat"},
                {"RowKey", "name"},
            };
        }

        [Test]
        public void ToTableEntityRecognizesExplicitlyImplementedInterfaceProperties()
        {
            var model = sourceDictionary.ToTableEntity<ExplicitInterfaceModel>();

            Assert.AreEqual("cat", model.Category);
            Assert.AreEqual("name", model.Name);
            Assert.AreEqual(1234, model.Priority);
            Assert.AreEqual("cat", ((ITableEntity)model).PartitionKey);
            Assert.AreEqual("name", ((ITableEntity)model).RowKey);
        }

        [Test]
        public void ToTableEntityListRecognizesExplicitlyImplementedInterfaceProperties()
        {
            var models = new List<IDictionary<string, object>>() { sourceDictionary, sourceDictionary }.ToTableEntityList<ExplicitInterfaceModel>();

            foreach (var model in models)
            {
                Assert.AreEqual("cat", model.Category);
                Assert.AreEqual("name", model.Name);
                Assert.AreEqual(1234, model.Priority);
                Assert.AreEqual("cat", ((ITableEntity)model).PartitionKey);
                Assert.AreEqual("name", ((ITableEntity)model).RowKey);
            }
        }

        [Test]
        public void ToOdataAnnotatedDictionaryRecognizesExplicitlyImplementedInterfaceProperties()
        {
            var dictionary = sourceModel.ToOdataAnnotatedDictionary();

            new TablesTypeBinder().Serialize(sourceModel, dictionary);

            Assert.AreEqual("cat", dictionary["Category"]);
            Assert.AreEqual("cat", dictionary["PartitionKey"]);
            Assert.AreEqual("name", dictionary["RowKey"]);
        }

        private class ExplicitInterfaceModel : ITableEntity
        {
            public string Category { get; set; }
            public string Name { get; set; }
            public int Priority { get; set; }

            string ITableEntity.PartitionKey
            {
                get => Category;
                set => Category = value;
            }

            string ITableEntity.RowKey
            {
                get => Name;
                set => Name = value;
            }

            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }
    }
}
