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
        protected CryptographyClientOptions() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        public CryptographyClientOptions(ServiceVersion version = ServiceVersion.V7_0)
        {
            this.Version = version;
        }

        #endregion

        #region Public Functions

        #endregion

        #region private functions

        #endregion

    }
}
