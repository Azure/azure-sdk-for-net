// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using FluentAssertions;
using NUnit.Framework;
using System;

namespace Azure.IoT.ModelsRepository.Tests
{
    public class DtmiConventionsTests : ModelsRepositoryTestBase
    {
        [TestCase("dtmi:com:Example:Model;1", "dtmi/com/example/model-1.json")]
        [TestCase("dtmi:com:example:Model;1", "dtmi/com/example/model-1.json")]
        [TestCase("dtmi:com:example:Model:1", null)]
        [TestCase("", null)]
        [TestCase(null, null)]
        [TestCase("dtmi:com:example:Model", "dtmi/com/example/model.json")]
        [TestCase("dtmi:com:example:Model;1.2", "dtmi/com/example/model-1.2.json")]
        public void DtmiToPath(string dtmi, string expectedPath)
        {
            DtmiConventions.DtmiToPath(dtmi).Should().Be(expectedPath);
        }

        [TestCase("dtmi:com:example:Thermostat;1", "https://localhost/repository/", "https://localhost/repository/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat;1", "https://localhost/REPOSITORY", "https://localhost/REPOSITORY/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat;1", "file:///path/to/repository/", "file:///path/to/repository/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat;1", "file://path/to/RepoSitory", "file://path/to/RepoSitory/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat;1", "C:\\path\\to\\repository\\", "file:///C:/path/to/repository/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat:1", "https://localhost/repository/", null)]
        [TestCase("dtmi:com:example:Thermostat:1", "file://path/to/repository/", null)]
        [TestCase("dtmi:com:example:Thermostat;1", "\\\\server\\repository", "file://server/repository/dtmi/com/example/thermostat-1.json")]
        public void GetModelUri(string dtmi, string repository, string expectedUri)
        {
            var repositoryUri = new Uri(repository);
            if (string.IsNullOrEmpty(expectedUri))
            {
                Action act = () => DtmiConventions.GetModelUri(dtmi, repositoryUri);
                act.Should().Throw<ArgumentException>().WithMessage(string.Format(StandardStrings.InvalidDtmiFormat, dtmi));
                return;
            }

            Uri modelUri = DtmiConventions.GetModelUri(dtmi, repositoryUri);
            modelUri.AbsoluteUri.Should().Be(expectedUri);

            string expectedExpandedUri = expectedUri.Replace(
                ModelsRepositoryConstants.JsonFileExtension, ModelsRepositoryConstants.ExpandedJsonFileExtension);

            Uri expandedModelUri = DtmiConventions.GetModelUri(dtmi, repositoryUri, true);
            expandedModelUri.Should().Be(expectedExpandedUri);
        }

        [TestCase("dtmi:com:example:Thermostat;1", true)]
        [TestCase("dtmi:contoso:scope:entity;2", true)]
        [TestCase("dtmi:com:example:Thermostat:1", false)]
        [TestCase("dtmi:com:example::Thermostat;1", false)]
        [TestCase("com:example:Thermostat;1", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("dtmi:contoso:scope:entity", true)]
        [TestCase("dtmi:contoso:scope:entity;2.1", true)]
        public void IsValidDtmi(string dtmi, bool expected)
        {
            DtmiConventions.IsValidDtmi(dtmi).Should().Be(expected);
        }

        [TestCase("https://localhost/repository/", "https://localhost/repository/metadata.json")]
        [TestCase("C:\\path\\to\\repository\\", "file:///C:/path/to/repository/metadata.json")]
        [TestCase("file:///path/to/repository/", "file:///path/to/repository/metadata.json")]
        public void GetMetadataUri(string repository, string expectedUri)
        {
            Uri metadataUri = DtmiConventions.GetMetadataUri(new Uri(repository));
            metadataUri.AbsoluteUri.Should().Be(expectedUri);
        }
    }
}
