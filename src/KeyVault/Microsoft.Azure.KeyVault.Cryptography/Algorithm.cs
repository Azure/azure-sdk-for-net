// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Microsoft.Azure.KeyVault.Cryptography
{
    /// <summary>
    /// Abstract Algorithm.
    /// </summary>
    public abstract class Algorithm 
    {
        private readonly string _name;

        protected Algorithm( string name )
        {
            if ( string.IsNullOrEmpty( name ) )
                throw new ArgumentNullException( "name" );

            _name = name;
        }

        /// <summary>
        /// The name of the algorithm
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
    }
}
