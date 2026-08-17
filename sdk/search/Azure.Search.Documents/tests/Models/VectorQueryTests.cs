// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

using System;
using System.Reflection;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class VectorQueryTests
    {
        [Test]
        public void LegacyModelFactoryOverloadPreservesKindParameter()
        {
            MethodInfo method = typeof(SearchModelFactory).GetMethod(
                nameof(SearchModelFactory.VectorQuery),
                BindingFlags.Public | BindingFlags.Static,
                binder: null,
                types: [typeof(int?), typeof(string), typeof(bool?), typeof(double?), typeof(float?), typeof(string)],
                modifiers: null);

            Assert.IsNotNull(method);
            Assert.AreEqual("kind", method.GetParameters()[5].Name);

            VectorQuery query = SearchModelFactory.VectorQuery(null, null, null, null, null, kind: "custom");
            Assert.AreEqual("custom", query.Kind.ToString());
        }
    }
}

#endif
