// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// A helper class to convert JObject to either <see cref="SignalRMessage"/> or <see cref="SignalRGroupAction"/>.
    /// </summary>
    public class SignalROutputConverter
    {
        /// <summary>
        /// We accept multiple output binding types and rely on them to determine rest api actions
        /// But in non .NET language, it's not able to convert JObject to different types
        /// So need a converter to accurate convert JObject to either SignalRMessage or SignalRGroupAction
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Breaking change")]
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