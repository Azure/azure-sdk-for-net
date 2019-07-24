// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for all Algorithms used in the Key Vault .NET SDK
    /// </summary>
    public class Algorithm
    {
        #region const
        //const string ARG_ALGORITHM_NAME = "algorithName";
        #endregion

        #region fields

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for Type of Algorithm that needs to be instantiated
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        protected Algorithm(string algorithmName)
        {
            // TODO:
            // We should have an enum instead of a string.
            // Serves two purpose, we will have a supported list of algorithms users can instantiate
            // Secondly, rather than throwing at a later stage for non supported algorithm.
            // OR
            // Have a way to validate other than NullCheck on the type of algorithms we support

            if (string.IsNullOrWhiteSpace(algorithmName))
                throw new ArgumentNullException(nameof(algorithmName));

            Name = algorithmName.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmType"></param>
        protected Algorithm(AlgorithmInfo algorithmType)
        {

        }
        #endregion

        #region Public Functions
        public AlgorithmInfo GetAlgorithmType()
        {

        }
        #endregion

        #region private functions

        #endregion

    }
}
