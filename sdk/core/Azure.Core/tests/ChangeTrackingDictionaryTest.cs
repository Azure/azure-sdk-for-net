// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ChangeTrackingDictionaryTest
    {
        [Test]
        public void UndefinedByDefault()
        {
            var dictionary = new ChangeTrackingDictionary<string, string>();
            Assert.That(dictionary.IsUndefined, Is.True);
        }

        [Test]
        public void ReadOperationsDontChange()
        {
            var dictionary = new ChangeTrackingDictionary<string, string>();
            _ = dictionary.Count;
            _ = dictionary.IsReadOnly;
            _ = dictionary.Keys;
            _ = dictionary.Values;
            _ = dictionary.Contains(new KeyValuePair<string, string>("c", "d"));
            _ = dictionary.ContainsKey("a");
            _ = dictionary.TryGetValue("a", out _);
            _ = dictionary.Remove("a");

            foreach (var kvp in dictionary)
            {
            }

            dictionary.CopyTo(new KeyValuePair<string, string>[5], 0);

            Assert.Throws<KeyNotFoundException>(() => _ = dictionary["a"]);

            Assert.That(dictionary.IsUndefined, Is.True);
        }

        [Test]
        public void CanAddElement()
        {
            var dictionary = new ChangeTrackingDictionary<string, string>();
            dictionary.Add("a", "b");

            Assert.That(dictionary["a"], Is.EqualTo("b"));
            Assert.That(dictionary.IsUndefined, Is.False);
        }

        [Test]
        public void RemoveElement()
        {
            var dictionary = new ChangeTrackingDictionary<string, string>();
            dictionary.Add("a", "b");
            dictionary.Add(new KeyValuePair<string, string>("c", "d"));
            dictionary.Remove("a");
            dictionary.Remove(new KeyValuePair<string, string>("c", "d"));

            Assert.That(dictionary.Count, Is.EqualTo(0));
            Assert.That(dictionary.IsUndefined, Is.False);
        }

        [Test]
        public void ClearResetsUndefined()
        {
            var dictionary = new ChangeTrackingDictionary<string, string>();
            dictionary.Clear();

            Assert.That(dictionary.Count, Is.EqualTo(0));
            Assert.That(dictionary.IsUndefined, Is.False);
        }
    }
}
