// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    public class SignalRTriggerException : Exception
    {
        public SignalRTriggerException() : base()
        {
        }

        public SignalRTriggerException(string message) : base(message)
        {
        }

        public SignalRTriggerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}