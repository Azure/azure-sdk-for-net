// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Developer.LoadTesting.Tests.Helper;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestTestsBase: RecordedTestBase<LoadTestingClientTestEnvironment>
    {
        internal string _testId;
        internal string _fileName;
        internal TestHelper _testHelper;
        internal LoadTestAdministrationClient _loadTestAdministrationClient;
        internal string _testRunId;
        internal string _resourceId;

        public LoadTestTestsBase(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            _testId = "test-from-csharp-sdk-testing-framework";
            _fileName = "sample.jmx";
            _testRunId = "test-run-id-from-csharp-sdk";
            _testHelper = new TestHelper();

            BodyKeySanitizers.Add(new BodyKeySanitizer(SanitizeValue)
            {
                GroupForReplace = "group",
                JsonPath = "$..url",
                Regex = @"sig=(?<group>.*?)(?=$|&)"
            });

            BodyRegexSanitizers.Add(new BodyRegexSanitizer("[^\\r](?<break>\\n)", "\r\n")
            {
                    GroupForReplace = "break"
            });
        }

        internal LoadTestAdministrationClient CreateAdministrationClient()
        {
            return InstrumentClient(new LoadTestAdministrationClient(new Uri("https://" + TestEnvironment.Endpoint), TestEnvironment.Credential, InstrumentClientOptions(new LoadTestingClientOptions())));
        }

        internal LoadTestRunClient CreateRunClient()
        {
            return InstrumentClient(new LoadTestRunClient(new Uri("https://" + TestEnvironment.Endpoint), TestEnvironment.Credential, InstrumentClientOptions(new LoadTestingClientOptions())));
        }
    }
}
