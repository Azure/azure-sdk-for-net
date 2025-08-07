// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;
    using TestUtilities;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class PropertyUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly ObjectFactory defaultObjectFactory;
        private readonly ObjectFactory customizedObjectFactory;

        private readonly ObjectComparer objectComparer;
        private readonly IList<ComparerPropertyMapping> proxyPropertyToObjectModelMapping;
        private const int TestRunCount = 1000;

        public PropertyUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;

            //Define the factories
            this.defaultObjectFactory = new ObjectFactory();

            this.proxyPropertyToObjectModelMapping = new List<ComparerPropertyMapping>()
            {
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.CloudPool), "AutoScaleEnabled", "EnableAutoScale"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.CloudPool), "VirtualMachineSize", "VmSize"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.CloudPool), "MaxTasksPerComputeNode", "MaxTasksPerNode"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.CloudPool), "Statistics", "Stats"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.CloudPool), "InterComputeNodeCommunicationEnabled", "EnableInterNodeCommunication"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.CloudPool), "CurrentDedicatedComputeNodes", "CurrentDedicatedNodes"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.CloudPool), "CurrentLowPriorityComputeNodes", "CurrentLowPriorityNodes"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.CloudPool), "TargetDedicatedComputeNodes", "TargetDedicatedNodes"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.CloudPool), "TargetLowPriorityComputeNodes", "TargetLowPriorityNodes"),

                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.PoolAddParameter), "VirtualMachineSize", "VmSize"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.PoolAddParameter), "AutoScaleEnabled", "EnableAutoScale"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.PoolAddParameter), "MaxTasksPerComputeNode", "MaxTasksPerNode"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.PoolAddParameter), "InterComputeNodeCommunicationEnabled", "EnableInterNodeCommunication"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.PoolAddParameter), "TargetDedicatedComputeNodes", "TargetDedicatedNodes"),
                new ComparerPropertyMapping(typeof(CloudPool), typeof(Protocol.Models.PoolAddParameter), "TargetLowPriorityComputeNodes", "TargetLowPriorityNodes"),

                new ComparerPropertyMapping(typeof(PoolSpecification), typeof(Protocol.Models.PoolSpecification), "AutoScaleEnabled", "EnableAutoScale"),
                new ComparerPropertyMapping(typeof(PoolSpecification), typeof(Protocol.Models.PoolSpecification), "VirtualMachineSize", "VmSize"),
                new ComparerPropertyMapping(typeof(PoolSpecification), typeof(Protocol.Models.PoolSpecification), "MaxTasksPerComputeNode", "MaxTasksPerNode"),
                new ComparerPropertyMapping(typeof(PoolSpecification), typeof(Protocol.Models.PoolSpecification), "InterComputeNodeCommunicationEnabled", "EnableInterNodeCommunication"),
                new ComparerPropertyMapping(typeof(PoolSpecification), typeof(Protocol.Models.PoolSpecification), "CurrentDedicatedComputeNodes", "CurrentDedicatedNodes"),
                new ComparerPropertyMapping(typeof(PoolSpecification), typeof(Protocol.Models.PoolSpecification), "CurrentLowPriorityComputeNodes", "CurrentLowPriorityNodes"),
                new ComparerPropertyMapping(typeof(PoolSpecification), typeof(Protocol.Models.PoolSpecification), "TargetDedicatedComputeNodes", "TargetDedicatedNodes"),
                new ComparerPropertyMapping(typeof(PoolSpecification), typeof(Protocol.Models.PoolSpecification), "TargetLowPriorityComputeNodes", "TargetLowPriorityNodes"),

                new ComparerPropertyMapping(typeof(TaskInformation), typeof(Protocol.Models.TaskInformation), "ExecutionInformation", "TaskExecutionInformation"),

                new ComparerPropertyMapping(typeof(AutoPoolSpecification), typeof(Protocol.Models.AutoPoolSpecification), "PoolSpecification", "Pool"),

                new ComparerPropertyMapping(typeof(JobPreparationAndReleaseTaskExecutionInformation), typeof(Protocol.Models.JobPreparationAndReleaseTaskExecutionInformation), "ComputeNodeId", "NodeId"),
                new ComparerPropertyMapping(typeof(JobPreparationAndReleaseTaskExecutionInformation), typeof(Protocol.Models.JobPreparationAndReleaseTaskExecutionInformation), "ComputeNodeUrl", "NodeUrl"),
                new ComparerPropertyMapping(typeof(JobPreparationAndReleaseTaskExecutionInformation), typeof(Protocol.Models.JobPreparationAndReleaseTaskExecutionInformation), "JobPreparationTaskExecutionInformation", "JobPreparationTaskExecutionInfo"),
                new ComparerPropertyMapping(typeof(JobPreparationAndReleaseTaskExecutionInformation), typeof(Protocol.Models.JobPreparationAndReleaseTaskExecutionInformation), "JobReleaseTaskExecutionInformation", "JobReleaseTaskExecutionInfo"),

                new ComparerPropertyMapping(typeof(JobPreparationTaskExecutionInformation), typeof(Protocol.Models.JobPreparationTaskExecutionInformation), "FailureInformation", "FailureInfo"),
                new ComparerPropertyMapping(typeof(JobPreparationTaskExecutionInformation), typeof(Protocol.Models.JobPreparationTaskExecutionInformation), "ContainerInformation", "ContainerInfo"),

                new ComparerPropertyMapping(typeof(JobReleaseTaskExecutionInformation), typeof(Protocol.Models.JobReleaseTaskExecutionInformation), "FailureInformation", "FailureInfo"),
                new ComparerPropertyMapping(typeof(JobReleaseTaskExecutionInformation), typeof(Protocol.Models.JobReleaseTaskExecutionInformation), "ContainerInformation", "ContainerInfo"),

                new ComparerPropertyMapping(typeof(TaskExecutionInformation), typeof(Protocol.Models.TaskExecutionInformation), "FailureInformation", "FailureInfo"),
                new ComparerPropertyMapping(typeof(TaskExecutionInformation), typeof(Protocol.Models.TaskExecutionInformation), "ContainerInformation", "ContainerInfo"),

                new ComparerPropertyMapping(typeof(SubtaskInformation), typeof(Protocol.Models.SubtaskInformation), "FailureInformation", "FailureInfo"),
                new ComparerPropertyMapping(typeof(SubtaskInformation), typeof(Protocol.Models.SubtaskInformation), "ContainerInformation", "ContainerInfo"),

                new ComparerPropertyMapping(typeof(StartTaskInformation), typeof(Protocol.Models.StartTaskInformation), "FailureInformation", "FailureInfo"),
                new ComparerPropertyMapping(typeof(StartTaskInformation), typeof(Protocol.Models.StartTaskInformation), "ContainerInformation", "ContainerInfo"),

                new ComparerPropertyMapping(typeof(PoolStatistics), typeof(Protocol.Models.PoolStatistics), "UsageStatistics", "UsageStats"),
                new ComparerPropertyMapping(typeof(PoolStatistics), typeof(Protocol.Models.PoolStatistics), "ResourceStatistics", "ResourceStats"),

                new ComparerPropertyMapping(typeof(JobStatistics), typeof(Protocol.Models.JobStatistics), "UserCpuTime", "UserCPUTime"),
                new ComparerPropertyMapping(typeof(JobStatistics), typeof(Protocol.Models.JobStatistics), "KernelCpuTime", "KernelCPUTime"),
                new ComparerPropertyMapping(typeof(JobStatistics), typeof(Protocol.Models.JobStatistics), "SucceededTaskCount", "NumSucceededTasks"),
                new ComparerPropertyMapping(typeof(JobStatistics), typeof(Protocol.Models.JobStatistics), "FailedTaskCount", "NumFailedTasks"),
                new ComparerPropertyMapping(typeof(JobStatistics), typeof(Protocol.Models.JobStatistics), "TaskRetryCount", "NumTaskRetries"),

                new ComparerPropertyMapping(typeof(JobScheduleStatistics), typeof(Protocol.Models.JobScheduleStatistics), "UserCpuTime", "UserCPUTime"),
                new ComparerPropertyMapping(typeof(JobScheduleStatistics), typeof(Protocol.Models.JobScheduleStatistics), "KernelCpuTime", "KernelCPUTime"),
                new ComparerPropertyMapping(typeof(JobScheduleStatistics), typeof(Protocol.Models.JobScheduleStatistics), "SucceededTaskCount", "NumSucceededTasks"),
                new ComparerPropertyMapping(typeof(JobScheduleStatistics), typeof(Protocol.Models.JobScheduleStatistics), "FailedTaskCount", "NumFailedTasks"),
                new ComparerPropertyMapping(typeof(JobScheduleStatistics), typeof(Protocol.Models.JobScheduleStatistics), "TaskRetryCount", "NumTaskRetries"),

                new ComparerPropertyMapping(typeof(ResourceStatistics), typeof(Protocol.Models.ResourceStatistics), "AverageCpuPercentage", "AvgCPUPercentage"),
                new ComparerPropertyMapping(typeof(ResourceStatistics), typeof(Protocol.Models.ResourceStatistics), "AverageMemoryGiB", "AvgMemoryGiB"),
                new ComparerPropertyMapping(typeof(ResourceStatistics), typeof(Protocol.Models.ResourceStatistics), "AverageDiskGiB", "AvgDiskGiB"),

                new ComparerPropertyMapping(typeof(TaskStatistics), typeof(Protocol.Models.TaskStatistics), "UserCpuTime", "UserCPUTime"),
                new ComparerPropertyMapping(typeof(TaskStatistics), typeof(Protocol.Models.TaskStatistics), "KernelCpuTime", "KernelCPUTime"),

                new ComparerPropertyMapping(typeof(CloudJob), typeof(Protocol.Models.CloudJob), "PoolInformation", "PoolInfo"),
                new ComparerPropertyMapping(typeof(CloudJob), typeof(Protocol.Models.CloudJob), "ExecutionInformation", "ExecutionInfo"),
                new ComparerPropertyMapping(typeof(CloudJob), typeof(Protocol.Models.CloudJob), "Statistics", "Stats"),

                new ComparerPropertyMapping(typeof(CloudJob), typeof(Protocol.Models.JobAddParameter), "PoolInformation", "PoolInfo"),

                new ComparerPropertyMapping(typeof(JobSpecification), typeof(Protocol.Models.JobSpecification), "PoolInformation", "PoolInfo"),

                new ComparerPropertyMapping(typeof(CloudJobSchedule), typeof(Protocol.Models.CloudJobSchedule), "ExecutionInformation", "ExecutionInfo"),
                new ComparerPropertyMapping(typeof(CloudJobSchedule), typeof(Protocol.Models.CloudJobSchedule), "Statistics", "Stats"),

                new ComparerPropertyMapping(typeof(CloudTask), typeof(Protocol.Models.CloudTask), "AffinityInformation", "AffinityInfo"),
                new ComparerPropertyMapping(typeof(CloudTask), typeof(Protocol.Models.CloudTask), "ExecutionInformation", "ExecutionInfo"),
                new ComparerPropertyMapping(typeof(CloudTask), typeof(Protocol.Models.CloudTask), "ComputeNodeInformation", "NodeInfo"),
                new ComparerPropertyMapping(typeof(CloudTask), typeof(Protocol.Models.CloudTask), "Statistics", "Stats"),

                new ComparerPropertyMapping(typeof(CloudTask), typeof(Protocol.Models.TaskAddParameter), "AffinityInformation", "AffinityInfo"),
                new ComparerPropertyMapping(typeof(CloudTask), typeof(Protocol.Models.TaskAddParameter), "ComputeNodeInformation", "NodeInfo"),

                new ComparerPropertyMapping(typeof(ExitConditions), typeof(Protocol.Models.ExitConditions), "Default", "DefaultProperty"),

                new ComparerPropertyMapping(typeof(TaskInformation), typeof(Protocol.Models.TaskInformation), "ExecutionInformation", "ExecutionInfo"),

                new ComparerPropertyMapping(typeof(ComputeNode), typeof(Protocol.Models.ComputeNode), "IPAddress", "IpAddress"),
                new ComparerPropertyMapping(typeof(ComputeNode), typeof(Protocol.Models.ComputeNode), "VirtualMachineSize", "VmSize"),
                new ComparerPropertyMapping(typeof(ComputeNode), typeof(Protocol.Models.ComputeNode), "StartTaskInformation", "StartTaskInfo"),
                new ComparerPropertyMapping(typeof(ComputeNode), typeof(Protocol.Models.ComputeNode), "NodeAgentInformation", "NodeAgentInfo"),

                new ComparerPropertyMapping(typeof(ComputeNodeInformation), typeof(Protocol.Models.ComputeNodeInformation), "ComputeNodeId", "NodeId"),
                new ComparerPropertyMapping(typeof(ComputeNodeInformation), typeof(Protocol.Models.ComputeNodeInformation), "ComputeNodeUrl", "NodeUrl"),

                new ComparerPropertyMapping(typeof(JobPreparationTask), typeof(Protocol.Models.JobPreparationTask), "RerunOnComputeNodeRebootAfterSuccess", "RerunOnNodeRebootAfterSuccess"),

                new ComparerPropertyMapping(typeof(ImageReference), typeof(Protocol.Models.ImageReference), "SkuId", "Sku"),

                new ComparerPropertyMapping(typeof(VirtualMachineConfiguration), typeof(Protocol.Models.VirtualMachineConfiguration), "NodeAgentSkuId", "NodeAgentSKUId"),
                new ComparerPropertyMapping(typeof(VirtualMachineConfiguration), typeof(Protocol.Models.VirtualMachineConfiguration), "OSDisk", "OsDisk"),

                new ComparerPropertyMapping(typeof(TaskSchedulingPolicy), typeof(Protocol.Models.TaskSchedulingPolicy), "ComputeNodeFillType", "NodeFillType"),

                new ComparerPropertyMapping(typeof(PoolEndpointConfiguration), typeof(Protocol.Models.PoolEndpointConfiguration), "InboundNatPools", "InboundNATPools"),
                new ComparerPropertyMapping(typeof(InboundEndpoint), typeof(Protocol.Models.InboundEndpoint), "PublicFqdn", "PublicFQDN"),

                new ComparerPropertyMapping(typeof(ImageInformation), typeof(Protocol.Models.ImageInformation), "NodeAgentSkuId", "NodeAgentSKUId"),
                new ComparerPropertyMapping(typeof(ImageInformation), typeof(Protocol.Models.ImageInformation), "OSType", "OsType"),
            };

            Random rand = new Random();

            object omTaskRangeBuilder()
            {
                int rangeLimit1 = rand.Next(0, int.MaxValue);
                int rangeLimit2 = rand.Next(0, int.MaxValue);

                return new TaskIdRange(Math.Min(rangeLimit1, rangeLimit2), Math.Max(rangeLimit1, rangeLimit2));
            }

            object iFileStagingProviderBuilder() => null;

            object batchClientBehaviorBuilder() => null;

            object taskRangeBuilder()
            {
                int rangeLimit1 = rand.Next(0, int.MaxValue);
                int rangeLimit2 = rand.Next(0, int.MaxValue);

                return new Protocol.Models.TaskIdRange(Math.Min(rangeLimit1, rangeLimit2), Math.Max(rangeLimit1, rangeLimit2));
            }

            ObjectFactoryConstructionSpecification certificateReferenceSpecification = new ObjectFactoryConstructionSpecification(
                typeof(Protocol.Models.CertificateReference),
                () => BuildCertificateReference(rand));

            ObjectFactoryConstructionSpecification authenticationTokenSettingsSpecification = new ObjectFactoryConstructionSpecification(
                typeof(Protocol.Models.AuthenticationTokenSettings),
                () => BuildAuthenticationTokenSettings(rand));

            ObjectFactoryConstructionSpecification taskRangeSpecification = new ObjectFactoryConstructionSpecification(
                typeof(Protocol.Models.TaskIdRange),
                taskRangeBuilder);

            ObjectFactoryConstructionSpecification omTaskRangeSpecification = new ObjectFactoryConstructionSpecification(
                typeof(TaskIdRange),
                omTaskRangeBuilder);

            ObjectFactoryConstructionSpecification batchClientBehaviorSpecification = new ObjectFactoryConstructionSpecification(
                typeof(BatchClientBehavior),
                batchClientBehaviorBuilder);

            ObjectFactoryConstructionSpecification fileStagingProviderSpecification = new ObjectFactoryConstructionSpecification(
                typeof(IFileStagingProvider),
                iFileStagingProviderBuilder);

            this.customizedObjectFactory = new ObjectFactory(new List<ObjectFactoryConstructionSpecification>
                {
                    certificateReferenceSpecification,
                    authenticationTokenSettingsSpecification,
                    taskRangeSpecification,
                    omTaskRangeSpecification,
                    fileStagingProviderSpecification,
                    batchClientBehaviorSpecification,
                });

            // We need a custom comparison rule for certificate references because they are a different type in the proxy vs
            // the object model (string in proxy, flags enum in OM
            ComparisonRule certificateReferenceComparisonRule = ComparisonRule.Create<CertificateVisibility?, List<Protocol.Models.CertificateVisibility>>(
                typeof(CertificateReference),
                typeof(Protocol.Models.CertificateReference), // This is the type that hold the target property  
                (visibility, proxyVisibility) =>
                {
                    CertificateVisibility? convertedProxyVisibility = UtilitiesInternal.ParseCertificateVisibility(proxyVisibility);

                    //Treat null as None for the purposes of comparison:
                    bool areEqual = convertedProxyVisibility == visibility || !visibility.HasValue && convertedProxyVisibility == CertificateVisibility.None;

                    return areEqual ? ObjectComparer.CheckEqualityResult.True : ObjectComparer.CheckEqualityResult.False("Certificate visibility doesn't match");
                },
                type1PropertyName: "Visibility",
                type2PropertyName: "Visibility");

            ComparisonRule accessScopeComparisonRule = ComparisonRule.Create<AccessScope, List<Protocol.Models.AccessScope>>(
                typeof(AuthenticationTokenSettings),
                typeof(Protocol.Models.AuthenticationTokenSettings),  // This is the type that hold the target property  
                (scope, proxyVisibility) =>
                {
                    AccessScope convertedProxyAccessScope = UtilitiesInternal.ParseAccessScope(proxyVisibility);

                    //Treat null as None for the purposes of comparison:
                    bool areEqual = convertedProxyAccessScope == scope || convertedProxyAccessScope == AccessScope.None;

                    return areEqual ? ObjectComparer.CheckEqualityResult.True : ObjectComparer.CheckEqualityResult.False("AccessScope doesn't match");
                },
                type1PropertyName: "Access",
                type2PropertyName: "Access");

            this.objectComparer = new ObjectComparer(
                comparisonRules: new List<ComparisonRule>() { certificateReferenceComparisonRule, accessScopeComparisonRule },
                propertyMappings: this.proxyPropertyToObjectModelMapping,
                shouldThrowOnPropertyReadException: e => !(e.InnerException is InvalidOperationException) || !e.InnerException.Message.Contains("while the object is in the Unbound"));
        }

        private Protocol.Models.CertificateReference BuildCertificateReference(Random rand)
        {
            //Build cert visibility (which is a required property)
            IList values = Enum.GetValues(typeof(CertificateVisibility));
            IList<object> valuesToSelect = new List<object>();

            foreach (object value in values)
            {
                valuesToSelect.Add(value);
            }

            int valuesToPick = rand.Next(0, values.Count);
            CertificateVisibility? visibility = null;

            // If valuesToPick is 0, we want to allow visibility to be null (since null is a valid value)
            // so only set visibility to be None if valuesToPick > 0
            if (valuesToPick > 0)
            {
                visibility = CertificateVisibility.None;
                for (int i = 0; i < valuesToPick; i++)
                {
                    int selectedValueIndex = rand.Next(valuesToSelect.Count);
                    object selectedValue = valuesToSelect[selectedValueIndex];
                    visibility |= (CertificateVisibility)selectedValue;

                    valuesToSelect.RemoveAt(selectedValueIndex);
                }
            }

            Protocol.Models.CertificateReference reference = this.defaultObjectFactory.GenerateNew<Protocol.Models.CertificateReference>();

            //Set certificate visibility since it is required
            reference.Visibility = visibility == null ? null : UtilitiesInternal.CertificateVisibilityToList(visibility.Value);

            return reference;
        }

        private Protocol.Models.AuthenticationTokenSettings BuildAuthenticationTokenSettings(Random rand)
        {
            //Build access scope (which is a required property)
            IList values = Enum.GetValues(typeof(AccessScope));
            IList<object> valuesToSelect = new List<object>();

            foreach (object value in values)
            {
                valuesToSelect.Add(value);
            }

            int valuesToPick = rand.Next(0, values.Count);
            AccessScope? accessScope = null;

            // If valuesToPick is 0, we want to allow access scope to be null (since null is a valid value)
            // so only set access scope to be None if valuesToPick > 0
            if (valuesToPick > 0)
            {
                accessScope = AccessScope.None;
                for (int i = 0; i < valuesToPick; i++)
                {
                    int selectedValueIndex = rand.Next(valuesToSelect.Count);
                    object selectedValue = valuesToSelect[selectedValueIndex];
                    accessScope |= (AccessScope)selectedValue;

                    valuesToSelect.RemoveAt(selectedValueIndex);
                }
            }

            Protocol.Models.AuthenticationTokenSettings tokenSettings = this.defaultObjectFactory.GenerateNew<Protocol.Models.AuthenticationTokenSettings>();

            //Set access scope since it is required
            tokenSettings.Access = accessScope == null ? null : UtilitiesInternal.AccessScopeToList(accessScope.Value);

            return tokenSettings;
        }

        #region Reflection based tests

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestRandomBoundCloudPoolProperties()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            for (int i = 0; i < TestRunCount; i++)
            {
                Protocol.Models.CloudPool poolModel =
                    this.customizedObjectFactory.GenerateNew<Protocol.Models.CloudPool>();

                CloudPool boundPool = new CloudPool(client, poolModel, client.CustomBehaviors);
                ObjectComparer.CheckEqualityResult result = this.objectComparer.CheckEquality(boundPool, poolModel);
                Assert.True(result.Equal, result.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestRandomBoundCloudJobProperties()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            for (int i = 0; i < TestRunCount; i++)
            {
                Protocol.Models.CloudJob jobModel =
                    this.customizedObjectFactory.GenerateNew<Protocol.Models.CloudJob>();

                CloudJob boundJob = new CloudJob(client.JobOperations.ParentBatchClient, jobModel, client.CustomBehaviors);

                ObjectComparer.CheckEqualityResult result = this.objectComparer.CheckEquality(boundJob, jobModel);
                Assert.True(result.Equal, result.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestRandomBoundCloudJobScheduleProperties()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            for (int i = 0; i < TestRunCount; i++)
            {
                Protocol.Models.CloudJobSchedule jobScheduleModel =
                    this.customizedObjectFactory.GenerateNew<Protocol.Models.CloudJobSchedule>();

                CloudJobSchedule boundJobSchedule = new CloudJobSchedule(client, jobScheduleModel, client.CustomBehaviors);

                ObjectComparer.CheckEqualityResult result = this.objectComparer.CheckEquality(boundJobSchedule, jobScheduleModel);
                Assert.True(result.Equal, result.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestRandomBoundCloudTaskProperties()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            for (int i = 0; i < TestRunCount; i++)
            {
                Protocol.Models.CloudTask taskModel = this.customizedObjectFactory.GenerateNew<Protocol.Models.CloudTask>();

                CloudTask boundTask = new CloudTask(client, "Foo", taskModel, client.CustomBehaviors);

                ObjectComparer.CheckEqualityResult result = this.objectComparer.CheckEquality(boundTask, taskModel);
                Assert.True(result.Equal, result.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestRandomBoundComputeNodeProperties()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            for (int i = 0; i < TestRunCount; i++)
            {
                Protocol.Models.ComputeNode computeNodeModel =
                    this.customizedObjectFactory.GenerateNew<Protocol.Models.ComputeNode>();

                ComputeNode boundComputeNode = new ComputeNode(client, "Foo", computeNodeModel, client.CustomBehaviors);

                ObjectComparer.CheckEqualityResult result = this.objectComparer.CheckEquality(boundComputeNode, computeNodeModel);
                Assert.True(result.Equal, result.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestRandomBoundCertificateProperties()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            for (int i = 0; i < TestRunCount; i++)
            {
                Protocol.Models.Certificate certificateModel =
                    this.customizedObjectFactory.GenerateNew<Protocol.Models.Certificate>();

                Certificate boundCertificate = new Certificate(client, certificateModel, client.CustomBehaviors);

                ObjectComparer.CheckEqualityResult result = this.objectComparer.CheckEquality(boundCertificate, certificateModel);
                Assert.True(result.Equal, result.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestRandomBoundImageInformationProperties()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            for (int i = 0; i < TestRunCount; i++)
            {
                Protocol.Models.ImageInformation imageModel =
                    this.customizedObjectFactory.GenerateNew<Protocol.Models.ImageInformation>();

                ImageInformation boundImageInfo = new ImageInformation(imageModel);
                ObjectComparer.CheckEqualityResult result = this.objectComparer.CheckEquality(boundImageInfo, imageModel);
                Assert.True(result.Equal, result.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestRandomBoundPrepReleaseTaskExecutionInformationProperties()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            for (int i = 0; i < TestRunCount; i++)
            {
                Protocol.Models.JobPreparationAndReleaseTaskExecutionInformation jobPrepReleaseExecutionInfo =
                    this.customizedObjectFactory.GenerateNew<Protocol.Models.JobPreparationAndReleaseTaskExecutionInformation>();

                JobPreparationAndReleaseTaskExecutionInformation boundJobPrepReleaseExecutionInfo =
                    new JobPreparationAndReleaseTaskExecutionInformation(jobPrepReleaseExecutionInfo);

                ObjectComparer.CheckEqualityResult result = this.objectComparer.CheckEquality(boundJobPrepReleaseExecutionInfo, jobPrepReleaseExecutionInfo);
                Assert.True(result.Equal, result.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestIReadOnlyMakesPropertiesReadOnly()
        {
            //Use reflection to traverse the set of objects in the DLL, find those that implement IReadOnly, and ensure that IReadOnly works for all
            //properties of those objects.
            Type iReadOnlyType = typeof(IReadOnly);

            List<Type> typesWithIReadOnlyBase = GetTypesWhichImplementInterface(iReadOnlyType.GetTypeInfo().Assembly, iReadOnlyType, requirePublicConstructor: false).ToList();
            foreach (Type type in typesWithIReadOnlyBase)
            {
                this.testOutputHelper.WriteLine("Reading/Setting properties of type: {0}", type.ToString());

                //Create an instance of that type
                IReadOnly objectUnderTest = this.customizedObjectFactory.CreateInstance<IReadOnly>(type);

                //Mark this object as readonly
                objectUnderTest.IsReadOnly = true;

                //Get the properties for the object under test
                IEnumerable<PropertyInfo> properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo property in properties.Where(p => p.Name != "CustomBehaviors"))
                {
                    if (property.CanWrite)
                    {
                        this.testOutputHelper.WriteLine("Attempting to write property: {0}", property.Name);

                        //Attempt to write
                        //Note that for value types null is mapped to default(valueType).  See: https://msdn.microsoft.com/en-us/library/xb5dd1f1%28v=vs.110%29.aspx
                        TargetInvocationException e = Assert.Throws<TargetInvocationException>(() => property.SetValue(objectUnderTest, null));
                        Assert.IsType<InvalidOperationException>(e.InnerException);
                    }

                    if (property.CanRead)
                    {
                        this.testOutputHelper.WriteLine("Attempting to read property: {0}", property.Name);

                        //Attempt to read
                        try
                        {
                            property.GetValue(objectUnderTest);
                        }
                        catch (TargetInvocationException e)
                        {
                            if (e.InnerException is InvalidOperationException inner)
                            {
                                if (!inner.Message.Contains("while the object is in the Unbound state"))
                                {
                                    throw;
                                }
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }

                this.testOutputHelper.WriteLine(string.Empty);
            }

            Assert.True(typesWithIReadOnlyBase.Count > 0);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestGetTransportObjectDoesntMissProperties()
        {
            const int objectsToValidate = 100;
            //Use reflection to traverse the set of objects in the DLL, find those that implement ITransportObjectProvider, ensure that GetTransportObject works for all
            //properties of those objects.
            Type iTransportObjectProviderType = typeof(ITransportObjectProvider<>);

            IEnumerable<Type> types = GetTypesWhichImplementInterface(iTransportObjectProviderType.GetTypeInfo().Assembly, iTransportObjectProviderType, requirePublicConstructor: false);

            foreach (Type type in types)
            {
                this.testOutputHelper.WriteLine("Generating {0} objects of type {1}", objectsToValidate, type);
                for (int i = 0; i < objectsToValidate; i++)
                {
                    object o = this.customizedObjectFactory.GenerateNew(type);
                    Type concreteInterfaceType = o.GetType().GetInterfaces().First(iFace =>
                        iFace.GetTypeInfo().IsGenericType &&
                        iFace.GetGenericTypeDefinition() == iTransportObjectProviderType);
                    //object protocolObject = concreteInterfaceType.GetMethod("GetTransportObject").Invoke(o, BindingFlags.Instance | BindingFlags.NonPublic, null, null, null);
                    object protocolObject = concreteInterfaceType.GetMethod("GetTransportObject").Invoke(o, null);

                    ObjectComparer.CheckEqualityResult result = this.objectComparer.CheckEquality(o, protocolObject);
                    Assert.True(result.Equal, result.Message);
                }
            }
        }

        private static IEnumerable<Type> GetTypesWhichImplementInterface(Assembly assembly, Type interfaceType, bool requirePublicConstructor)
        {
            Func<Type, bool> requirePublicConstructorFunc;
            if (requirePublicConstructor)
            {
                requirePublicConstructorFunc = (t => t.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Any());
            }
            else
            {
                requirePublicConstructorFunc = (t => true);
            }

            if (!interfaceType.GetTypeInfo().IsGenericType)
            {
                return assembly.GetTypes().Where(t =>
                    interfaceType.IsAssignableFrom(t) &&
                    !t.GetTypeInfo().IsInterface &&
                    t.GetTypeInfo().IsVisible &&
                    requirePublicConstructorFunc(t));
            }
            else
            {
                return assembly.GetTypes().Where(t =>
                    t.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == interfaceType) &&
                    !t.GetTypeInfo().IsInterface &&
                    t.GetTypeInfo().IsVisible &&
                    requirePublicConstructorFunc(t));
            }
        }

        #endregion

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void Bug1432987CloudTaskTaskConstraints()
        {
            using BatchClient batchCli = ClientUnitTestCommon.CreateDummyClient();
            CloudTask badTask = new CloudTask("bug1432987TaskConstraints", "hostname");

            TaskConstraints isThisBroken = badTask.Constraints;
            TaskConstraints trySettingThem = new TaskConstraints(null, null, null);

            badTask.Constraints = trySettingThem;

            TaskConstraints readThemBack = badTask.Constraints;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestCertificateReferenceVisibilityGet()
        {
            CertificateReference certificateReference = new CertificateReference();
            Assert.Null(certificateReference.Visibility);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestResourceFilePropertiesArePropagatedToTransportObject()
        {
            const string filePath = "Foo";
            const string blobPath = "Bar";
            const string mode = "0700";

            ResourceFile resourceFile = ResourceFile.FromUrl(blobPath, filePath, mode);
            Protocol.Models.ResourceFile protoFile = resourceFile.GetTransportObject();

            Assert.Equal(filePath, protoFile.FilePath);
            Assert.Equal(blobPath, protoFile.HttpUrl);
            Assert.Equal(mode, protoFile.FileMode);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestAutoPoolSpecificationUnboundConstraints()
        {
            const string idPrefix = "Bar";
            const bool keepAlive = false;
            const PoolLifetimeOption poolLifetimeOption = PoolLifetimeOption.Job;
            PoolSpecification poolSpecification = new PoolSpecification();

            AutoPoolSpecification autoPoolSpecification = new AutoPoolSpecification();

            //Properties should start out as their defaults
            Assert.Equal(default, autoPoolSpecification.AutoPoolIdPrefix);
            Assert.Equal(default, autoPoolSpecification.KeepAlive);
            Assert.Equal(default, autoPoolSpecification.PoolLifetimeOption);
            Assert.Equal(default, autoPoolSpecification.PoolSpecification);

            Assert.False(((IModifiable)autoPoolSpecification).HasBeenModified);

            //Should be able to set all properties

            autoPoolSpecification.AutoPoolIdPrefix = idPrefix;
            autoPoolSpecification.KeepAlive = keepAlive;
            autoPoolSpecification.PoolLifetimeOption = poolLifetimeOption;
            autoPoolSpecification.PoolSpecification = poolSpecification;

            Assert.True(((IModifiable)autoPoolSpecification).HasBeenModified);

            Protocol.Models.AutoPoolSpecification protoAutoPoolSpecification = autoPoolSpecification.GetTransportObject();
            ((IReadOnly)autoPoolSpecification).IsReadOnly = true; //Forces read-onlyness

            //After MarkReadOnly, the original object should be unsettable
            Assert.Throws<InvalidOperationException>(() => autoPoolSpecification.AutoPoolIdPrefix = "bar");
            Assert.Throws<InvalidOperationException>(() => autoPoolSpecification.KeepAlive = false);
            Assert.Throws<InvalidOperationException>(() => autoPoolSpecification.PoolLifetimeOption = PoolLifetimeOption.JobSchedule);
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(() => autoPoolSpecification.PoolSpecification = new PoolSpecification());
            this.testOutputHelper.WriteLine(e.ToString());

            //After GetProtocolObject, the child objects should be unreadable too
            Assert.Throws<InvalidOperationException>(() => poolSpecification.TaskSlotsPerNode = 4);

            //The original data should be on the protocol specification
            Assert.Equal(idPrefix, protoAutoPoolSpecification.AutoPoolIdPrefix);
            Assert.Equal(keepAlive, protoAutoPoolSpecification.KeepAlive);
            Assert.Equal(poolLifetimeOption, UtilitiesInternal.MapEnum<Protocol.Models.PoolLifetimeOption, PoolLifetimeOption>(protoAutoPoolSpecification.PoolLifetimeOption));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestAutoPoolSpecificationBoundConstraints()
        {
            Protocol.Models.AutoPoolSpecification protoAutoPoolSpecification = new Protocol.Models.AutoPoolSpecification
            {
                KeepAlive = true,
                PoolLifetimeOption = Protocol.Models.PoolLifetimeOption.JobSchedule,
                AutoPoolIdPrefix = "Matt",
                Pool = new Protocol.Models.PoolSpecification
                {
                    VirtualMachineConfiguration = new Protocol.Models.VirtualMachineConfiguration(imageReference: new Protocol.Models.ImageReference(), nodeAgentSKUId: "df"),
                    ResizeTimeout = TimeSpan.FromDays(1),
                    StartTask = new Protocol.Models.StartTask
                    {
                        CommandLine = "Bar"
                    }
                }
            };

            AutoPoolSpecification autoPoolSpecification = new AutoPoolSpecification(protoAutoPoolSpecification);

            //Assert that the wrapped properties are equal as we expect
            Assert.Equal(protoAutoPoolSpecification.AutoPoolIdPrefix, autoPoolSpecification.AutoPoolIdPrefix);
            Assert.Equal(protoAutoPoolSpecification.KeepAlive, autoPoolSpecification.KeepAlive);
            Assert.Equal(UtilitiesInternal.MapEnum<Protocol.Models.PoolLifetimeOption, PoolLifetimeOption>(protoAutoPoolSpecification.PoolLifetimeOption), autoPoolSpecification.PoolLifetimeOption);

            Assert.NotNull(autoPoolSpecification.PoolSpecification);
            Assert.NotNull(protoAutoPoolSpecification.Pool.VirtualMachineConfiguration);

            Assert.Equal(protoAutoPoolSpecification.Pool.VirtualMachineConfiguration.NodeAgentSKUId, autoPoolSpecification.PoolSpecification.VirtualMachineConfiguration.NodeAgentSkuId);
            Assert.Equal(protoAutoPoolSpecification.Pool.ResizeTimeout, autoPoolSpecification.PoolSpecification.ResizeTimeout);

            Assert.NotNull(autoPoolSpecification.PoolSpecification.StartTask);
            Assert.Equal(protoAutoPoolSpecification.Pool.StartTask.CommandLine, autoPoolSpecification.PoolSpecification.StartTask.CommandLine);

            //When we change a property on the underlying object PoolSpecification, AutoPoolSpecification should notice the change
            Assert.False(((IModifiable)autoPoolSpecification).HasBeenModified);

            autoPoolSpecification.PoolSpecification.ResizeTimeout = TimeSpan.FromSeconds(122);

            Assert.True(((IModifiable)autoPoolSpecification).HasBeenModified);
        }
    }
}
