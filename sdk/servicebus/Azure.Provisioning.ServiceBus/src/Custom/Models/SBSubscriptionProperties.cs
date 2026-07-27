// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.ServiceBus;

internal partial class SBSubscriptionProperties
{
    // Service Bus ARM duration fields require ISO 8601 values, while the TypeSpec provisioning
    // generator currently omits the format metadata and would otherwise emit TimeSpan.ToString().
    partial void DefineAdditionalProperties()
    {
        _lockDuration = DefineProperty<TimeSpan>(nameof(LockDuration), new string[] { "lockDuration" }, format: "P");
        _defaultMessageTimeToLive = DefineProperty<TimeSpan>(nameof(DefaultMessageTimeToLive), new string[] { "defaultMessageTimeToLive" }, format: "P");
        _duplicateDetectionHistoryTimeWindow = DefineProperty<TimeSpan>(nameof(DuplicateDetectionHistoryTimeWindow), new string[] { "duplicateDetectionHistoryTimeWindow" }, format: "P");
        _autoDeleteOnIdle = DefineProperty<TimeSpan>(nameof(AutoDeleteOnIdle), new string[] { "autoDeleteOnIdle" }, format: "P");
    }
}
