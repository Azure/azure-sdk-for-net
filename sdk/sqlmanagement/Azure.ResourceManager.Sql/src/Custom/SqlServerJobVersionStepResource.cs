// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SqlServerJobVersionStepResource : SqlServerJobStepResource
    {
        public static new readonly ResourceType ResourceType = SqlServerJobStepResource.ResourceType;

        protected SqlServerJobVersionStepResource()
        {
        }

        internal SqlServerJobVersionStepResource(ArmClient client, SqlServerJobStepData data) : base(client, data)
        {
        }

        internal SqlServerJobVersionStepResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
