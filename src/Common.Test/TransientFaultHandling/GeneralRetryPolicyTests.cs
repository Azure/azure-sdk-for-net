//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using Xunit;
using Hyak.Common.TransientFaultHandling;

namespace Microsoft.Azure.Common.Test.TransientFaultHandling
{
    /// <summary>
    /// Implements general test cases for retry policies.
    /// </summary>
    public class GeneralRetryPolicyTests
    {
        [Fact]
        public void TestNegativeRetryCount()
        {
            try
            {
                // First, instantiate a policy directly bypassing the configuration data validation.
                var retryPolicy = new RetryPolicy<DefaultHttpErrorDetectionStrategy>(-1);
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
                var retryPolicy = new RetryPolicy<DefaultHttpErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(-2));
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
                new RetryPolicy<DefaultHttpErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(-1), TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(100));
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
                new RetryPolicy<DefaultHttpErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(-2), TimeSpan.FromMilliseconds(100));
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
                new RetryPolicy<DefaultHttpErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
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
                new RetryPolicy<DefaultHttpErrorDetectionStrategy>(3, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100));
                Assert.True(false, "When the MinBackoff greater than MaxBackoff, the retry policy should throw an exception.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.Equal("minBackoff", ex.ParamName);
            }
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
    }
}
