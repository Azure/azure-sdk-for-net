// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.WebJobs.Extensions.Storage.Common.Tests
{
    // TODO (kasobol-msft) replace this with LiveOnlyAttribute from Core when ready live tests are integrated properly.
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    public class WebJobsLiveOnlyAttribute : NUnitAttribute, IApplyToTest
    {
        /// <summary>
        /// Modifies the <paramref name="test"/> by adding categories to it and changing the run state as needed.
        /// </summary>
        /// <param name="test">The <see cref="Test"/> to modify.</param>
        public void ApplyToTest(Test test)
        {
            test.Properties.Add("Category", "Live");

            if (test.RunState != RunState.NotRunnable)
            {
                string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", "This test requires connection string to real storage account defined in AzureWebJobsStorage variable");
                }
            }
        }
    }
}
