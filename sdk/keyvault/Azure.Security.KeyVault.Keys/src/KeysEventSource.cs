// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Text;
using Azure.Core.Diagnostics;

namespace Azure.Security.KeyVault.Keys
{
    [EventSource(Name = EventSourceName)]
    internal sealed class KeysEventSource : AzureEventSource
    {
        internal const int AlgorithmNotSupportedEvent = 1;
        internal const int KeyTypeNotSupportedEvent = 2;
        internal const int PrivateKeyRequiredEvent = 3;
        internal const int CryptographicExceptionEvent = 4;
        internal const int GetPermissionDeniedEvent = 5;

        private const string EventSourceName = "Azure-Security-KeyVault-Keys";

        private KeysEventSource() : base(EventSourceName) { }

        public static KeysEventSource Singleton { get; } = new KeysEventSource();

        [NonEvent]
        public void AlgorithmNotSupported<T>(string operation, T algorithm) where T : notnull
        {
            if (IsEnabled())
            {
                AlgorithmNotSupported(operation, algorithm.ToString());
            }
        }

        [Event(AlgorithmNotSupportedEvent, Level = EventLevel.Verbose, Message = "The algorithm {1} is not supported on this machine. Cannot perform the {0} operation locally.")]
        public void AlgorithmNotSupported(string operation, string algorithm) => WriteEvent(AlgorithmNotSupportedEvent, operation, algorithm);

        [NonEvent]
        public void KeyTypeNotSupported(string operation, KeyVaultKey key)
        {
            if (IsEnabled())
            {
                string keyType = "(null)";
                if (key != null)
                {
                    keyType = key.KeyType.ToString();
                }

                KeyTypeNotSupported(operation, keyType);
            }
        }

        [Event(KeyTypeNotSupportedEvent, Level = EventLevel.Verbose, Message = "The key type {1} is not supported on this machine. Cannot perform the {0} operation locally.")]
        public void KeyTypeNotSupported(string operation, string keyType) => WriteEvent(KeyTypeNotSupportedEvent, operation, keyType);

        [Event(PrivateKeyRequiredEvent, Level = EventLevel.Verbose, Message = "A private key is required for a {0} operation")]
        public void PrivateKeyRequired(string operation) => WriteEvent(PrivateKeyRequiredEvent, operation);

        [NonEvent]
        public void CryptographicException(string operation, Exception ex)
        {
            if (IsEnabled())
            {
                string message = FormatException(ex);
                CryptographicException(operation, message);
            }
        }

        [Event(CryptographicExceptionEvent, Level = EventLevel.Informational, Message = "A cryptographic exception occured: {1}.\r\nCannot perform the {0} operation locally.")]
        public void CryptographicException(string operation, string message) => WriteEvent(CryptographicExceptionEvent, operation, message);

        private static string FormatException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            bool nest = false;

            do
            {
                if (nest)
                {
                    // Format how Exception.ToString() would.
                    sb.AppendLine()
                      .Append(" ---> ");
                }

                // Do not include StackTrace, but do include HResult (often useful for CryptographicExceptions or IOExceptions).
                sb.Append(ex.GetType().FullName)
                  .Append(" (0x")
                  .Append(ex.HResult.ToString("x", CultureInfo.InvariantCulture))
                  .Append("): ")
                  .Append(ex.Message);

                ex = ex.InnerException;
                nest = true;
            }
            while (ex != null);

            return sb.ToString();
        }

        [Event(GetPermissionDeniedEvent, Level = EventLevel.Verbose, Message = "Permission denied to get key {1}. Cannot perform the {0} operation locally.")]
        public void GetPermissionDenied(string operation, string keyName) => WriteEvent(GetPermissionDeniedEvent, operation, keyName);
    }
}
