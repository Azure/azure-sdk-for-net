// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
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
        public void ToTableEntityConvertsTableEntity()
        {
            var model = sourceDictionary.ToTableEntity<TableEntity>();

            Assert.AreEqual("cat", model["Category"]);
            Assert.AreEqual("name", model["Name"]);
            Assert.AreEqual(1234, model["Priority"]);
            Assert.AreEqual("cat", model.PartitionKey);
            Assert.AreEqual("name", model.RowKey);
        }

        [Test]
        public void ToTableEntityConvertsCustomIDictionary()
        {
            var model = sourceDictionary.ToTableEntity<CustomIDictionary>();

            Assert.AreEqual("cat", model.Category);
            Assert.AreEqual("name", model.Name);
            Assert.AreEqual(1234, model.Priority);
            Assert.AreEqual("cat", model.PartitionKey);
            Assert.AreEqual("name", model.RowKey);
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

        private class CustomIDictionary : ITableEntity, IDictionary<string, object>
        {
            private IDictionary<string, object> _dict = new Dictionary<string, object>();
            public string Category
            {
                get
                {
                    return _dict.TryGetValue("Category", out var value) switch
                    {
                        true => (string)value,
                        _ => default
                    };
                }
                set => _dict["Category"] = value;
            }
            public string Name
            {
                get
                {
                    return _dict.TryGetValue("Name", out var value) switch
                    {
                        true => (string)value,
                        _ => default
                    };
                }
                set => _dict["Name"] = value;
            }
            public int Priority
            {
                get
                {
                    return _dict.TryGetValue("Priority", out var value) switch
                    {
                        true => (int)value,
                        _ => default
                    };
                }
                set => _dict["Priority"] = value;
            }

            public string PartitionKey
            {
                get
                {
                    return _dict.TryGetValue("PartitionKey", out var value) switch
                    {
                        true => (string)value,
                        _ => default
                    };
                }
                set => _dict["PartitionKey"] = value;
            }

            public string RowKey
            {
                get
                {
                    return _dict.TryGetValue("RowKey", out var value) switch
                    {
                        true => (string)value,
                        _ => default
                    };
                }
                set => _dict["RowKey"] = value;
            }

            public DateTimeOffset? Timestamp
            {
                get
                {
                    return _dict.TryGetValue("Timestamp", out var value) switch
                    {
                        true => (DateTimeOffset)value,
                        _ => default
                    };
                }
                set => _dict["Timestamp"] = value;
            }

            public ETag ETag
            {
                get
                {
                    return _dict.TryGetValue("ETag", out var value) switch
                    {
                        true => (ETag)value,
                        _ => default
                    };
                }
                set => _dict["ETag"] = value;
            }

            public ICollection<string> Keys => _dict.Keys;

            public ICollection<object> Values => _dict.Values;

            public int Count => _dict.Count;

            public bool IsReadOnly => _dict.IsReadOnly;

            public object this[string key] { get => _dict[key]; set => _dict[key] = value; }

            public void Add(string key, object value) => _dict.Add(key, value);

            public bool ContainsKey(string key) => _dict.ContainsKey(key);

            public bool Remove(string key) => _dict.Remove(key);

            public bool TryGetValue(string key, out object value){
                 var result = _dict.TryGetValue(key, out object val);
                 value = val;
                 return result;
            }

            public void Add(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
