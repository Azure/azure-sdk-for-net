// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Extension methods for <see cref="HttpMessage"/>.
    /// </summary>
    public static class HttpMessageExtensions
    {
        /// <summary>
        /// Sets the package name and version portion of the UserAgent telemetry value.
        /// Note: If <see cref="DiagnosticsOptions.IsTelemetryEnabled"/> is false, this value is never used.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/>.</param>
        /// <param name="userAgentString">The <see cref="SetUserAgentString"/>.</param>
        public static void SetUserAgentString(this HttpMessage message, UserAgentString userAgentString)
        {
            message.SetInternalProperty(userAgentString.GetType(), userAgentString);
        }
    }
}
