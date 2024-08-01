// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
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
                Priority = 1234,
                Price = 99.99m,
                CreatedDate = new DateTime(2023, 1, 1),
                LastUpdated = new DateTimeOffset(new DateTime(2023, 1, 1), TimeSpan.Zero),
                Identifier = new Guid("12345678-1234-1234-1234-1234567890ab"),
                Counter = 100,
                Rating = 4.5
            };

            sourceDictionary = new Dictionary<string, object> {
                {"Category", "cat"},
                {"Name", "name"},
                {"Priority", 1234},
                {"PartitionKey", "cat"},
                {"RowKey", "name"},
                {"Price", "99.99"},
                {"CreatedDate", "2023-01-01T00:00:00Z"},
                {"LastUpdated", "2023-01-01T00:00:00Z"},
                {"Identifier", "12345678-1234-1234-1234-1234567890ab"},
                {"Counter", "100"},
                {"Rating", 4.5},
            };
        }

        [Test]
        public void ToTableEntityRecognizesExplicitlyImplementedInterfaceProperties()
        {
            var model = sourceDictionary.ToTableEntity<ExplicitInterfaceModel>();

            Assert.AreEqual("cat", ((ITableEntity)model).PartitionKey);
            Assert.AreEqual("name", ((ITableEntity)model).RowKey);
            Assert.AreEqual("cat", model.Category);
            Assert.AreEqual("name", model.Name);
            Assert.AreEqual(1234, model.Priority);
            Assert.AreEqual(99.99m, model.Price);
            Assert.AreEqual(new DateTime(2023, 1, 1), model.CreatedDate);
            Assert.AreEqual(new DateTimeOffset(new DateTime(2023, 1, 1), TimeSpan.Zero), model.LastUpdated);
            Assert.AreEqual(new Guid("12345678-1234-1234-1234-1234567890ab"), model.Identifier);
            Assert.AreEqual(100, model.Counter);
            Assert.AreEqual(4.5, model.Rating);
        }

        [Test]
        public void ToTableEntityConvertsTableEntity()
        {
            var model = sourceDictionary.ToTableEntity<TableEntity>();

            Assert.AreEqual("cat", model.PartitionKey);
            Assert.AreEqual("name", model.RowKey);
            Assert.AreEqual("cat", model["Category"]);
            Assert.AreEqual("name", model["Name"]);
            Assert.AreEqual(1234, model["Priority"]);
            Assert.AreEqual("99.99", model["Price"]);
            Assert.AreEqual("2023-01-01T00:00:00Z", model["CreatedDate"]);
            Assert.AreEqual("2023-01-01T00:00:00Z", model["LastUpdated"]);
            Assert.AreEqual("12345678-1234-1234-1234-1234567890ab", model["Identifier"]);
            Assert.AreEqual("100", model["Counter"]);
            Assert.AreEqual(4.5, model["Rating"]);
        }

        [Test]
        public void ToTableEntityConvertsCustomIDictionary()
        {
            var model = sourceDictionary.ToTableEntity<CustomIDictionary>();

            Assert.AreEqual("cat", model.PartitionKey);
            Assert.AreEqual("name", model.RowKey);
            Assert.AreEqual("cat", model.Category);
            Assert.AreEqual("name", model.Name);
            Assert.AreEqual(1234, model.Priority);
            Assert.AreEqual(99.99m, model.Price);
            Assert.AreEqual(new DateTime(2023, 1, 1), model.CreatedDate);
            Assert.AreEqual(new DateTimeOffset(new DateTime(2023, 1, 1), TimeSpan.Zero), model.LastUpdated);
            Assert.AreEqual(new Guid("12345678-1234-1234-1234-1234567890ab"), model.Identifier);
            Assert.AreEqual(100, model.Counter);
            Assert.AreEqual(4.5, model.Rating);
        }

        [Test]
        public void ToTableEntityListRecognizesExplicitlyImplementedInterfaceProperties()
        {
            var models = new List<IDictionary<string, object>>() { sourceDictionary, sourceDictionary }.ToTableEntityList<ExplicitInterfaceModel>();

            foreach (var model in models)
            {
                Assert.AreEqual("cat", ((ITableEntity)model).PartitionKey);
                Assert.AreEqual("name", ((ITableEntity)model).RowKey);
                Assert.AreEqual("cat", model.Category);
                Assert.AreEqual("name", model.Name);
                Assert.AreEqual(1234, model.Priority);
                Assert.AreEqual(99.99m, model.Price);
                Assert.AreEqual(new DateTime(2023, 1, 1), model.CreatedDate);
                Assert.AreEqual(new DateTimeOffset(new DateTime(2023, 1, 1), TimeSpan.Zero), model.LastUpdated);
                Assert.AreEqual(new Guid("12345678-1234-1234-1234-1234567890ab"), model.Identifier);
                Assert.AreEqual(100, model.Counter);
                Assert.AreEqual(4.5, model.Rating);
            }
        }

        [Test]
        public void ToOdataAnnotatedDictionaryRecognizesExplicitlyImplementedInterfaceProperties()
        {
            var dictionary = sourceModel.ToOdataAnnotatedDictionary();

            new TablesTypeBinder().Serialize(sourceModel, dictionary);

            Assert.AreEqual("cat", dictionary["PartitionKey"]);
            Assert.AreEqual("name", dictionary["RowKey"]);
            Assert.AreEqual("cat", dictionary["Category"]);
            Assert.AreEqual("name", dictionary["Name"]);
            Assert.AreEqual(1234, dictionary["Priority"]);
            Assert.AreEqual("99.99", dictionary["Price"]);
            Assert.AreEqual(new DateTime(2023, 1, 1), dictionary["CreatedDate"]);
            Assert.AreEqual(new DateTimeOffset(new DateTime(2023, 1, 1), TimeSpan.Zero), dictionary["LastUpdated"]);
        }

        private class ExplicitInterfaceModel : ITableEntity
        {
            public string Category { get; set; }
            public string Name { get; set; }
            public int Priority { get; set; }
            public decimal Price { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTimeOffset LastUpdated { get; set; }
            public Guid Identifier { get; set; }
            public long Counter { get; set; }
            public double Rating { get; set; }

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
            public decimal Price
            {
                get
                {
                    return _dict.TryGetValue("Price", out var value) switch
                    {
                        true => Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture),
                        _ => default
                    };
                }
            }
            public DateTime CreatedDate
            {
                get
                {
                    return _dict.TryGetValue("CreatedDate", out var value) switch
                    {
                        true => Convert.ToDateTime(value, System.Globalization.CultureInfo.InvariantCulture),
                        _ => default
                    };
                }
            }
            public DateTimeOffset LastUpdated
            {
                get
                {
                    return _dict.TryGetValue("LastUpdated", out var value) switch
                    {
                        true => DateTimeOffset.Parse(value.ToString(), System.Globalization.CultureInfo.InvariantCulture),
                        _ => default
                    };
                }
            }
            public Guid Identifier
            {
                get
                {
                    return _dict.TryGetValue("Identifier", out var value) switch
                    {
                        true => Guid.Parse(value.ToString()),
                        _ => default
                    };
                }
            }

            public long Counter
            {
                get
                {
                    return _dict.TryGetValue("Counter", out var value) switch
                    {
                        true => long.Parse(value.ToString(), System.Globalization.CultureInfo.InvariantCulture),
                        _ => default
                    };
                }
            }

            public double Rating
            {
                get
                {
                    return _dict.TryGetValue("Rating", out var value) switch
                    {
                        true => double.Parse(value.ToString(), System.Globalization.CultureInfo.InvariantCulture),
                        _ => default
                    };
                }
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
