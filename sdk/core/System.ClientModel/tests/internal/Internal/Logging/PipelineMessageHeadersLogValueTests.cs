// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal;

public class PipelineMessageHeadersLogValueTests
{
    [Test]
    public void PipelineMessageHeadersLogValueToStringHidesOnlySensitiveHeaders()
    {
        MockRequestHeaders requestHeaders = new()
        {
            { "Sensitive-Header", "SensitiveValue" },
            { "NonSensitive-Header", "NonSensitiveValue" },
            { "Content-Length", "6" }
        };
        Dictionary<string, string> headers = new()
        {
            { "Sensitive-Header", "SensitiveValue" },
            { "NonSensitive-Header", "NonSensitiveValue" },
            { "Content-Length", "6" }
        };
        MockResponseHeaders responseHeaders = new(headers);

        PipelineMessageSanitizer sanitizer = new([], ["NonSensitive-Header"]);

        PipelineMessageHeadersLogValue requestLogValue = new(requestHeaders, sanitizer);
        PipelineMessageHeadersLogValue responseLogValue = new(responseHeaders, sanitizer);

        string loggedRequestValue = requestLogValue.ToString();
        string loggedResponseValue = responseLogValue.ToString();

        Assert.That(loggedRequestValue, Is.Not.Null);
        Assert.That(loggedResponseValue, Is.Not.Null);

        string expected = string.Join(Environment.NewLine,
            "Sensitive-Header:REDACTED",
            "NonSensitive-Header:NonSensitiveValue",
            "Content-Length:REDACTED",
            string.Empty);

        Assert.AreEqual(loggedRequestValue, expected);
        Assert.AreEqual(loggedResponseValue, expected);
    }
}
