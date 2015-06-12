// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Xml;
namespace StorSimple.Tests.Utilities
{
    public class LegacyApplianceConfigTestParser
    {
        public LegacyApplianceConfigTestParser()
        {
            // no implementation
        }

        public LegacyApplianceConfig ParseLegacyApplianceTestConfig(string configXml)
        {
            XmlDocument document = new XmlDocument();
            document.Load(configXml);
            LegacyApplianceConfig config = CreateLegacyApplianceConfig(document);
            config.AccessControlRecords = ParseACRs(document);
            config.BackupPolicies = ParseBackupPolicy(document);
            config.BandwidthSettings = ParseBandwidthSetting(document);
            config.CloudConfigurations = ParseVolumeContainer(document);
            config.Volumes = ParseVolume(document);
            config.VolumeGroups = ParseVolumeGroup(document);
            config.TargetChapSettings = ParseTargetChap(document);
            config.InboundChapSettings = ParseInboundChap(document);
            config.StorageAccountCredentials = ParseSACs(document);
            this.FixCrossReferencesWithLegacyApplianceConfig(config);
            return config;
        }

        private DataContainer ConvertToDataContainer(MigrationDataContainer dataContainer)
        {
            DataContainer dc = new DataContainer();
            dc.BandwidthRate = dataContainer.BandwidthSetting.Schedules[0].Rate;
            dc.EncryptionKey = dataContainer.EncryptionKey;
            dc.InstanceId = dataContainer.InstanceId;
            dc.IsDefault = dataContainer.IsDefault;
            dc.IsEncryptionEnabled = !string.IsNullOrEmpty(dataContainer.EncryptionKey);
            dc.Name = dataContainer.Name;
            dc.OperationInProgress = dataContainer.OperationInProgress;
            dc.Owned = dataContainer.Owned;
            dc.PrimaryStorageAccountCredential = this.ConvertToSACResponse(dataContainer.PrimaryStorageAccountCredential);
            dc.VolumeCount = 0;
            return dc;
        }

        private StorageAccountCredentialResponse ConvertToSACResponse(StorageAccountCredential cred)
        {
            StorageAccountCredentialResponse sac = new StorageAccountCredentialResponse();
            sac.CloudType = cred.CloudType;
            sac.Hostname = cred.Hostname;
            sac.InstanceId = cred.InstanceId;
            sac.IsDefault = cred.IsDefault;
            sac.Location = cred.Location;
            sac.Login = cred.Login;
            sac.Name = cred.Name;
            sac.OperationInProgress = cred.OperationInProgress;
            sac.PasswordEncryptionCertThumbprint = cred.PasswordEncryptionCertThumbprint;
            sac.Password = cred.Password;
            sac.UseSSL = cred.UseSSL;
            sac.VolumeCount = 0;
            return sac;
        }

        private void FixCrossReferencesWithLegacyApplianceConfig(LegacyApplianceConfig config)
        {
            List<BandwidthSetting> bandwidthSettingList = (List<BandwidthSetting>)config.BandwidthSettings;
            List<StorageAccountCredential> sacList = (List<StorageAccountCredential>)config.StorageAccountCredentials;
            foreach(MigrationDataContainer dataContainer in config.CloudConfigurations)
            {
                dataContainer.BandwidthSetting = bandwidthSettingList.Find(bwSetting => bwSetting.InstanceId == dataContainer.BandwidthSetting.InstanceId);
                dataContainer.PrimaryStorageAccountCredential = sacList.Find(sac => sac.InstanceId == dataContainer.PrimaryStorageAccountCredential.InstanceId);
                dataContainer.BackupStorageAccountCredential = sacList.Find(sac => sac.InstanceId == dataContainer.BackupStorageAccountCredential.InstanceId);
            }

            List<AccessControlRecord> acrList = (List<AccessControlRecord>)config.AccessControlRecords;
            foreach( VirtualDisk virtualDisk in config.Volumes)
            {
                MigrationDataContainer dataContainer = ((List<MigrationDataContainer>)config.CloudConfigurations).Find(dc => dc.InstanceId == virtualDisk.DataContainerId);
                virtualDisk.DataContainer = this.ConvertToDataContainer(dataContainer);
                virtualDisk.DataContainer.VolumeCount++;
                virtualDisk.AcrList = acrList.FindAll(acr => virtualDisk.AcrIdList.Contains(acr.InstanceId));
                foreach(AccessControlRecord acr in virtualDisk.AcrList)
                {
                    acr.VolumeCount++;
                }
            }
        }

