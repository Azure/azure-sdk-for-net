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
using System.IO;

namespace Microsoft.WindowsAzure.Common.Tracing.Log4Net
{
    /// <summary>
    /// Implementation for ICloudTracingInterceptor that works using log4net framework.
    /// </summary>
    public class Log4NetTracingInterceptor : ICloudTracingInterceptor
    {
        ILog logger;

        public Log4NetTracingInterceptor(string filePath = null)
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(filePath));
            }
            else
            {
                throw new FileNotFoundException(filePath);
            }
        }

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Configuration(string source, string name, string value)
        {
            logger.DebugFormat("Configuration: source={0}, name={1}, value={2}", source, name, value);
        }

        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            string parametersLog = ToLogString<string, object>(parameters);
            logger.DebugFormat("invocationId: {0}\r\ninstance: {1}\r\nmethod: {2}\r\nparameters: {3}", 
                invocationId, instance, method, parametersLog);
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            string requestAsString = request == null ? string.Empty : request.AsFormattedString();
            logger.DebugFormat("InvocationId: {0}\r\nRequest: {1}", invocationId, requestAsString);
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            string requestAsString = response == null ? string.Empty : response.AsFormattedString();
            logger.DebugFormat("InvocationId: {0}\r\nResponse: {1}", invocationId, requestAsString);
        }

        public void Error(string invocationId, System.Exception ex)
        {
            logger.Error("InvocationId: " + invocationId, ex);
        }

        public void Exit(string invocationId, object returnValue)
        {
            string returnValueAsString = returnValue == null ? string.Empty : returnValue.ToString();
            logger.Debug(string.Format("Exit with invocation id {0}, the return value is {1}", 
                invocationId,
                returnValueAsString));
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
