// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.Management.Media
{
    /// <summary>
    /// Defines values for PredefinedStreamingPolicy.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    public struct PredefinedStreamingPolicy : System.IEquatable<PredefinedStreamingPolicy>
    {
        private PredefinedStreamingPolicy(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        /// <summary>
        /// Predefined Streaming Policy which supports download only
        /// </summary>
        public static readonly PredefinedStreamingPolicy DownloadOnly = "Predefined_DownloadOnly";

        /// <summary>
        /// Predefined Streaming Policy which supports clear streaming only
        /// </summary>
        public static readonly PredefinedStreamingPolicy ClearStreamingOnly = "Predefined_ClearStreamingOnly";

        /// <summary>
        /// Predefined Streaming Policy which supports download and clear
        /// streaming
        /// </summary>
        public static readonly PredefinedStreamingPolicy DownloadAndClearStreaming = "Predefined_DownloadAndClearStreaming";

        /// <summary>
        /// Predefined Streaming Policy which supports envelope encryption
        /// </summary>
        public static readonly PredefinedStreamingPolicy ClearKey = "Predefined_ClearKey";

        /// <summary>
        /// Predefined Streaming Policy which supports envelope and cenc
        /// encryption
        /// </summary>
        public static readonly PredefinedStreamingPolicy SecureStreaming = "Predefined_SecureStreaming";

        /// <summary>
        /// Predefined Streaming Policy which supports clear key, cenc and cbcs
        /// encryption
        /// </summary>
        public static readonly PredefinedStreamingPolicy SecureStreamingWithFairPlay = "Predefined_SecureStreamingWithFairPlay";


        /// <summary>
        /// Underlying value of enum PredefinedStreamingPolicy
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for PredefinedStreamingPolicy
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type PredefinedStreamingPolicy
        /// </summary>
        public bool Equals(PredefinedStreamingPolicy e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to PredefinedStreamingPolicy
        /// </summary>
        public static implicit operator PredefinedStreamingPolicy(string value)
        {
            return new PredefinedStreamingPolicy(value);
        }

        /// <summary>
        /// Implicit operator to convert PredefinedStreamingPolicy to string
        /// </summary>
        public static implicit operator string(PredefinedStreamingPolicy e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum PredefinedStreamingPolicy
        /// </summary>
        public static bool operator == (PredefinedStreamingPolicy e1, PredefinedStreamingPolicy e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum PredefinedStreamingPolicy
        /// </summary>
        public static bool operator != (PredefinedStreamingPolicy e1, PredefinedStreamingPolicy e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for PredefinedStreamingPolicy
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is PredefinedStreamingPolicy && Equals((PredefinedStreamingPolicy)obj);
        }

        /// <summary>
        /// Returns for hashCode PredefinedStreamingPolicy
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}
