// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Error codes returned by the service.
    /// </summary>
    public partial struct ShareErrorCode
    {
        /// <summary> Overloading equality for ShareErrorCode==string </summary>
        public static bool operator ==(ShareErrorCode code, string value) => code.Equals(value);

        /// <summary> Overloading inequality for ShareErrorCode!=string </summary>
        public static bool operator !=(ShareErrorCode code, string value) => !(code == value);

        /// <summary> Overloading equality for string==ShareErrorCode </summary>
        public static bool operator ==(string value, ShareErrorCode code) => code.Equals(value);

        /// <summary> Overloading inequality for string!=ShareErrorCode </summary>
        public static bool operator !=(string value, ShareErrorCode code) => !(value == code);

        /// <summary> Implementing ShareErrorCode.Equals(string) </summary>
        public bool Equals(string value)
        {
            if (value == null)
                return false;
            return this.Equals(new ShareErrorCode(value));
        }
    }
}
