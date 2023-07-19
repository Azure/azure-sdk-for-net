// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The base class of CustomContext SipHeader and VoipHeader.
    /// </summary>
    public abstract class CustomContextHeader
    {
        /// <summary>
        /// The CustomContext Key name.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// The CustomContext Key value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new CustomContextHeader
        /// </summary>
        protected CustomContextHeader(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
