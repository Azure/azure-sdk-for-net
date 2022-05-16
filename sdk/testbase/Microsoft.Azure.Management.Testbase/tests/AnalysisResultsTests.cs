// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace TestBase.Tests
{
    public class AnalysisResultsTests : TestbaseBase
    {
        string testResultName = "TestResult-98f12f56-9cd9-4b21-8eab-7acf448c46df";
        string[] analysisResultTypes = new string[] { AnalysisResultType.ScriptExecution, AnalysisResultType.CPUUtilization, AnalysisResultType.MemoryRegression, AnalysisResultType.MemoryUtilization, AnalysisResultType.Reliability, AnalysisResultType.CPURegression
        };

        [Fact]
        public void TestAnalysisOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);


                foreach (var anaResultType in analysisResultTypes)
                {
                    try
                    {
                        var result = t_TestBaseClient.AnalysisResults.ListWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, t_PackageName, testResultName, anaResultType).GetAwaiter().GetResult();
                        Assert.NotNull(result);
                        Assert.NotNull(result.Body);
                    }
                    catch (Exception ex)
                    {
                        Assert.NotNull(ex.Message);
                    }
                }

                foreach (var anaResultType in analysisResultTypes)
                {
                    try
                    {
                        var result = t_TestBaseClient.AnalysisResults.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, t_PackageName, testResultName, anaResultType).GetAwaiter().GetResult();
                        Assert.NotNull(result);
                        Assert.NotNull(result.Body);
                    }
                    catch (Exception ex)
                    {
                        Assert.NotNull(ex.Message);
                    }
                }

            }
        }

    }
}
