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

        [TestCase("dtmi:com:example:Thermostat;1", "dtmi/com/example/thermostat-1.json", "https://localhost/repository")]
        [TestCase("dtmi:com:example:Thermostat;1", "dtmi/com/example/thermostat-1.json", @"C:\fakeRegistry")]
        [TestCase("dtmi:com:example:Thermostat;1", "dtmi/com/example/thermostat-1.json", "/me/fakeRegistry")]
        [TestCase("dtmi:com:example:Thermostat:1", null, "https://localhost/repository")]
        [TestCase("dtmi:com:example:Thermostat:1", null, "/me/fakeRegistry")]
        public void DtmiToQualifiedPath(string dtmi, string expectedPath, string repository)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                repository = repository.Replace("\\", "/");
            }

            if (string.IsNullOrEmpty(expectedPath))
            {
                Action act = () => DtmiConventions.DtmiToQualifiedPath(dtmi, repository);
                act.Should().Throw<ArgumentException>().WithMessage(string.Format(StandardStrings.InvalidDtmiFormat, dtmi));
                return;
            }

            string modelPath = DtmiConventions.DtmiToQualifiedPath(dtmi, repository);
            modelPath.Should().Be($"{repository}/{expectedPath}");

            string expandedModelPath = DtmiConventions.DtmiToQualifiedPath(dtmi, repository, true);
            expandedModelPath
                .Should()
                .Be($"{repository}/{expectedPath.Replace(ModelsRepositoryConstants.JsonFileExtension, ModelsRepositoryConstants.ExpandedJsonFileExtension)}");
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
            DtmiConventions.IsDtmi(dtmi).Should().Be(expected);
        }
    }
}
