// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRTriggerAuthorizeFailedException : SignalRTriggerException
    {
        public SignalRTriggerAuthorizeFailedException() : base("The request is unauthorized, please check the Signature.")
        {
        }
    }
}