// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class IndexingParametersTests
    {
        // This parameter should likely never be defined by Cognitive Search.
        private const string CustomParameterName = "_2ff83761cb3b4a2eab2f88b733128751";

        [Test]
        public void ConfigurationInitializesIndexingParametersConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters();
            Assert.IsNull(parameters.IndexingParametersConfiguration);

            // Setting Configuration should initialize IndexingParametersConfiguration
            Assert.IsNotNull(parameters.Configuration);

            parameters.Configuration[CustomParameterName] = "custom";
            Assert.IsNotNull(parameters.IndexingParametersConfiguration);
        }

        [Test]
        public void SetIndexingParametersConfiguration()
        {
            IndexingParameters parameters = new IndexingParameters
            {
                IndexingParametersConfiguration = new IndexingParametersConfiguration
                {
                    ParsingMode = BlobIndexerParsingMode.Json,
                    [CustomParameterName] = "custom",
                },
            };

            Assert.AreEqual(2, parameters.Configuration.Count);
            Assert.AreEqual(BlobIndexerParsingMode.Json, parameters.Configuration["parsingMode"]);
            Assert.AreEqual("custom", parameters.Configuration[CustomParameterName]);

            Assert.AreEqual(1, parameters.IndexingParametersConfiguration.Count());
            Assert.AreEqual("custom", parameters.IndexingParametersConfiguration[CustomParameterName]);

            Assert.AreEqual(BlobIndexerParsingMode.Json, parameters.IndexingParametersConfiguration.ParsingMode);
        }

        // TODO: Continue...
    }
}
