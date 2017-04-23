// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using log4net;

namespace Microsoft.Rest.Tracing.Log4Net
{
    /// <summary>
    /// Implementation for IServiceClientTracingInterceptor that works using log4net framework.
    /// </summary>
    public class Log4NetTracingInterceptor : IServiceClientTracingInterceptor
    {
        private ILog _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetTracingInterceptor" /> class with log4net logger.
        /// </summary>
        /// <param name="logger">log4net logger.</param>
        public Log4NetTracingInterceptor(ILog logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetTracingInterceptor" /> class with configuration file.
        /// </summary>
        /// <param name="filePath">The configuration file absolute path.</param>
        public Log4NetTracingInterceptor(string filePath)
            : this(LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType))
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(filePath));
                }
                else
                {
                    throw new FileNotFoundException(filePath);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetTracingInterceptor" /> class without configuration file.
        /// </summary>
        public Log4NetTracingInterceptor() : this(string.Empty)
        {
        }

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
            _logger.DebugFormat(CultureInfo.InvariantCulture,
                "Configuration: source={0}, name={1}, value={2}", source, name, value);
        }

        /// <summary>
        /// Enter a method.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="instance">The instance with the method.</param>
        /// <param name="method">Name of the method.</param>
        /// <param name="parameters">Method parameters.</param>
        public void EnterMethod(string invocationId, object instance, string method,
            IDictionary<string, object> parameters)
        {
            _logger.DebugFormat(CultureInfo.InvariantCulture,
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
            string requestAsString = (request == null ? string.Empty : request.AsFormattedString());
            _logger.DebugFormat(CultureInfo.InvariantCulture,
                "invocationId: {0}\r\nrequest: {1}", invocationId, requestAsString);
        }

        /// <summary>
        /// Receive an HTTP response.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="response">The response instance.</param>
        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            string requestAsString = (response == null ? string.Empty : response.AsFormattedString());
            _logger.DebugFormat(CultureInfo.InvariantCulture,
                "invocationId: {0}\r\nresponse: {1}", invocationId, requestAsString);
        }

        /// <summary>
        /// Raise an error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="exception">The error.</param>
        public void TraceError(string invocationId, Exception exception)
        {
            _logger.Error("invocationId: " + invocationId, exception);
        }

        /// <summary>
        /// Exit a method.  Note: Exit will not be called in the event of an
        /// error.
        /// </summary>
        /// <param name="invocationId">Method invocation identifier.</param>
        /// <param name="returnValue">Method return value.</param>
        public void ExitMethod(string invocationId, object returnValue)
        {
            string returnValueAsString = (returnValue == null ? string.Empty : returnValue.ToString());
            _logger.DebugFormat(CultureInfo.InvariantCulture,
                "Exit with invocation id {0}, the return value is {1}",
                invocationId,
                returnValueAsString);
        }
    }
}
