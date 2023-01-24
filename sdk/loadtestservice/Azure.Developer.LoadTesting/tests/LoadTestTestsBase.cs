// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Developer.LoadTesting.Tests.Helper;
using NUnit.Framework;
using static NUnit.Framework.TestContext;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestTestsBase: RecordedTestBase<LoadTestingClientTestEnvironment>
    {
        internal string _testId;
        internal string _fileName;
        internal TestHelper _testHelper;
        internal LoadTestAdministrationClient _loadTestAdministrationClient;
        internal LoadTestRunClient _loadTestRunClient;
        internal string _testRunId;
        internal string _resourceId;
        internal const string SKIP_SET_UP = "SkipSetUp";
        internal const string SKIP_TEAR_DOWN = "SkipTearDown";
        internal const string UPLOAD_TEST_FILE = "UploadTestFile";
        internal const string SKIP_TEST_RUN = "SkipTestRun";
        internal const string SKIP_DELETE_TEST_RUN = "SkipDeleteTestRun";
        internal TestRunOperation _testRunOperation;

        internal bool CheckForSkipSetUp()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(SKIP_SET_UP);
        }

        internal bool CheckForSkipTearDown()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(SKIP_TEAR_DOWN);
        }

        internal bool CheckForUploadTestFile()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(UPLOAD_TEST_FILE);
        }

        internal bool CheckForSkipTestRun()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(SKIP_TEST_RUN);
        }

        internal bool CheckForSkipDeleteTestRun()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(SKIP_DELETE_TEST_RUN);
        }

        public LoadTestTestsBase(bool isAsync) : base(isAsync)
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
