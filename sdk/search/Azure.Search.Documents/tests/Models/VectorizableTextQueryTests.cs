// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

using System;
using System.ClientModel.Primitives;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    /// <summary>
    /// Unit tests for the handwritten <see cref="QueryRewrites"/> customization on
    /// <see cref="VectorizableTextQuery"/>. Verifies the typed wrapper round-trips through
    /// the underlying generated <c>queryRewrites</c> wire field.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("ModelSerialization")]
    public class VectorizableTextQueryTests
    {
        [Test]
        public void QueryRewrites_DefaultsToNull()
        {
            VectorizableTextQuery query = new VectorizableTextQuery("hello world");

            Assert.IsNull(query.QueryRewrites);
        }

        [Test]
        public void QueryRewrites_TypeOnly_SerializesAsBareString()
        {
            VectorizableTextQuery query = new VectorizableTextQuery("hello world")
            {
                QueryRewrites = new QueryRewrites(QueryRewritesType.Generative),
            };

            string json = ModelReaderWriter.Write(query, ModelReaderWriterOptions.Json).ToString();

            StringAssert.Contains("\"queryRewrites\":\"generative\"", json);
        }

        [Test]
        public void QueryRewrites_TypeAndCount_SerializesAsCompoundString()
        {
            VectorizableTextQuery query = new VectorizableTextQuery("hello world")
            {
                QueryRewrites = new QueryRewrites(QueryRewritesType.Generative)
                {
                    Count = 3,
                },
            };

            string json = ModelReaderWriter.Write(query, ModelReaderWriterOptions.Json).ToString();

            StringAssert.Contains("\"queryRewrites\":\"generative|count-3\"", json);
        }

        [Test]
        public void QueryRewrites_RoundtripsThroughSerialization()
        {
            VectorizableTextQuery original = new VectorizableTextQuery("hello world")
            {
                QueryRewrites = new QueryRewrites(QueryRewritesType.Generative)
                {
                    Count = 5,
                },
            };

            BinaryData wire = ModelReaderWriter.Write(original, ModelReaderWriterOptions.Json);
            VectorizableTextQuery parsed = ModelReaderWriter.Read<VectorizableTextQuery>(wire, ModelReaderWriterOptions.Json);

            Assert.IsNotNull(parsed.QueryRewrites);
            Assert.AreEqual(QueryRewritesType.Generative, parsed.QueryRewrites.RewritesType);
            Assert.AreEqual(5, parsed.QueryRewrites.Count);
        }

        [Test]
        public void QueryRewrites_DeserializesBareTypeIntoWrapper()
        {
            const string json = "{\"kind\":\"text\",\"text\":\"hello\",\"queryRewrites\":\"generative\"}";

            VectorizableTextQuery parsed = ModelReaderWriter.Read<VectorizableTextQuery>(BinaryData.FromString(json), ModelReaderWriterOptions.Json);

            Assert.IsNotNull(parsed.QueryRewrites);
            Assert.AreEqual(QueryRewritesType.Generative, parsed.QueryRewrites.RewritesType);
            Assert.IsNull(parsed.QueryRewrites.Count);
        }

        [Test]
        public void QueryRewrites_NotEmitted_WhenUnset()
        {
            VectorizableTextQuery query = new VectorizableTextQuery("hello world");

            string json = ModelReaderWriter.Write(query, ModelReaderWriterOptions.Json).ToString();

            StringAssert.DoesNotContain("queryRewrites", json);
        }

        [Test]
        public void QueryRewrites_SetToNullAfterAssignment_StopsEmission()
        {
            VectorizableTextQuery query = new VectorizableTextQuery("hello world")
            {
                QueryRewrites = new QueryRewrites(QueryRewritesType.Generative) { Count = 2 },
            };

            query.QueryRewrites = null;

            string json = ModelReaderWriter.Write(query, ModelReaderWriterOptions.Json).ToString();

            StringAssert.DoesNotContain("queryRewrites", json);
        }
    }
}

#endif
