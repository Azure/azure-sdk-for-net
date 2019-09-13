// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using System;
using System.Reflection;

namespace Azure.AI.InkRecognizer
{
    /// <summary>
    /// Options that allow to configure the request sent to the InkRecognizer service.
    /// </summary>
    public class InkRecognizerClientOptions : ClientOptions
    {
        /// <summary>
        /// InkRecognizer Service API version to use.
        /// </summary>
        public ServiceVersion Version { get; set; }

        /// <summary>
        /// The domain of the application (Writing or Drawing. The default is "Mixed").
        /// </summary>
        public ApplicationKind ApplicationKind { get; set; } = ApplicationKind.Mixed;

        /// <summary>
        /// IETF BCP 47 language code (for ex. en-US, en-GB, hi-IN etc.) for the strokes.
        /// </summary>
        public string Language { get; set; } = "en-US";

        /// <summary>
        /// A multiplier applied to the unit value to indicate the true unit being used.
        /// </summary>
        public float UnitMultiple { get; set; } = 1.0f;

        /// <summary>
        /// The physical unit for the points in the stroke.
        /// </summary>
        public InkPointUnit InkPointUnit { get; set; } = InkPointUnit.Mm;

        /// <summary>
        /// Creates a new instance of the <see cref="InkRecognizerClientOptions"/> that stores the configuration settings
        /// to use when communicating with the Ink Recognizer service.
        /// </summary>
        /// <param name="version">InkRecognizer Service API version to use.</param>
        public InkRecognizerClientOptions(ServiceVersion version = ServiceVersion.Preview_1_0_0)
        {
            Version = version;

            _createPolicies();
        }

        /// <summary>
        /// Supported API versions for InkRecognizer service.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// Preview 1.0.0
            /// </summary>
            Preview_1_0_0 = 0,
        }

        void _createPolicies()
        {
            RetryPolicy = new RetryPolicy()
            {
                Mode = RetryMode.Exponential,
                MaxDelay = TimeSpan.FromSeconds(0.8),
                MaxRetries = 3
            };

            LoggingPolicy = new LoggingPolicy();

            (var componentName, var componentVersion) = _getComponentNameAndVersion();
            var applicationId = Guid.NewGuid().ToString();
            var telemetryPolicy = new TelemetryPolicy(componentName, componentVersion)
            {
                ApplicationId = applicationId
            };
        }

        private (string ComponentName, string ComponentVersion) _getComponentNameAndVersion()
        {
            Assembly clientAssembly = GetType().Assembly;
            AzureSdkClientLibraryAttribute componentAttribute = clientAssembly.GetCustomAttribute<AzureSdkClientLibraryAttribute>();
            if (componentAttribute == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(AzureSdkClientLibraryAttribute)} is required to be set on client SDK assembly '{clientAssembly.FullName}'.");
            }

            return (componentAttribute.ComponentName, clientAssembly.GetName().Version.ToString());
        }
    }

    /// <summary>
    /// The ApplicationKind enum allows an application to identify its domain (when it has one).
    /// Specifying a domain allows the application to inform the service of its contents. This
    /// can facilitate faster processing as the service will skip some classification steps.
    /// Applications that don't have a specific domain can simply specify "MIXED"
    /// </summary>
    public enum ApplicationKind
    {
        /// <summary>
        /// Application has mixture of drawing and writing strokes
        /// </summary>
        Mixed = 0,

        /// <summary>
        /// Application will have only writing strokes
        /// </summary>
        Writing = 1,

        /// <summary>
        /// Application will have only drawing strokes
        /// </summary>
        Drawing = 2
    }

    /// <summary>
    /// The InkPointUnit is used to specified the physical unit of the ink points. If a value isn't
    /// specified, it is assumed that the points are in Millimeters
    /// </summary>
    public enum InkPointUnit
    {
        /// <summary>
        /// Millimeters
        /// </summary>
        Mm = 0,

        /// <summary>
        /// Centimeters
        /// </summary>
        Cm = 1,

        /// <summary>
        /// Inches
        /// </summary>
        Inch = 2
    }
}
