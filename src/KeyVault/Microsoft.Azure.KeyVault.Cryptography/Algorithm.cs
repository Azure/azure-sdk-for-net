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
