// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Models
{
    using Azure.Security.KeyVault.Keys;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal class KeyOperationResult : Model
    {

        #region fields

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string Kid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Result { get; set; }
        #endregion

        #region Constructor
        public KeyOperationResult() { }
        public KeyOperationResult(string kid, byte[] result)
        {
            Kid = kid;
            Result = result;
        }
        #endregion

        #region Public Functions

        #endregion

        #region private functions
        internal override void ReadProperties(JsonElement json)
        {
            throw new NotImplementedException();
        }

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(JsonEncodedText.Encode(@"kid"), Kid);

            ReadOnlySpan<byte> rob = new ReadOnlySpan<byte>(Result);
            json.WriteBase64String(JsonEncodedText.Encode(@"value"), rob);
        }
        #endregion
    }
}
