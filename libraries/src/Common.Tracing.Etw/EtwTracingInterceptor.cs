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
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

[assembly: CLSCompliant(true)]
namespace Microsoft.WindowsAzure.Common.Tracing.Etw
{
    /// <summary>
    /// Implementation for ICloudTracingInterceptor that raises ETW events.
    /// </summary>
    public class EtwTracingInterceptor : ICloudTracingInterceptor
    {
        public void Information(string message)
        {
            CloudTracingEventSource.Log.Information(message);
        }

        public void Configuration(string source, string name, string value)
        {
            CloudTracingEventSource.Log.Configuration(source, name, value);
        }

        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            instance = instance ?? string.Empty;
            string parametersLog = ToLogString<string, object>(parameters);

            CloudTracingEventSource.Log.Enter(invocationId, instance.ToString(), method, parametersLog);
        }

        public virtual void SendRequest(string invocationId, HttpRequestMessage request)
        {
            string requestBody = request == null ? string.Empty : request.ToString();
            if (request != null && request.Content != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Body:");
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine(request.Content.ReadAsStringAsync().Result);
                stringBuilder.AppendLine("}");
                requestBody += stringBuilder.ToString();
            }

            CloudTracingEventSource.Log.SendRequest(invocationId, requestBody);
        }

        public virtual void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            string responseBody = response == null ? string.Empty : response.ToString();
            if (response != null && response.Content != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Body:");
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine(response.Content.ReadAsStringAsync().Result);
                stringBuilder.AppendLine("}");
                responseBody += stringBuilder.ToString();
            }

            CloudTracingEventSource.Log.ReceiveResponse(invocationId, responseBody);
        }

        public void Error(string invocationId, Exception exception)
        {
            string exceptionBody = exception == null ? string.Empty : exception.ToString();

            CloudTracingEventSource.Log.Error(invocationId, exceptionBody);
        }

        public void Exit(string invocationId, object returnValue)
        {
            string returnValueAsString = returnValue == null ? string.Empty : returnValue.ToString();

            CloudTracingEventSource.Log.Exit(invocationId, returnValueAsString);
        }

        /// <summary>
        /// Converts given dictionary into a log string.
        /// </summary>
        /// <typeparam name="TKey">The dictionary key type</typeparam>
        /// <typeparam name="TValue">The dictionary value type</typeparam>
        /// <param name="dictionary">The dictionary collection object</param>
        /// <returns>The log string</returns>
        private static string ToLogString<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
                return "{}";
            else
                return "{" + string.Join(",", dictionary.Select(kv => kv.Key.ToString() + "=" + (kv.Value == null ? string.Empty : kv.Value.ToString())).ToArray()) + "}";
        }
    }
}
