// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// Marks tests failing with specific service error codes as "inconclusive". Must be used with test fixtures derived
    /// from <see cref="RecordedTestBase"/> and is used only by tests attributed with <see cref="RecordedTestAttribute"/>.
    /// </summary>
    /// <remarks>
    /// This is intended for use with intermittent service issues that happen only during internal testing,
    /// or that are temporary issues causing test failures but will be fixed. Please engage with service teams
    /// before using this attribute to see if live test issues can be resolved first.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class IgnoreServiceErrorAttribute : Attribute
    {
        private readonly string _statusMessage;
        private readonly string _errorCodeMessage;

        /// <summary>
        /// Creates an instance of the <see cref="IgnoreServiceErrorAttribute"/> class.
        /// </summary>
        /// <param name="status">The HTTP status code to ignore e.g., 400.</param>
        /// <param name="errorCode">The Azure error code to ignore e.g., BadParameter.</param>
        /// <exception cref="ArgumentException"><paramref name="status"/> is &lt; 100 or &gt; 599, or <paramref name="errorCode"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="errorCode"/> is null.</exception>
        public IgnoreServiceErrorAttribute(int status, string errorCode)
        {
            Argument.AssertInRange(status, 100, 599, nameof(status));
            Argument.AssertNotNullOrEmpty(errorCode, nameof(errorCode));

            _statusMessage = $"Status: {status.ToString(CultureInfo.InvariantCulture)}";
            _errorCodeMessage = $"ErrorCode: {errorCode}";
        }

        /// <summary>
        /// Gets or sets a substring of the error message to ignore.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the reason this service error was ignored.
        /// The default is "Intermittent service error".
        /// </summary>
        public string Reason { get; set; } = "Intermittent service error";

        /// <summary>
        /// Determines whether the <paramref name="message"/> matches the current attribute.
        /// </summary>
        /// <param name="message">The message to match.</param>
        /// <returns>True if the <paramref name="message"/> matches the current attribute; otherwise, false.</returns>
        protected internal bool Matches(string message) =>
            !string.IsNullOrEmpty(message) &&
            message.Contains(_statusMessage) &&
            message.Contains(_errorCodeMessage) &&
            (string.IsNullOrWhiteSpace(Message) || message.Contains(Message));
    }
}
