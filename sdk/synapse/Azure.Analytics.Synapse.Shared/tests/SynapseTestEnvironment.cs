// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.Synapse.Tests
{
    public class SynapseTestEnvironment : TestEnvironment
    {
        public string EndpointUrl => GetRecordedVariable("AZURE_SYNAPSE_WORKSPACE_URL");
        public string SparkPoolName => GetRecordedVariable("AZURE_SYNAPSE_SPARK_POOL_NAME");
        public string StorageAccountName => GetRecordedVariable("AZURE_STORAGE_ACCOUNT_NAME");
        public string StorageFileSystemName => GetRecordedVariable("AZURE_STORAGE_FILE_SYSTEM_NAME");
        public string PrincipalId => GetRecordedVariable("AZURE_SYNAPSE_PRINCIPAL_ID");

        private string _workspaceName;
        public string WorkspaceName
        {
            get
            {
                if (_workspaceName == null)
                {
                    _workspaceName = EndpointUrl.Split('.')[0].Split('/')[2];
                }
                return _workspaceName;
            }
        }
    }
}
