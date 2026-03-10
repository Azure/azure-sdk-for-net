// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("SecretParameters")]
    public partial class PostgreSqlMigrationPatch
    {
        /// <summary> Migration secret parameters. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.secretParameters")]
        public PostgreSqlMigrationSecretParameters SecretParameters
        {
            get
            {
                var src = Properties is null ? default : Properties.SecretParameters;
                if (src is null)
                    return default;
                var creds = src.AdminCredentials;
                PostgreSqlMigrationAdminCredentials adminCreds = null;
                if (creds != null)
                {
                    adminCreds = new PostgreSqlMigrationAdminCredentials(
                        creds.SourceServerPassword ?? string.Empty,
                        creds.TargetServerPassword ?? string.Empty);
                }
                return new PostgreSqlMigrationSecretParameters(adminCreds ?? new PostgreSqlMigrationAdminCredentials(string.Empty, string.Empty))
                {
                    SourceServerUsername = src.SourceServerUsername,
                    TargetServerUsername = src.TargetServerUsername,
                };
            }
            set
            {
                if (value is null)
                {
                    if (Properties != null)
                        Properties.SecretParameters = null;
                }
                else
                {
                    if (Properties is null)
                        Properties = new MigrationPropertiesForPatch();
                    var patch = new MigrationSecretParametersForPatch();
                    if (value.AdminCredentials != null)
                    {
                        patch.AdminCredentials = new AdminCredentialsForPatch()
                        {
                            SourceServerPassword = value.AdminCredentials.SourceServerPassword,
                            TargetServerPassword = value.AdminCredentials.TargetServerPassword,
                        };
                    }
                    patch.SourceServerUsername = value.SourceServerUsername;
                    patch.TargetServerUsername = value.TargetServerUsername;
                    Properties.SecretParameters = patch;
                }
            }
        }
    }
}
