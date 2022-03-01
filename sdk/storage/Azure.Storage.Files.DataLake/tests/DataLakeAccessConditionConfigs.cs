// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Files.DataLake.Tests
{
    /// <summary>
    /// Extends <see cref="AccessConditionConfigs"/> to setup datalake-service-specific
    /// request conditions.
    /// </summary>
    public class DataLakeAccessConditionConfigs : AccessConditionConfigs
    {
        public DataLakeAccessConditionConfigs(RecordedTestBase recordedTestBase)
            : base(recordedTestBase)
        {
        }

        public DataLakeRequestConditions BuildAccessConditions(
            AccessConditionParameters parameters,
            bool lease = true)
        {
            var accessConditions = BuildRequestConditions(parameters).ToDataLakeRequestConditions();
            if (lease)
            {
                accessConditions.LeaseId = parameters.LeaseId;
            }
            return accessConditions;
        }

        public async Task<string> SetupFileMatchCondition(DataLakeFileClient file, string match)
        {
            if (match == ReceivedETag)
            {
                Response<PathProperties> headers = await file.GetPropertiesAsync();
                return headers.GetRawResponse().Headers.ETag.ToString();
            }
            else
            {
                return match;
            }
        }
    }
}
