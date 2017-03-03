using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using SiteRecovery.Tests;

namespace SiteRecovery.Extensions
{
    public static class AzureSDKExtensions
    {
        #region Common Helpers
        public static CustomRequestHeaders GetRequestHeaders()
        {
            return new CustomRequestHeaders()
            {
                ClientRequestId = Guid.NewGuid().ToString() + "-AzureSDK"
            };
        }

        #endregion

        #region Pairing Helpers
        public static MappingOperationResponse PairClouds(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer primaryContainer, 
            ProtectionContainer recoveryContainer,
            Policy policy,
            string armResourceName)
        {
            CreateProtectionContainerMappingInputProperties pairingProps = 
                new CreateProtectionContainerMappingInputProperties()
            {
                PolicyId = policy.Id,
                TargetProtectionContainerId = recoveryContainer.Id,
                ProviderSpecificInput = new ReplicationProviderContainerMappingInput()
            };

            CreateProtectionContainerMappingInput pairingInput = 
                new CreateProtectionContainerMappingInput()
            {
                Properties = pairingProps
            };

            return client.ProtectionContainerMapping.ConfigureProtection(
                primaryFabric.Name,
                primaryContainer.Name,
                armResourceName,
                pairingInput,
                GetRequestHeaders()) as MappingOperationResponse;
        }

        public static MappingOperationResponse PairCloudToAzure(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer primaryContainer, 
            Policy policy,
            string armResourceName)
        {
            CreateProtectionContainerMappingInputProperties pairingProps = 
                new CreateProtectionContainerMappingInputProperties()
            {
                PolicyId = policy.Id,
                TargetProtectionContainerId = "Microsoft Azure",
                ProviderSpecificInput = new ReplicationProviderContainerMappingInput()
            };

            CreateProtectionContainerMappingInput pairingInput = 
                new CreateProtectionContainerMappingInput()
            {
                Properties = pairingProps
            };

            return client.ProtectionContainerMapping.ConfigureProtection(
                primaryFabric.Name,
                primaryContainer.Name,
                armResourceName,
                pairingInput,
                GetRequestHeaders()) as MappingOperationResponse;
        }

        public static LongRunningOperationResponse UnpairClouds(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer primaryContainer,
            string armResourceName)
        {
            ProtectionContainerMapping mapping = 
                client.ProtectionContainerMapping.Get(
                    primaryFabric.Name,
                    primaryContainer.Name,
                    armResourceName,
                    GetRequestHeaders()).ProtectionContainerMapping;

            return client.ProtectionContainerMapping.UnconfigureProtection(
                primaryFabric.Name,
                primaryContainer.Name,
                armResourceName,
                new RemoveProtectionContainerMappingInput(), 
                GetRequestHeaders());
        }
        #endregion

        #region Protection Operations

        public static ReplicationProtectedItemOperationResponse EnableDR(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer protectionContainer,
            Policy policy,
            ProtectableItem protectableItem,
            string armResourceName)
        {
            if (policy.Properties.ProviderSpecificDetails.InstanceType == "HyperVReplicaAzure")
            {
                string vhdId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails)
                    .DiskDetailsList[0].VhdId;

                DiskDetails osDisk = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).DiskDetailsList
                    .FirstOrDefault(item => item.VhdType == "OperatingSystem");

                if (osDisk != null)
                {
                    vhdId = osDisk.VhdId;
                }

                HyperVReplicaAzureEnableProtectionInput hvrAEnableDRInput = 
                    new HyperVReplicaAzureEnableProtectionInput()
                {
                    HvHostVmId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).SourceItemId,
                    OSType = "Windows",
                    VhdId = vhdId,
                    VmName = protectableItem.Properties.FriendlyName,
                    TargetStorageAccountId = 
                        (policy.Properties.ProviderSpecificDetails as HyperVReplicaAzurePolicyDetails)
                        .ActiveStorageAccountId,
                };

                EnableProtectionInputProperties enableDRProp = new EnableProtectionInputProperties()
                {
                    PolicyId = policy.Id,
                    ProtectableItemId = protectableItem.Id,
                    ProviderSpecificDetails = hvrAEnableDRInput
                };

                EnableProtectionInput enableDRInput = new EnableProtectionInput()
                {
                    Properties = enableDRProp
                };

