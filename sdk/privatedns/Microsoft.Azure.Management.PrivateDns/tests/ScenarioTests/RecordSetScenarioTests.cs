// ------------------------------------------------------------------------------------------------
// <copyright file="RecordSetScenarioTests.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace PrivateDns.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using FluentAssertions;
    using Microsoft.Azure.Management.PrivateDns;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.Azure;
    using PrivateDns.Tests.Extensions;
    using Xunit;
    using Xunit.Abstractions;

    public class RecordSetScenarioTests : BaseScenarioTests
    {
        public RecordSetScenarioTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        public void PutRecordSet_ZoneNotExists_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var nonExistentPrivateZoneName = TestDataGenerator.GeneratePrivateZoneName();
            var recordType = RecordType.A;
            var recordSetName = "recordName";
            var parameters = TestDataGenerator.GenerateRecordSetWithARecords();

            Action putRecordSetAction = () => this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(resourceGroupName, nonExistentPrivateZoneName, recordType, recordSetName, parameters);
            putRecordSetAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void PutRecordSet_IfNoneMatchSuccess_ExpectRecordSetCreated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var recordType = RecordType.A;
            var recordSetName = "recordName";
            var parameters = TestDataGenerator.GenerateRecordSetWithARecords();

            var createdRecordSet = this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                recordType: recordType,
                relativeRecordSetName: recordSetName,
                ifNoneMatch: "*",
                parameters: parameters);

            createdRecordSet.Should().NotBeNull();
        }

        [Fact]
        public void PutRecordSet_IfMatchSuccess_ExpectRecordSetUpdated()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var recordType = RecordType.A;
            var recordSetName = "recordName";
            var parameters = TestDataGenerator.GenerateRecordSetWithARecords();

            var createdRecordSet = this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(resourceGroupName, privateZoneName, recordType, recordSetName, parameters);

            var updatedRecordSet = this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                recordType: recordType,
                relativeRecordSetName: recordSetName,
                ifMatch: createdRecordSet.Etag,
                parameters: parameters);

            updatedRecordSet.Should().NotBeNull();
            updatedRecordSet.Etag.Should().NotBeNullOrEmpty().And.NotBe(createdRecordSet.Etag);
        }

        [Fact]
        public void PutRecordSet_IfMatchFailure_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var recordType = RecordType.A;
            var recordSetName = "recordName";
            var parameters = TestDataGenerator.GenerateRecordSetWithARecords();

            var createdRecordSet = this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(resourceGroupName, privateZoneName, recordType, recordSetName, parameters);

            Action updatedRecordSetAction = () => this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                recordType: recordType,
                relativeRecordSetName: recordSetName,
                ifMatch: Guid.NewGuid().ToString(),
                parameters: parameters);

            updatedRecordSetAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        public void GetRecordSet_SoaRecord_ExpectRecordSetRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var recordType = RecordType.SOA;
            var recordSetName = "@";

            var retrievedRecordSet = this.PrivateDnsManagementClient.RecordSets.Get(resourceGroupName, privateZoneName, recordType, recordSetName);
            retrievedRecordSet.Should().NotBeNull();
            retrievedRecordSet.SoaRecord.Should().NotBeNull();
            retrievedRecordSet.SoaRecord.Host.Should().NotBeNullOrEmpty();
            retrievedRecordSet.SoaRecord.Email.Should().NotBeNullOrEmpty();
            retrievedRecordSet.SoaRecord.SerialNumber.Should().NotBeNull();
            retrievedRecordSet.SoaRecord.RefreshTime.Should().NotBeNull();
            retrievedRecordSet.SoaRecord.RetryTime.Should().NotBeNull();
            retrievedRecordSet.SoaRecord.ExpireTime.Should().NotBeNull();
            retrievedRecordSet.SoaRecord.MinimumTtl.Should().NotBeNull();
        }

        [Fact]
        public void PatchRecordSet_AddMetadata_ExpectMetadataAdded()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var recordType = RecordType.SOA;
            var recordSetName = "@";
            var metadataToAdd = TestDataGenerator.GenerateTags();

            var updatedRecordSet = this.PrivateDnsManagementClient.RecordSets.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                recordType: recordType,
                relativeRecordSetName: recordSetName,
                parameters: TestDataGenerator.GenerateRecordSet(metadata: metadataToAdd));

            updatedRecordSet.Should().NotBeNull();
            updatedRecordSet.Metadata.Should().BeEquivalentTo(metadataToAdd);
        }

        [Fact]
        public void PatchRecordSet_ChangeMetadata_ExpectMetadataChanged()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var recordType = RecordType.A;
            var recordSetName = "recordName";

            var createdRecordSet = this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                recordType: recordType,
                relativeRecordSetName: recordSetName,
                parameters: TestDataGenerator.GenerateRecordSetWithARecords(metadata: TestDataGenerator.GenerateTags()));

            var metadataToUpdate = TestDataGenerator.GenerateTags(startFrom: createdRecordSet.Metadata.Count);
            var updatedRecordSet = this.PrivateDnsManagementClient.RecordSets.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                recordType: recordType,
                relativeRecordSetName: recordSetName,
                parameters: TestDataGenerator.GenerateRecordSet(metadata: metadataToUpdate));

            updatedRecordSet.Should().NotBeNull();
            updatedRecordSet.Metadata.Should().BeEquivalentTo(metadataToUpdate);
        }

        [Fact]
        public void PatchRecordSet_RemoveMetadata_ExpectMetadataRemoved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var recordType = RecordType.A;
            var recordSetName = "recordName";

            var createdRecordSet = this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                recordType: recordType,
                relativeRecordSetName: recordSetName,
                parameters: TestDataGenerator.GenerateRecordSetWithARecords(metadata: TestDataGenerator.GenerateTags()));

            var updatedRecordSet = this.PrivateDnsManagementClient.RecordSets.Update(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                recordType: recordType,
                relativeRecordSetName: recordSetName,
                parameters: TestDataGenerator.GenerateRecordSet(metadata: new Dictionary<string, string>()));

            updatedRecordSet.Should().NotBeNull();
            updatedRecordSet.Metadata.Should().BeEmpty();
        }

        [Fact]
        public void DeleteRecordSet_SoaRecord_ExpectError()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var recordType = RecordType.SOA;
            var recordSetName = "@";

            Action deleteRecordSetAction = () => this.PrivateDnsManagementClient.RecordSets.Delete(resourceGroupName, privateZoneName, recordType, recordSetName);
            deleteRecordSetAction.Should().Throw<CloudException>().Which.Response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void CrudRecordSet_ARecord_ExpectCrudSuccessful()
        {
            this.CrudRecordSet_Valid_ExpectCrudSuccessful(
                recordType: RecordType.A,
                createFunc: () => TestDataGenerator.GenerateRecordSetWithARecords(ipV4Address: "10.0.0.1"),
                updateFunc: () => TestDataGenerator.GenerateRecordSetWithARecords(ipV4Address: "10.0.0.2"));
        }

        [Fact]
        public void CrudRecordSet_AaaaRecord_ExpectCrudSuccessful()
        {
            this.CrudRecordSet_Valid_ExpectCrudSuccessful(
                recordType: RecordType.AAAA,
                createFunc: () => TestDataGenerator.GenerateRecordSetWithAaaaRecords(ipV6Address: "::1"),
                updateFunc: () => TestDataGenerator.GenerateRecordSetWithAaaaRecords(ipV6Address: "2001:0db8:85a3:0000:0000:8a2e:0370:7334"));
        }

        [Fact]
        public void CrudRecordSet_CnameRecord_ExpectCrudSuccessful()
        {
            this.CrudRecordSet_Valid_ExpectCrudSuccessful(
                recordType: RecordType.CNAME,
                createFunc: () => TestDataGenerator.GenerateRecordSetWithCnameRecord(cname: "cname1"),
                updateFunc: () => TestDataGenerator.GenerateRecordSetWithCnameRecord(cname: "cname2"));
        }

        [Fact]
        public void CrudRecordSet_MxRecord_ExpectCrudSuccessful()
        {
            this.CrudRecordSet_Valid_ExpectCrudSuccessful(
                recordType: RecordType.MX,
                createFunc: () => TestDataGenerator.GenerateRecordSetWithMxRecords(exchange: "exc.chan.ge1", preference: 10),
                updateFunc: () => TestDataGenerator.GenerateRecordSetWithMxRecords(exchange: "exc.chan.ge2", preference: 20));
        }

        [Fact]
        public void CrudRecordSet_PtrRecord_ExpectCrudSuccessful()
        {
            this.CrudRecordSet_Valid_ExpectCrudSuccessful(
                recordType: RecordType.PTR,
                createFunc: () => TestDataGenerator.GenerateRecordSetWithPtrRecords(ptrdname: "ptrd.name1"),
                updateFunc: () => TestDataGenerator.GenerateRecordSetWithPtrRecords(ptrdname: "ptrd.name2"));
        }

        [Fact]
        public void CrudRecordSet_SrvRecord_ExpectCrudSuccessful()
        {
            this.CrudRecordSet_Valid_ExpectCrudSuccessful(
                recordType: RecordType.SRV,
                createFunc: () => TestDataGenerator.GenerateRecordSetWithSrvRecords(port: 150, priority: 1, target: "targ.et1", weight: 5),
                updateFunc: () => TestDataGenerator.GenerateRecordSetWithSrvRecords(port: 200, priority: 2, target: "targ.et2", weight: 10));
        }

        [Fact]
        public void CrudRecordSet_TxtRecord_ExpectCrudSuccessful()
        {
            this.CrudRecordSet_Valid_ExpectCrudSuccessful(
                recordType: RecordType.TXT,
                createFunc: () => TestDataGenerator.GenerateRecordSetWithTxtRecords(value: new[] { "value1" }),
                updateFunc: () => TestDataGenerator.GenerateRecordSetWithTxtRecords(value: new[] { "value1", "value2" }));
        }

        [Fact]
        public void ListRecordSetsByType_NoRecordSetsPresent_ExpectNoRecordSetsRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;

            var listResult = this.PrivateDnsManagementClient.RecordSets.ListByType(resourceGroupName, privateZoneName, RecordType.A);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listedRecordSets = listResult.ToArray();
            listedRecordSets.Count().Should().Be(0);
        }

        [Fact]
        public void ListRecordSetsByType_MultipleRecordSetsPresent_ExpectMultipleRecordSetsRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdARecordSets = this.CreateARecordSets(resourceGroupName, privateZoneName);
            var createdAaaaRecordSets = this.CreateAaaaRecordSets(resourceGroupName, privateZoneName);

            var listResult = this.PrivateDnsManagementClient.RecordSets.ListByType(resourceGroupName, privateZoneName, RecordType.A);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listedRecordSets = listResult.ToArray();
            listedRecordSets.Count().Should().Be(createdARecordSets.Count());
            listedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, createdARecordSets));
        }

        [Fact]
        public void ListRecordSetsByType_WithTopParameter_ExpectSpecifiedRecordSetsRetrieved()
        {
            const int numRecordSets = 2;
            const int topValue = numRecordSets - 1;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdRecordSets = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSets);
            var expectedRecordSets = createdRecordSets.OrderBy(x => x.Name).Take(topValue);

            var listResult = this.PrivateDnsManagementClient.RecordSets.ListByType(resourceGroupName, privateZoneName, RecordType.A, top: topValue);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().NotBeNullOrEmpty();

            var listedRecordSets = listResult.ToArray();
            listedRecordSets.Count().Should().Be(topValue);
            listedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, expectedRecordSets));
        }

        [Fact]
        public void ListRecordSetsByType_WithSuffixParameter_ExpectSpecifiedRecordSetsRetrieved()
        {
            const int numRecordSets = 2;
            const string recordSetNameSuffix = "contoso";

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdRecordSetsWithSuffix = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSets, suffix: recordSetNameSuffix);
            var createdRecordSetsWithoutSuffix = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSets, suffix: "unexpectedsuffix");

            var listResult = this.PrivateDnsManagementClient.RecordSets.ListByType(resourceGroupName, privateZoneName, RecordType.A, recordsetnamesuffix: recordSetNameSuffix);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listedRecordSets = listResult.ToArray();
            listedRecordSets.Count().Should().Be(createdRecordSetsWithSuffix.Count());
            listedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, createdRecordSetsWithSuffix));
        }

        [Fact]
        public void ListRecordSetsByType_ListNextPageWithoutSuffix_ExpectNextRecordSetsRetrieved()
        {
            const int numRecordSets = 2;
            const int topValue = numRecordSets - 1;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdRecordSets = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSets);
            var expectedNextRecordSets = createdRecordSets.OrderBy(x => x.Name).Skip(topValue);

            var initialListResult = this.PrivateDnsManagementClient.RecordSets.ListByType(resourceGroupName, privateZoneName, RecordType.A, top: topValue);
            var nextLink = initialListResult.NextPageLink;

            var nextListResult = this.PrivateDnsManagementClient.RecordSets.ListByTypeNext(nextLink);
            nextListResult.Should().NotBeNull();
            if (nextListResult.NextPageLink != null)
            {
                ValidateExtraNextPageLinkReturnsRecords(nextListResult.NextPageLink, numExpectedRecords: 0);
            }

            var nextListedRecordSets = nextListResult.ToArray();
            nextListedRecordSets.Count().Should().Be(topValue);
            nextListedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, expectedNextRecordSets));
        }

        [Fact]
        public void ListRecordSetsByType_ListNextPageWithSuffix_ExpectNextRecordSetsRetrieved()
        {
            const int numRecordSets = 2;
            const int topValue = numRecordSets - 1;
            const string recordSetNameSuffix = "contoso";

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdRecordSetsWithSuffix = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSets, suffix: recordSetNameSuffix);
            var createdRecordSetsWithoutSuffix = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSets, suffix: "unexpectedsuffix");
            var expectedNextRecordSets = createdRecordSetsWithSuffix.OrderBy(x => x.Name).Skip(topValue);

            var initialListResult = this.PrivateDnsManagementClient.RecordSets.ListByType(resourceGroupName, privateZoneName, RecordType.A, top: topValue, recordsetnamesuffix: recordSetNameSuffix);
            var nextLink = initialListResult.NextPageLink;

            var nextListResult = this.PrivateDnsManagementClient.RecordSets.ListByTypeNext(nextLink);
            nextListResult.Should().NotBeNull();
            if (nextListResult.NextPageLink != null)
            {
                ValidateExtraNextPageLinkReturnsRecords(nextListResult.NextPageLink, numExpectedRecords: 0);
            }

            var nextListedRecordSets = nextListResult.ToArray();
            nextListedRecordSets.Count().Should().Be(topValue);
            nextListedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, expectedNextRecordSets));
        }

        [Fact]
        public void ListRecordSetsAcrossType_DefaultRecordSetPresent_ExpectDefaultRecordSetRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;

            var listResult = this.PrivateDnsManagementClient.RecordSets.List(resourceGroupName, privateZoneName);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listedRecordSets = listResult.ToArray();
            listedRecordSets.Count().Should().Be(1);
            listedRecordSets.Single().SoaRecord.Should().NotBeNull();
        }

        [Fact]
        public void ListRecordSetsAcrossType_MultipleRecordSetsPresent_ExpectMultipleRecordSetsRetrieved()
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;

            var createdARecordSets = this.CreateARecordSets(resourceGroupName, privateZoneName);
            var createdAaaaRecordSets = this.CreateAaaaRecordSets(resourceGroupName, privateZoneName);

            var defaultRecordSet = this.PrivateDnsManagementClient.RecordSets.Get(resourceGroupName, privateZoneName, RecordType.SOA, "@");
            var expectedRecordSets = createdARecordSets.Concat(createdAaaaRecordSets).Concat(new[] { defaultRecordSet });

            var listResult = this.PrivateDnsManagementClient.RecordSets.List(resourceGroupName, privateZoneName);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listedRecordSets = listResult.ToArray();
            listedRecordSets.Count().Should().Be(expectedRecordSets.Count());
            listedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, expectedRecordSets));
        }

        [Fact]
        public void ListRecordSetsAcrossType_WithTopParameter_ExpectSpecifiedRecordSetsRetrieved()
        {
            const int numRecordSetsPerType = 2;
            const int topValue = 2;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var createdARecordSets = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType);
            var createdAaaaRecordSets = this.CreateAaaaRecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType);
            var expectedRecordSets = createdARecordSets.Concat(createdAaaaRecordSets).OrderBy(x => x.Name).Take(topValue);

            var listResult = this.PrivateDnsManagementClient.RecordSets.List(resourceGroupName, privateZoneName, top: topValue);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().NotBeNullOrEmpty();

            var listedRecordSets = listResult.ToArray();
            listedRecordSets.Count().Should().Be(topValue);
            listedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, expectedRecordSets));
        }

        [Fact]
        public void ListRecordSetsAcrossType_WithSuffixParameter_ExpectSpecifiedRecordSetsRetrieved()
        {
            const int numRecordSetsPerType = 2;
            const string recordSetNameSuffix = "contoso";

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;

            var createdARecordSetsWithSuffix = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType, suffix: recordSetNameSuffix);
            var createdAaaaRecordSetsWithSuffix = this.CreateAaaaRecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType, suffix: recordSetNameSuffix);
            var createdARecordSetsWithoutSuffix = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType, suffix: "unexpectedsuffix");
            var createdAaaaRecordSetsWithoutSuffix = this.CreateAaaaRecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType, suffix: "unexpectedsuffix");

            var expectedRecordSets = createdARecordSetsWithSuffix.Concat(createdAaaaRecordSetsWithSuffix);

            var listResult = this.PrivateDnsManagementClient.RecordSets.List(resourceGroupName, privateZoneName, recordsetnamesuffix: recordSetNameSuffix);
            listResult.Should().NotBeNull();
            listResult.NextPageLink.Should().BeNull();

            var listedRecordSets = listResult.ToArray();
            listedRecordSets.Count().Should().Be(expectedRecordSets.Count());
            listedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, expectedRecordSets));
        }

        [Fact]
        public void ListRecordSetsAcrossType_ListNextPageWithoutSuffix_ExpectNextRecordSetsRetrieved()
        {
            const int numRecordSetsPerType = 2;
            const int topValue = 2;

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;

            var createdARecordSets = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType);
            var createdAaaaRecordSets = this.CreateAaaaRecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType);

            var defaultRecordSet = this.PrivateDnsManagementClient.RecordSets.Get(resourceGroupName, privateZoneName, RecordType.SOA, "@");
            var expectedNextRecordSets = createdARecordSets.Concat(createdAaaaRecordSets).Concat(new[] { defaultRecordSet }).OrderBy(x => x.Name).Skip(topValue);

            var initialListResult = this.PrivateDnsManagementClient.RecordSets.List(resourceGroupName, privateZoneName, top: topValue);
            var nextLink = initialListResult.NextPageLink;

            var nextListResult = this.PrivateDnsManagementClient.RecordSets.ListNext(nextLink);
            nextListResult.Should().NotBeNull();
            if (nextListResult.NextPageLink != null)
            {
                // We expect the next link to still return an additional record because the default record also meets the filter criteria.
                ValidateExtraNextPageLinkReturnsRecords(nextListResult.NextPageLink, numExpectedRecords: 1);
            }

            var nextListedRecordSets = nextListResult.ToArray();
            nextListedRecordSets.Count().Should().Be(topValue);
            nextListedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, expectedNextRecordSets));
        }

        [Fact]
        public void ListRecordSetsAcrossType_ListNextPageWithSuffix_ExpectNextRecordSetsRetrieved()
        {
            const int numRecordSetsPerType = 2;
            const int topValue = 2;
            const string recordSetNameSuffix = "contoso";

            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;

            var createdARecordSetsWithSuffix = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType, suffix: recordSetNameSuffix);
            var createdAaaaRecordSetsWithSuffix = this.CreateAaaaRecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType, suffix: recordSetNameSuffix);
            var createdARecordSetsWithoutSuffix = this.CreateARecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType, suffix: "unexpectedsuffix");
            var createdAaaaRecordSetsWithoutSuffix = this.CreateAaaaRecordSets(resourceGroupName, privateZoneName, numRecordSets: numRecordSetsPerType, suffix: "unexpectedsuffix");

            var expectedNextRecordSets = createdARecordSetsWithSuffix.Concat(createdAaaaRecordSetsWithSuffix).OrderBy(x => x.Name).Skip(topValue);

            var initialListResult = this.PrivateDnsManagementClient.RecordSets.List(resourceGroupName, privateZoneName, top: topValue, recordsetnamesuffix: recordSetNameSuffix);
            var nextLink = initialListResult.NextPageLink;

            var nextListResult = this.PrivateDnsManagementClient.RecordSets.ListNext(nextLink);
            nextListResult.Should().NotBeNull();
            if (nextListResult.NextPageLink != null)
            {
                ValidateExtraNextPageLinkReturnsRecords(nextListResult.NextPageLink, numExpectedRecords: 0);
            }

            var nextListedRecordSets = nextListResult.ToArray();
            nextListedRecordSets.Count().Should().Be(topValue);
            nextListedRecordSets.All(listedRecordSet => ValidateListedRecordSetIsExpected(listedRecordSet, expectedNextRecordSets));
        }

        private void CrudRecordSet_Valid_ExpectCrudSuccessful(RecordType recordType, Func<RecordSet> createFunc, Func<RecordSet> updateFunc)
        {
            var resourceGroupName = this.CreateResourceGroup().Name;
            var privateZoneName = this.CreatePrivateZone(resourceGroupName).Name;
            var recordSetName = TestDataGenerator.GenerateRecordSetName();

            var initialParameters = createFunc();
            var updatedParameters = updateFunc();

            var createdRecordSet = this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(resourceGroupName, privateZoneName, recordType, recordSetName, initialParameters);
            createdRecordSet.Should().NotBeNull();
            createdRecordSet.Should().BeEquivalentTo(initialParameters, checkEtag: false, checkFqdn: false);

            var retrievedRecordSet = this.PrivateDnsManagementClient.RecordSets.Get(resourceGroupName, privateZoneName, recordType, recordSetName);
            retrievedRecordSet.Should().NotBeNull();
            retrievedRecordSet.Should().BeEquivalentTo(createdRecordSet, checkEtag: true, checkFqdn: true);

            var updatedRecordSet = this.PrivateDnsManagementClient.RecordSets.Update(resourceGroupName, privateZoneName, recordType, recordSetName, updatedParameters);
            updatedRecordSet.Should().NotBeNull();
            updatedRecordSet.Should().BeEquivalentTo(updatedParameters, checkEtag: false, checkFqdn: false);

            Action deleteAction = () => this.PrivateDnsManagementClient.RecordSets.Delete(resourceGroupName, privateZoneName, recordType, recordSetName);
            deleteAction.Should().NotThrow();
        }

        private static bool ValidateListedRecordSetIsExpected(RecordSet listedRecordSet, IEnumerable<RecordSet> expectedRecordSets)
        {
            return expectedRecordSets.Any(expectedRecordSet => string.Equals(expectedRecordSet.Id, listedRecordSet.Id, StringComparison.OrdinalIgnoreCase));
        }

        private RecordSet CreateRecordSet(string resourceGroupName, string privateZoneName, RecordType recordType, string recordSetName, RecordSet recordSet)
        {
            return this.PrivateDnsManagementClient.RecordSets.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                recordType: recordType,
                relativeRecordSetName: recordSetName,
                parameters: recordSet);
        }

        private ICollection<RecordSet> CreateARecordSets(string resourceGroupName, string privateZoneName, int numRecordSets = 2, string suffix = null)
        {
            const RecordType recordType = RecordType.A;

            var subzone = suffix == null ? string.Empty : $".{suffix}";

            var createdRecordSets = new List<RecordSet>();
            for (var i = 0; i < numRecordSets; i++)
            {
                var recordSetName = $"{TestDataGenerator.GenerateRecordSetName()}{subzone}";
                var recordSetToCreate = TestDataGenerator.GenerateRecordSetWithARecords($"10.0.0.{i + 1}");
                createdRecordSets.Add(this.CreateRecordSet(resourceGroupName, privateZoneName, recordType, recordSetName, recordSetToCreate));
            }

            return createdRecordSets;
        }

        private ICollection<RecordSet> CreateAaaaRecordSets(string resourceGroupName, string privateZoneName, int numRecordSets = 2, string suffix = null)
        {
            const RecordType recordType = RecordType.AAAA;

            var subzone = suffix == null ? string.Empty : $".{suffix}";

            var createdRecordSets = new List<RecordSet>();
            for (var i = 0; i < numRecordSets; i++)
            {
                var recordSetName = $"{TestDataGenerator.GenerateRecordSetName()}{subzone}";
                var recordSetToCreate = TestDataGenerator.GenerateRecordSetWithAaaaRecords($"2001:0db8:85a3:0000:0000:8a2e:0370:733{i}");
                createdRecordSets.Add(this.CreateRecordSet(resourceGroupName, privateZoneName, recordType, recordSetName, recordSetToCreate));
            }

            return createdRecordSets;
        }

        private void ValidateExtraNextPageLinkReturnsRecords(string nextPageLink, int numExpectedRecords)
        {
            nextPageLink.Should().NotBeNullOrEmpty();
            var extraNextListResult = this.PrivateDnsManagementClient.RecordSets.ListByTypeNext(nextPageLink);

            extraNextListResult.Should().NotBeNull();
            extraNextListResult.NextPageLink.Should().BeNull();

            var extraNextListedRecordSets = extraNextListResult.ToArray();
            extraNextListedRecordSets.Count().Should().Be(numExpectedRecords);
        }
    }
}
