// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Rest.TransientFaultHandling
{
    /// <summary>
    /// Defines a callback delegate that will be invoked whenever a retry condition is encountered.
    /// </summary>
    /// <param name="retryCount">The current retry attempt count.</param>
    /// <param name="lastException">The exception that caused the retry conditions to occur.</param>
    /// <returns>A retry condition instance</returns>
    public delegate RetryCondition ShouldRetryHandler(int retryCount, Exception lastException);

    /// <summary>
    /// Represents a retry strategy that determines the number of retry attempts and the interval 
    /// between retries.
    /// </summary>
    public abstract class RetryStrategy
    {
        /// <summary>
        /// Represents the default number of retry attempts.
        /// </summary>
        public static readonly int DefaultClientRetryCount = 10;

        /// <summary>
        /// Represents the default interval between retries.
        /// </summary>
        public static readonly TimeSpan DefaultRetryInterval = TimeSpan.FromSeconds(1.0);

        /// <summary>
        /// Represents the default flag indicating whether the first retry attempt will be made immediately,
        /// whereas subsequent retries will remain subject to the retry interval.
        /// </summary>
        public static readonly bool DefaultFirstFastRetry = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryStrategy"/> class. 
        /// </summary>
        /// <param name="name">The name of the retry strategy.</param>
        /// <param name="firstFastRetry">true to immediately retry in the first attempt; otherwise, false. 
        /// The subsequent retries will remain subject to the configured retry interval.</param>
        protected RetryStrategy(string name, bool firstFastRetry)
        {
            this.Name = name;
            this.FastFirstRetry = firstFastRetry;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the first retry attempt will be made immediately,
        /// whereas subsequent retries will remain subject to the retry interval.
        /// </summary>
        public bool FastFirstRetry { get; set; }

        /// <summary>
        /// Gets the name of the retry strategy.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Returns the corresponding ShouldRetry delegate.
        /// </summary>
        /// <returns>The ShouldRetry delegate.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "Getter not appropriate for returning new delegate instance for each call.")]
        public abstract ShouldRetryHandler GetShouldRetryHandler();
    }
}