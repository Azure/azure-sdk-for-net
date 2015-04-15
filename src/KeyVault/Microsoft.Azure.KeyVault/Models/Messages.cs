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
using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.KeyVault.WebKey.Json;
using Newtonsoft.Json;

namespace Microsoft.Azure.KeyVault
{
    public static class MessagePropertyNames
    {
        public const string Algorithm    = "alg";
        public const string Attributes   = "attributes";        
        public const string Digest       = "digest";        
        public const string Hsm          = "hsm";
        public const string Key          = "key";
        public const string KeyOps       = "key_ops";
        public const string KeySize      = "key_size";
        public const string Kid          = "kid";
        public const string Kty          = "kty";        
        public const string Result       = "result";
        public const string Signature    = "signature";
        public const string Value        = "value";
        public const string Id           = "id";
        public const string NextLink     = "nextLink";
        public const string Tags = "tags";
        public const string ContentType = "contentType";
    }

    #region Error Response Messages

    [JsonObject]
    public class Error
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "code", Required = Required.Default)]
        public string Code { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "message", Required = Required.Default)]
        public string Message { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalInfo { get; set; }
    }

    [JsonObject]
    public class ErrorResponseMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = "error", Required = Required.Default)]
        public Error Error { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalInfo { get; set; }
    }

    #endregion

    #region Key Management   

    [JsonObject]
    public class BackupKeyResponseMessage
    {
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Always )]
        [JsonConverter(typeof(Base64UrlConverter))]
        public byte[] Value { get; set; }
    }

    [JsonObject]
    public class GetKeyResponseMessage
    {
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Key, Required = Required.Always )]
        public JsonWebKey Key { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Always )]
        public KeyAttributes Attributes { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Tags, Required = Required.Default)]
        public Dictionary<string, string> Tags { get; set; }
    }

    [JsonObject]
    public class CreateKeyRequestMessage
    {
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Kty, Required = Required.Always )]
        public string Kty { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.KeySize, Required = Required.Default )]
        public int? KeySize { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.KeyOps, Required = Required.Default )]
        public string[] KeyOps { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Default )]
        public KeyAttributes Attributes { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Tags, Required = Required.Default)]
        public Dictionary<string, string> Tags { get; set; }
    }

    [JsonObject]
    public class ImportKeyRequestMessage
    {
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Key, Required = Required.Always )]
        public JsonWebKey Key { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Hsm, Required = Required.Default )]
        public bool? Hsm { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Default )]
        public KeyAttributes Attributes { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Tags, Required = Required.Default)]
        public Dictionary<string, string> Tags { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class KeyItem
    {        
        private KeyIdentifier _identifier;
        public KeyIdentifier Identifier
        {
            get
            {
                return _identifier;
            }
        }

        private string _kid;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore,
            PropertyName = MessagePropertyNames.Kid, Required = Required.Always)]
        public string Kid
        {
            get
            {
                return _kid;
            }

            set
            {
                _kid = value;
                _identifier = !string.IsNullOrWhiteSpace(value) ? new KeyIdentifier(value) : null;
            }
        }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Always )]
        public KeyAttributes Attributes { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Tags, Required = Required.Default)]
        public Dictionary<string, string> Tags { get; set; }
    }

    [JsonObject]
    public class ListKeysResponseMessage
    {
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Include, NullValueHandling = NullValueHandling.Include, PropertyName = MessagePropertyNames.Value, Required = Required.Default )]
        public IEnumerable<KeyItem> Value { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Include, NullValueHandling = NullValueHandling.Include, PropertyName = MessagePropertyNames.NextLink, Required = Required.Default )]
        public string NextLink { get; set; }
    }

    [JsonObject]
    public class RestoreKeyRequestMessage
    {
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Always )]
        [JsonConverter(typeof(Base64UrlConverter))]
        public byte[] Value { get; set; }
    }
  
    [JsonObject]
    public class UpdateKeyRequestMessage
    {
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.KeyOps, Required = Required.Default )]
        public string[] KeyOps { get; set; }

        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Default )]
        public KeyAttributes Attributes { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Tags, Required = Required.Default)]
        public Dictionary<string, string> Tags { get; set; }
    }

    [JsonObject]
    public class DeleteKeyRequestMessage
    {
        // Since DELETE is a POST operation, it must have a body.
        // But so far there is no field.
    }

    #endregion

    #region Key Operations

    [JsonObject]
    public class KeyOpRequestMessage
    {
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Algorithm, Required = Required.Always )]
        public string Alg { get; set; }

        // Data to be encrypted.
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Always )]
        [JsonConverter(typeof(Base64UrlConverter))]
        public byte[] Value { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class KeyOpResponseMessage
    {

        private KeyIdentifier _identifier;
        public KeyIdentifier Identifier
        {
            get
            {
                return _identifier;
            }
        }

        private string _kid;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore,
            PropertyName = MessagePropertyNames.Kid, Required = Required.Always)]
        public string Kid
        {
            get
            {
                return _kid;
            }

            set
            {
                _kid = value;
                _identifier = new KeyIdentifier(value);
            }
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Default)]
        [JsonConverter(typeof(Base64UrlConverter))]
        public byte[] Value
        {
            get;
            set;
        }

    }

    [JsonObject]
    public class VerifyRequestMessage : KeyOpRequestMessage
    {
        // Digest to be verified, in Base64URL.
        [JsonProperty( DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Digest, Required = Required.Always )]
        [JsonConverter(typeof(Base64UrlConverter))]
        public byte[] Digest;
    }

    [JsonObject]
    public class VerifyResponseMessage
    {
        // true if signature was verified, false otherwise.
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Always)]
        public bool Value;       
    }

    #endregion

    #region Secret Messages    

    [JsonObject(MemberSerialization.OptIn)]
    public class SecretItem
    {
        private SecretIdentifier _identifier;
        public SecretIdentifier Identifier
        {
            get
            {
                return _identifier;
            }
        }

        private string _id;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore,
            PropertyName = MessagePropertyNames.Id, Required = Required.Always)]
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                _identifier = !string.IsNullOrWhiteSpace(value) ? new SecretIdentifier(value) : null;          
            }
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Always)]
        public SecretAttributes Attributes { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Tags, Required = Required.Default)]
        public Dictionary<string, string> Tags { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.ContentType, Required = Required.Default)]
        public string ContentType { get; set; }
    }

    [JsonObject]
    public class ListSecretsResponseMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include, NullValueHandling = NullValueHandling.Include, PropertyName = MessagePropertyNames.Value, Required = Required.Default)]
        public IEnumerable<SecretItem> Value { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include, NullValueHandling = NullValueHandling.Include, PropertyName = MessagePropertyNames.NextLink, Required = Required.Default)]
        public string NextLink { get; set; }
    }

    #endregion

}