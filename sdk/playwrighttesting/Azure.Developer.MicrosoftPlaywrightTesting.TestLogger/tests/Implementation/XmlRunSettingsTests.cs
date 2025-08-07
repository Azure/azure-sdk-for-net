// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using System.Collections.Generic;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Implementation
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    internal class XmlRunSettingsTests
    {
        [Test]
        public void GetNUnitParameters_WhenSettingsXmlContainsNUnitNode_ReturnsParameters()
        {
            var xmlRunSettings = new XmlRunSettings();
            var settingsXml = @"<NUnit><NumberOfTestWorkers>5</NumberOfTestWorkers><StopOnError>False</StopOnError></NUnit>";

            Dictionary<string, object> parameters = xmlRunSettings.GetNUnitParameters(settingsXml);

            Assert.AreEqual(2, parameters.Count);
            Assert.AreEqual(parameters["NumberOfTestWorkers"], "5");
            Assert.AreEqual(parameters["StopOnError"], "False");
        }

        [Test]
        public void GetNUnitParameters_WhenSettingsXmlContainsInvalidNode_ReturnsEmptyDictionary()
        {
            var xmlRunSettings = new XmlRunSettings();
            var settingsXml = @"<NUnit><NumberOfTestWorkers>5</NumberOfTestW";

            Dictionary<string, object> parameters = xmlRunSettings.GetNUnitParameters(settingsXml);

            Assert.AreEqual(0, parameters.Count);
        }

        [Test]
        public void GetNUnitParameters_WhenSettingsXmlDoesNotContainNUnitNode_ReturnsEmptyDictionary()
        {
            var xmlRunSettings = new XmlRunSettings();
            var settingsXml = @"<MSTest><NumberOfTestWorkers>5</NumberOfTestWorkers><StopOnError>False</StopOnError></MSTest>";

            Dictionary<string, object> parameters = xmlRunSettings.GetNUnitParameters(settingsXml);

            Assert.AreEqual(0, parameters.Count);
        }

        [Test]
        public void GetNUnitParameters_WhenSettingsXmlIsNull_ReturnsEmptyDictionary()
        {
            var xmlRunSettings = new XmlRunSettings();

            Dictionary<string, object> parameters = xmlRunSettings.GetNUnitParameters(null);

            Assert.AreEqual(0, parameters.Count);
        }
    }
}
