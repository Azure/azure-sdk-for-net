// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation
{
    internal class XmlRunSettings : IXmlRunSettings
    {
        private static readonly string NUnitNodeName = "NUnit";
        public Dictionary<string, object> GetTestRunParameters(string? settingsXml)
        {
            return XmlRunSettingsUtilities.GetTestRunParameters(settingsXml);
        }

        public Dictionary<string, object> GetNUnitParameters(string? settingsXml)
        {
            try
            {
                var parameters = new Dictionary<string, object>();
                XmlDocument xmlDocument = ParseXmlSettings(settingsXml);
                XmlNodeList nUnitNodes = xmlDocument.GetElementsByTagName(NUnitNodeName);
                foreach (XmlNode nUnitNode in nUnitNodes)
                {
                    foreach (XmlNode childNode in nUnitNode.ChildNodes)
                    {
                        parameters.Add(childNode.Name, childNode.InnerText);
                    }
                }
                return parameters;
            }
            catch (Exception)
            {
                return new Dictionary<string, object>();
            }
        }

        private static XmlDocument ParseXmlSettings(string? settingsXml)
        {
            XmlDocument xmlDocument = new();
            xmlDocument.LoadXml(settingsXml!); // this will throw argument null exception if settingsXml is null
            return xmlDocument;
        }
    }
}
