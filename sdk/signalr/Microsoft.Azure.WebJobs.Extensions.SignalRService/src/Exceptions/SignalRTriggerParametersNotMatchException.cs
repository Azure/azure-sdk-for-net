// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRTriggerParametersNotMatchException : SignalRTriggerException
    {
        public SignalRTriggerParametersNotMatchException(int excepted, int actual) : base(
            $"The function accept {excepted} arguments but message provided {actual}.")
        {
        }

        public SignalRTriggerParametersNotMatchException()
        {
        }

        public SignalRTriggerParametersNotMatchException(string message) : base(message)
        {
        }

        public SignalRTriggerParametersNotMatchException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}