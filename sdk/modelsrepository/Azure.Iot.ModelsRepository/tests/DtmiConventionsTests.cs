// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using FluentAssertions;
using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class DtmiConventionsTests : ModelsRepositoryTestBase
    {
        [TestCase("dtmi:com:Example:Model;1", "dtmi/com/example/model-1.json")]
        [TestCase("dtmi:com:example:Model;1", "dtmi/com/example/model-1.json")]
        [TestCase("dtmi:com:example:Model:1", null)]
        [TestCase("", null)]
        [TestCase(null, null)]
        public void DtmiToPath(string dtmi, string expectedPath)
        {
            DtmiConventions.DtmiToPath(dtmi).Should().Be(expectedPath);
        }

        [TestCase("dtmi:com:example:Thermostat;1", "https://localhost/repository/", "https://localhost/repository/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat;1", "https://localhost/REPOSITORY", "https://localhost/REPOSITORY/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat;1", "/path/to/repository/", "/path/to/repository/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat;1", "/path/to/RepoSitory", "/path/to/RepoSitory/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat;1", "C:\\path\\to\\repository", "C:/path/to/repository/dtmi/com/example/thermostat-1.json")]
        [TestCase("dtmi:com:example:Thermostat:1", "https://localhost/repository", null)]
        [TestCase("dtmi:com:example:Thermostat:1", "/path/to/repository/", null)]
        public void DtmiToQualifiedPath(string dtmi, string repository, string expectedPath)
        {
            if (string.IsNullOrEmpty(expectedPath))
            {
                Action act = () => DtmiConventions.DtmiToQualifiedPath(dtmi, repository);
                act.Should().Throw<ArgumentException>().WithMessage(string.Format(StandardStrings.InvalidDtmiFormat, dtmi));
                return;
            }

            string modelPath = DtmiConventions.DtmiToQualifiedPath(dtmi, repository);
            modelPath.Should().Be(expectedPath);

            string expectedExpandedPath = expectedPath.Replace(
                ModelsRepositoryConstants.JsonFileExtension, ModelsRepositoryConstants.ExpandedJsonFileExtension);
            string expandedModelPath = DtmiConventions.DtmiToQualifiedPath(dtmi, repository, true);
            expandedModelPath.Should().Be(expectedExpandedPath);
        }

        [TestCase("dtmi:com:example:Thermostat;1", true)]
        [TestCase("dtmi:contoso:scope:entity;2", true)]
        [TestCase("dtmi:com:example:Thermostat:1", false)]
        [TestCase("dtmi:com:example::Thermostat;1", false)]
        [TestCase("com:example:Thermostat;1", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void ClientIsValidDtmi(string dtmi, bool expected)
        {
            DtmiConventions.IsValidDtmi(dtmi).Should().Be(expected);
        }
    }
}
