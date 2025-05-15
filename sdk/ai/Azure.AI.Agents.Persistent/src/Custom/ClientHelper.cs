// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Agents.Persistent
{
    internal class ClientHelper
    {
        // Connection string format: <endpoint>;<subscription_id>;<resource_group_name>;<project_name>
        public static string ParseConnectionString(string connectionString, string resourceName)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            // Split the connection string by ';'
            var parts = connectionString.Split(';');
            if (parts.Length != 4)
            {
                throw new ArgumentException("Invalid connection string format. Expected format: <endpoint>;<subscription_id>;<resource_group_name>;<project_name>", nameof(connectionString));
            }

            switch (resourceName.ToLower())
            {
                case "endpoint":
                    return "https://" + parts[0];
                case "subscriptionid":
                    return parts[1];
                case "resourcegroupname":
                    return parts[2];
                case "projectname":
                    return parts[3];
                default:
                    throw new ArgumentException($"Invalid resource name: {resourceName}");
            }
        }
    }
}
