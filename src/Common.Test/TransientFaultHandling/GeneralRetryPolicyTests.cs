using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Common.TransientFaultHandling;
using Xunit;

namespace Microsoft.WindowsAzure.Common.Test.TransientFaultHandling
{
    /// <summary>
    /// Implements general test cases for retry policies.
    /// </summary>
    public class GeneralRetryPolicyTests
    {
        public void GeneralRetryPolicyTests()
        {
            RetryPolicyFactory.CreateDefault();
        }

        [TestCleanup]
        public void Cleanup()
        {
            RetryPolicyFactory.SetRetryManager(null, false);
        }

        [TestMethod]
        public void TestNegativeRetryCount()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy> retryPolicy = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(-1);
                Assert.Fail("When the RetryCount is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("retryCount", ex.ParamName, String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }

            // Removed - different approach when dealing with the factory.
            ////try
            ////{
            ////    // Second, attempt to instantiate a retry policy from configuration with invalid settings.
            ////    RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("NegativeRetryCount");
            ////    Assert.Fail("When the RetryCount is negative, the retry policy should throw an exception.");
            ////}
            ////catch (ConfigurationErrorsException ex)
            ////{
            ////    Assert.IsTrue(ex.Message.Contains("maxRetryCount"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            ////}

            try
            {
                // And last, instantiate a policy description with invalid settings.
                new FixedIntervalData { MaxRetryCount = -1 };
                Assert.Fail("When the RetryCount is negative, the retry policy should throw an exception.");
            }
            catch (ConfigurationErrorsException ex)
            {
                Assert.IsTrue(ex.Message.Contains("maxRetryCount"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }

            try
            {
                // And last, instantiate a policy description with invalid settings.
                new IncrementalData { MaxRetryCount = -1 };
                Assert.Fail("When the RetryCount is negative, the retry policy should throw an exception.");
            }
            catch (ConfigurationErrorsException ex)
            {
                Assert.IsTrue(ex.Message.Contains("maxRetryCount"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }

            try
            {
                // And last, instantiate a policy description with invalid settings.
                new ExponentialBackoffData { MaxRetryCount = -1 };
                Assert.Fail("When the RetryCount is negative, the retry policy should throw an exception.");
            }
            catch (ConfigurationErrorsException ex)
            {
                Assert.IsTrue(ex.Message.Contains("maxRetryCount"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }
        }

        [TestMethod]
        public void TestNegativeRetryInterval()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy> retryPolicy = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(-2));
                Assert.Fail("When the RetryInterval is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("retryInterval", ex.ParamName, String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }

            ////try
            ////{
            ////    // Second, attempt to instantiate a retry policy from configuration with invalid settings.
            ////    RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("NegativeRetryInterval");
            ////    Assert.Fail("When the RetryInterval is negative, the retry policy should throw an exception.");
            ////}
            ////catch (ConfigurationErrorsException ex)
            ////{
            ////    Assert.IsTrue(ex.Message.Contains("retryInterval"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            ////}

            try
            {
                // And last, instantiate a policy description with invalid settings.
                new FixedIntervalData { RetryInterval = TimeSpan.FromMilliseconds(-2) };
                Assert.Fail("When the RetryInterval is negative, the retry policy should throw an exception.");
            }
            catch (ConfigurationErrorsException ex)
            {
                Assert.IsTrue(ex.Message.Contains("retryInterval"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }
        }

        [TestMethod]
        public void TestZeroRetryInterval()
        {
            RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("ZeroRetryInterval");

            int retryCount = 0;
            TimeSpan totalDelay;

            GeneralRetryPolicyTests.TestRetryPolicy(retryPolicy, out retryCount, out totalDelay);

            Assert.Equal<int>(3, retryCount, "The action was not retried using the expected amount of times");
        }

        [TestMethod]
        public void TestNegativeRetryIncrement()
        {
            ////RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("NegativeRetryIncrement");

            ////int retryCount = 0;
            ////TimeSpan totalDelay;

            ////GeneralRetryPolicyTests.TestRetryPolicy(retryPolicy, out retryCount, out totalDelay);

            ////Assert.Equal<int>(15, retryCount, "The action was not retried using the expected amount of times");
            ////Assert.Equal<double>(550, totalDelay.TotalMilliseconds, "The total delay between retries does not match the expected result");

            ////retryPolicy = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(new Incremental(3, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(-10)));

            ////GeneralRetryPolicyTests.TestRetryPolicy(retryPolicy, out retryCount, out totalDelay);

            ////Assert.Equal<int>(3, retryCount, "The action was not retried using the expected amount of times");
            ////Assert.Equal<double>(270, totalDelay.TotalMilliseconds, "The total delay between retries does not match the expected result");

            try
            {
                // And last, instantiate a policy description with invalid settings.
                new IncrementalData { RetryIncrement = TimeSpan.FromSeconds(-1) };
                Assert.Fail("When the RetryCount is negative, the retry policy should throw an exception.");
            }
            catch (ConfigurationErrorsException ex)
            {
                Assert.IsTrue(ex.Message.Contains("retryIncrement"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }
        }

        [TestMethod]
        public void TestNegativeMinBackoff()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(-1), TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(100));
                Assert.Fail("When the MinBackoff is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("minBackoff", ex.ParamName, String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }

            ////try
            ////{
            ////    // Second, attempt to instantiate a retry policy from configuration with invalid settings.
            ////    RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("NegativeMinBackoff");
            ////    Assert.Fail("When the MinBackoff is negative, the retry policy should throw an exception.");
            ////}
            ////catch (ConfigurationErrorsException ex)
            ////{
            ////    Assert.IsTrue(ex.Message.Contains("minBackoff"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            ////}

            try
            {
                // And last, instantiate a policy description with invalid settings.
                new ExponentialBackoffData { MinBackoff = TimeSpan.FromMilliseconds(-1) };
                Assert.Fail("When the MinBackoff is negative, the retry policy should throw an exception.");
            }
            catch (ConfigurationErrorsException ex)
            {
                Assert.IsTrue(ex.Message.Contains("minBackoff"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }
        }

        [TestMethod]
        public void TestNegativeMaxBackoff()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(-2), TimeSpan.FromMilliseconds(100));
                Assert.Fail("When the MaxBackoff is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("maxBackoff", ex.ParamName, String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }

            ////try
            ////{
            ////    // Second, attempt to instantiate a retry policy from configuration with invalid settings.
            ////    RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("NegativeMaxBackoff");
            ////    Assert.Fail("When the MaxBackoff is negative, the retry policy should throw an exception.");
            ////}
            ////catch (ConfigurationErrorsException ex)
            ////{
            ////    Assert.IsTrue(ex.Message.Contains("maxBackoff"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            ////}

            try
            {
                // And last, instantiate a policy description with invalid settings.
                new ExponentialBackoffData { MaxBackoff = TimeSpan.FromMilliseconds(-2) };
                Assert.Fail("When the MaxBackoff is negative, the retry policy should throw an exception.");
            }
            catch (ConfigurationErrorsException ex)
            {
                Assert.IsTrue(ex.Message.Contains("maxBackoff"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }
        }

        [TestMethod]
        public void TestNegativeDeltaBackoff()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
                Assert.Fail("When the DeltaBackoff is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("deltaBackoff", ex.ParamName, String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }

            ////try
            ////{
            ////    // Second, attempt to instantiate a retry policy from configuration with invalid settings.
            ////    RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("NegativeDeltaBackoff");
            ////    Assert.Fail("When the DeltaBackoff is negative, the retry policy should throw an exception.");
            ////}
            ////catch (ConfigurationErrorsException ex)
            ////{
            ////    Assert.IsTrue(ex.Message.Contains("deltaBackoff"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            ////}

            try
            {
                // And last, instantiate a policy description with invalid settings.
                new ExponentialBackoffData { DeltaBackoff = TimeSpan.FromMilliseconds(-1) };
                Assert.Fail("When the DeltaBackoff is negative, the retry policy should throw an exception.");
            }
            catch (ConfigurationErrorsException ex)
            {
                Assert.IsTrue(ex.Message.Contains("deltaBackoff"), String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }
        }

        [TestMethod]
        public void TestMinBackoffGreaterThanMax()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100));
                Assert.Fail("When the MinBackoff greater than MaxBackoff, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("minBackoff", ex.ParamName, String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            }

            ////try
            ////{
            ////    // Second, attempt to instantiate a retry policy from configuration with invalid settings.
            ////    RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("MinBackoffGreaterThanMax");
            ////    Assert.Fail("When the MinBackoff greater than MaxBackoff, the retry policy should throw an exception.");
            ////}
            ////catch (ArgumentOutOfRangeException ex)
            ////{
            ////    Assert.Equal("minBackoff", ex.ParamName, String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            ////}

            // this cannot be validated through config validators
            ////try
            ////{
            ////    // And last, instantiate a policy description with invalid settings.
            ////    new ExponentialBackoffData { MinBackoff = TimeSpan.FromMilliseconds(1000), MaxBackoff = TimeSpan.FromMilliseconds(100) };

            ////    Assert.Fail("When the MinBackoff greater than MaxBackoff, the retry policy should throw an exception.");
            ////}
            ////catch (ArgumentOutOfRangeException ex)
            ////{
            ////    Assert.Equal("minBackoff", ex.ParamName, String.Format("A wrong argument has caused the {0} exception", ex.GetType().Name));
            ////}
        }

        [TestMethod]
        public void TestLargeDeltaBackoff()
        {
            int retryCount = 0;
            TimeSpan totalDelay;

            try
            {
                // Second, attempt to instantiate a retry policy from configuration with invalid settings.
                RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("LargeDeltaBackoff");

                GeneralRetryPolicyTests.TestRetryPolicy(retryPolicy, out retryCount, out totalDelay);
                Assert.Equal<int>(3, retryCount, "The action was not retried using the expected amount of times");
            }
            catch
            {
                Assert.Fail("When the DeltaBackoff is very large, the retry policy should work normally.");
            }

            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy> retryPolicy = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(100000000000000));

                GeneralRetryPolicyTests.TestRetryPolicy(retryPolicy, out retryCount, out totalDelay);
                Assert.Equal<int>(3, retryCount, "The action was not retried using the expected amount of times");
            }
            catch
            {
                Assert.Fail("When the DeltaBackoff is very large, the retry policy should work normally.");
            }
        }

        [TestMethod]
        public void TestFixedInterval_MissingRetryInterval()
        {
            int retryCount = 0;
            TimeSpan totalDelay;

            RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("FixedInterval_MissingRetryInterval");
            GeneralRetryPolicyTests.TestRetryPolicy(retryPolicy, out retryCount, out totalDelay);

            Assert.Equal<int>(3, retryCount, "The action was not retried using the expected amount of times");
        }

        [TestMethod]
        public void TestIncrementalInterval_MissingRetryInterval()
        {
            int retryCount = 0;
            TimeSpan totalDelay;

            RetryPolicy retryPolicy = RetryPolicyFactory.GetRetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>("IncrementalInterval_MissingRetryInterval");
            GeneralRetryPolicyTests.TestRetryPolicy(retryPolicy, out retryCount, out totalDelay);

            Assert.Equal<int>(3, retryCount, "The action was not retried using the expected amount of times");
        }

        #region Private methods
        private static RetryStrategyData GetRetryPolicyFromConfig(string policyName)
        {
            RetryPolicyConfigurationSettings retryPolicySettings = RetryPolicyConfigurationSettings.GetRetryPolicySettings(new SystemConfigurationSource());
            RetryStrategyData retryPolicyInfo = retryPolicySettings.RetryStrategies.Get(policyName);

            Assert.IsNotNull(retryPolicyInfo, String.Format("The retry policy {0} was expected in the configuration but has not been found.", policyName));

            return retryPolicyInfo;
        }

        internal static void TestRetryPolicy(RetryPolicy retryPolicy, out int retryCount, out TimeSpan totalDelay)
        {
            int callbackCount = 0;
            double totalDelayInMs = 0;

            retryPolicy.Retrying += (sender, args) =>
            {
                callbackCount++;
                totalDelayInMs += args.Delay.TotalMilliseconds;
            };

            try
            {
                retryPolicy.ExecuteAction(() =>
                {
                    throw new TimeoutException("Forced Exception");
                });
            }
            catch (TimeoutException ex)
            {
                Assert.Equal("Forced Exception", ex.Message);
            }

            retryCount = callbackCount;
            totalDelay = TimeSpan.FromMilliseconds(totalDelayInMs);
        }
        #endregion
    }
}
