// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Error Message
    /// </summary>
    public class ErrorMessage
    {
        /// <summary>
        /// Error Code of Message
        /// </summary>
        public ErrorCodes ErrorCode { get; set; }

        /// <summary>
        /// Previous Message ID
        /// </summary>
        public byte PrevMessageID { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Time of Error
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// Correlation ID
        /// </summary>
        public uint CorrelationID { get; set; }

        /// <summary>
        /// Override Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj is ErrorMessage errorMessage)
            {
                return ErrorCode == errorMessage.ErrorCode &&
                   PrevMessageID == errorMessage.PrevMessageID &&
                   string.Equals(Message, errorMessage.Message, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(TimeStamp, errorMessage.TimeStamp, StringComparison.OrdinalIgnoreCase) &&
                   CorrelationID == errorMessage.CorrelationID;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method for ErrorMessage
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(ErrorCode,
                                    PrevMessageID,
                                    Message ?? string.Empty,
                                    TimeStamp,
                                    CorrelationID);
        }
    }
}
