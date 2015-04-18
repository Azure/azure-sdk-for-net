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

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// Supported JsonWebKey Algorithms
    /// </summary>
    public static class JsonWebKeySignatureAlgorithm
    {
        public const string RS256   = "RS256";
        public const string RS384   = "RS384";
        public const string RS512   = "RS512";
        public const string RSNULL  = "RSNULL";

        /// <summary>
        /// All algorithms names. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllAlgorithms
        {
            get { return (string[])_allAlgorithms.Clone(); }
        }

        private static readonly string[] _allAlgorithms = { RS256, RS384, RS512, RSNULL };
    }
 }
