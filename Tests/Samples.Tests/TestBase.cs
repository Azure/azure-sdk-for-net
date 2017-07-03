// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Runtime.CompilerServices;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public abstract class TestBase
    {
        public TestBase(ITestOutputHelper output)
        {
            Microsoft.Azure.Management.Samples.Common.Utilities.LoggerMethod = output.WriteLine;
            Microsoft.Azure.Management.Samples.Common.Utilities.PauseMethod = TestHelper.ReadLine;
        }

        protected void RunSampleAsTest(
            string testTypeName,
            Action<IAzure> runSampleDelegate,
            string assetFolderLocation = null,
            [CallerMemberName] string methodName = "testframework_failed")
        {
            using (var context = FluentMockContext.Start(testTypeName, methodName))
            {
                Microsoft.Azure.Management.Samples.Common.Utilities.IsRunningMocked = HttpMockServer.Mode == HttpRecorderMode.Playback;
                if (assetFolderLocation != null)
                {
                    Microsoft.Azure.Management.Samples.Common.Utilities.ProjectPath = assetFolderLocation;
                }

                var rollUpClient = TestHelper.CreateRollupClient();
                runSampleDelegate(rollUpClient);
            }
        }

        protected void RunSampleAsTest(
            string testTypeName,
            Action<Microsoft.Azure.Management.Fluent.Azure.IAuthenticated> runSampleDelegate,
            string assetFolderLocation = null,
            [CallerMemberName] string methodName = "testframework_failed")
        {
            using (var context = FluentMockContext.Start(testTypeName, methodName))
            {
                Microsoft.Azure.Management.Samples.Common.Utilities.IsRunningMocked = HttpMockServer.Mode == HttpRecorderMode.Playback;
                if (assetFolderLocation != null)
                {
                    Microsoft.Azure.Management.Samples.Common.Utilities.ProjectPath = assetFolderLocation;
                }

                var createAuthenticatedClient = TestHelper.CreateAuthenticatedClient();
                runSampleDelegate(createAuthenticatedClient);
            }
        }
    }
}
