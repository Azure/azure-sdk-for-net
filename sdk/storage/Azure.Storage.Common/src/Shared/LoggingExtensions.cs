// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Web;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    internal static class LoggingExtensions
    {
        // The Azure.Core logging plan is still being settled, so we're adding
        // [Condtional] extensions we can implement later to light up logging
        // on par with the previous ILogger approach.

#pragma warning disable IDE0060 // Remove unused parameter
        public static IDisposable BeginLoggingScope(
            this HttpPipeline pipeline,
#pragma warning disable CA1801 // Review unused parameters
            string className,
            [CallerMemberName] string member = default)
#pragma warning restore CA1801 // Review unused parameters
            // Methods that return values can't be marked [Conditional], but
            // using statements will check for null before calling Dispose
            => null;
#pragma warning restore IDE0060 // Remove unused parameter

        [Conditional("EnableLoggingHelpers")]
        public static void LogMethodEnter(
            this HttpPipeline pipeline,
            string className,
            [CallerMemberName] string member = default,
            string message = default)
        => LogTrace(pipeline, $"ENTER METHOD {className} {member}\n{message}");

        [Conditional("EnableLoggingHelpers")]
        public static void LogMethodExit(
            this HttpPipeline pipeline,
            string className,
            [CallerMemberName] string member = default,
            string message = "")
        => LogTrace(pipeline, $"EXIT METHOD {className} {member}\n{message}");

        [Conditional("EnableLoggingHelpers")]
        public static void LogException(
            this HttpPipeline pipeline,
            Exception ex,
            string message = default)
        {
            // ExceptionDispatchInfo e =>
            //    if (e != default)
            //    {
            //        logger.LogError(e.SourceException, message);
            //        e.Throw();
            //    }
        }

        [Conditional("EnableLoggingHelpers")]
        public static void LogTrace(
            this HttpPipeline pipeline,
            string message = default)
        {
        }

        /*
        Temporarily removing unused code that depends on HttpUtility.ParseQueryString


        public static HttpRequestMessage Sanitize(this HttpRequestMessage httpRequest)
        {
            if (httpRequest == null)
            {
                return null;
            }

            var sanitizedRequest = new HttpRequestMessage
            {
                Content = httpRequest.Content,
                Method = httpRequest.Method,
                Version = httpRequest.Version,
            };

            foreach (var header in httpRequest.Headers)
            {
                // Redact Authorization header
                if (header.Key.Equals(Constants.Authorization, StringComparison.InvariantCulture))
                {
                    sanitizedRequest.Headers.Authorization = AuthenticationHeaderValue.Parse(Constants.Redacted);
                }
                else if(header.Key.Equals(Constants.CopySource, StringComparison.InvariantCulture))
                {
                    sanitizedRequest.Headers.Add(Constants.CopySource, new Uri(header.Value.First()).Sanitize().ToString());
                }
                else
                {
                    sanitizedRequest.Headers.Add(header.Key, header.Value);
                }
            }

            foreach (var property in httpRequest.Properties)
            {
                sanitizedRequest.Properties.Add(property);
            }

            // Redact SAS Signature, if necessary
            sanitizedRequest.RequestUri = httpRequest.RequestUri.Sanitize();

            return sanitizedRequest;
        }

        public static Uri Sanitize(this Uri uri)
        {
            if(uri?.Query == null)
            {
                return uri;
            }
            var parameters = HttpUtility.ParseQueryString(uri.Query);
            if (parameters[Constants.Sas.Parameters.Signature] != null)
            {
                parameters[Constants.Sas.Parameters.Signature] = Constants.Redacted;
            }

            var uriBuilder = new UriBuilder(uri)
            {
                Query = parameters.ToString()
            };
            return uriBuilder.Uri;
        }
        */
    }
}
