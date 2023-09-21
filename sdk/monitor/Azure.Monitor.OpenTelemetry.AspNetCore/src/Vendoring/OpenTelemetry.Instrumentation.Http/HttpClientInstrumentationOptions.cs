// <copyright file="HttpClientInstrumentationOptions.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
#if NETFRAMEWORK
using System.Net.Http;
#endif
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using OpenTelemetry.Instrumentation.Http.Implementation;
using static OpenTelemetry.Internal.HttpSemanticConventionHelper;

namespace OpenTelemetry.Instrumentation.Http
{
    /// <summary>
    /// Options for HttpClient instrumentation.
    /// </summary>
    internal class HttpClientInstrumentationOptions
    {
        internal readonly HttpSemanticConvention HttpSemanticConvention;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientInstrumentationOptions"/> class.
        /// </summary>
        public HttpClientInstrumentationOptions()
            : this(new ConfigurationBuilder().AddEnvironmentVariables().Build())
        {
        }

        internal HttpClientInstrumentationOptions(IConfiguration configuration)
        {
            Debug.Assert(configuration != null, "configuration was null");

            this.HttpSemanticConvention = GetSemanticConventionOptIn(configuration);
        }

        /// <summary>
        /// Gets or sets a filter function that determines whether or not to
        /// collect telemetry on a per request basis.
        /// </summary>
        /// <remarks>
        /// <para><b>FilterHttpRequestMessage is only executed on .NET and .NET
        /// Core runtimes. <see cref="HttpClient"/> and <see
        /// cref="HttpWebRequest"/> on .NET and .NET Core are both implemented
        /// using <see cref="HttpRequestMessage"/>.</b></para>
        /// Notes:
        /// <list type="bullet">
        /// <item>The return value for the filter function is interpreted as:
        /// <list type="bullet">
        /// <item>If filter returns <see langword="true" />, the request is
        /// collected.</item>
        /// <item>If filter returns <see langword="false" /> or throws an
        /// exception the request is NOT collected.</item>
        /// </list></item>
        /// </list>
        /// </remarks>
        public Func<HttpRequestMessage, bool> FilterHttpRequestMessage { get; set; }

        /// <summary>
        /// Gets or sets an action to enrich an <see cref="Activity"/> with <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <remarks>
        /// <para><b>EnrichWithHttpRequestMessage is only executed on .NET and .NET
        /// Core runtimes. <see cref="HttpClient"/> and <see
        /// cref="HttpWebRequest"/> on .NET and .NET Core are both implemented
        /// using <see cref="HttpRequestMessage"/>.</b></para>
        /// </remarks>
        public Action<Activity, HttpRequestMessage> EnrichWithHttpRequestMessage { get; set; }

        /// <summary>
        /// Gets or sets an action to enrich an <see cref="Activity"/> with <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <remarks>
        /// <para><b>EnrichWithHttpResponseMessage is only executed on .NET and .NET
        /// Core runtimes. <see cref="HttpClient"/> and <see
        /// cref="HttpWebRequest"/> on .NET and .NET Core are both implemented
        /// using <see cref="HttpRequestMessage"/>.</b></para>
        /// </remarks>
        public Action<Activity, HttpResponseMessage> EnrichWithHttpResponseMessage { get; set; }

        /// <summary>
        /// Gets or sets an action to enrich an <see cref="Activity"/> with <see cref="Exception"/>.
        /// </summary>
        /// <remarks>
        /// <para><b>EnrichWithException is called for all runtimes.</b></para>
        /// </remarks>
        public Action<Activity, Exception> EnrichWithException { get; set; }

        /// <summary>
        /// Gets or sets a filter function that determines whether or not to
        /// collect telemetry on a per request basis.
        /// </summary>
        /// <remarks>
        /// <para><b>FilterHttpWebRequest is only executed on .NET Framework
        /// runtimes. <see cref="HttpClient"/> and <see cref="HttpWebRequest"/>
        /// on .NET Framework are both implemented using <see
        /// cref="HttpWebRequest"/>.</b></para>
        /// Notes:
        /// <list type="bullet">
        /// <item>The return value for the filter function is interpreted as:
        /// <list type="bullet">
        /// <item>If filter returns <see langword="true" />, the request is
        /// collected.</item>
        /// <item>If filter returns <see langword="false" /> or throws an
        /// exception the request is NOT collected.</item>
        /// </list></item>
        /// </list>
        /// </remarks>
        public Func<HttpWebRequest, bool> FilterHttpWebRequest { get; set; }

        /// <summary>
        /// Gets or sets an action to enrich an <see cref="Activity"/> with <see cref="HttpWebRequest"/>.
        /// </summary>
        /// <remarks>
        /// <para><b>EnrichWithHttpWebRequest is only executed on .NET Framework
        /// runtimes. <see cref="HttpClient"/> and <see cref="HttpWebRequest"/>
        /// on .NET Framework are both implemented using <see
        /// cref="HttpWebRequest"/>.</b></para>
        /// </remarks>
        public Action<Activity, HttpWebRequest> EnrichWithHttpWebRequest { get; set; }

        /// <summary>
        /// Gets or sets an action to enrich an <see cref="Activity"/> with <see cref="HttpWebResponse"/>.
        /// </summary>
        /// <remarks>
        /// <para><b>EnrichWithHttpWebResponse is only executed on .NET Framework
        /// runtimes. <see cref="HttpClient"/> and <see cref="HttpWebRequest"/>
        /// on .NET Framework are both implemented using <see
        /// cref="HttpWebRequest"/>.</b></para>
        /// </remarks>
        public Action<Activity, HttpWebResponse> EnrichWithHttpWebResponse { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether exception will be recorded
        /// as an <see cref="ActivityEvent"/> or not. Default value: <see
        /// langword="false"/>.
        /// </summary>
        /// <remarks>
        /// <para><b>RecordException is supported on all runtimes.</b></para>
        /// <para>For specification details see: <see
        /// href="https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/exceptions.md"
        /// />.</para>
        /// </remarks>
        public bool RecordException { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool EventFilterHttpRequestMessage(string activityName, object arg1)
        {
            try
            {
                return
                    this.FilterHttpRequestMessage == null ||
                    !TryParseHttpRequestMessage(activityName, arg1, out HttpRequestMessage requestMessage) ||
                    this.FilterHttpRequestMessage(requestMessage);
            }
            catch (Exception ex)
            {
                HttpInstrumentationEventSource.Log.RequestFilterException(ex);
                return false;
            }
        }

        internal bool EventFilterHttpWebRequest(HttpWebRequest request)
        {
            try
            {
                return this.FilterHttpWebRequest?.Invoke(request) ?? true;
            }
            catch (Exception ex)
            {
                HttpInstrumentationEventSource.Log.RequestFilterException(ex);
                return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryParseHttpRequestMessage(string activityName, object arg1, out HttpRequestMessage requestMessage)
        {
            return (requestMessage = arg1 as HttpRequestMessage) != null && activityName == "System.Net.Http.HttpRequestOut";
        }
    }
}
