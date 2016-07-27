﻿namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.Batch.Common;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Batch;
    using Protocol = Microsoft.Azure.Batch.Protocol;
    using BatchTestCommon;
    using IntegrationTestUtilities;
    using Fixtures;

    public class AutoScaleIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(5);
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(1);

        public AutoScaleIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            //Note -- this class does not and should not need a pool fixture
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task AutoScaleEvaluationIntervalTest()
        {
            await SynchronizationContextHelper.RunTestAsync(async () =>
                {
                    using (BatchClient batchCli = await TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment(), addDefaultRetryPolicy: false))
                    {
                        const string poolASFormulaOrig = "$TargetDedicated = 0;";
                        TimeSpan evalInterval = TimeSpan.FromMinutes(6);
                        string poolId0 = "AutoScaleEvalInterval0-" + TestUtilities.GetMyName();

                        try
                        {
                            // create an empty pool with autoscale and an eval interval
                            CloudServiceConfiguration cloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily);
                            CloudPool ubPool = batchCli.PoolOperations.CreatePool(
                                poolId0, 
                                cloudServiceConfiguration: cloudServiceConfiguration, 
                                virtualMachineSize: PoolFixture.VMSize);
                            ubPool.AutoScaleEnabled = true;
                            ubPool.AutoScaleEvaluationInterval = evalInterval;
                            ubPool.AutoScaleFormula = poolASFormulaOrig;

                            ubPool.Commit();

                            // confirm values are returned
                            CloudPool bndPool = batchCli.PoolOperations.GetPool(poolId0);

                            Assert.True(bndPool.AutoScaleEnabled.HasValue && bndPool.AutoScaleEnabled.Value);
                            Assert.Equal(evalInterval, bndPool.AutoScaleEvaluationInterval);

                            // change eval interval
                            TimeSpan newEvalInterval = evalInterval + TimeSpan.FromMinutes(1);

                            bndPool.EnableAutoScale(autoscaleEvaluationInterval: newEvalInterval);

                            int enableCallCounter = 1; // count these to validate server throttle
                            const int expectedEnableCallToFail = 2;

                            bndPool.Refresh();

                            Assert.True(bndPool.AutoScaleEnabled.HasValue && bndPool.AutoScaleEnabled.Value);
                            Assert.True(bndPool.AutoScaleEvaluationInterval.HasValue);
                            Assert.Equal(newEvalInterval, bndPool.AutoScaleEvaluationInterval.Value);

                            // check the interval floor assert
                            var batchException = TestUtilities.AssertThrows<BatchException>(
                                () => bndPool.EnableAutoScale(autoscaleEvaluationInterval: TimeSpan.FromMinutes(1)));
                            Assert.Equal(Microsoft.Azure.Batch.Common.BatchErrorCodeStrings.InvalidPropertyValue, batchException.RequestInformation.BatchError.Code);

                            // check for AutoScaleTooManyRequestsToEnable
                            try
                            {
                                // spam the server
                                for (int i = 0; i < 99; i++)  // remember there was already one (1) call made above
                                {
                                    enableCallCounter++; // one more call
                                    bndPool.EnableAutoScale(autoscaleEvaluationInterval: newEvalInterval + TimeSpan.FromSeconds(i));
                                }

                                // server never pushed back on the spam.  this is a bug
                                throw new Exception("AutoScaleEvaluationIntervalTest: unable to force AutoScaleTooManyRequestsToEnable");
                            }
                            catch (Exception ex)
                            {
                                TestUtilities.AssertIsBatchExceptionAndHasCorrectAzureErrorCode(ex, Microsoft.Azure.Batch.Common.BatchErrorCodeStrings.AutoScaleTooManyRequestsToEnable, this.testOutputHelper);

                                // if we get here the exception passed.

                                // confirm that the expected call fails
                                Assert.Equal(expectedEnableCallToFail, enableCallCounter);
                            }
                        }
                        finally
                        {
                            // cleanup
                            TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId0).Wait();
                        }
                    }
                },
                TestTimeout);
        }
    }
}
