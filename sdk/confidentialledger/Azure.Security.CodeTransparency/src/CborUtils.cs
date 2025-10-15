// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Formats.Cbor;
using Azure.Core;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// Utility methods for reading simple string values from CBOR-encoded maps used within
    /// Signing Transparency receipts and responses. Methods are defensive: on invalid input, key
    /// absence, or unexpected CBOR shapes they return an empty string instead of throwing,
    /// allowing callers to decide whether absence is an error condition.
    /// </summary>
    public class CborUtils
    {
        /// <summary>
        /// Reads a CBOR-encoded map and returns the text string value associated with the specified key.
        /// </summary>
        /// <param name="cborBytes">The CBOR payload (byte array) whose root element is expected to be a map. Null or empty data returns empty string.</param>
        /// <param name="key">The map key whose associated text string value should be returned (case-sensitive comparison).</param>
        /// <returns>
        /// The string value associated with the key if present; otherwise an empty string if the key is absent,
        /// the value is not a text string, or the CBOR payload is invalid/not a map.
        /// </returns>
        public static string GetStringValueFromCborMapByKey(byte[] cborBytes, string key)
        {
            if (cborBytes == null || cborBytes.Length == 0 || string.IsNullOrEmpty(key))
                return string.Empty;

            string value = string.Empty;

            CborReader cborReader = new(cborBytes);
            cborReader.ReadStartMap();
            while (cborReader.PeekState() != CborReaderState.EndMap)
            {
                CborReaderState keyState = cborReader.PeekState();

                if (keyState != CborReaderState.TextString)
                {
                    // Non-text key: skip key and its value
                    cborReader.SkipValue();
                    cborReader.SkipValue();
                    continue;
                }

                string currentKey = cborReader.ReadTextString();
                if (string.Equals(currentKey, key, StringComparison.Ordinal))
                {
                    if (cborReader.PeekState() == CborReaderState.TextString)
                    {
                        value = cborReader.ReadTextString();
                    }
                    else
                    {
                        cborReader.SkipValue();
                    }
                    break;
                }
                else
                {
                    cborReader.SkipValue();
                }
            }

            return value;
        }

        /// <summary>
        /// Reads a CBOR-encoded map and returns the text string value associated with the specified integer key.
        /// </summary>
        /// <param name="cborBytes">The CBOR payload (byte array) whose root element is expected to be a map. Null or empty data returns empty string.</param>
        /// <param name="key">The integer map key whose associated text string value should be returned.</param>
        /// <returns>
        /// The string value associated with the key if present; otherwise an empty string if the key is absent,
        /// the value is not a text string, or the CBOR payload is invalid/not a map.
        /// </returns>
        public static string GetStringValueFromCborMapByKey(byte[] cborBytes, int key)
        {
            if (cborBytes == null || cborBytes.Length == 0)
                return string.Empty;

            string value = string.Empty;

            CborReader cborReader = new(cborBytes);
            cborReader.ReadStartMap();
            while (cborReader.PeekState() != CborReaderState.EndMap)
            {
                CborReaderState keyState = cborReader.PeekState();

                int? currentIntKey = null;
                switch (keyState)
                {
                    case CborReaderState.UnsignedInteger:
                    case CborReaderState.NegativeInteger:
                        currentIntKey = cborReader.ReadInt32();
                        break;
                    case CborReaderState.TextString:
                        // Different key type (string) - consume and skip its value
                        cborReader.ReadTextString();
                        cborReader.SkipValue();
                        continue;
                    default:
                        // Unsupported key type - skip key and its value
                        cborReader.SkipValue();
                        cborReader.SkipValue();
                        continue;
                }

                if (currentIntKey.HasValue && currentIntKey.Value == key)
                {
                    if (cborReader.PeekState() == CborReaderState.TextString)
                    {
                        value = cborReader.ReadTextString();
                    }
                    else
                    {
                        cborReader.SkipValue();
                    }
                    break;
                }
                else
                {
                    cborReader.SkipValue();
                }
            }

            return value;
        }
    }
}
