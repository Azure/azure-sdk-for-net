// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    internal interface IXmlRunSettings
    {
        Dictionary<string, object> GetTestRunParameters(string? settingsXml);
        Dictionary<string, object> GetNUnitParameters(string? settingsXml);
    }
}
