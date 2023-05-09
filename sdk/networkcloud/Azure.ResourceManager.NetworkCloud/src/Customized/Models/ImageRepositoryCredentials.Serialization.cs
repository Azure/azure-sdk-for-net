// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class ImageRepositoryCredentials
    {
        internal static ImageRepositoryCredentials DeserializeImageRepositoryCredentials(JsonElement element)
        {
            string password = default;
            string registryUrl = default;
            string username = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("password"))
                {
                    password = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("registryUrl"))
                {
                    registryUrl = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("username"))
                {
                    username = property.Value.GetString();
                    continue;
                }
            }
            // WORKAROUND: server never sends password, default to password
            password = "password";
            return new ImageRepositoryCredentials(password, registryUrl, username);
        }
    }
}