                return client.ReplicationProtectedItem.EnableProtection(
                    primaryFabric.Name,
                    protectionContainer.Name,
                    armResourceName,
                    enableDRInput,
                    GetRequestHeaders()) as ReplicationProtectedItemOperationResponse;
            }
            else if (policy.Properties.ProviderSpecificDetails.InstanceType == "HyperVReplica2012" ||
                policy.Properties.ProviderSpecificDetails.InstanceType == "HyperVReplica2012R2")
            {
                var enableDRProp = new EnableProtectionInputProperties()
                {
                    PolicyId = policy.Id,
                    ProtectableItemId = protectableItem.Id,
                    ProviderSpecificDetails = new EnableProtectionProviderSpecificInput()
                };

                EnableProtectionInput enableInput = new EnableProtectionInput()
                {
                    Properties = enableDRProp
                };

                return client.ReplicationProtectedItem.EnableProtection(
                    primaryFabric.Name,
                    protectionContainer.Name,
                    armResourceName,
                    enableInput,
                    GetRequestHeaders()) as ReplicationProtectedItemOperationResponse;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static LongRunningOperationResponse DisableDR(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer protectionContainer,
            string armResourceName)
        {
            return client.ReplicationProtectedItem.DisableProtection(
                primaryFabric.Name,
                protectionContainer.Name,
                armResourceName,
                new DisableProtectionInput(),
                GetRequestHeaders());
        }
        #endregion

        #region Failover Operations
        public static ReplicationProtectedItemOperationResponse PlannedFailover(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer protectionContainer,
            ReplicationProtectedItem protectedItem)
        {
            PlannedFailoverInputProperties plannedFailoverProp = 
                new PlannedFailoverInputProperties();

            if (protectedItem.Properties.ProviderSpecificDetails.InstanceType == "HyperVReplicaAzure")
            {
                if (protectedItem.Properties.ActiveLocation == "Recovery")
                {
                    HyperVReplicaAzureFailbackProviderInput hvrAFBInput = new HyperVReplicaAzureFailbackProviderInput()
                    {
                        RecoveryVmCreationOption = "NoAction",
                        DataSyncOption = "ForSyncronization"
                    };

                    plannedFailoverProp.ProviderSpecificDetails = hvrAFBInput;
                }
                else
                {
                    HyperVReplicaAzureFailoverProviderInput hvrAFOInput =
                       new HyperVReplicaAzureFailoverProviderInput()
                       {
                           VaultLocation = "West US",
                       };

                    plannedFailoverProp.ProviderSpecificDetails = hvrAFOInput;
                }
            }

            PlannedFailoverInput pfoInput = new PlannedFailoverInput()
            {
                Properties = plannedFailoverProp
            };

            return client.ReplicationProtectedItem.PlannedFailover(
                primaryFabric.Name,
                protectionContainer.Name,
                protectedItem.Name,
                pfoInput,
                GetRequestHeaders()) as ReplicationProtectedItemOperationResponse;
        }

        public static ReplicationProtectedItemOperationResponse CommitFailover(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer protectionContainer,
            ReplicationProtectedItem protectedItem)
        {
            return client.ReplicationProtectedItem.CommitFailover(
               primaryFabric.Name,
               protectionContainer.Name,
               protectedItem.Name,
               GetRequestHeaders()) as ReplicationProtectedItemOperationResponse;
        }

        public static ReplicationProtectedItemOperationResponse ReverseReplication(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer protectionContainer,
            ReplicationProtectedItem protectedItem)
        {
            if (protectedItem.Properties.ProviderSpecificDetails.InstanceType == "HyperVReplicaAzure")
            {
                ProtectableItem protectableItem = client.ProtectableItem.Get(
                    primaryFabric.Name,
                    protectionContainer.Name,
                    protectedItem.Properties.ProtectableItemId.Substring(
                        protectedItem.Properties.ProtectableItemId.LastIndexOf("/") + 1),
                    GetRequestHeaders()).ProtectableItem;

                string vhdId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails)
                    .DiskDetailsList[0].VhdId;

                DiskDetails osDisk = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails)
                    .DiskDetailsList
                    .FirstOrDefault(item => item.VhdType == "OperatingSystem");

                if (osDisk != null)
                {
                    vhdId = osDisk.VhdId;
                }

                string storageAccount =
                    (protectedItem.Properties.ProviderSpecificDetails as HyperVReplicaAzureReplicationDetails)
                    .RecoveryAzureStorageAccount;

                HyperVReplicaAzureReprotectInput hvrARRInput = new HyperVReplicaAzureReprotectInput()
                {
                    HvHostVmId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).SourceItemId,
                    OSType = "Windows",
                    VHDId = vhdId,
                    VmName = protectableItem.Properties.FriendlyName,
                    StorageAccountId = storageAccount,
                };

                ReverseReplicationInputProperties rrProp = new ReverseReplicationInputProperties()
                {
                    FailoverDirection = "",
                    ProviderSpecificDetails = hvrARRInput
                };

                ReverseReplicationInput rrInput = new ReverseReplicationInput()
                {
                    Properties = rrProp
                };

                return client.ReplicationProtectedItem.Reprotect(
                    primaryFabric.Name,
                    protectionContainer.Name, 
                    protectedItem.Name, 
                    rrInput,
                    GetRequestHeaders()) as ReplicationProtectedItemOperationResponse;
            }
            else if (protectedItem.Properties.ProviderSpecificDetails.InstanceType == "HyperVReplica2012" ||
                protectedItem.Properties.ProviderSpecificDetails.InstanceType == "HyperVReplica2012R2")
            {
                ReverseReplicationInputProperties rrProp = new ReverseReplicationInputProperties()
                {
                    ProviderSpecificDetails = new ReverseReplicationProviderSpecificInput()
                };

                ReverseReplicationInput rrInput = new ReverseReplicationInput()
                {
                    Properties = rrProp
                };

                return client.ReplicationProtectedItem.Reprotect(
                    primaryFabric.Name,
                    protectionContainer.Name,
                    protectedItem.Name,
                    rrInput,
                    GetRequestHeaders()) as ReplicationProtectedItemOperationResponse;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static LongRunningOperationResponse TestFailover(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer protectionContainer,
            ReplicationProtectedItem protectedItem)
        {
            TestFailoverInput tfoInput = new TestFailoverInput()
            {
                Properties = new TestFailoverInputProperties()
                {
                    ProviderSpecificDetails = new ProviderSpecificFailoverInput()
                }
            };

            if (protectedItem.Properties.ProviderSpecificDetails.InstanceType == "HyperVReplicaAzure")
            {
                HyperVReplicaAzureFailoverProviderInput hvrAFOInput = 
                    new HyperVReplicaAzureFailoverProviderInput()
                {
                    VaultLocation = "West US",
                };

                string networkId = (protectedItem.Properties.ProviderSpecificDetails as HyperVReplicaAzureReplicationDetails)
                        .SelectedRecoveryAzureNetworkId;
                TestFailoverInputProperties tfoProp = new TestFailoverInputProperties()
                {
                    ProviderSpecificDetails = hvrAFOInput,
                    NetworkType = string.IsNullOrEmpty(networkId) ? null : "VmNetworkAsInput",
                    NetworkId = networkId
                };

                tfoInput.Properties = tfoProp;
            }

            DateTime startTFO = DateTime.UtcNow;
            var tfoOp = client.ReplicationProtectedItem.TestFailover(
                primaryFabric.Name,
                protectionContainer.Name,
                protectedItem.Name, 
                tfoInput, 
                GetRequestHeaders());

            var jobs = MonitoringHelper.GetJobId(MonitoringHelper.TestFailoverJobName, startTFO, client, GetRequestHeaders());

            ResumeJobParamsProperties resProp = new ResumeJobParamsProperties()
            {
                Comments = "Res TFO"
            };

            ResumeJobParams resParam = new ResumeJobParams()
            {
                Properties = resProp
            };

            return client.Jobs.Resume(jobs.Name, resParam, GetRequestHeaders());
        }

        public static ReplicationProtectedItemOperationResponse UnplannedFailover(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer protectionContainer,
            ReplicationProtectedItem protectedItem)
        {
            UnplannedFailoverInput ufoInput = new UnplannedFailoverInput()
            {
                Properties = new UnplannedFailoverInputProperties()
                {
                    ProviderSpecificDetails = new ProviderSpecificFailoverInput()
                }
            };

            if (protectedItem.Properties.ProviderSpecificDetails.InstanceType == "HyperVReplicaAzure")
            {
                HyperVReplicaAzureFailoverProviderInput hvrAFOInput =
                    new HyperVReplicaAzureFailoverProviderInput()
                {
                    VaultLocation = "West US",
                };

                UnplannedFailoverInputProperties ufoProp = new UnplannedFailoverInputProperties()
                {
                    ProviderSpecificDetails = new ProviderSpecificFailoverInput(),
                    SourceSiteOperations = "NotRequired"
                };

                ufoInput.Properties = ufoProp;
            }

            return client.ReplicationProtectedItem.UnplannedFailover(
                primaryFabric.Name,
                protectionContainer.Name,
                protectedItem.Name,
                ufoInput,
                GetRequestHeaders()) as ReplicationProtectedItemOperationResponse;
        }

        #endregion

        #region Policy Operation
        public static CreatePolicyOperationResponse CreateHyperVReplicaAzurePolicy(
            this SiteRecoveryManagementClient client,
            string armResourceName,
            string storageAccountArmId)
        {
            HyperVReplicaAzurePolicyInput hvrAPolicy = new HyperVReplicaAzurePolicyInput()
            {
                ApplicationConsistentSnapshotFrequencyInHours = 0,
                Encryption = "Disable",
                OnlineIrStartTime = null,
                RecoveryPointHistoryDuration = 0,
                ReplicationInterval = 30,
                StorageAccounts = new List<string>() { storageAccountArmId }
            };

            CreatePolicyInputProperties createInputProp = new CreatePolicyInputProperties()
            {
                ProviderSpecificInput = hvrAPolicy
            };

            CreatePolicyInput policyInput = new CreatePolicyInput()
            {
                Properties = createInputProp
            };

            return (client.Policies.Create(armResourceName, policyInput, GetRequestHeaders()) as CreatePolicyOperationResponse);
        }

        public static CreatePolicyOperationResponse CreateHyperV2012Policy(
            this SiteRecoveryManagementClient client,
            string armResourceName)
        {
            HyperVReplica2012PolicyInput hvrsp1ProfileInput = new HyperVReplica2012PolicyInput()
            {
                ApplicationConsistentSnapshotFrequencyInHours = 0,
                AllowedAuthenticationType = 1,
                Compression = "Enable",
                InitialReplicationMethod = "OverNetwork",
                OnlineReplicationStartTime = null,
                RecoveryPoints = 0,
                ReplicaDeletion = "Required",
                ReplicationPort = 8083
            };

            CreatePolicyInputProperties policySp1CreationProp = new CreatePolicyInputProperties()
            {
                ProviderSpecificInput = hvrsp1ProfileInput
            };

            CreatePolicyInput policySp1CreationInput = new CreatePolicyInput()
            {
                Properties = policySp1CreationProp
            };

            return client.Policies.Create(
                armResourceName, 
                policySp1CreationInput,
                GetRequestHeaders()) as CreatePolicyOperationResponse;
        }

        public static CreatePolicyOperationResponse CreateHyperV2012R2Policy(
            this SiteRecoveryManagementClient client,
            string armResourceName)
        {
            HyperVReplica2012R2PolicyInput hvrProfileInput = new HyperVReplica2012R2PolicyInput()
            {
                ApplicationConsistentSnapshotFrequencyInHours = 0,
                AllowedAuthenticationType = 1,
                Compression = "Enable",
                InitialReplicationMethod = "OverNetwork",
                OnlineReplicationStartTime = null,
                RecoveryPoints = 0,
                ReplicaDeletion = "Required",
                ReplicationPort = 8083,
                ReplicationFrequencyInSeconds = 300
            };

            CreatePolicyInputProperties policyCreationProp = new CreatePolicyInputProperties()
            {
                ProviderSpecificInput = hvrProfileInput
            };

            CreatePolicyInput policyCreationInput = new CreatePolicyInput()
            {
                Properties = policyCreationProp
            };

            return client.Policies.Create(
                armResourceName,
                policyCreationInput,
                GetRequestHeaders()) as CreatePolicyOperationResponse;
        }

        public static LongRunningOperationResponse RemovePolicy(
            this SiteRecoveryManagementClient client,
            string armResourceName)
        {
            return client.Policies.Delete(
                armResourceName,
                GetRequestHeaders());
        }
        #endregion

        #region Storage Classification Operations
        public static StorageClassificationMappingOperationResponse PairStorageClassification(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            StorageClassification primaryClassification,
            StorageClassification recoveryClassification,
            string armResourceName)
        {
            StorageClassificationMappingInputProperties props = new StorageClassificationMappingInputProperties()
            {
                TargetStorageClassificationId = recoveryClassification.Id
            };

            StorageClassificationMappingInput input = new StorageClassificationMappingInput()
            {
                Properties = props
            };

            return client.StorageClassificationMapping.PairStorageClassification(
                primaryFabric.Name,
                primaryClassification.Name,
                armResourceName,
                input,
                GetRequestHeaders()) as StorageClassificationMappingOperationResponse;
        }

        public static LongRunningOperationResponse UnpairStorageClassification(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            StorageClassification primaryClassification,
            string armResourceName)
        {
            return client.StorageClassificationMapping.UnpairStorageClassification(
                primaryFabric.Name,
                primaryClassification.Name,
                armResourceName,
                GetRequestHeaders());
        }
        #endregion

        #region Get Operations

        #region Fabrics
        public static List<Fabric> GetVMMs(
            this SiteRecoveryManagementClient client)
        {
            var fabricList = client.Fabrics.List(GetRequestHeaders());
            List<Fabric> vmms = new List<Fabric>();

            foreach (var fabric in fabricList.Fabrics)
            {
                if (fabric.Properties.CustomDetails.InstanceType == "VMM")
                {
                    vmms.Add(fabric);
                }
            }

            return vmms;
        }

        public static List<Fabric> GetHyperVSites(
            this SiteRecoveryManagementClient client)
        {
            var fabricList = client.Fabrics.List(GetRequestHeaders());
            List<Fabric> sites = new List<Fabric>();

            foreach (var fabric in fabricList.Fabrics)
            {
                if (fabric.Properties.CustomDetails.InstanceType == "HyperVSite")
                {
                    sites.Add(fabric);
                }
            }

            return sites;
        }
        #endregion

        #region Protection Containers
        public static List<ProtectionContainer> GetUnpairedContainers(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric)
        {
            var protectionContainers = client.ProtectionContainer.List(
                primaryFabric.Name,
                GetRequestHeaders());

            return protectionContainers.ProtectionContainers
                .ToList().TakeWhile(item => item.Properties.PairingStatus == "NotPaired").ToList();
        }

        public static List<ProtectionContainer> GetPairedContainers(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric)
        {
            var protectionContainers = client.ProtectionContainer.List(
                primaryFabric.Name,
                GetRequestHeaders());

            return protectionContainers.ProtectionContainers
                .ToList().TakeWhile(item => item.Properties.PairingStatus == "Paired").ToList();
        }
        #endregion

        #region Protectable Items

        public static List<ProtectableItem> GetProtectedItems(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer container)
        {
            List<ProtectableItem> protectableItemList = new List<ProtectableItem>();
            ProtectableItemListResponse protectableItemListResponse = client.ProtectableItem.List(
                primaryFabric.Name, 
                container.Name, 
                "Protected", 
                null, 
                "1000", 
                GetRequestHeaders());
            protectableItemList.AddRange(protectableItemListResponse.ProtectableItems);
            while (protectableItemListResponse.NextLink != null)
            {
                protectableItemListResponse = client.ProtectableItem.ListNext(
                    protectableItemListResponse.NextLink, 
                    GetRequestHeaders());
                protectableItemList.AddRange(protectableItemListResponse.ProtectableItems);
            }

            return protectableItemList;
        }

        public static List<ProtectableItem> GetUnprotectedItems(
            this SiteRecoveryManagementClient client,
            Fabric primaryFabric,
            ProtectionContainer container)
        {
            List<ProtectableItem> protectableItemList = new List<ProtectableItem>();
            ProtectableItemListResponse protectableItemListResponse = client.ProtectableItem.List(
                primaryFabric.Name,
                container.Name,
                "Unprotected",
                null,
                "1000",
                GetRequestHeaders());
            protectableItemList.AddRange(protectableItemListResponse.ProtectableItems);
            while (protectableItemListResponse.NextLink != null)
            {
                protectableItemListResponse = client.ProtectableItem.ListNext(
                    protectableItemListResponse.NextLink,
                    GetRequestHeaders());
                protectableItemList.AddRange(protectableItemListResponse.ProtectableItems);
            }

            return protectableItemList;
        }
        #endregion

        #endregion
    }
}