        private LegacyApplianceConfig CreateLegacyApplianceConfig(XmlDocument document)
        {
            LegacyApplianceConfig config = new LegacyApplianceConfig();
            XmlNode node = document.SelectSingleNode(@"//LegacyApplianceConfig");
            config.InstanceId = node.Attributes["Id"].Value;
            config.Name = node.Attributes["Name"].Value;
            config.SerialNumber = int.Parse(node.Attributes["SerialNo"].Value);
            config.TotalCount = int.Parse(node.Attributes["TotalCount"].Value);
            return config;
        }

        private List<AccessControlRecord> ParseACRs(XmlDocument document)
        {
            List<AccessControlRecord> acrList = new List<AccessControlRecord>();
            XmlNodeList nodeList = document.SelectNodes(@"//ACR");
            foreach (XmlNode node in nodeList)
            {
                AccessControlRecord acr = new AccessControlRecord();
                acr.Name = node.Attributes["Name"].Value;
                acr.InstanceId = node.Attributes["Id"].Value;
                acr.InitiatorName = node.Attributes["InitiatorName"].Value;
                acrList.Add(acr);
            }

            return acrList;
        }

        private List<MigrationDataContainer> ParseVolumeContainer(XmlDocument document)
        {
            List<MigrationDataContainer> dataContainerList = new List<MigrationDataContainer>();
            XmlNodeList nodeList = document.SelectNodes(@"//VolumeContainer");
            foreach (XmlNode node in nodeList)
            {
                MigrationDataContainer volumeContainer = new MigrationDataContainer();
                volumeContainer.Name = node.Attributes["Name"].Value;
                volumeContainer.InstanceId = node.Attributes["Id"].Value;
                volumeContainer.BandwidthSetting = new BandwidthSetting()
                {
                    InstanceId = node.Attributes["BandwidthTempateId"].Value
                };

                volumeContainer.EncryptionKey = node.Attributes["EncryptionKey"].Value;
                volumeContainer.SecretsEncryptionThumbprint = node.Attributes["SecretEncryptionThumbPrint"].Value;
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if ("PrimaryBucket" == childNode.Name)
                    {
                        volumeContainer.PrimaryBucket = childNode.Attributes["Name"].Value;
                        volumeContainer.PrimaryStorageAccountCredential = new StorageAccountCredential()
                        {
                            InstanceId = childNode.Attributes["CredentialId"].Value
                        };
                    }
                    else if ("BackupBucket" == childNode.Name)
                    {
                        volumeContainer.BackupBucket = childNode.Attributes["Name"].Value;
                        volumeContainer.BackupStorageAccountCredential = new StorageAccountCredential()
                        {
                            InstanceId = childNode.Attributes["CredentialId"].Value
                        };
                    }
                }

                dataContainerList.Add(volumeContainer);
            }

            return dataContainerList;
        }

