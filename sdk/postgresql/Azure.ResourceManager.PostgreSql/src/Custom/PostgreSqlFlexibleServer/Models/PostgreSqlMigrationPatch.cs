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
        [WirePath("properties.secretParameters")]
        public MigrationSecretParametersForPatch InternalSecretParameters
        {
            get => Properties is null ? default : Properties.SecretParameters;
            set
            {
                if (Properties is null)
                    Properties = new MigrationPropertiesForPatch();
                Properties.SecretParameters = value;
            }
        }

        /// <summary> Migration secret parameters. </summary>
        [WirePath("properties.secretParameters")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlMigrationSecretParameters SecretParameters
        {
            get
            {
                var p = InternalSecretParameters;
                if (p is null) return null;
                return new PostgreSqlMigrationSecretParameters(
                    p.AdminCredentials is null ? null : new PostgreSqlMigrationAdminCredentials()
                    {
                        SourceServerPassword = p.AdminCredentials.SourceServerPassword,
                        TargetServerPassword = p.AdminCredentials.TargetServerPassword
                    })
                {
                    SourceServerUsername = p.SourceServerUsername,
                    TargetServerUsername = p.TargetServerUsername
                };
            }
            set
            {
                if (value is null)
                {
                    InternalSecretParameters = null;
                    return;
                }
                InternalSecretParameters = new MigrationSecretParametersForPatch()
                {
                    AdminCredentials = value.AdminCredentials is null ? null : new AdminCredentialsForPatch()
                    {
                        SourceServerPassword = value.AdminCredentials.SourceServerPassword,
                        TargetServerPassword = value.AdminCredentials.TargetServerPassword
                    },
                    SourceServerUsername = value.SourceServerUsername,
                    TargetServerUsername = value.TargetServerUsername
                };
            }
        }
    }
}
