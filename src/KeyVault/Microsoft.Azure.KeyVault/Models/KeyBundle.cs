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

using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.Azure.KeyVault.WebKey;
using Newtonsoft.Json;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// A KeyBundle consisting of a WebKey plus its Attributes
    /// </summary>
    [DataContract()]
    public class KeyBundle
    {
        internal const string Property_Key        = "key";
        internal const string Property_Attributes = "attributes";
        internal const string Property_Tags = "tags";
        
        public KeyIdentifier KeyIdentifier
        {
            get
            {          
                if (Key != null && !string.IsNullOrWhiteSpace(Key.Kid))
                    return new KeyIdentifier(Key.Kid);
                else                
                    return null;                
            }
        }

        /// <summary>
        /// The Json web key 
        /// </summary>        
        [DataMember(Name = Property_Key)]
        public JsonWebKey Key { get; set; }

        /// <summary>
        /// The key management attributes
        /// </summary>
        [DataMember( Name = Property_Attributes, IsRequired = false, EmitDefaultValue = false )]
        public KeyAttributes Attributes { get; set; }

        /// <summary>
        /// The tags for the secret
        /// </summary>
        [DataMember(Name = Property_Tags, IsRequired = false, EmitDefaultValue = false)]
        public Dictionary<string, string> Tags { get; set; } 

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyBundle()
        {
            Key        = new JsonWebKey();
            Attributes = new KeyAttributes();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject( this );
        }
    }
}
