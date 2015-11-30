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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    internal class HttpClientAbstraction : DisposableObject, IHttpClientAbstraction
    {
        private const string ResponseLogFormat =
            " HTTP Request:\r\n  SDK Version: {8}\r\n          Uri: {0}\r\n       Method: {1}\r\n Content Type: {2}\r\n      Headers: {3}\r\n      Content:\r\n{4}\r\n\r\nHTTP Response:\r\n  Status Code: {5}\r\n      Headers: {6}\r\n      Content:\r\n{7}\r\n\r\n";

        private const string ExceptionLogFormat =
            " HTTP Request:\r\n  SDK Version: {6}\r\n          Uri: {0}\r\n       Method: {1}\r\n Content Type: {2}\r\n      Headers: {3}\r\n      Content:\r\n{4}\r\n\r\n    Exception:\r\n{5}\r\n\r\n";

        private const string BearerAuthenticationType = "Bearer";
        private const string AuthorizationHeader = "Authorization";

        private HttpClient client;
        private CancellationToken cancellationToken = CancellationToken.None;
        private readonly ILogger instanceLogger;

        internal static TimeSpan DefaultTimeout = new TimeSpan(0, 5, 0);
        private bool ignoreSslErrors = false;

        internal HttpClientAbstraction(HttpClient client, WebRequestHandler handler, bool ignoreSslErrors)
        {
            this.client = client;
            this.ignoreSslErrors = ignoreSslErrors;
            this.Timeout = DefaultTimeout;
            this.Method = HttpMethod.Get;
            handler.ServerCertificateValidationCallback += this.ServerCertificateValidationCallback;
            this.RequestHeaders = new Dictionary<string, string>();
            this.ContentType = HttpConstants.ApplicationXml;
            this.instanceLogger = new Logger();
        }

        internal HttpClientAbstraction(HttpClient client, IAbstractionContext context, WebRequestHandler handler, bool ignoreSslErrors)
            : this(client, handler, ignoreSslErrors)
        {
            if (context.Logger.IsNotNull())
            {
                this.instanceLogger = context.Logger;
            }
            this.cancellationToken = context.CancellationToken;
        }

        public TimeSpan Timeout { get; set; }

        public HttpMethod Method { get; set; }

        public Uri RequestUri { get; set; }

        private HttpContent content;

        public HttpContent Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
                if (value.IsNotNull())
                {
                    this.Content.LoadIntoBufferAsync().WaitForResult();
                }
            }
        }

        private string stringContent;

        public string StringContent 
        {
            get
            {
                if (this.stringContent.IsNullOrEmpty())
                {
                    if (this.Content.IsNotNull())
                    {
                        this.stringContent = this.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        this.stringContent = string.Empty;
                    }
                }
                return this.stringContent;
            }
        }

        private Stream streamContent;

        public Stream StreamContent
        {
            get
            {
                if (this.streamContent.IsNull())
                {
                    if (this.Content.IsNotNull())
                    {
                        this.streamContent = this.Content.ReadAsStreamAsync().Result;
                    }
                    else
                    {
                        this.streamContent = null;
                    }
                }
                return this.streamContent;
            }
        }

        public IDictionary<string, string> RequestHeaders { get; private set; }

        public string ContentType { get; set; }

        public async Task<IHttpResponseMessageAbstraction> SendAsync()
        {
            var requestMessage = new HttpRequestMessage();

            requestMessage.Method = this.Method;
            requestMessage.RequestUri = this.RequestUri;
            if (this.Method == HttpMethod.Post || this.Method == HttpMethod.Put)
            {
                requestMessage.Content = this.CopyContent();
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(this.ContentType);
            }
            requestMessage.Headers.Clear();
            foreach (KeyValuePair<string, string> header in this.RequestHeaders)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }
            this.client.Timeout = this.Timeout;

            DateTime start = DateTime.Now;
            try
            {
                var result = await this.client.SendAsync(requestMessage, this.cancellationToken);
                string content = null;
                if (result.Content.IsNotNull())
                {
                    content = result.Content.ReadAsStringAsync().WaitForResult();
                }
                var retval = new HttpResponseMessageAbstraction(result.StatusCode, new HttpResponseHeadersAbstraction(result.Headers), content);

                this.LogRequestResponseDetails(retval);
                return retval;
            }
            catch (Exception ex)
            {
                this.LogRequestException(ex);
                var tcex = ex as TaskCanceledException;
                if (tcex.IsNotNull())
                {
                    if (this.cancellationToken.IsCancellationRequested)
                    {
                        throw new OperationCanceledException("The operation was canceled at the users request.", tcex, this.cancellationToken);
                    }
                    else if (DateTime.Now - start > this.Timeout)
                    {
                        throw new TimeoutException(string.Format(CultureInfo.InvariantCulture, "The requested task failed to complete in the allotted time ({0}).", this.Timeout));
                    }
                }
                throw;
            }
        }

        private HttpContent CopyContent()
        {
            HttpContent localContent;
            if (this.Content is StringContent)
            {
                localContent = new StringContent(this.StringContent);
            }
            else
            {
                localContent = new StreamContent(this.StreamContent);
            }
            return localContent;
        }

        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.LogProviderExtensions.LogMessage(Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogProvider,System.String,Microsoft.WindowsAzure.Management.HDInsight.Logging.Severity,Microsoft.WindowsAzure.Management.HDInsight.Logging.Verbosity)",
            Justification = "Strictly log formatting string.")]
        private void LogRequestResponseDetails(HttpResponseMessageAbstraction response)
        {
            bool isFirst;
            var requestHeaders = this.GetFormatedRequestHeaders();

            isFirst = true;
            StringBuilder responseHeaders = new StringBuilder();
            var responseContentType = HttpConstants.ApplicationXml;
            foreach (var header in response.Headers)
            {
                if (!isFirst)
                {
                    responseHeaders.Append(string.Empty.PadLeft(15));
                }

                if (header.Key == HttpConstants.ContentTypeHeader && header.Value.IsNotNull())
                {
                    responseContentType = string.Join(",", header.Value);
                }

                responseHeaders.Append(header.Key);
                responseHeaders.Append(" = ");
                bool innerFirst = true;
                foreach (var value in header.Value)
                {
                    if (!innerFirst)
                    {
                        responseHeaders.Append(string.Empty.PadLeft(15 + header.Key.Length + 3));
                    }
                    responseHeaders.AppendLine(value);
                    innerFirst = false;
                }
                isFirst = false;
            }

            var formattedRequestContent = this.StringContent;
            if (this.ContentType == HttpConstants.ApplicationXml)
            {
                TryPrettyPrintXml(formattedRequestContent, out formattedRequestContent);
            }

            var formattedResponseContent = response.Content;
            if (responseContentType == HttpConstants.ApplicationXml)
            {
                TryPrettyPrintXml(formattedResponseContent, out formattedResponseContent);
            }

            string message = string.Format(CultureInfo.InvariantCulture,
                                           ResponseLogFormat,
                                           this.RequestUri,
                                           this.Method,
                                           this.ContentType,
                                           requestHeaders,
                                           formattedRequestContent,
                                           response.StatusCode,
                                           responseHeaders,
                                           formattedResponseContent,
                                           this.GetType().Assembly.GetName().Version);

            this.LogMessage(message, Severity.Informational, Verbosity.Detailed);
        }

        private StringBuilder GetFormatedRequestHeaders()
        {
            bool isFirst = true;
            StringBuilder requestHeaders = new StringBuilder();

            foreach (var header in this.RequestHeaders)
            {
                if (!isFirst)
                {
                    requestHeaders.Append(string.Empty.PadLeft(15));
                }
                requestHeaders.Append(header.Key);
                requestHeaders.Append(" = ");
                requestHeaders.AppendLine(header.Value);
                isFirst = false;
            }
            return requestHeaders;
        }

        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.LogProviderExtensions.LogMessage(Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogProvider,System.String,Microsoft.WindowsAzure.Management.HDInsight.Logging.Severity,Microsoft.WindowsAzure.Management.HDInsight.Logging.Verbosity)",
            Justification = "Strictly log formatting string.")]
        private void LogRequestException(Exception ex)
        {
            var requestHeaders = this.GetFormatedRequestHeaders();

            var formattedRequestContent = this.StringContent;
            if (this.ContentType == HttpConstants.ApplicationXml)
            {
                TryPrettyPrintXml(formattedRequestContent, out formattedRequestContent);
            }

            string message = string.Format(CultureInfo.InvariantCulture,
                                           ExceptionLogFormat,
                                           this.RequestUri,
                                           this.Method,
                                           this.ContentType,
                                           requestHeaders,
                                           formattedRequestContent,
                                           ex,
                                           this.GetType().Assembly.GetName().Version);

            this.LogMessage(message, Severity.Error, Verbosity.Normal);
        }

        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.LogProviderExtensions.LogMessage(Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogProvider,System.String,Microsoft.WindowsAzure.Management.HDInsight.Logging.Severity,Microsoft.WindowsAzure.Management.HDInsight.Logging.Verbosity)",
            Justification = "Logging line. [tgs]")]
        private bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            var msg = string.Format(CultureInfo.InvariantCulture, "Validating SSL with an ignore setting of ({0})", this.ignoreSslErrors);
            this.LogMessage(msg, Severity.Informational, Verbosity.Detailed);
            msg = string.Format(CultureInfo.InvariantCulture, "Current Result: ({0})", sslPolicyErrors.ToString());
            this.LogMessage(msg, Severity.Informational, Verbosity.Detailed);
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }
            return this.ignoreSslErrors;
        }

        public static IHttpClientAbstraction Create(X509Certificate2 cert, bool ignoreSslErrors)
        {
            var handler = new WebRequestHandler();
            handler.ClientCertificates.Add(cert);
            return Help.SafeCreate(() => new HttpClientAbstraction(Help.SafeCreate(() => new HttpClient(handler)), handler, ignoreSslErrors));
        }

        public static IHttpClientAbstraction Create(IAbstractionContext context, bool ignoreSslErrors)
        {
            var handler = new WebRequestHandler();
            return Help.SafeCreate(() => new HttpClientAbstraction(Help.SafeCreate(() => new HttpClient(handler)), context, handler, ignoreSslErrors));
        }

        public static IHttpClientAbstraction Create(X509Certificate2 cert, IAbstractionContext context, bool ignoreSslErrors)
        {
            var handler = new WebRequestHandler();
            handler.ClientCertificates.Add(cert);
            return Help.SafeCreate(() => new HttpClientAbstraction(Help.SafeCreate(() => new HttpClient(handler)), context, handler, ignoreSslErrors));
        }

        public static IHttpClientAbstraction Create(string accessToken, bool ignoreSslErrors)
        {
            var handler = new WebRequestHandler();
            var authorizationHeaderValue = string.Format(CultureInfo.InvariantCulture, "{0} {1}", BearerAuthenticationType, accessToken);
            var abstractClient = Help.SafeCreate(() => new HttpClientAbstraction(Help.SafeCreate(() => new HttpClient(handler)), handler, ignoreSslErrors));
            abstractClient.RequestHeaders.Add(AuthorizationHeader, authorizationHeaderValue);
            return abstractClient;
        }

        public static IHttpClientAbstraction Create(IAbstractionContext context)
        {
            return Create(context, false);
        }

        public static IHttpClientAbstraction Create()
        {
            return Create(false);
        }

        public static IHttpClientAbstraction Create(X509Certificate2 cert)
        {
            return Create(cert, false);
        }

        public static IHttpClientAbstraction Create(X509Certificate2 cert, IAbstractionContext context)
        {
            return Create(cert, context, false);
        }

        public static IHttpClientAbstraction Create(string accessToken)
        {
            return Create(accessToken, false);
        }

        public static IHttpClientAbstraction Create(string accessToken, IAbstractionContext context)
        {
            return Create(accessToken, context, false);
        }

        public static IHttpClientAbstraction Create(string accessToken, IAbstractionContext context, bool ignoreSslErrors)
        {
            var handler = new WebRequestHandler();
            var authorizationHeaderValue = string.Format(CultureInfo.InvariantCulture, "{0} {1}", BearerAuthenticationType, accessToken);
            var abstractClient = Help.SafeCreate(() => new HttpClientAbstraction(Help.SafeCreate(() => new HttpClient(handler)), context, handler, ignoreSslErrors));
            abstractClient.RequestHeaders.Add(AuthorizationHeader, authorizationHeaderValue);
            return abstractClient;
        }

        public static IHttpClientAbstraction Create(bool ignoreSslErrors)
        {
            var handler = new WebRequestHandler();
            var abstractClient = Help.SafeCreate(() => new HttpClientAbstraction(Help.SafeCreate(() => new HttpClient(handler)), handler, ignoreSslErrors));
            return abstractClient;
        }

        public static IHttpClientAbstraction Create(bool ignoreSslErrors, bool allowAutoRedirect)
        {
            var handler = new WebRequestHandler();
            handler.AllowAutoRedirect = allowAutoRedirect;
            var abstractClient = Help.SafeCreate(() => new HttpClientAbstraction(Help.SafeCreate(() => new HttpClient(handler)), handler, ignoreSslErrors));
            return abstractClient;
        }

        internal static bool TryPrettyPrintXml(string content, out string formattedXml)
        {
            formattedXml = content;
            if (content.IsNullOrEmpty())
            {
                return false;
            }

            try
            {
                var document = XDocument.Parse(content, LoadOptions.PreserveWhitespace);
                using (var memoryStream = new MemoryStream())
                {
                    var prettyPrinter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                    prettyPrinter.Formatting = Formatting.Indented;
                    document.Save(prettyPrinter);
                    prettyPrinter.Flush();
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    formattedXml = new StreamReader(memoryStream).ReadToEnd();
                    prettyPrinter.Close();
                }
            }
            catch (XmlException formatException)
            {
                // if the xml content is malformed because of errors, we don't want this function to throw.
                formatException.IsNotNull();
                return false;
            }

            return true;
        }

        public ILogger Logger
        {
            get { return this.instanceLogger; }
        }
    }
}