        private List<VirtualDisk> ParseVolume(XmlDocument document)
        {
            List<VirtualDisk> virtualDiskList = new List<VirtualDisk>();
            XmlNodeList nodeList = document.SelectNodes(@"//Volume");
            foreach (XmlNode node in nodeList)
            {
                VirtualDisk virtualDisk = new VirtualDisk();
                virtualDisk.Name = node.Attributes["Name"].Value;
                virtualDisk.InstanceId = node.Attributes["Id"].Value;
                virtualDisk.DataContainerId = node.Attributes["ContainerId"].Value;
                virtualDisk.AccessType = (AccessType)Enum.Parse(typeof(AccessType), node.Attributes["Attr"].Value, true);
                virtualDisk.SizeInBytes = long.Parse(node.Attributes["BlockCount"].Value);
                virtualDisk.Online = Boolean.Parse(node.Attributes["Online"].Value);
                virtualDisk.AppType = (AppType)Enum.Parse(typeof(AppType), node.Attributes["Type"].Value, true);
                virtualDisk.VSN = node.Attributes["VSN"].Value;
                virtualDisk.AcrIdList = new List<string>();
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if ("ACRId" == childNode.Name)
                    {
                        virtualDisk.AcrIdList.Add(childNode.InnerText);
                    }
                }

                virtualDiskList.Add(virtualDisk);
            }

