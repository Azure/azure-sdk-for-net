// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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