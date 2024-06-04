// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.PostgreSql.FlexibleServers;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.Provisioning.PostgreSql
{
    /// <summary>
    /// Represents a PostgreSql flexible server configuration.
    /// </summary>
    public class PostgreSqlFlexibleServerConfiguration : Resource<PostgreSqlFlexibleServerConfigurationData>
    {
        private const string ResourceTypeName = "Microsoft.DBforPostgreSQL/flexibleServers/configurations";
        private static PostgreSqlFlexibleServerConfigurationData Empty(string name)
            => ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlFlexibleServerConfigurationData();

        /// <summary>
        /// Creates a new instance of the <see cref="PostgreSqlFlexibleServerConfiguration"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="propertyName">The config property name.</param>
        /// <param name="propertyValue">The value.</param>
        /// <param name="propertySource">The source.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public PostgreSqlFlexibleServerConfiguration(
            IConstruct scope,
            string propertyName,
            string propertyValue,
            string propertySource = "user-override",
            PostgreSqlFlexibleServer? parent = null,
            string name = "config",
            string version = PostgreSqlFlexibleServer.DefaultVersion)
            : this(scope, parent, name, ResourceTypeName, version, (_) => ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlFlexibleServerConfigurationData(name: propertyName, value: propertyValue, source: propertySource))
        {
        }

        private PostgreSqlFlexibleServerConfiguration(
            IConstruct scope,
            Resource? parent,
            string resourceName,
            ResourceType resourceType,
            string version,
            Func<string, PostgreSqlFlexibleServerConfigurationData> createProperties,
            bool isExisting = false)
            : base(scope, parent, resourceName, resourceType, version, createProperties, isExisting)
        {
        }
    }
}
