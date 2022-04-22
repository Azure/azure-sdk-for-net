// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRTriggerAuthorizeFailedException : SignalRTriggerException
    {
        public SignalRTriggerAuthorizeFailedException() : base("The request is unauthorized, please check the Signature.")
        {
        }

        public SignalRTriggerAuthorizeFailedException(string message) : base(message)
        {
        }

        public SignalRTriggerAuthorizeFailedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}