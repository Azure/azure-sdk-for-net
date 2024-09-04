// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.PostgreSql.Tests;

public class BasicPostgreSqlTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [RecordedTest]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.dbforpostgresql/flexible-postgresql-with-aad/main.bicep")]
    public async Task CreateFlexibleServer()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "The database location.";

                BicepParameter adminLogin = BicepParameter.Create<string>(nameof(adminLogin));
                adminLogin.Description = "The administrator username of the server.";

                BicepParameter adminPass = BicepParameter.Create<string>(nameof(adminPass));
                adminPass.Description = "The administrator password of the server.";
                adminPass.IsSecure = true;

                BicepParameter aadAdminName = BicepParameter.Create<string>(nameof(aadAdminName));
                aadAdminName.Description = "The AAD admin username.";

                BicepParameter aadAdminOid = BicepParameter.Create<string>(nameof(aadAdminOid));
                aadAdminOid.Description = "The AAD admin Object ID.";

                PostgreSqlFlexibleServer server =
                    new(nameof(server))
                    {
                        Location = location,
                        Sku =
                            new PostgreSqlFlexibleServerSku
                            {
                                Name = "Standard_D2ds_v4",
                                Tier = PostgreSqlFlexibleServerSkuTier.GeneralPurpose
                            },
                        CreateMode = PostgreSqlFlexibleServerCreateMode.Default,
                        Version = PostgreSqlFlexibleServerVersion.Ver14,
                        AdministratorLogin = adminLogin,
                        AdministratorLoginPassword = adminPass,
                        AuthConfig =
                            new PostgreSqlFlexibleServerAuthConfig
                            {
                                ActiveDirectoryAuth = PostgreSqlFlexibleServerActiveDirectoryAuthEnum.Enabled,
                                PasswordAuth = PostgreSqlFlexibleServerPasswordAuthEnum.Disabled,
                                TenantId = BicepFunction.GetSubscription().TenantId
                            },
                        Storage =
                            new PostgreSqlFlexibleServerStorage
                            {
                                StorageSizeInGB = 32
                            },
                        Backup =
                            new PostgreSqlFlexibleServerBackupProperties
                            {
                                BackupRetentionDays = 7,
                                GeoRedundantBackup = PostgreSqlFlexibleServerGeoRedundantBackupEnum.Disabled
                            },
                        HighAvailability = new PostgreSqlFlexibleServerHighAvailability
                        {
                            Mode = PostgreSqlFlexibleServerHighAvailabilityMode.Disabled
                        }
                    };

                PostgreSqlFlexibleServerActiveDirectoryAdministrator admin =
                    new(nameof(admin), PostgreSqlFlexibleServer.ResourceVersions.V2022_12_01)
                    {
                        Parent = server,
                        Name = aadAdminOid,
                        TenantId = BicepFunction.GetSubscription().TenantId,
                        PrincipalName = aadAdminName,
                        PrincipalType = PostgreSqlFlexibleServerPrincipalType.ServicePrincipal
                    };
            })
        .Compare(
            """
            @description('The database location.')
            param location string = resourceGroup().location

            @description('The administrator username of the server.')
            param adminLogin string

            @secure()
            @description('The administrator password of the server.')
            param adminPass string

            @description('The AAD admin username.')
            param aadAdminName string

            @description('The AAD admin Object ID.')
            param aadAdminOid string

            resource server 'Microsoft.DBforPostgreSQL/flexibleServers@2022-12-01' = {
                name: take('server${uniqueString(resourceGroup().id)}', 24)
                location: location
                properties: {
                    administratorLogin: adminLogin
                    administratorLoginPassword: adminPass
                    authConfig: {
                        activeDirectoryAuth: 'Enabled'
                        passwordAuth: 'Disabled'
                        tenantId: subscription().tenantId
                    }
                    backup: {
                        backupRetentionDays: 7
                        geoRedundantBackup: 'Disabled'
                    }
                    createMode: 'Default'
                    highAvailability: {
                        mode: 'Disabled'
                    }
                    storage: {
                        storageSizeGB: 32
                    }
                    version: '14'
                }
                sku: {
                    name: 'Standard_D2ds_v4'
                    tier: 'GeneralPurpose'
                }
            }

            resource admin 'Microsoft.DBforPostgreSQL/flexibleServers/administrators@2022-12-01' = {
                name: aadAdminOid
                properties: {
                    principalName: aadAdminName
                    principalType: 'ServicePrincipal'
                    tenantId: subscription().tenantId
                }
                parent: server
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
