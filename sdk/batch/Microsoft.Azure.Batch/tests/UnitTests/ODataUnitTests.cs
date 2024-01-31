// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Protocol=Microsoft.Azure.Batch.Protocol;

    public class ODataUnitTests
    {
        private static readonly ODATADetailLevel FullDetailLevel = new ODATADetailLevel(
            filterClause: "Foo",
            selectClause: "Bar",
            expandClause: "Baz");

        private static readonly ODATADetailLevel FilterSelectDetailLevel = new ODATADetailLevel(
            filterClause: "Foo",
            selectClause: "Bar");

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanUseODataPredicatesOnTaskListWithMultiplePages()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            client.CustomBehaviors.Add(new Protocol.RequestInterceptor(
                req => VerifyODataClausesAndReturnMultiplePages<
                    Protocol.Models.CloudTask,
                    Protocol.Models.TaskListOptions,
                    Protocol.Models.TaskListNextOptions,
                    Protocol.Models.TaskListHeaders>(req, FullDetailLevel)));

            IEnumerable<CloudTask> tasks = client.JobOperations.ListTasks(
                "Foo",
                FullDetailLevel);

            Assert.Empty(tasks.ToList());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanUseODataPredicatesOnJobListWithMultiplePages()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            client.CustomBehaviors.Add(new Protocol.RequestInterceptor(
                req => VerifyODataClausesAndReturnMultiplePages<
                    Protocol.Models.CloudJob,
                    Protocol.Models.JobListOptions,
                    Protocol.Models.JobListNextOptions,
                    Protocol.Models.JobListHeaders>(req, FullDetailLevel)));

            IEnumerable<CloudJob> jobs = client.JobOperations.ListJobs(
                FullDetailLevel);

            Assert.Empty(jobs.ToList());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanUseODataPredicatesOnJobScheduleListWithMultiplePages()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            client.CustomBehaviors.Add(new Protocol.RequestInterceptor(
                req => VerifyODataClausesAndReturnMultiplePages<
                    Protocol.Models.CloudJobSchedule,
                    Protocol.Models.JobScheduleListOptions,
                    Protocol.Models.JobScheduleListNextOptions,
                    Protocol.Models.JobScheduleListHeaders>(req, FullDetailLevel)));

            IEnumerable<CloudJobSchedule> jobSchedules = client.JobScheduleOperations.ListJobSchedules(
                FullDetailLevel);

            Assert.Empty(jobSchedules.ToList());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanUseODataPredicatesOnJobFromJobScheduleListWithMultiplePages()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            client.CustomBehaviors.Add(new Protocol.RequestInterceptor(
                req => VerifyODataClausesAndReturnMultiplePages<
                    Protocol.Models.CloudJob,
                    Protocol.Models.JobListFromJobScheduleOptions,
                    Protocol.Models.JobListFromJobScheduleNextOptions,
                    Protocol.Models.JobListFromJobScheduleHeaders>(req, FullDetailLevel)));

            IEnumerable<CloudJob> jobs = client.JobScheduleOperations.ListJobs(
                "Foo",
                FullDetailLevel);

            Assert.Empty(jobs.ToList());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanUseODataPredicatesOnPoolListWithMultiplePages()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            client.CustomBehaviors.Add(new Protocol.RequestInterceptor(
                req => VerifyODataClausesAndReturnMultiplePages<
                    Protocol.Models.CloudPool,
                    Protocol.Models.PoolListOptions,
                    Protocol.Models.PoolListNextOptions,
                    Protocol.Models.PoolListHeaders>(req, FullDetailLevel)));

            IEnumerable<CloudPool> pools = client.PoolOperations.ListPools(
                FullDetailLevel);

            Assert.Empty(pools.ToList());
        }


        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanUseODataPredicatesOnCertificateListWithMultiplePages()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            client.CustomBehaviors.Add(new Protocol.RequestInterceptor(
                req => VerifyODataClausesAndReturnMultiplePages<
                    Protocol.Models.Certificate,
                    Protocol.Models.CertificateListOptions,
                    Protocol.Models.CertificateListNextOptions,
                    Protocol.Models.CertificateListHeaders>(req, FilterSelectDetailLevel)));

