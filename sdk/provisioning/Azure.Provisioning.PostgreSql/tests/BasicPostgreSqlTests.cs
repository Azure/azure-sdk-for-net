// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.PostgreSql.Tests;

public class BasicPostgreSqlTests
{
    internal static Trycep CreateFlexibleServerTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:PostgreSqlBasic
                Infrastructure infra = new();

                ProvisioningParameter adminLogin =
                    new(nameof(adminLogin), typeof(string))
                    {
                        Description = "The administrator username of the server."
                    };
                infra.Add(adminLogin);

                ProvisioningParameter adminPass =
                    new(nameof(adminPass), typeof(string))
                    {
                        Description = "The administrator password of the server.",
                        IsSecure = true
                    };
                infra.Add(adminPass);

                ProvisioningParameter aadAdminName =
                    new(nameof(aadAdminName), typeof(string))
                    {
                        Description = "The AAD admin username."
                    };
                infra.Add(aadAdminName);

                ProvisioningParameter aadAdminOid =
                    new(nameof(aadAdminOid), typeof(string))
                    {
                        Description = "The AAD admin Object ID."
                    };
                infra.Add(aadAdminOid);

                PostgreSqlFlexibleServer server =
                    new(nameof(server), PostgreSqlFlexibleServer.ResourceVersions.V2022_12_01)
                    {
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
                                TenantId = BicepFunction.GetTenant().TenantId
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
                infra.Add(server);

                PostgreSqlFlexibleServerActiveDirectoryAdministrator admin =
                    new(nameof(admin), PostgreSqlFlexibleServer.ResourceVersions.V2022_12_01)
                    {
                        Parent = server,
                        Name = aadAdminOid,
                        TenantId = BicepFunction.GetSubscription().TenantId,
                        PrincipalName = aadAdminName,
                        PrincipalType = PostgreSqlFlexibleServerPrincipalType.ServicePrincipal
                    };
                infra.Add(admin);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.dbforpostgresql/flexible-postgresql-with-aad/main.bicep")]
    public async Task CreateFlexibleServer()
    {
        await using Trycep test = CreateFlexibleServerTest();
        test.Compare(
            """
            @description('The administrator username of the server.')
            param adminLogin string

            @secure()
            @description('The administrator password of the server.')
            param adminPass string

            @description('The AAD admin username.')
            param aadAdminName string

            @description('The AAD admin Object ID.')
            param aadAdminOid string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource server 'Microsoft.DBforPostgreSQL/flexibleServers@2022-12-01' = {
              name: take('server-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                administratorLogin: adminLogin
                administratorLoginPassword: adminPass
                authConfig: {
                  activeDirectoryAuth: 'Enabled'
                  passwordAuth: 'Disabled'
                  tenantId: tenant().tenantId
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
            """);
    }

    // this test is only a unit test that validates the "convenience property" StorageSizeInGB would not override the actual
    // storage.storageSizeInGB property if both are set.
    [Test]
    public async Task TestStorageSizeInGB()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                var infra = new Infrastructure();
                var server = new PostgreSqlFlexibleServer("testServer", "2024-08-01");
                server.StorageSizeInGB = 100;
                server.Storage.StorageSizeInGB = 64;
                server.Storage.AutoGrow = StorageAutoGrow.Disabled;

                infra.Add(server);
                return infra;
            })
            .Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location
            
            resource testServer 'Microsoft.DBforPostgreSQL/flexibleServers@2024-08-01' = {
              name: take('testserver-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                storage: {
                  storageSizeGB: 64
                  autoGrow: 'Disabled'
                }
              }
            }
            """);
    }
}
