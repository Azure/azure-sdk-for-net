// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> Provides a compatibility shim for the IngestionSettingToken class. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class IngestionSettingToken
    {
        /// <summary> Initializes a new instance of <see cref="IngestionSettingToken"/>. </summary>
        public IngestionSettingToken()
        {
        }

        internal IngestionSettingToken(string token)
        {
            Token = token;
        }

        /// <summary> Gets or sets the token. </summary>
        public string Token { get; set; }
    }
}
