//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using Newtonsoft.Json;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// The attributes of a secret managed by the KeyVault service
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SecretAttributes
    {
        public const string PropertyEnabled = "enabled";
        public const string PropertyNotBefore = "nbf";
        public const string PropertyExpires = "exp";
        public const string PropertyCreated = "created";
        public const string PropertyUpdated = "updated";

        #region UnixTime
        /// <summary>
        /// NotBefore date as the number of seconds since the Unix Epoch (1/1/1970)
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = PropertyNotBefore, Required = Required.Default)]
        private long? _notBeforeUnixTime { get; set; }

        /// <summary>
        /// Expiry date as the number of seconds since the Unix Epoch (1/1/1970)
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = PropertyExpires, Required = Required.Default)]
        private long? _expiresUnixTime { get; set; }

        /// <summary>
        /// Creation time as the number of seconds since the Unix Epoch (1/1/1970)
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = PropertyCreated, Required = Required.Default)]
        private long? _createdUnixTime { get; set; }

        /// <summary>
        /// Last updated time as the number of seconds since the Unix Epoch (1/1/1970)
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = PropertyUpdated, Required = Required.Default)]
        private long? _updatedUnixTime { get; set; }

        #endregion

        /// <summary>
        /// Determines whether the key is enabled
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = PropertyEnabled, Required = Required.Default)]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Not before date in UTC
        /// </summary>
        public DateTime? NotBefore
        {
            get
            {
                return FromUnixTime(_notBeforeUnixTime);
            }
            set
            {
                _notBeforeUnixTime = ToUnixTime(value);
            }
        }

        /// <summary>
        /// Expiry date in UTC
        /// </summary>
        public DateTime? Expires
        {
            get
            {
                return FromUnixTime(_expiresUnixTime);
            }
            set
            {
                _expiresUnixTime = ToUnixTime(value);
            }
        }

        /// <summary>
        /// Creation time in UTC
        /// </summary>
        public DateTime? Created
        {
            get
            {
                return FromUnixTime(_createdUnixTime);
            }
        }

        /// <summary>
        /// Last updated time in UTC
        /// </summary>
        public DateTime? Updated
        {
            get
            {
                return FromUnixTime(_updatedUnixTime);
            }
        }        

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <remarks>
        /// The defauts for the properties are:
        /// Enabled   = null
        /// NotBefore = null
        /// Expires   = null
        /// Created   = null
        /// Updated   = null
        /// </remarks>
        public SecretAttributes()
        {
            Enabled = null;
            NotBefore = null;
            Expires = null;            
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        private static DateTime? FromUnixTime(long? unixTime)
        {            
            if (unixTime.HasValue)
                return UnixEpoch.FromUnixTime((long)unixTime);
            else
                return null;
        }

        private static long? ToUnixTime(DateTime? value)
        {
            if (value.HasValue)
                return ((DateTime)value).ToUniversalTime().ToUnixTime();
            else
                return null;
        }
    }
}
