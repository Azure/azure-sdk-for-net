// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Template.Models
{
    /// <summary> Model factory that enables mocking of the Template client library. </summary>
    public static partial class TemplateModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="SecretBundle"/>. </summary>
        /// <param name="value"> The secret value. </param>
        /// <param name="id"> The secret id. </param>
        /// <param name="contentType"> The content type of the secret. </param>
        /// <param name="tags"> Application specific metadata in the form of key-value pairs. </param>
        /// <param name="kid"> If this is a secret backing a KV certificate, then this field specifies the corresponding key backing the KV certificate. </param>
        /// <param name="managed"> True if the secret's lifetime is managed by key vault. If this is a secret backing a certificate, then managed will be true. </param>
        /// <returns> A new <see cref="SecretBundle"/> instance for mocking. </returns>
        public static SecretBundle SecretBundle(string value = null, string id = null, string contentType = null, IReadOnlyDictionary<string, string> tags = null, string kid = null, bool? managed = null)
        {
            tags ??= new Dictionary<string, string>();

            return new SecretBundle(value, id, contentType, tags, kid, managed);
        }
    }
}