// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Client
{
    using Azure.Core;
    using Azure.Core.Pipeline;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class CryptographyClientOptions : ClientOptions
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool EnableLocalCryptographyOperations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool EnableServerCryptographyOperations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceVersion Version { get; }
        #endregion

        #region Enum
        /// <summary>
        /// 
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The Key Vault API Version 7.0
            /// </summary>
            V7_0 = 0x0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        protected CryptographyClientOptions()
        {
            this.Version = ServiceVersion.V7_0;
            EnableLocalCryptographyOperations = true;
            EnableServerCryptographyOperations = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        public CryptographyClientOptions(ServiceVersion version = ServiceVersion.V7_0) : this()
        {
            this.Version = version;
        }

        #endregion

        #region Public Functions
        internal string GetVersionString()
        {
            var version = string.Empty;

            switch (this.Version)
            {
                case ServiceVersion.V7_0:
                    version = "7.0";
                    break;

                default:
                    throw new ArgumentException(this.Version.ToString());
            }

            return version;
        }
        #endregion

        #region private functions

        #endregion

    }
}
