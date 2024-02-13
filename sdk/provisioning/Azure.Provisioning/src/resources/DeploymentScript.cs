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
        private const string ResourceTypeName = "Microsoft.Resources/deploymentScripts";
        private const string _defaultVersion = "2020-10-01";

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentScript"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="scriptEnvironmentVariables">The script environment variables.</param>
        /// <param name="scriptContent">The script content.</param>
        /// <param name="version">The resource version.</param>
        /// <param name="location">The resource location.</param>
        public DeploymentScript(IConstruct scope, string resourceName, IEnumerable<ScriptEnvironmentVariable> scriptEnvironmentVariables, string scriptContent, string version = _defaultVersion, AzureLocation? location = default)
            : base(scope, null, GetName(scope, resourceName), ResourceTypeName, version, ArmResourcesModelFactory.AzureCliScript(
                name: GetName(scope, resourceName),
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                azCliVersion: "2.37.0",
                retentionInterval: TimeSpan.FromHours(1),
                timeout: TimeSpan.FromMinutes(5),
                cleanupPreference: ScriptCleanupOptions.OnSuccess,
                environmentVariables: scriptEnvironmentVariables,
                scriptContent: scriptContent))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentScript"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="database">The database.</param>
        /// <param name="appUserPasswordSecret">The app user password secret.</param>
        /// <param name="sqlAdminPasswordSecret">The sql admin password secret.</param>
        /// <param name="version">The resource version.</param>
        /// <param name="location">The resource location.</param>
        public DeploymentScript(IConstruct scope, string resourceName, Resource database, Parameter appUserPasswordSecret, Parameter sqlAdminPasswordSecret, string version = _defaultVersion, AzureLocation? location = default)
            : base(scope, null, GetName(scope, resourceName), ResourceTypeName, version, ArmResourcesModelFactory.AzureCliScript(
                name: GetName(scope, resourceName),
                resourceType: ResourceTypeName,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                azCliVersion: "2.37.0",
                retentionInterval: TimeSpan.FromHours(1),
                timeout: TimeSpan.FromMinutes(5),
                cleanupPreference: ScriptCleanupOptions.OnSuccess,
                environmentVariables: new List<ScriptEnvironmentVariable>
                {
                    new ScriptEnvironmentVariable("APPUSERNAME") { Value = "appUser" },
                    new ScriptEnvironmentVariable("APPUSERPASSWORD") { SecureValue = $"_p_.{appUserPasswordSecret.Name}" },
                    new ScriptEnvironmentVariable("DBNAME") { Value = $"_p_.{database.Name}.name" },
                    new ScriptEnvironmentVariable("DBSERVER") { Value = $"_p_.{database.Parent!.Name}.properties.fullyQualifiedDomainName" },
                    new ScriptEnvironmentVariable("SQLCMDPASSWORD") { SecureValue = $"_p_.{sqlAdminPasswordSecret.Name}" },
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
            Scope.AddParameter(appUserPasswordSecret);
            Scope.AddParameter(sqlAdminPasswordSecret);
        }

        private static string GetName(IConstruct scope, string? name) => name is null ? $"deploymentScript-{scope.EnvironmentName}" : $"{name}-{scope.EnvironmentName}";

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
