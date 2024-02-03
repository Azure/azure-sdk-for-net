﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core
{
    /// <summary>
    ///  The set of options that can be specified to influence how
    ///  retry attempts are made, and a failure is eligible to be retried.
    /// </summary>
    public class RetryOptions
    {
        internal const int DefaultMaxRetries = 3;
        internal static readonly TimeSpan DefaultMaxDelay = TimeSpan.FromMinutes(1);
        internal static readonly TimeSpan DefaultInitialDelay = TimeSpan.FromSeconds(0.8);

        private int _maxRetries = DefaultMaxRetries;
        private TimeSpan _delay = DefaultInitialDelay;
        private TimeSpan _maxDelay = DefaultMaxDelay;
        private RetryMode _retryMode = RetryMode.Exponential;
        private TimeSpan _networkTimeout = ClientOptions.DefaultNetworkTimeout;

        private bool _frozen;

        /// <summary>
        /// Creates a new <see cref="RetryOptions"/> instance with default values.
        /// </summary>
        internal RetryOptions()
        {
        }

        /// <summary>
        /// Initializes the newly created <see cref="RetryOptions"/> with the same settings as the specified <paramref name="retryOptions"/>.
        /// </summary>
        /// <param name="retryOptions">The <see cref="RetryOptions"/> to model the newly created instance on.</param>
        internal RetryOptions(RetryOptions? retryOptions)
        {
            if (retryOptions != null)
            {
                MaxRetries = retryOptions.MaxRetries;
                Delay = retryOptions.Delay;
                MaxDelay = retryOptions.MaxDelay;
                Mode = retryOptions.Mode;
                NetworkTimeout = retryOptions.NetworkTimeout;
            }
        }

        /// <summary>
        /// The maximum number of retry attempts before giving up.
        /// </summary>
        public int MaxRetries
        {
            get => _maxRetries;
            set
            {
                AssertNotFrozen();

                _maxRetries = value;
            }
        }

        /// <summary>
        /// The delay between retry attempts for a fixed approach or the delay
        /// on which to base calculations for a backoff-based approach.
        /// If the service provides a Retry-After response header, the next retry will be delayed by the duration specified by the header value.
        /// </summary>
        public TimeSpan Delay
        {
            get => _delay;
            set
            {
                AssertNotFrozen();

                _delay = value;
            }
        }

        /// <summary>
        /// The maximum permissible delay between retry attempts when the service does not provide a Retry-After response header.
        /// If the service provides a Retry-After response header, the next retry will be delayed by the duration specified by the header value.
        /// </summary>
        public TimeSpan MaxDelay
        {
            get => _maxDelay;
            set
            {
                AssertNotFrozen();

                _maxDelay = value;
            }
        }

        /// <summary>
        /// The approach to use for calculating retry delays.
        /// </summary>
        public RetryMode Mode
        {
            get => _retryMode;
            set
            {
                AssertNotFrozen();

                _retryMode = value;
            }
        }

        /// <summary>
        /// The timeout applied to an individual network operations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimeSpan NetworkTimeout
        {
            get => _networkTimeout;
            set
            {
                AssertNotFrozen();

                _networkTimeout = value;
            }
        }

        internal void Freeze() => _frozen = true;

        private void AssertNotFrozen()
        {
            if (_frozen)
            {
                throw new InvalidOperationException("Cannot change a ClientOptions instance after it has been used to create a client.");
            }
        }
    }
}
