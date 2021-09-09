// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRTriggerException : Exception
    {
        public SignalRTriggerException() : base()
        {
        }

        public SignalRTriggerException(string message) : base(message)
        {
        }
    }
}