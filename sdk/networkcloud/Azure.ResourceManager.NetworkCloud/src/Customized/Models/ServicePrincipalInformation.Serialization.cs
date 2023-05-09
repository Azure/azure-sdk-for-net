// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class ServicePrincipalInformation
    {
        internal static ServicePrincipalInformation DeserializeServicePrincipalInformation(JsonElement element)
        {
            string applicationId = default;
            string password = default;
            string principalId = default;
            Guid tenantId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("applicationId"))
                {
                    applicationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("password"))
                {
                    password = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("principalId"))
                {
                    principalId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tenantId"))
                {
                    tenantId = property.Value.GetGuid();
                    continue;
                }
            }
            // WORKAROUND: server never sends password, default to password
            password = "password";
            return new ServicePrincipalInformation(applicationId, password, principalId, tenantId);
        }
    }
}
