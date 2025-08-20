// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.DataMigration;
using Azure.ResourceManager.DataMigration.Models;
using Azure.Core;
using Azure.ResourceManager.Models;
using NUnit.Framework;
using System.Collections;

namespace Azure.ResourceManager.DataMigration.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region DataMigrationService
        public static DataMigrationServiceData GetServiceData(string subnetId)
        {
            var data = new DataMigrationServiceData(AzureLocation.EastUS)
            {
                VirtualSubnetId = subnetId,
                Sku = new DataMigrationServiceSku()
                {
                    Name = "Premium_4vCores",
                    Tier = "Premium"
                }
            };
            return data;
        }

        public static void AssertServiceData(DataMigrationServiceData data1, DataMigrationServiceData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.VirtualSubnetId, data2.VirtualSubnetId);
            Assert.AreEqual(data1.Sku.Name, data2.Sku.Name);
            Assert.AreEqual(data1.Sku.Tier, data2.Sku.Tier);
        }
        #endregion

        #region project
        public static DataMigrationProjectData GetProject()
        {
            var data = new DataMigrationProjectData(AzureLocation.EastUS)
            {
                SourcePlatform = DataMigrationProjectSourcePlatform.Sql,
                TargetPlatform = DataMigrationProjectTargetPlatform.SqlDB
            };
            return data;
        }

        public static void AssertProjectData(DataMigrationProjectData data1, DataMigrationProjectData data2)
        {
            AssertTrackedResource(data1 as DataMigrationProjectData, data2);
            Assert.AreEqual(data1.SourcePlatform, data2.SourcePlatform);
            Assert.AreEqual(data1.TargetPlatform, data2.TargetPlatform);
        }
        #endregion

        #region flie
        public static DataMigrationProjectFileData GetProjectFileData()
        {
            var data = new DataMigrationProjectFileData()
            {
                Properties = new DataMigrationProjectFileProperties()
                {
                    FilePath = "NorthWind.sql"
                }
            };
            return data;
        }
        public static void AssertFlieData(DataMigrationProjectFileData data1, DataMigrationProjectFileData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Properties.FilePath, data2.Properties.FilePath);
        }
        #endregion

        #region Project(Test For Task)
        public static DataMigrationProjectData GetTaskProject()
        {
            var data = new DataMigrationProjectData(AzureLocation.EastUS)
            {
                SourcePlatform = DataMigrationProjectSourcePlatform.MySql,
                TargetPlatform = DataMigrationProjectTargetPlatform.AzureDBForMySql
            };
            return data;
        }
        #endregion

        #region project task(MigrateMySqlAzureDBForMySqlOfflineTask)
        public static DataMigrationProjectTaskData GetProjectTaskData()
        {
            var sourceInfo = new DataMigrationMySqlConnectionInfo("someSourceServerName", 0)
            {
                UserName = "someSourceUser",
                Password = "password"
            };
            var targetInfo = new DataMigrationMySqlConnectionInfo("someTargetServerName", 0)
            {
                UserName = "someTargetUser",
                Password = "someTargetPassword"
            };
            IEnumerable<MigrateMySqlAzureDBForMySqlOfflineDatabaseInput> selectDataBases = new List<MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>
            {
                new MigrateMySqlAzureDBForMySqlOfflineDatabaseInput()
                {
                    Name = "someSourceDatabaseName",
                    TargetDatabaseName = "someTargetDatabaseName",
                    TableMap =
                    {
                        ["someTableSource"] = "someTableSource",
                    }
                }
            };
            var data = new DataMigrationProjectTaskData()
            {
                Properties = new MigrateMySqlAzureDBForMySqlOfflineTaskProperties()
                {
                    Input = new MigrateMySqlAzureDBForMySqlOfflineTaskInput(sourceInfo, targetInfo, selectDataBases)
                    {
                    }
                }
            };
            return data;
        }

        public static void AssertMySqlOfflineTaskData(DataMigrationProjectTaskData data1, DataMigrationProjectTaskData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Properties.TaskType, data2.Properties.TaskType);
        }
        #endregion
    }
}
