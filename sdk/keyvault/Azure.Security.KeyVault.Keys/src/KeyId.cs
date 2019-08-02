// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Keys
{
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal class KeyId
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public Uri KeyVaultUri { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string KeyName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string KeyVersion { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyVaultKeyId"></param>
        public KeyId(Uri keyVaultKeyId)
        {
            Check.NotNull(keyVaultKeyId, nameof(keyVaultKeyId));
            ParseId(keyVaultKeyId.ToString());
        }
        #endregion

        #region Public Functions

        #endregion

        #region private functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void ParseId(string id)
        {
            var idToParse = new Uri(id, UriKind.Absolute); ;

            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (idToParse.Segments.Length != 3 && idToParse.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", id, idToParse.Segments.Length));

            if (!string.Equals(idToParse.Segments[1], "keys" + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be 'keys/', found '{1}'", id, idToParse.Segments[1]));

            KeyVaultUri = new Uri($"{idToParse.Scheme}://{idToParse.Authority}");
            KeyName = idToParse.Segments[2].Trim('/');
            KeyVersion = (idToParse.Segments.Length == 4) ? idToParse.Segments[3].TrimEnd('/') : null;
        }
        #endregion
    }
}
