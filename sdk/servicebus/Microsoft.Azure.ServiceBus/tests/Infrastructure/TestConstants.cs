﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;

    static class TestConstants
    {
        // Enviornment Variables
        internal const string ConnectionStringEnvironmentVariable = "AZ_SERVICE_BUS_CONNECTION";
        
        // General 
        internal const string SessionPrefix = "session";
        internal const int MaxAttemptsCount = 5;
        internal readonly static TimeSpan WaitTimeBetweenAttempts = TimeSpan.FromSeconds(1);

        // Retry Policy Defaults
        internal const int RetryMaxAttempts = 5;
        internal const double RetryExponentialBackoffSeconds = 1.0;
        internal const double RetryBaseJitterSeconds = 3.0;

        // Queue Property Defaults
        internal const int QueueDefaultMaxSizeMegabytes = 1024;
        internal static readonly TimeSpan QueueDefaultMessageTimeToLive = TimeSpan.FromDays(10675199);
        internal static readonly TimeSpan QueueDefaultLockDuration = TimeSpan.FromMinutes(1);
        internal static readonly TimeSpan QueueDefaultDeuplicateDetectionHistory = TimeSpan.FromMinutes(10);
        
        // Topic Property Defaults
        internal const int TopicDefaultMaxSizeMegabytes = 1024;
        internal static readonly TimeSpan TopicDefaultMessageTimeToLive = TimeSpan.FromDays(10675199);
        internal static readonly TimeSpan TopicDefaultDeuplicateDetectionHistory = TimeSpan.FromMinutes(10);
        
        // Subscription Property Defaults
        internal const string SubscriptionName = "subscription";
        internal const string SessionSubscriptionName = "session-subscription";
        internal const int SubscriptionMaximumDeliveryCount = 10;
        internal const bool SubscriptionDefaultDeadLetterOnExpire = false;
        internal const bool SubscriptionDefaultDeadLetterOnException = true;        
        internal static readonly TimeSpan SubscriptionDefaultMessageTimeToLive = TimeSpan.FromDays(10675199);
        internal static readonly TimeSpan SubscriptionDefaultLockDuration = TimeSpan.FromMinutes(1);
    }
}