            return virtualDiskList;
        }

        private List<MigrationBackupPolicy> ParseBackupPolicy(XmlDocument document)
        {
            List<MigrationBackupPolicy> backupPolicyList = new List<MigrationBackupPolicy>();
            XmlNodeList nodeList = document.SelectNodes(@"//BackupPolicy");
            backupPolicyList = new List<MigrationBackupPolicy>();
            foreach (XmlNode node in nodeList)
            {
                MigrationBackupPolicy backupPolicy = new MigrationBackupPolicy();
                backupPolicy.Name = node.Attributes["Name"].Value;
                backupPolicy.InstanceId = node.Attributes["Id"].Value;
                backupPolicy.MaxRetentionCount = long.Parse(node.Attributes["RetentionCount"].Value);
                backupPolicy.CreatedOn = node.Attributes["CreatedOn"].Value;
                backupPolicy.Type = (BackupType)Enum.Parse(typeof(BackupType), node.Attributes["Type"].Value, true);
                backupPolicy.LastRunTime = null;
                if (null != node.Attributes["LastRunTime"])
                {
                    backupPolicy.LastRunTime = node.Attributes["LastRunTime"].Value;
                }

                backupPolicy.VirtualDiskGroupId = node.Attributes["VirtualDiskGroupId"].Value;
                backupPolicyList.Add(backupPolicy);
            }

            return backupPolicyList;
        }

        private List<VirtualDiskGroup> ParseVolumeGroup(XmlDocument document)
        {
            List<VirtualDiskGroup> virtualDiskGroupList = new List<VirtualDiskGroup>();
            XmlNodeList nodeList = document.SelectNodes(@"//VolumeContainerGroup");
            foreach (XmlNode node in nodeList)
            {
                VirtualDiskGroup virtualDiskGroup = new VirtualDiskGroup();
                virtualDiskGroup.Name = node.Attributes["Name"].Value;
                virtualDiskGroup.InstanceId = node.Attributes["Id"].Value;
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if ("VolumeID" == childNode.Name)
                    {
                        virtualDiskGroup.VirtualDiskList.Add(childNode.InnerText);
                    }
                }

                virtualDiskGroupList.Add(virtualDiskGroup);
            }

            return virtualDiskGroupList;

        }

        private List<BandwidthSetting> ParseBandwidthSetting(XmlDocument document)
        {
            List<BandwidthSetting> bandwidthSettingList = new List<BandwidthSetting>();
            XmlNodeList nodeList = document.SelectNodes(@"//BandwidthTemplate");
            foreach (XmlNode node in nodeList)
            {
                BandwidthSetting bandwidthSetting = new BandwidthSetting();
                bandwidthSetting.Name = node.Attributes["Name"].Value;
                bandwidthSetting.InstanceId = node.Attributes["Id"].Value;
                bandwidthSetting.CreatedFromTemplateId = int.Parse(node.Attributes["CreatedFromTemplateId"].Value);
                bandwidthSetting.Schedules = new List<BandwidthSchedule>();
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if ("BanbdwidthSchedule" == childNode.Name)
                    {
                        BandwidthSchedule schedule = new BandwidthSchedule();
                        XmlAttribute dayNodeAtt = childNode.Attributes["Days"];
                        if (null != dayNodeAtt && !string.IsNullOrEmpty(dayNodeAtt.Value))
                        {
                            string[] days = dayNodeAtt.Value.Split(',');
                            schedule.Days = new List<int>();
                            foreach (string day in days)
                            {
                                schedule.Days.Add((int)((DayOfWeek)Enum.Parse(typeof(DayOfWeek), day, true)));
                            }
                        }

                        schedule.Rate = int.Parse(childNode.Attributes["Rate"].Value);
                        schedule.Start = childNode.Attributes["StartTime"].Value;
                        schedule.Stop = childNode.Attributes["StopTime"].Value;
                        bandwidthSetting.Schedules.Add(schedule);
                    }
                }
                

                bandwidthSettingList.Add(bandwidthSetting);
            }

            return bandwidthSettingList;
        }

        private List<StorageAccountCredential> ParseSACs(XmlDocument document)
        {
            List<StorageAccountCredential> sacList = new List<StorageAccountCredential>();
            XmlNodeList nodeList = document.SelectNodes(@"//SAC");
            foreach (XmlNode node in nodeList)
            {
                StorageAccountCredential sac = new StorageAccountCredential();
                sac.Name = node.Attributes["Name"].Value;
                sac.Hostname = node.Attributes["HostName"].Value;
                sac.Password = node.Attributes["Password"].Value;
                sac.Location = node.Attributes["Location"].Value;
                sac.Login = node.Attributes["Login"].Value;
                sac.InstanceId = node.Attributes["Id"].Value;
                sac.CloudType = (CloudType)Enum.Parse(typeof(CloudType), node.Attributes["Provider"].Value, true);
                sac.UseSSL = Boolean.Parse(node.Attributes["UseSSL"].Value);
                sac.PasswordEncryptionCertThumbprint = node.Attributes["PasswordEncryptionCertThumbprint"].Value;
                sacList.Add(sac);
            }

            return sacList;
        }

        private List<MigrationChapSetting> ParseChapSettings(XmlDocument document, string chapSettingsNodeName)
        {
            List<MigrationChapSetting> iscsiChapList = null;
            XmlNodeList nodeList = document.SelectNodes(@"//" + chapSettingsNodeName);
            if (null != nodeList && 0 < nodeList.Count)
            {
                iscsiChapList = new List<MigrationChapSetting>();
                foreach (XmlNode node in nodeList)
                {
                    if (null != node.Attributes["Name"])
                    {
                        MigrationChapSetting iscsiChap = new MigrationChapSetting();
                        iscsiChap.Name = node.Attributes["Name"].Value;
                        iscsiChap.Password = node.Attributes["Password"].Value;
                        iscsiChap.Valid = Boolean.Parse(node.Attributes["Valid"].Value);
                        iscsiChap.Id = node.Attributes["Id"].Value;
                        iscsiChap.SecretsEncryptionThumbprint = node.Attributes["SecretsEncryptionThumbprint"].Value;
                        iscsiChapList.Add(iscsiChap);
                    }
                }
            }

            return iscsiChapList;
        }

        private List<MigrationChapSetting> ParseInboundChap(XmlDocument document)
        {
            return this.ParseChapSettings(document, "InBoundIScsiChap");
        }

        private List<MigrationChapSetting> ParseTargetChap(XmlDocument document)
        {
            return this.ParseChapSettings(document, "OutBoundIScsiChap");
        }

        private List<string[]> ParseRelatedVolumeContainers(XmlDocument document)
        {
            List<string[]> relatedContainerList = new List<string[]>();
            XmlNodeList nodeList = document.SelectNodes(@"//RelatedVolumeContainer");
            foreach (XmlNode node in nodeList)
            {
                string[] relatedContainers = node.Attributes["Containers"].Value.Split(',');
                relatedContainerList.Add(relatedContainers);
            }

            return relatedContainerList;
        }
    }
}
