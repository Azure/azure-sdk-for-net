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
    }
}