// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace Azure.Provisioning.Resources
{
    /// <summary>
    /// DeploymentScript resource.
    /// </summary>
    public class DeploymentScript : Resource<AzureCliScript>
    {
        // https://learn.microsoft.com/azure/templates/microsoft.resources/2020-10-01/deploymentscripts?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.Resources/deploymentScripts";
        // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resources/Azure.ResourceManager.Resources/src/Generated/RestOperations/DeploymentScriptsRestOperations.cs#L36
        private const string DefaultVersion = "2020-10-01";

        private static AzureCliScript Empty(string name) => ArmResourcesModelFactory.AzureCliScript();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentScript"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="scriptEnvironmentVariables">The script environment variables.</param>
        /// <param name="scriptContent">The script content.</param>
        /// <param name="version">The resource version.</param>
        /// <param name="location">The resource location.</param>
        public DeploymentScript(IConstruct scope, string resourceName, IEnumerable<ScriptEnvironmentVariable> scriptEnvironmentVariables, string scriptContent, string version = DefaultVersion, AzureLocation? location = default)
            : this(scope, null, resourceName, version, (name) => ArmResourcesModelFactory.AzureCliScript(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                azCliVersion: "2.37.0",
                retentionInterval: TimeSpan.FromHours(1),
                timeout: TimeSpan.FromMinutes(5),
                cleanupPreference: ScriptCleanupOptions.OnSuccess,
                environmentVariables: scriptEnvironmentVariables,
                scriptContent: scriptContent),
                  false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentScript"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="database">The database.</param>
        /// <param name="databaseServerName">The database server name.</param>
        /// <param name="appUserPasswordSecret">The app user password secret.</param>
        /// <param name="sqlAdminPasswordSecret">The sql admin password secret.</param>
        /// <param name="version">The resource version.</param>
        /// <param name="location">The resource location.</param>
        public DeploymentScript(IConstruct scope, string resourceName, Resource database, Parameter databaseServerName, Parameter appUserPasswordSecret, Parameter sqlAdminPasswordSecret, string version = DefaultVersion, AzureLocation? location = default)
            : this(scope, null, resourceName, version, (name) => ArmResourcesModelFactory.AzureCliScript(
                name: name,
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                azCliVersion: "2.37.0",
                retentionInterval: TimeSpan.FromHours(1),
                timeout: TimeSpan.FromMinutes(5),
                cleanupPreference: ScriptCleanupOptions.OnSuccess,
                environmentVariables: new List<ScriptEnvironmentVariable>
                {
                    new ScriptEnvironmentVariable("APPUSERPASSWORD"),
                    new ScriptEnvironmentVariable("SQLCMDPASSWORD"),
                    new ScriptEnvironmentVariable("DBSERVER"),
                    new ScriptEnvironmentVariable("DBNAME") { Value = database.Id.Name },
                    new ScriptEnvironmentVariable("APPUSERNAME") { Value = "appUser" },
                    new ScriptEnvironmentVariable("SQLADMIN") { Value = "sqlAdmin" },
                },
                scriptContent: """
                        wget https://github.com/microsoft/go-sqlcmd/releases/download/v0.8.1/sqlcmd-v0.8.1-linux-x64.tar.bz2
                        tar x -f sqlcmd-v0.8.1-linux-x64.tar.bz2 -C .

                        cat <<SCRIPT_END > ./initDb.sql
                        drop user ${APPUSERNAME}
                        go
                        create user ${APPUSERNAME} with password = '${APPUSERPASSWORD}'
                        go
                        alter role db_owner add member ${APPUSERNAME}
                        go
                        SCRIPT_END

                        ./sqlcmd -S ${DBSERVER} -d ${DBNAME} -U ${SQLADMIN} -i ./initDb.sql
                        """))
        {
            AssignProperty(data => data.EnvironmentVariables[0].SecureValue, appUserPasswordSecret);
            AssignProperty(data => data.EnvironmentVariables[1].SecureValue, sqlAdminPasswordSecret);
            AssignProperty(data => data.EnvironmentVariables[2].Value, databaseServerName);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DeploymentScript"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static DeploymentScript FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new DeploymentScript(scope, parent: parent, name: name, isExisting: true);

        private DeploymentScript(IConstruct scope, ResourceGroup? parent, string name, string version = DefaultVersion, Func<string, AzureCliScript>? creator = null, bool isExisting = false)
            : base(scope, parent, name, ResourceTypeName, DefaultVersion, creator ?? Empty, isExisting)
        {
        }

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetOrAddResourceGroup();
            }
            return result;
        }
    }
}
