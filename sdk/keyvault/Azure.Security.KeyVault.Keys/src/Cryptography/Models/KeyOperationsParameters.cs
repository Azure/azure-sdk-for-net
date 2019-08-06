// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography
{
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Azure.Security.KeyVault.Keys.Cryptography.ExtensionMethods;
    using Azure.Security.KeyVault.Keys;

    /// <summary>
    /// 
    /// </summary>
    internal class KeyOperationsParameters : Model
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string Algorithm { get; set; }

        public byte[] Value { get; set; }
        #endregion

        #region Constructor
        public KeyOperationsParameters(string algorithmNameOnWire, byte[] value)
        {
            Check.NotEmptyNotNull(algorithmNameOnWire, nameof(algorithmNameOnWire));
            Check.NotNull(value, nameof(value));

            //TODO: reverse lookup from on the wire name to enum
            Algorithm = algorithmNameOnWire;
            Value = value;
        }

        public KeyOperationsParameters(EncryptionAlgorithmKind algorithm, byte[] value)
        {
            Algorithm = algorithm.GetAttributeInfoForEnum<string, AlgorithmKindMetadataAttribute>((attrib) => attrib.AlgorithmNameOnWire);
            Value = value;
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
            if(!string.IsNullOrWhiteSpace(Algorithm))
            {
                json.WriteString(JsonEncodedText.Encode(@"alg"), Algorithm);
            }

            if(Value != null)
            {
                ReadOnlySpan<byte> rob = new ReadOnlySpan<byte>(Value);
                json.WriteBase64String(JsonEncodedText.Encode("value"), rob);
            }
        }
        #endregion
    }
}
