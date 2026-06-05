// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    /// <summary>
    /// Unit tests for the <see cref="QueryRewrites"/> wrapper that packs/unpacks the
    /// compound <c>"queryRewrites"</c> wire value (e.g. <c>"generative"</c> or
    /// <c>"generative|count-3"</c>) used by <see cref="SemanticSearchOptions"/> and
    /// <see cref="VectorizableTextQuery"/>.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("ModelSerialization")]
    public class QueryRewritesTests
    {
        [Test]
        public void Pack_TypeOnly_ProducesBareTypeString()
        {
            QueryRewrites rewrites = new QueryRewrites(QueryRewritesType.Generative);

            Assert.AreEqual("generative", rewrites.QueryRewritesRaw);
        }

        [Test]
        public void Pack_TypeAndCount_ProducesCompoundString()
        {
            QueryRewrites rewrites = new QueryRewrites(QueryRewritesType.Generative)
            {
                Count = 3,
            };

            Assert.AreEqual("generative|count-3", rewrites.QueryRewritesRaw);
        }

        [Test]
        public void Pack_NoneType_ProducesNoneString()
        {
            QueryRewrites rewrites = new QueryRewrites(QueryRewritesType.None);

            Assert.AreEqual("none", rewrites.QueryRewritesRaw);
        }

        [Test]
        public void Unpack_BareType_PopulatesRewritesTypeOnly()
        {
            QueryRewrites rewrites = new QueryRewrites(QueryRewritesType.None)
            {
                QueryRewritesRaw = "generative",
            };

            Assert.AreEqual(QueryRewritesType.Generative, rewrites.RewritesType);
            Assert.IsNull(rewrites.Count);
        }

        [Test]
        public void Unpack_CompoundString_PopulatesRewritesTypeAndCount()
        {
            QueryRewrites rewrites = new QueryRewrites(QueryRewritesType.None)
            {
                QueryRewritesRaw = "generative|count-3",
            };

            Assert.AreEqual(QueryRewritesType.Generative, rewrites.RewritesType);
            Assert.AreEqual(3, rewrites.Count);
        }

        [Test]
        public void Unpack_UnknownParameter_IsIgnored()
        {
            QueryRewrites rewrites = new QueryRewrites(QueryRewritesType.None)
            {
                QueryRewritesRaw = "generative|threshold-0.5",
            };

            Assert.AreEqual(QueryRewritesType.Generative, rewrites.RewritesType);
            Assert.IsNull(rewrites.Count);
        }

        [Test]
        public void Unpack_MultipleParameters_PicksCount()
        {
            QueryRewrites rewrites = new QueryRewrites(QueryRewritesType.None)
            {
                QueryRewritesRaw = "generative|threshold-0.5,count-7",
            };

            Assert.AreEqual(QueryRewritesType.Generative, rewrites.RewritesType);
            Assert.AreEqual(7, rewrites.Count);
        }

        [TestCase("generative")]
        [TestCase("generative|count-1")]
        [TestCase("generative|count-10")]
        [TestCase("none")]
        public void Roundtrip_RawString_SurvivesUnpackThenPack(string raw)
        {
            QueryRewrites rewrites = new QueryRewrites(QueryRewritesType.None)
            {
                QueryRewritesRaw = raw,
            };

            Assert.AreEqual(raw, rewrites.QueryRewritesRaw);
        }

        [Test]
        public void Roundtrip_TypedValues_SurvivePackThenUnpack()
        {
            QueryRewrites original = new QueryRewrites(QueryRewritesType.Generative)
            {
                Count = 5,
            };

            string wire = original.QueryRewritesRaw;

            QueryRewrites parsed = new QueryRewrites(QueryRewritesType.None)
            {
                QueryRewritesRaw = wire,
            };

            Assert.AreEqual(original.RewritesType, parsed.RewritesType);
            Assert.AreEqual(original.Count, parsed.Count);
        }
    }
}

#endif
