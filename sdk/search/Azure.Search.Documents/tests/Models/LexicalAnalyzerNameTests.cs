// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class LexicalAnalyzerNameTests
    {
        [Test]
        public void PropertiesEqualConstantFields()
        {
            var properties = typeof(LexicalAnalyzerName)
                .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(p => p.PropertyType == p.DeclaringType)
                .Select(p => new { p.Name, Value = p.GetValue(null)?.ToString() });

            var fields = typeof(LexicalAnalyzerName.Values)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(p => p.FieldType == typeof(string))
                .Select(p => new { p.Name, Value = (string)p.GetRawConstantValue() });

            // Note: tested that declaring an extra property or field does fail the assert.
            CollectionAssert.AreEquivalent(properties, fields);
        }
    }
}
