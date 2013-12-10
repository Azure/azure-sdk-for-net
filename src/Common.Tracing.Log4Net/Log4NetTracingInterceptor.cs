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
using System.IO;
using System.Net.Http;
using log4net;

namespace Microsoft.WindowsAzure.Common.Tracing.Log4Net
{
    /// <summary>
    /// Implementation for ICloudTracingInterceptor that works using log4net framework.
    /// </summary>
    public class Log4NetTracingInterceptor : ICloudTracingInterceptor
    {
        private ILog _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetTracingInterceptor" /> class with configuration file.
        /// </summary>
        /// <param name="filePath">The configuration file absolute path.</param>
        public Log4NetTracingInterceptor(string filePath)
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(filePath));
            }
            else
            {
                throw new FileNotFoundException(filePath);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetTracingInterceptor" /> class without configuration file.
        /// </summary>
        public Log4NetTracingInterceptor() : this(null) { }

        /// <summary>
        /// Trace information.
        /// </summary>
        /// <param name="message">The information to trace.</param>
        public void Information(string message)
        {
            _logger.Info(message);
        }

        /// <summary>
        /// Probe configuration for the value of a setting.
        /// </summary>
        /// <param name="source">The configuration source.</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The value of the setting in the source.</param>
        public void Configuration(string source, string name, string value)
        {
            _logger.DebugFormat("Configuration: source={0}, name={1}, value={2}", source, name, value);
        }

        /// <summary>
        /// Enter a method.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="instance">The instance with the method.</param>
        /// <param name="method">Name of the method.</param>
        /// <param name="parameters">Method parameters.</param>
        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            _logger.DebugFormat(
                "invocationId: {0}\r\ninstance: {1}\r\nmethod: {2}\r\nparameters: {3}",
                invocationId, instance, method, parameters.AsFormattedString());
        }

        /// <summary>
        /// Send an HTTP request.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="request">The request about to be sent.</param>
        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            string requestAsString = request == null ? string.Empty : request.AsFormattedString();
            _logger.DebugFormat("invocationId: {0}\r\nrequest: {1}", invocationId, requestAsString);
        }

        /// <summary>
        /// Receive an HTTP response.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="response">The response instance.</param>
        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            string requestAsString = response == null ? string.Empty : response.AsFormattedString();
            _logger.DebugFormat("invocationId: {0}\r\nresponse: {1}", invocationId, requestAsString);
        }

        /// <summary>
        /// Raise an error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="exception">The error.</param>
        public void Error(string invocationId, Exception exception)
        {
            _logger.Error("invocationId: " + invocationId, exception);
        }

        /// <summary>
        /// Exit a method.  Note: Exit will not be called in the event of an
        /// error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="returnValue">Method return value.</param>
        public void Exit(string invocationId, object returnValue)
        {
            string returnValueAsString = returnValue == null ? string.Empty : returnValue.ToString();
            _logger.Debug(
                string.Format("Exit with invocation id {0}, the return value is {1}", 
                invocationId,
                returnValueAsString));
        }
    }
}
