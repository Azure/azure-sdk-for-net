// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.Rest;
using System;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    internal static class TracingHelper
    {
        private static bool shouldTrace { get; set; }
        private static string invocationId { get; set; }
        static TracingHelper()
        {
            shouldTrace = ServiceClientTracing.IsEnabled;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
            }
        }

        internal static void LogInfo(string message, params object[] parameters)
        {
            if (shouldTrace)
            {
                ServiceClientTracing.Information(message, parameters);
            }
        }

        internal static void LogError(Exception ex)
        {
            if (shouldTrace)
            {
                ServiceClientTracing.Error(invocationId, ex);
            }
        }
    }
}
