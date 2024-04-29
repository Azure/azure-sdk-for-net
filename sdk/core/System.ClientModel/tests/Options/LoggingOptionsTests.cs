// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.Identity.Client;
using NUnit.Framework;
using System.ClientModel.Options;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Options
{
    public class LoggingOptionsTests
    {
        public LoggingOptionsTests()
        {
        }

        [Test]
        public void DefaultOptionsAreSet()
        {
            LoggingOptions options = new();
            Assert.AreEqual(4 * 1024, options.LoggedContentSizeLimit);
            Assert.AreEqual(21, options.LoggedHeaderNames.Count);
            Assert.AreEqual(1, options.LoggedQueryParameters.Count);
            Assert.AreEqual(false, options.IsLoggingContentEnabled);
            Assert.AreEqual(true, options.IsLoggingEnabled);
            Assert.AreEqual(null, options.LoggedClientAssemblyName);
            Assert.AreEqual(null, options.RequestIdHeaderName);
        }

        [Test]
        public void OptionsFreeze()
        {
            List<string> MyHeadersToLog = new() { "header1", "header2" };
            List<string> MyQueryParametersToLog = new() { "query1", "query2" };

            LoggingOptions options = new()
            {
                LoggedHeaderNames = MyHeadersToLog,
                LoggedQueryParameters = MyQueryParametersToLog,
                LoggedClientAssemblyName = "MyAssembly",
                RequestIdHeaderName = "RequestID"
            };

            options.Freeze();

            Assert.Throws<InvalidOperationException>(() => options.LoggedHeaderNames = new List<string>());
            Assert.Throws<InvalidOperationException>(() => options.IsLoggingEnabled = false);
            Assert.Throws<InvalidOperationException>(() => options.LoggedContentSizeLimit = 5);
            Assert.Throws<InvalidOperationException>(() => options.IsLoggingContentEnabled = true);
            Assert.Throws<InvalidOperationException>(() => options.LoggedQueryParameters = new List<string>());
            Assert.Throws<InvalidOperationException>(() => options.LoggedClientAssemblyName = "other name");
            Assert.Throws<InvalidOperationException>(() => options.RequestIdHeaderName = "other header");

            options.LoggedHeaderNames.Add("Shouldn't be added");
            MyHeadersToLog.Add("Shouldn't impact logged header names");

            options.LoggedQueryParameters.Add("Shouldn't be added");
            MyQueryParametersToLog.Add("Shouldn't impact logged queries");

            Assert.AreEqual(2, options.LoggedHeaderNames.Count);
            Assert.AreEqual(2, options.LoggedQueryParameters.Count);
        }
    }
}
