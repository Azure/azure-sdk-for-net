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
        internal string _testProfileId;
        internal TestHelper _testHelper;
        internal LoadTestAdministrationClient _loadTestAdministrationClient;
        internal LoadTestRunClient _loadTestRunClient;
        internal string _testRunId;
        internal string _testProfileRunId;
        internal string _resourceId;
        internal string _targetResourceId;
        internal const string SKIP_SET_UP = "SkipSetUp";
        internal const string SKIP_TEAR_DOWN = "SkipTearDown";
        internal const string SKIP_DELETE_TEST_RUN = "SkipDeleteTestRun";
        internal TestRunResultOperation _testRunOperation;
        internal Operation<BinaryData> _testProfileRunOperation;

        internal const string REQUIRES_LOAD_TEST = "RequiresLoadTest";
        internal const string REQUIRES_TEST_FILE = "RequiresTestFile";
        internal const string REQUIRES_TEST_PROFILE = "RequiresTestProfile";
        internal const string REQUIRES_TEST_RUN = "RequiresTestRun";
        internal const string REQUIRES_TEST_PROFILE_RUN = "RequiresTestProfileRun";

        internal bool RequiresLoadTest()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(REQUIRES_LOAD_TEST);
        }

        internal bool RequiresTestFile()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(REQUIRES_TEST_FILE);
        }

        internal bool RequiresTestProfile()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(REQUIRES_TEST_PROFILE);
        }

        internal bool RequiresTestRun()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(REQUIRES_TEST_RUN);
        }

        internal bool RequiresTestProfileRun()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(REQUIRES_TEST_PROFILE_RUN);
        }

        internal bool SkipTearDown()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(SKIP_TEAR_DOWN);
        }

        internal bool CheckForSkipDeleteTestRun()
        {
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(SKIP_DELETE_TEST_RUN);
        }

        public LoadTestTestsBase(bool isAsync) : base(isAsync)
        {
            _testId = "test-from-csharp-sdk-testing-framework";
            _testProfileId = "test-profile-from-csharp-sdk-testing";
            _fileName = "sample.jmx";
            _testRunId = "test-run-id-from-csharp-sdk";
            _testProfileRunId = "test-profile-run-id-from-csharp-sdk";
            _testHelper = new TestHelper();

            BodyKeySanitizers.Add(new BodyKeySanitizer("$..url")
            {
                GroupForReplace = "group",
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
