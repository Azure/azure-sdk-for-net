// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class DtmiConversionTests
    {
        [TestCase("dtmi:com:Example:Model;1", "dtmi/com/example/model-1.json")]
        [TestCase("dtmi:com:example:Model;1", "dtmi/com/example/model-1.json")]
        [TestCase("dtmi:com:example:Model:1", null)]
        [TestCase("", null)]
        [TestCase(null, null)]
        public void DtmiToPath(string dtmi, string expectedPath)
        {
            Assert.AreEqual(expectedPath, DtmiConventions.DtmiToPath(dtmi));
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
                ArgumentException re = Assert.Throws<ArgumentException>(() => DtmiConventions.DtmiToQualifiedPath(dtmi, repository));
                Assert.AreEqual(re.Message, string.Format(StandardStrings.InvalidDtmiFormat, dtmi));
                return;
            }

            string modelPath = DtmiConventions.DtmiToQualifiedPath(dtmi, repository);
            Assert.AreEqual($"{repository}/{expectedPath}", modelPath);

            string expandedModelPath = DtmiConventions.DtmiToQualifiedPath(dtmi, repository, true);
            Assert.AreEqual($"{repository}/{expectedPath.Replace(".json", ".expanded.json")}", expandedModelPath);
        }
    }
}
