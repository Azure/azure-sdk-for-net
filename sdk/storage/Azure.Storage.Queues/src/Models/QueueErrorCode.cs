// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueErrorCode.
    /// </summary>
    [CodeGenModel("StorageErrorCode")]
    public readonly partial struct QueueErrorCode
    {
        /// <summary> Overloading equality for QueueErrorCode==string </summary>
        public static bool operator ==(QueueErrorCode code, string value) => code.Equals(value);

        /// <summary> Overloading inequality for QueueErrorCode!=string </summary>
        public static bool operator !=(QueueErrorCode code, string value) => !(code == value);

        /// <summary> Overloading equality for string==QueueErrorCode </summary>
        public static bool operator ==(string value, QueueErrorCode code) => code.Equals(value);

        /// <summary> Overloading inequality for string!=QueueErrorCode </summary>
        public static bool operator !=(string value, QueueErrorCode code) => !(value == code);

        /// <summary> Implementing QueueErrorCode.Equals(string) </summary>
        public bool Equals(string value)
        {
            if (value == null)
                return false;
            return this.Equals(new QueueErrorCode(value));
        }
    }
}
