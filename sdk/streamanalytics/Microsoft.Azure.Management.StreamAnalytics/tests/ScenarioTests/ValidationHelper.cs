// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.StreamAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StreamAnalytics.Tests
{
    // Anything being asserted as Assert.NotNull should be of the format Assert.NotNull(actual.{propertyName})
    // This means we assume/expect that the property is always returned in the response
    // This is also done for properties that you cannot easily verify the value for, but we expect to be in the response
    // For example, the JobId property is expected to be returned for all responses, but on initial creation of the resource
    // we don't know what the expected value of the JobId will be since it is generated on the service side. Therefore, the best
    // we can do is validate that a non-null JobId is returned.
    public static class ValidationHelper
    {
        public static void ValidateStreamingJob(StreamingJob expected, StreamingJob actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.NotNull(actual.Id);
                Assert.NotNull(actual.Name);
                Assert.NotNull(actual.Type);
                Assert.Equal(expected.Location, actual.Location);
                if (actual.Tags != null)
                {
                    Assert.NotNull(expected.Tags);
                    Assert.NotNull(actual.Tags);
                    Assert.Equal(expected.Tags.Count, actual.Tags.Count);
                    foreach (var pair in actual.Tags)
                    {
                        Assert.True(expected.Tags.ContainsKey(pair.Key));
                        Assert.Equal(expected.Tags[pair.Key], pair.Value);
                    }
                }
                else
                {
                    Assert.Null(expected.Tags);
                    Assert.Null(actual.Tags);
                }

                if (actual.Sku != null)
                {
                    Assert.NotNull(expected.Sku);
                    Assert.NotNull(actual.Sku);
                    Assert.Equal(expected.Sku.Name, actual.Sku.Name);
                }
                else
                {
                    Assert.Null(expected.Sku);
                    Assert.Null(actual.Sku);
                }
                Assert.NotNull(actual.JobId);
                Guid.Parse(actual.JobId);
                Assert.NotNull(actual.ProvisioningState);
                Assert.NotNull(actual.JobState);
                Assert.Equal(expected.OutputStartMode, actual.OutputStartMode);
                Assert.Equal(expected.OutputStartTime, actual.OutputStartTime);
                Assert.Equal(expected.LastOutputEventTime, actual.LastOutputEventTime);
                Assert.Equal(expected.EventsOutOfOrderPolicy, actual.EventsOutOfOrderPolicy);
                Assert.Equal(expected.OutputErrorPolicy, actual.OutputErrorPolicy);
                Assert.Equal(expected.EventsOutOfOrderMaxDelayInSeconds, actual.EventsOutOfOrderMaxDelayInSeconds);
                Assert.Equal(expected.EventsLateArrivalMaxDelayInSeconds, actual.EventsLateArrivalMaxDelayInSeconds);
                Assert.Equal(expected.DataLocale, actual.DataLocale);
                Assert.Equal(expected.CompatibilityLevel, actual.CompatibilityLevel);
                Assert.NotNull(actual.CreatedDate);
                if (actual.Inputs != null)
                {
                    Assert.NotNull(expected.Inputs);
                    Assert.NotNull(actual.Inputs);
                    Assert.Equal(expected.Inputs.Count, actual.Inputs.Count);
                    foreach (var actualInput in actual.Inputs)
                    {
                        Assert.NotNull(actualInput);
                        var expectedInput = expected.Inputs.Single(input => string.Equals(input.Id, actualInput.Id));
                        Assert.NotNull(expectedInput);
                        ValidateInput(expectedInput, actualInput, validateReadOnlyProperties);
                    }
                }
                else
                {
                    Assert.Null(expected.Inputs);
                    Assert.Null(actual.Inputs);
                }
                ValidateTransformation(expected.Transformation, actual.Transformation, validateReadOnlyProperties);
                if (actual.Outputs != null)
                {
                    Assert.NotNull(expected.Outputs);
                    Assert.NotNull(actual.Outputs);
                    Assert.Equal(expected.Outputs.Count, actual.Outputs.Count);
                    foreach (var actualOutput in actual.Outputs)
                    {
                        Assert.NotNull(actualOutput);
                        var expectedOutput = expected.Outputs.Single(output => string.Equals(output.Id, actualOutput.Id));
                        Assert.NotNull(expectedOutput);
                        ValidateOutput(expectedOutput, actualOutput, validateReadOnlyProperties);
                    }
                }
                else
                {
                    Assert.Null(expected.Outputs);
                    Assert.Null(actual.Outputs);
                }
                if (actual.Functions != null)
                {
                    Assert.NotNull(expected.Functions);
                    Assert.NotNull(actual.Functions);
                    Assert.Equal(expected.Functions.Count, actual.Functions.Count);
                    foreach (var actualFunction in actual.Functions)
                    {
                        Assert.NotNull(actualFunction);
                        var expectedFunction = expected.Functions.Single(function => string.Equals(function.Id, actualFunction.Id));
                        Assert.NotNull(expectedFunction);
                        ValidateFunction(expectedFunction, actualFunction, validateReadOnlyProperties);
                    }
                }
                else
                {
                    Assert.Null(expected.Outputs);
                    Assert.Null(actual.Outputs);
                }

                /*Assert.NotNull(actual.Etag);
                Guid.Parse(actual.Etag);*/

                if (validateReadOnlyProperties)
                {
                    Assert.Equal(expected.Id, actual.Id);
                    Assert.Equal(expected.Name, actual.Name);
                    Assert.Equal(expected.Type, actual.Type);

                    Assert.Equal(expected.JobId, actual.JobId);
                    Assert.Equal(expected.ProvisioningState, actual.ProvisioningState);
                    Assert.Equal(expected.JobState, actual.JobState);
                    Assert.Equal(expected.CreatedDate, actual.CreatedDate);
                    //Assert.Equal(expected.Etag, actual.Etag);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        public static void ValidateInput(Input expected, Input actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);
                ValidateSubResource(expected, actual, validateReadOnlyProperties);
                ValidateInputProperties(expected.Properties, actual.Properties, validateReadOnlyProperties);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        public static void ValidateTransformation(Transformation expected, Transformation actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.StreamingUnits, actual.StreamingUnits);
                Assert.Equal(expected.Query, actual.Query);

                if (validateReadOnlyProperties)
                {
                    //Assert.Equal(expected.Etag, actual.Etag);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        public static void ValidateOutput(Output expected, Output actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);
                ValidateSubResource(expected, actual, validateReadOnlyProperties);
                ValidateSerialization(expected.Serialization, actual.Serialization, validateReadOnlyProperties);
                ValidateOutputDataSource(expected.Datasource, actual.Datasource, validateReadOnlyProperties);

                if (validateReadOnlyProperties)
                {
                    ValidateDiagnostics(expected.Diagnostics, actual.Diagnostics, validateReadOnlyProperties);
                    //Assert.Equal(expected.Etag, actual.Etag);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        public static void ValidateFunction(Function expected, Function actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);
                ValidateSubResource(expected, actual, validateReadOnlyProperties);
                ValidateFunctionProperties(expected.Properties, actual.Properties, validateReadOnlyProperties);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        public static void ValidateFunctionProperties(FunctionProperties expected, FunctionProperties actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                if (actual is ScalarFunctionProperties)
                {
                    Assert.IsType<ScalarFunctionProperties>(expected);
                    Assert.IsType<ScalarFunctionProperties>(actual);

                    var expectedScalarFunctionProperties = expected as ScalarFunctionProperties;
                    var actualScalarFunctionProperties = actual as ScalarFunctionProperties;

                    ValidateScalarFunctionProperties(expectedScalarFunctionProperties, actualScalarFunctionProperties, validateReadOnlyProperties);
                }
                else
                {
                    throw new Exception("Function properties could not be cast to ScalarFunctionProperties");
                }

                if (validateReadOnlyProperties)
                {
                    //Assert.Equal(expected.Etag, actual.Etag);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateInputProperties(InputProperties expected, InputProperties actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                ValidateSerialization(expected.Serialization, actual.Serialization, validateReadOnlyProperties);

                if (actual is StreamInputProperties)
                {
                    Assert.IsType<StreamInputProperties>(expected);
                    Assert.IsType<StreamInputProperties>(actual);

                    var expectedStreamInputProperties = expected as StreamInputProperties;
                    var actualStreamInputProperties = actual as StreamInputProperties;

                    Assert.NotNull(expectedStreamInputProperties);
                    Assert.NotNull(actualStreamInputProperties);

                    ValidateStreamInputDataSource(expectedStreamInputProperties.Datasource, actualStreamInputProperties.Datasource, validateReadOnlyProperties);
                }
                else if (actual is ReferenceInputProperties)
                {
                    Assert.IsType<ReferenceInputProperties>(expected);
                    Assert.IsType<ReferenceInputProperties>(actual);

                    var expectedReferenceInputProperties = expected as ReferenceInputProperties;
                    var actualReferenceInputProperties = actual as ReferenceInputProperties;

                    Assert.NotNull(expectedReferenceInputProperties);
                    Assert.NotNull(actualReferenceInputProperties);

                    ValidateReferenceInputDataSource(expectedReferenceInputProperties.Datasource, actualReferenceInputProperties.Datasource, validateReadOnlyProperties);
                }
                else
                {
                    throw new Exception("Input properties could not be cast to either StreamInputProperties or ReferenceInputProperties");
                }

                if (validateReadOnlyProperties)
                {
                    ValidateDiagnostics(expected.Diagnostics, actual.Diagnostics, validateReadOnlyProperties);
                    //Assert.Equal(expected.Etag, actual.Etag);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateStreamInputDataSource(StreamInputDataSource expected, StreamInputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                if (actual is BlobStreamInputDataSource)
                {
                    Assert.IsType<BlobStreamInputDataSource>(expected);
                    Assert.IsType<BlobStreamInputDataSource>(actual);

                    var expectedBlobStreamInputDataSource = expected as BlobStreamInputDataSource;
                    var actualBlobStreamInputDataSource = actual as BlobStreamInputDataSource;

                    ValidateBlobStreamInputDataSource(expectedBlobStreamInputDataSource, actualBlobStreamInputDataSource, validateReadOnlyProperties);
                }
                else if (actual is EventHubStreamInputDataSource)
                {
                    Assert.IsType<EventHubStreamInputDataSource>(expected);
                    Assert.IsType<EventHubStreamInputDataSource>(actual);

                    var expectedEventHubStreamInputDataSource = expected as EventHubStreamInputDataSource;
                    var actualEventHubStreamInputDataSource = actual as EventHubStreamInputDataSource;

                    ValidateEventHubStreamInputDataSource(expectedEventHubStreamInputDataSource, actualEventHubStreamInputDataSource, validateReadOnlyProperties);
                }
                else if (actual is IoTHubStreamInputDataSource)
                {
                    Assert.IsType<IoTHubStreamInputDataSource>(expected);
                    Assert.IsType<IoTHubStreamInputDataSource>(actual);

                    var expectedIoTHubStreamInputDataSource = expected as IoTHubStreamInputDataSource;
                    var actualIoTHubStreamInputDataSource = actual as IoTHubStreamInputDataSource;

                    ValidateIoTHubStreamInputDataSource(expectedIoTHubStreamInputDataSource, actualIoTHubStreamInputDataSource, validateReadOnlyProperties);
                }
                else
                {
                    throw new Exception("Input properties could not be cast to BlobStreamInputDataSource, EventHubStreamInputDataSource, or IoTHubStreamInputDataSource");
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateBlobStreamInputDataSource(BlobStreamInputDataSource expected, BlobStreamInputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                ValidateStorageAccountList(expected.StorageAccounts, actual.StorageAccounts, validateReadOnlyProperties);
                Assert.Equal(expected.Container, actual.Container);
                Assert.Equal(expected.PathPattern, actual.PathPattern);
                Assert.Equal(expected.DateFormat, actual.DateFormat);
                Assert.Equal(expected.TimeFormat, actual.TimeFormat);
                Assert.Equal(expected.SourcePartitionCount, actual.SourcePartitionCount);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateEventHubStreamInputDataSource(EventHubStreamInputDataSource expected, EventHubStreamInputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.ServiceBusNamespace, actual.ServiceBusNamespace);
                Assert.Equal(expected.SharedAccessPolicyName, actual.SharedAccessPolicyName);
                Assert.Equal(expected.SharedAccessPolicyKey, actual.SharedAccessPolicyKey);
                Assert.Equal(expected.EventHubName, actual.EventHubName);
                Assert.Equal(expected.ConsumerGroupName, actual.ConsumerGroupName);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateIoTHubStreamInputDataSource(IoTHubStreamInputDataSource expected, IoTHubStreamInputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.IotHubNamespace, actual.IotHubNamespace);
                Assert.Equal(expected.SharedAccessPolicyName, actual.SharedAccessPolicyName);
                Assert.Equal(expected.SharedAccessPolicyKey, actual.SharedAccessPolicyKey);
                Assert.Equal(expected.ConsumerGroupName, actual.ConsumerGroupName);
                Assert.Equal(expected.Endpoint, actual.Endpoint);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateReferenceInputDataSource(ReferenceInputDataSource expected, ReferenceInputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                if (actual is BlobReferenceInputDataSource)
                {
                    Assert.IsType<BlobReferenceInputDataSource>(expected);
                    Assert.IsType<BlobReferenceInputDataSource>(actual);

                    var expectedBlobReferenceInputDataSource = expected as BlobReferenceInputDataSource;
                    var actualBlobReferenceInputDataSource = actual as BlobReferenceInputDataSource;

                    ValidateBlobReferenceInputDataSource(expectedBlobReferenceInputDataSource, actualBlobReferenceInputDataSource, validateReadOnlyProperties);
                }
                else
                {
                    throw new Exception("Input properties could not be cast to BlobReferenceInputDataSource");
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateBlobReferenceInputDataSource(BlobReferenceInputDataSource expected, BlobReferenceInputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                ValidateStorageAccountList(expected.StorageAccounts, actual.StorageAccounts, validateReadOnlyProperties);
                Assert.Equal(expected.Container, actual.Container);
                Assert.Equal(expected.PathPattern, actual.PathPattern);
                Assert.Equal(expected.DateFormat, actual.DateFormat);
                Assert.Equal(expected.TimeFormat, actual.TimeFormat);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateOutputDataSource(OutputDataSource expected, OutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                if (actual is BlobOutputDataSource)
                {
                    Assert.IsType<BlobOutputDataSource>(expected);
                    Assert.IsType<BlobOutputDataSource>(actual);

                    var expectedBlobOutputDataSource = expected as BlobOutputDataSource;
                    var actualBlobOutputDataSource = actual as BlobOutputDataSource;

                    ValidateBlobOutputDataSource(expectedBlobOutputDataSource, actualBlobOutputDataSource, validateReadOnlyProperties);
                }
                else if (actual is AzureTableOutputDataSource)
                {
                    Assert.IsType<AzureTableOutputDataSource>(expected);
                    Assert.IsType<AzureTableOutputDataSource>(actual);

                    var expectedAzureTableOutputDataSource = expected as AzureTableOutputDataSource;
                    var actualAzureTableOutputDataSource = actual as AzureTableOutputDataSource;

                    ValidateAzureTableOutputDataSource(expectedAzureTableOutputDataSource, actualAzureTableOutputDataSource, validateReadOnlyProperties);
                }
                else if (actual is EventHubOutputDataSource)
                {
                    Assert.IsType<EventHubOutputDataSource>(expected);
                    Assert.IsType<EventHubOutputDataSource>(actual);

                    var expectedEventHubOutputDataSource = expected as EventHubOutputDataSource;
                    var actualEventHubOutputDataSource = actual as EventHubOutputDataSource;

                    ValidateEventHubOutputDataSource(expectedEventHubOutputDataSource, actualEventHubOutputDataSource, validateReadOnlyProperties);
                }
                else if (actual is AzureSqlDatabaseOutputDataSource)
                {
                    Assert.IsType<AzureSqlDatabaseOutputDataSource>(expected);
                    Assert.IsType<AzureSqlDatabaseOutputDataSource>(actual);

                    var expectedAzureSqlDatabaseOutputDataSource = expected as AzureSqlDatabaseOutputDataSource;
                    var actualAzureSqlDatabaseOutputDataSource = actual as AzureSqlDatabaseOutputDataSource;

                    ValidateAzureSqlDatabaseOutputDataSource(expectedAzureSqlDatabaseOutputDataSource, actualAzureSqlDatabaseOutputDataSource, validateReadOnlyProperties);
                }
                else if (actual is DocumentDbOutputDataSource)
                {
                    Assert.IsType<DocumentDbOutputDataSource>(expected);
                    Assert.IsType<DocumentDbOutputDataSource>(actual);

                    var expectedDocumentDbOutputDataSource = expected as DocumentDbOutputDataSource;
                    var actualDocumentDbOutputDataSource = actual as DocumentDbOutputDataSource;

                    ValidateDocumentDbOutputDataSource(expectedDocumentDbOutputDataSource, actualDocumentDbOutputDataSource, validateReadOnlyProperties);
                }
                else if (actual is ServiceBusQueueOutputDataSource)
                {
                    Assert.IsType<ServiceBusQueueOutputDataSource>(expected);
                    Assert.IsType<ServiceBusQueueOutputDataSource>(actual);

                    var expectedServiceBusQueueOutputDataSource = expected as ServiceBusQueueOutputDataSource;
                    var actualServiceBusQueueOutputDataSource = actual as ServiceBusQueueOutputDataSource;

                    ValidateServiceBusQueueOutputDataSource(expectedServiceBusQueueOutputDataSource, actualServiceBusQueueOutputDataSource, validateReadOnlyProperties);
                }
                else if (actual is ServiceBusTopicOutputDataSource)
                {
                    Assert.IsType<ServiceBusTopicOutputDataSource>(expected);
                    Assert.IsType<ServiceBusTopicOutputDataSource>(actual);

                    var expectedServiceBusTopicOutputDataSource = expected as ServiceBusTopicOutputDataSource;
                    var actualServiceBusTopicOutputDataSource = actual as ServiceBusTopicOutputDataSource;

                    ValidateServiceBusTopicOutputDataSource(expectedServiceBusTopicOutputDataSource, actualServiceBusTopicOutputDataSource, validateReadOnlyProperties);
                }
                else if (actual is PowerBIOutputDataSource)
                {
                    Assert.IsType<PowerBIOutputDataSource>(expected);
                    Assert.IsType<PowerBIOutputDataSource>(actual);

                    var expectedPowerBIOutputDataSource = expected as PowerBIOutputDataSource;
                    var actualPowerBIOutputDataSource = actual as PowerBIOutputDataSource;

                    ValidatePowerBIOutputDataSource(expectedPowerBIOutputDataSource, actualPowerBIOutputDataSource, validateReadOnlyProperties);
                }
                else if (actual is AzureDataLakeStoreOutputDataSource)
                {
                    Assert.IsType<AzureDataLakeStoreOutputDataSource>(expected);
                    Assert.IsType<AzureDataLakeStoreOutputDataSource>(actual);

                    var expectedAzureDataLakeStoreOutputDataSource = expected as AzureDataLakeStoreOutputDataSource;
                    var actualAzureDataLakeStoreOutputDataSource = actual as AzureDataLakeStoreOutputDataSource;

                    ValidateAzureDataLakeStoreOutputDataSource(expectedAzureDataLakeStoreOutputDataSource, actualAzureDataLakeStoreOutputDataSource, validateReadOnlyProperties);
                }
                else
                {
                    throw new Exception("Output data source could not be cast to BlobStreamInputDataSource, EventHubStreamInputDataSource, or IoTHubStreamInputDataSource");
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateBlobOutputDataSource(BlobOutputDataSource expected, BlobOutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                ValidateStorageAccountList(expected.StorageAccounts, actual.StorageAccounts, validateReadOnlyProperties);
                Assert.Equal(expected.Container, actual.Container);
                Assert.Equal(expected.PathPattern, actual.PathPattern);
                Assert.Equal(expected.DateFormat, actual.DateFormat);
                Assert.Equal(expected.TimeFormat, actual.TimeFormat);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateAzureTableOutputDataSource(AzureTableOutputDataSource expected, AzureTableOutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.AccountName, actual.AccountName);
                Assert.Equal(expected.AccountKey, actual.AccountKey);
                Assert.Equal(expected.Table, actual.Table);
                Assert.Equal(expected.PartitionKey, actual.PartitionKey);
                Assert.Equal(expected.RowKey, actual.RowKey);
                ValidateStringList(expected.ColumnsToRemove, actual.ColumnsToRemove);
                /*if (actual.ColumnsToRemove != null)
                {
                    Assert.NotNull(expected.ColumnsToRemove);
                    Assert.NotNull(actual.ColumnsToRemove);

                    Assert.Equal(expected.ColumnsToRemove.Count, actual.ColumnsToRemove.Count);
                    foreach (var actualColumnName in actual.ColumnsToRemove)
                    {
                        var numFromExpectedList = expected.ColumnsToRemove.Count(
                            expectedColumnName => string.Equals(expectedColumnName, actualColumnName));
                        var numFromActualList = actual.ColumnsToRemove.Count(
                            columnName => string.Equals(columnName, actualColumnName));
                        Assert.True(numFromExpectedList > 0);
                        Assert.Equal(numFromExpectedList, numFromActualList);
                    }
                }
                else
                {
                    Assert.Null(expected.ColumnsToRemove);
                    Assert.Null(actual.ColumnsToRemove);
                }*/
                Assert.Equal(expected.BatchSize, actual.BatchSize);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateEventHubOutputDataSource(EventHubOutputDataSource expected, EventHubOutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.ServiceBusNamespace, actual.ServiceBusNamespace);
                Assert.Equal(expected.SharedAccessPolicyName, actual.SharedAccessPolicyName);
                Assert.Equal(expected.SharedAccessPolicyKey, actual.SharedAccessPolicyKey);
                Assert.Equal(expected.EventHubName, actual.EventHubName);
                Assert.Equal(expected.PartitionKey, actual.PartitionKey);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateAzureSqlDatabaseOutputDataSource(AzureSqlDatabaseOutputDataSource expected, AzureSqlDatabaseOutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.Server, actual.Server);
                Assert.Equal(expected.Database, actual.Database);
                Assert.Equal(expected.User, actual.User);
                Assert.Equal(expected.Password, actual.Password);
                Assert.Equal(expected.Table, actual.Table);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateDocumentDbOutputDataSource(DocumentDbOutputDataSource expected, DocumentDbOutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.AccountId, actual.AccountId);
                Assert.Equal(expected.AccountKey, actual.AccountKey);
                Assert.Equal(expected.Database, actual.Database);
                Assert.Equal(expected.CollectionNamePattern, actual.CollectionNamePattern);
                Assert.Equal(expected.PartitionKey, actual.PartitionKey);
                Assert.Equal(expected.DocumentId, actual.DocumentId);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateServiceBusQueueOutputDataSource(ServiceBusQueueOutputDataSource expected, ServiceBusQueueOutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.ServiceBusNamespace, actual.ServiceBusNamespace);
                Assert.Equal(expected.SharedAccessPolicyName, actual.SharedAccessPolicyName);
                Assert.Equal(expected.SharedAccessPolicyKey, actual.SharedAccessPolicyKey);
                Assert.Equal(expected.QueueName, actual.QueueName);
                ValidateStringList(expected.PropertyColumns, actual.PropertyColumns);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateServiceBusTopicOutputDataSource(ServiceBusTopicOutputDataSource expected, ServiceBusTopicOutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.ServiceBusNamespace, actual.ServiceBusNamespace);
                Assert.Equal(expected.SharedAccessPolicyName, actual.SharedAccessPolicyName);
                Assert.Equal(expected.SharedAccessPolicyKey, actual.SharedAccessPolicyKey);
                Assert.Equal(expected.TopicName, actual.TopicName);
                ValidateStringList(expected.PropertyColumns, actual.PropertyColumns);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidatePowerBIOutputDataSource(PowerBIOutputDataSource expected, PowerBIOutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.RefreshToken, actual.RefreshToken);
                Assert.Equal(expected.TokenUserPrincipalName, actual.TokenUserPrincipalName);
                Assert.Equal(expected.TokenUserDisplayName, actual.TokenUserDisplayName);
                Assert.Equal(expected.Dataset, actual.Dataset);
                Assert.Equal(expected.Table, actual.Table);
                Assert.Equal(expected.GroupId, actual.GroupId);
                Assert.Equal(expected.GroupName, actual.GroupName);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }
        private static void ValidateAzureDataLakeStoreOutputDataSource(AzureDataLakeStoreOutputDataSource expected, AzureDataLakeStoreOutputDataSource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.RefreshToken, actual.RefreshToken);
                Assert.Equal(expected.TokenUserPrincipalName, actual.TokenUserPrincipalName);
                Assert.Equal(expected.TokenUserDisplayName, actual.TokenUserDisplayName);
                Assert.Equal(expected.AccountName, actual.AccountName);
                Assert.Equal(expected.TenantId, actual.TenantId);
                Assert.Equal(expected.FilePathPrefix, actual.FilePathPrefix);
                Assert.Equal(expected.DateFormat, actual.DateFormat);
                Assert.Equal(expected.TimeFormat, actual.TimeFormat);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateStorageAccountList(IList<StorageAccount> expected, IList<StorageAccount> actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.Count, actual.Count);
                foreach (var actualStorageAccount in actual)
                {
                    Assert.NotNull(actualStorageAccount);
                    var numFromExpectedList = expected.Count(
                        expectedStorageAccount =>
                        string.Equals(expectedStorageAccount.AccountName, actualStorageAccount.AccountName) &&
                        string.Equals(expectedStorageAccount.AccountKey, actualStorageAccount.AccountKey));
                    var numFromActualList = actual.Count(
                        storageAccount =>
                        string.Equals(storageAccount.AccountName, actualStorageAccount.AccountName) &&
                        string.Equals(storageAccount.AccountKey, actualStorageAccount.AccountKey));
                    Assert.True(numFromExpectedList > 0);
                    Assert.Equal(numFromExpectedList, numFromActualList);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateSerialization(Serialization expected, Serialization actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                if (actual is CsvSerialization)
                {
                    Assert.IsType<CsvSerialization>(expected);
                    Assert.IsType<CsvSerialization>(actual);

                    var expectedCsvSerialization = expected as CsvSerialization;
                    var actualCsvSerialization = actual as CsvSerialization;

                    Assert.NotNull(expectedCsvSerialization);
                    Assert.NotNull(actualCsvSerialization);

                    Assert.Equal(expectedCsvSerialization.FieldDelimiter, actualCsvSerialization.FieldDelimiter);
                    Assert.Equal(expectedCsvSerialization.Encoding, actualCsvSerialization.Encoding);
                }
                else if (actual is JsonSerialization)
                {
                    Assert.IsType<JsonSerialization>(expected);
                    Assert.IsType<JsonSerialization>(actual);

                    var expectedJsonSerialization = expected as JsonSerialization;
                    var actualJsonSerialization = actual as JsonSerialization;

                    Assert.NotNull(expectedJsonSerialization);
                    Assert.NotNull(actualJsonSerialization);

                    Assert.Equal(expectedJsonSerialization.Encoding, actualJsonSerialization.Encoding);
                    Assert.Equal(expectedJsonSerialization.Format, actualJsonSerialization.Format);
                }
                else if (actual is AvroSerialization)
                {
                    Assert.IsType<AvroSerialization>(expected);
                    Assert.IsType<AvroSerialization>(actual);

                    var expectedAvroSerialization = expected as AvroSerialization;
                    var actualAvroSerialization = actual as AvroSerialization;

                    Assert.NotNull(expectedAvroSerialization);
                    Assert.NotNull(actualAvroSerialization);
                }
                else
                {
                    throw new Exception("Serialization could not be cast to either Csv, Json or Avro");
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateDiagnostics(Diagnostics expected, Diagnostics actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                ValidateDiagnosticConditions(expected.Conditions, actual.Conditions, validateReadOnlyProperties);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateDiagnosticConditions(IList<DiagnosticCondition> expected, IList<DiagnosticCondition> actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.Count, actual.Count);
                foreach (var actualDiagnosticCondition in actual)
                {
                    Assert.NotNull(actualDiagnosticCondition);
                    var numFromExpectedList = expected.Count(
                        expectedDiagnosticCondition =>
                        string.Equals(expectedDiagnosticCondition.Since, actualDiagnosticCondition.Since) &&
                        string.Equals(expectedDiagnosticCondition.Code, actualDiagnosticCondition.Code) &&
                        string.Equals(expectedDiagnosticCondition.Message, actualDiagnosticCondition.Message));
                    var numFromActualList = actual.Count(
                        diagnosticCondition =>
                        string.Equals(diagnosticCondition.Since, actualDiagnosticCondition.Since) &&
                        string.Equals(diagnosticCondition.Code, actualDiagnosticCondition.Code) &&
                        string.Equals(diagnosticCondition.Message, actualDiagnosticCondition.Message));
                    Assert.True(numFromExpectedList > 0);
                    Assert.Equal(numFromExpectedList, numFromActualList);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateScalarFunctionProperties(ScalarFunctionProperties expected, ScalarFunctionProperties actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                ValidateFunctionInputList(expected.Inputs, actual.Inputs, validateReadOnlyProperties);
                ValidateFunctionOutput(expected.Output, actual.Output, validateReadOnlyProperties);
                ValidateFunctionBinding(expected.Binding, actual.Binding, validateReadOnlyProperties);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateFunctionInputList(IList<FunctionInput> expected, IList<FunctionInput> actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.Count, actual.Count);
                foreach (var actualFunctionInput in actual)
                {
                    Assert.NotNull(actualFunctionInput);
                    var numFromExpectedList = expected.Count(
                        expectedFunctionInput =>
                        string.Equals(expectedFunctionInput.DataType, actualFunctionInput.DataType) &&
                        expectedFunctionInput.IsConfigurationParameter == actualFunctionInput.IsConfigurationParameter);
                    var numFromActualList = actual.Count(
                        functionInput =>
                        string.Equals(functionInput.DataType, actualFunctionInput.DataType) &&
                        functionInput.IsConfigurationParameter == actualFunctionInput.IsConfigurationParameter);
                    Assert.True(numFromExpectedList > 0);
                    Assert.Equal(numFromExpectedList, numFromActualList);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateFunctionOutput(FunctionOutput expected, FunctionOutput actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.DataType, actual.DataType);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateFunctionBinding(FunctionBinding expected, FunctionBinding actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                if (actual is AzureMachineLearningStudioFunctionBinding)
                {
                    Assert.IsType<AzureMachineLearningStudioFunctionBinding>(expected);
                    Assert.IsType<AzureMachineLearningStudioFunctionBinding>(actual);

                    var expectedAzureMachineLearningStudioFunctionBinding = expected as AzureMachineLearningStudioFunctionBinding;
                    var actualAzureMachineLearningStudioFunctionBinding = actual as AzureMachineLearningStudioFunctionBinding;

                    ValidateAzureMachineLearningStudioFunctionBinding(expectedAzureMachineLearningStudioFunctionBinding, actualAzureMachineLearningStudioFunctionBinding, validateReadOnlyProperties);
                }
                else if (actual is JavaScriptFunctionBinding)
                {
                    Assert.IsType<JavaScriptFunctionBinding>(expected);
                    Assert.IsType<JavaScriptFunctionBinding>(actual);

                    var expectedJavaScriptFunctionBinding = expected as JavaScriptFunctionBinding;
                    var actualJavaScriptFunctionBinding = actual as JavaScriptFunctionBinding;

                    ValidateJavaScriptFunctionBinding(expectedJavaScriptFunctionBinding, actualJavaScriptFunctionBinding, validateReadOnlyProperties);
                }
                else
                {
                    throw new Exception("FunctionBinding could not be cast to either AzureMachineLearningStudioFunctionBinding or JavaScriptFunctionBinding");
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateAzureMachineLearningStudioFunctionBinding(AzureMachineLearningStudioFunctionBinding expected, AzureMachineLearningStudioFunctionBinding actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.Endpoint, actual.Endpoint);
                Assert.Equal(expected.ApiKey, actual.ApiKey);
                ValidateAzureMachineLearningStudioInputs(expected.Inputs, actual.Inputs, validateReadOnlyProperties);
                ValidateAzureMachineLearningStudioOutputColumnList(expected.Outputs, actual.Outputs, validateReadOnlyProperties);
                Assert.Equal(expected.BatchSize, actual.BatchSize);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateAzureMachineLearningStudioInputs(AzureMachineLearningStudioInputs expected, AzureMachineLearningStudioInputs actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.Name, actual.Name);
                ValidateAzureMachineLearningStudioInputColumnList(expected.ColumnNames, actual.ColumnNames, validateReadOnlyProperties);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateAzureMachineLearningStudioInputColumnList(IList<AzureMachineLearningStudioInputColumn> expected, IList<AzureMachineLearningStudioInputColumn> actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.Count, actual.Count);
                foreach (var actualAzureMachineLearningStudioInputColumn in actual)
                {
                    Assert.NotNull(actualAzureMachineLearningStudioInputColumn);
                    var numFromExpectedList = expected.Count(
                        expectedAzureMachineLearningStudioInputColumn =>
                        string.Equals(expectedAzureMachineLearningStudioInputColumn.Name, actualAzureMachineLearningStudioInputColumn.Name) &&
                        string.Equals(expectedAzureMachineLearningStudioInputColumn.DataType, actualAzureMachineLearningStudioInputColumn.DataType) &&
                        expectedAzureMachineLearningStudioInputColumn.MapTo == actualAzureMachineLearningStudioInputColumn.MapTo);
                    var numFromActualList = actual.Count(
                        AzureMachineLearningStudioInputColumn =>
                        string.Equals(AzureMachineLearningStudioInputColumn.Name, actualAzureMachineLearningStudioInputColumn.Name) &&
                        string.Equals(AzureMachineLearningStudioInputColumn.DataType, actualAzureMachineLearningStudioInputColumn.DataType) &&
                        AzureMachineLearningStudioInputColumn.MapTo == actualAzureMachineLearningStudioInputColumn.MapTo);
                    Assert.True(numFromExpectedList > 0);
                    Assert.Equal(numFromExpectedList, numFromActualList);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateAzureMachineLearningStudioOutputColumnList(IList<AzureMachineLearningStudioOutputColumn> expected, IList<AzureMachineLearningStudioOutputColumn> actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.Count, actual.Count);
                foreach (var actualAzureMachineLearningStudioOutputColumn in actual)
                {
                    Assert.NotNull(actualAzureMachineLearningStudioOutputColumn);
                    var numFromExpectedList = expected.Count(
                        expectedAzureMachineLearningStudioOutputColumn =>
                        string.Equals(expectedAzureMachineLearningStudioOutputColumn.Name, actualAzureMachineLearningStudioOutputColumn.Name) &&
                        string.Equals(expectedAzureMachineLearningStudioOutputColumn.DataType, actualAzureMachineLearningStudioOutputColumn.DataType));
                    var numFromActualList = actual.Count(
                        AzureMachineLearningStudioOutputColumn =>
                        string.Equals(AzureMachineLearningStudioOutputColumn.Name, actualAzureMachineLearningStudioOutputColumn.Name) &&
                        string.Equals(AzureMachineLearningStudioOutputColumn.DataType, actualAzureMachineLearningStudioOutputColumn.DataType));
                    Assert.True(numFromExpectedList > 0);
                    Assert.Equal(numFromExpectedList, numFromActualList);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateJavaScriptFunctionBinding(JavaScriptFunctionBinding expected, JavaScriptFunctionBinding actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.Equal(expected.Script, actual.Script);
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateSubResource(SubResource expected, SubResource actual, bool validateReadOnlyProperties)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.NotNull(actual.Id);
                Assert.NotNull(actual.Name);
                Assert.NotNull(actual.Type);

                if (validateReadOnlyProperties)
                {
                    Assert.Equal(expected.Id, actual.Id);
                    Assert.Equal(expected.Name, actual.Name);
                    Assert.Equal(expected.Type, actual.Type);
                }
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }

        private static void ValidateStringList(IList<String> expected, IList<String> actual)
        {
            if (actual != null)
            {
                Assert.NotNull(expected);
                Assert.NotNull(actual);

                Assert.True(expected.OrderBy(str => str).SequenceEqual(actual.OrderBy(str => str)));
            }
            else
            {
                Assert.Null(expected);
                Assert.Null(actual);
            }
        }
    }
}
