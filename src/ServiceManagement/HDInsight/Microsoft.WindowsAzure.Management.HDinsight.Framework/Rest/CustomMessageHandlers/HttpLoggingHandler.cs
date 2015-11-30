// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers
{
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// This is a logging handler that would log all http requests and responses.
    /// </summary>
    internal class HttpLoggingHandler : MessageProcessingHandler
    {
        private readonly ILogger logger;

        internal HttpLoggingHandler(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this.logger = logger;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", 
            MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogger.LogMessage(System.String,Microsoft.WindowsAzure.Management.HDInsight.Logging.Severity,Microsoft.WindowsAzure.Management.HDInsight.Logging.Verbosity)",
            Justification = "Not Needed"), 
         System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", 
            MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogger.LogMessage(System.String)", Justification = "Not localized.")]
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                this.logger.LogMessage(request.ToString(), Severity.Informational, Verbosity.Detailed);
                if (request.Content != null)
                {
                    this.logger.LogMessage(string.Format(CultureInfo.InvariantCulture, "Payload: {0} ", request.Content.ReadAsStringAsync().Result), Severity.Informational, Verbosity.Detailed);
                }
            }
            return request;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
            MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogger.LogMessage(System.String,Microsoft.WindowsAzure.Management.HDInsight.Logging.Severity,Microsoft.WindowsAzure.Management.HDInsight.Logging.Verbosity)", Justification = "Not needed"), 
        System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", 
            MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogger.LogMessage(System.String)", Justification = "Not localized.")]
        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            if (response != null)
            {
                this.logger.LogMessage(response.ToString(), Severity.Informational, Verbosity.Detailed);
                if (response.Content != null)
                {
                    this.logger.LogMessage(string.Format(CultureInfo.InvariantCulture, "Payload: {0} ", response.Content.ReadAsStringAsync().Result), Severity.Informational, Verbosity.Detailed);
                }
            }
            return response;
        }
    }
}
