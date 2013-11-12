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

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using log4net;
using Microsoft.WindowsAzure;

namespace Microsoft.WindowsAzure.Common.Tracing.Log4Net
{
    /// <summary>
    /// Implementation for ICloudTracingInterceptor that works using log4net framework.
    /// </summary>
    public class Log4NetTracingInterceptor : ICloudTracingInterceptor
    {
        ILog logger;

        public Log4NetTracingInterceptor()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Configuration(string source, string name, string value)
        {
            throw new System.NotImplementedException();
        }

        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            string parametersLog = ToLogString<string, object>(parameters);
            logger.InfoFormat(@"invocationId: {0}\r\n
                                instance: {1}\r\n
                                method: {2}\r\n
                                parameters: {3}", invocationId, instance, method, parametersLog);
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            logger.Debug("Request Message:");
            logger.Debug(request);
            if (request.Content != null)
            {
                logger.Debug("Request Body");
                logger.Debug(request.Content.ReadAsStringAsync().Result);
            }

            logger.Debug("-----");
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            logger.Debug("Response Message:");
            logger.Debug(response);
            if (response.Content != null)
            {
                logger.Debug("Response Body");
                logger.Debug(response.Content.ReadAsStringAsync().Result);
            }
            logger.Debug("-----");
        }

        public void Error(string invocationId, System.Exception ex)
        {
            logger.Error(invocationId, ex);
        }

        public void Exit(string invocationId, object returnValue)
        {
            logger.Debug(string.Format("Exiting with invocation id {0}, the return value is logged in the next line", invocationId));
            logger.Debug(returnValue);
        }

        /// <summary>
        /// Converts given dictionary into a log string.
        /// </summary>
        /// <typeparam name="TKey">The dictionary key type</typeparam>
        /// <typeparam name="TValue">The dictionary value type</typeparam>
        /// <param name="dictionary">The dictionary collection object</param>
        /// <returns>The log string</returns>
        private string ToLogString<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray()) + "}";
        }
    }
}
