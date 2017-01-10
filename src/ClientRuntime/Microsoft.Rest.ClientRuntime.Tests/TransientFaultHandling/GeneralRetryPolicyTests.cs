// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests.TransientFaultHandling
{
    /// <summary>
    ///     Implements general test cases for retry policies.
    /// </summary>
    public class GeneralRetryPolicyTests
    {
        [Fact]
        public void TestNegativeRetryCount()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(-1);
                Assert.True(false, "When the RetryCount is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("retryCount", ex.ParamName);
            }
        }

        [Fact]
        public void TestNegativeRetryInterval()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(-2));
                Assert.True(false, "When the RetryInterval is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("retryInterval", ex.ParamName);
            }
        }

        [Fact]
        public void TestNegativeMinBackoff()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(-1),
                    TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(100));
                Assert.True(false, "When the MinBackoff is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("minBackoff", ex.ParamName);
            }
        }

        [Fact]
        public void TestNegativeMaxBackoff()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(100),
                    TimeSpan.FromMilliseconds(-2), TimeSpan.FromMilliseconds(100));
                Assert.True(false, "When the MaxBackoff is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("maxBackoff", ex.ParamName);
            }
        }

        [Fact]
        public void TestNegativeDeltaBackoff()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(100),
                    TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
                Assert.True(false, "When the DeltaBackoff is negative, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("deltaBackoff", ex.ParamName);
            }
        }

        [Fact]
        public void TestMinBackoffGreaterThanMax()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(1000),
                    TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100));
                Assert.True(false,
                    "When the MinBackoff greater than MaxBackoff, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("minBackoff", ex.ParamName);
            }
        }

        internal static void TestRetryPolicy(RetryPolicy retryPolicy, out int retryCount, out TimeSpan totalDelay)
        {
            var callbackCount = 0;
            double totalDelayInMs = 0;

            retryPolicy.Retrying += (sender, args) =>
            {
                callbackCount++;
                totalDelayInMs += args.Delay.TotalMilliseconds;
            };

            try
            {
                retryPolicy.ExecuteAction(() => { throw new TimeoutException("Forced Exception"); });
            }
            catch (TimeoutException ex)
            {
                Assert.Equal("Forced Exception", ex.Message);
            }

            retryCount = callbackCount;
            totalDelay = TimeSpan.FromMilliseconds(totalDelayInMs);
        }
    }
}