#pragma warning disable CS0618 // Type or member is obsolete
            IEnumerable<Certificate> certificates = client.CertificateOperations.ListCertificates(
                FilterSelectDetailLevel);
#pragma warning restore CS0618 // Type or member is obsolete

            Assert.Empty(certificates.ToList());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanUseODataPredicatesOnComputeNodeListWithMultiplePages()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            client.CustomBehaviors.Add(new Protocol.RequestInterceptor(
                req => VerifyODataClausesAndReturnMultiplePages<
                    Protocol.Models.ComputeNode,
                    Protocol.Models.ComputeNodeListOptions,
                    Protocol.Models.ComputeNodeListNextOptions,
                    Protocol.Models.ComputeNodeListHeaders>(req, FilterSelectDetailLevel)));

            IEnumerable<ComputeNode> nodes = client.PoolOperations.ListComputeNodes(
                "Foo",
                FilterSelectDetailLevel);

            Assert.Empty(nodes.ToList());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanUseODataPredicatesOnJobPrepAndReleaseStatusListWithMultiplePages()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            client.JobOperations.CustomBehaviors.Add(new Protocol.RequestInterceptor(
                req => VerifyODataClausesAndReturnMultiplePages<
                    Protocol.Models.JobPreparationAndReleaseTaskExecutionInformation,
                    Protocol.Models.JobListPreparationAndReleaseTaskStatusOptions,
                    Protocol.Models.JobListPreparationAndReleaseTaskStatusNextOptions,
                    Protocol.Models.JobListPreparationAndReleaseTaskStatusHeaders>(req, FilterSelectDetailLevel)));

            IEnumerable<JobPreparationAndReleaseTaskExecutionInformation> jobPrepAndReleaseInfo = client.JobOperations.ListJobPreparationAndReleaseTaskStatus(
                "Foo",
                FilterSelectDetailLevel);

            Assert.Empty(jobPrepAndReleaseInfo.ToList());
        }

        private static void VerifyODataClausesAndReturnMultiplePages<TPage, TListOptions, TListNextOptions, THeaders>(Protocol.IBatchRequest req, ODATADetailLevel expectedDetailLevel)
            where TListOptions : Protocol.Models.IOptions, new()
            where TListNextOptions : Protocol.Models.IOptions, new()
        {
            if (req is Protocol.BatchRequest<TListOptions, AzureOperationResponse<IPage<TPage>, THeaders>> listRequest)
            {
                listRequest.ServiceRequestFunc = token =>
                {
                    var filter = listRequest.Options as Protocol.Models.IODataFilter;
                    var select = listRequest.Options as Protocol.Models.IODataSelect;
                    var expand = listRequest.Options as Protocol.Models.IODataExpand;

                    Assert.Equal(expectedDetailLevel.FilterClause, filter?.Filter);
                    Assert.Equal(expectedDetailLevel.SelectClause, select?.Select);
                    Assert.Equal(expectedDetailLevel.ExpandClause, expand?.Expand);

                    return Task.FromResult(new AzureOperationResponse<IPage<TPage>, THeaders>()
                    {
                        Body = new FakePage<TPage>(new List<TPage>(), "Bar")
                    });
                };
            }

            if (req is Protocol.BatchRequest<TListNextOptions, AzureOperationResponse<IPage<TPage>, THeaders>> listNextRequest)
            {
                listNextRequest.ServiceRequestFunc = token =>
                {
                    return Task.FromResult(new AzureOperationResponse<IPage<TPage>, THeaders>()
                    {
                        Body = new FakePage<TPage>(new List<TPage>())
                    });
                };
            }
        }
    }
}
