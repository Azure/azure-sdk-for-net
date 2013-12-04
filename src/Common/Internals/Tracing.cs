//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;

namespace Microsoft.WindowsAzure.Common.Internals
{
    public static class Tracing
    {
        private static long _nextInvocationId = 0;

        public static long NextInvocationId
        {
            get
            {
                // In the event of long.MaxValue requests, this will
                // automatically rollover
                return Interlocked.Increment(ref _nextInvocationId);             
            }
        }

        public static void Information(string message, params object[] parameters)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                Information(string.Format(CultureInfo.InvariantCulture, message, parameters));
            }
        }
        
        public static void Configuration(string source, string name, string value)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in CloudContext.Configuration.Tracing.TracingInterceptors)
                {
                    writer.Configuration(source, name, value);
                }
            }
        }

        public static void Information(string message)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in CloudContext.Configuration.Tracing.TracingInterceptors)
                {
                    writer.Information(message);
                }
            }
        }

        public static void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in CloudContext.Configuration.Tracing.TracingInterceptors)
                {
                    writer.Enter(invocationId, instance, method, parameters);
                }
            }
        }

        public static void SendRequest(string invocationId, HttpRequestMessage request)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in CloudContext.Configuration.Tracing.TracingInterceptors)
                {
                    writer.SendRequest(invocationId, request);
                }
            }
        }

        public static void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in CloudContext.Configuration.Tracing.TracingInterceptors)
                {
                    writer.ReceiveResponse(invocationId, response);
                }
            }
        }

        public static void Error(string invocationId, Exception ex)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in CloudContext.Configuration.Tracing.TracingInterceptors)
                {
                    writer.Error(invocationId, ex);
                }
            }
        }

        public static void Exit(string invocationId, object result)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                foreach (ICloudTracingInterceptor writer in CloudContext.Configuration.Tracing.TracingInterceptors)
                {
                    writer.Exit(invocationId, result);
                }
            }
        }
    }
}
