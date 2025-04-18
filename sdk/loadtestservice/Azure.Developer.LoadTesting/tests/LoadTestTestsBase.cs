// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Developer.LoadTesting.Tests.Helper;
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
        internal string _asyncSuffix = string.Empty;
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
            _testId = SafeSubstring($"{CurrentContext.Test.MethodName.Replace("_", "-")}{_asyncSuffix}-loadtest".ToLower(), 50);
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
            _testProfileId = SafeSubstring($"{CurrentContext.Test.MethodName.Replace("_","-")}{_asyncSuffix}-testprofile".ToLower(), 50);
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(REQUIRES_TEST_PROFILE);
        }

        internal bool RequiresTestRun()
        {
            _testRunId = SafeSubstring($"{CurrentContext.Test.MethodName.Replace("_", "-")}{_asyncSuffix}-testrun".ToLower(), 50);
            var categories = CurrentContext.Test.Properties["Category"];
            return categories != null && categories.Contains(REQUIRES_TEST_RUN);
        }

        internal bool RequiresTestProfileRun()
        {
            _testProfileRunId = SafeSubstring($"{CurrentContext.Test.MethodName.Replace("_", "-")}{_asyncSuffix}-testprofilerun".ToLower(), 50);
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

        internal string SafeSubstring(string str, int maxLength)
        {
            if (str.Length > maxLength)
            {
                return str.Substring(0, maxLength);
            }

            return str;
        }

        public LoadTestTestsBase(bool isAsync) : base(isAsync)
        {
            _asyncSuffix = isAsync ? "a" : string.Empty;
            _testId = "loadtest-from-csharp-sdk" + _asyncSuffix;
            _testProfileId = "testprofile-from-csharp-sdk" + _asyncSuffix;
            _fileName = "sample.jmx";
            _testRunId = "testrun-from-csharp-sdk" + _asyncSuffix;
            _testProfileRunId = "testprofilerun-from-csharp-sdk" + _asyncSuffix;
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
