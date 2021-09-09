// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    public class SignalROutputConverter
    {
        // We accept multiple output binding types and rely on them to determine rest api actions
        // But in non .NET language, it's not able to convert JObject to different types
        // So need a converter to accurate convert JObject to either SignalRMessage or SignalRGroupAction
        public object ConvertToSignalROutput(object input)
        {
            if (input.GetType() != typeof(JObject))
            {
                return input;
            }

            var jobject = input as JObject;

            if (jobject.TryToObject<SignalRMessage>(out var message))
            {
                return message;
            }

            if (jobject.TryToObject<SignalRGroupAction>(out var groupAction))
            {
                return groupAction;
            }

            throw new ArgumentException("Unable to convert JObject to valid output binding type, check parameters.");
        }
    }
}