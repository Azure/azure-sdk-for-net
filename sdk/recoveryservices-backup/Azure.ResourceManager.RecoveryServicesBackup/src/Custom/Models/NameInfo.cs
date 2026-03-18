// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> The name of usage. </summary>
    public partial class NameInfo
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="NameInfo"/>. </summary>
        internal NameInfo()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NameInfo"/>. </summary>
        /// <param name="value"> Value of usage. </param>
        /// <param name="localizedValue"> Localized value of usage. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal NameInfo(string value, string localizedValue, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Value = value;
            LocalizedValue = localizedValue;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Value of usage. </summary>
        public string Value { get; }

        /// <summary> Localized value of usage. </summary>
        public string LocalizedValue { get; }
    }
}
