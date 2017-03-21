// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System;

namespace Microsoft.Azure.Management.Resource.Fluent
{
    internal class DeploymentOperationImpl :
        IndexableRefreshableWrapper<IDeploymentOperation, DeploymentOperationInner>,
        IDeploymentOperation
    {
        private string resourceGroupName;
        private string deploymentName;

        private Management.ResourceManager.Fluent.IDeploymentOperations client;

        internal DeploymentOperationImpl(DeploymentOperationInner innerModel, Management.ResourceManager.Fluent.IDeploymentOperations client) : base(innerModel.Id, innerModel)
        {
            this.client = client;
            var resourceId = ResourceId.FromString(innerModel.Id);

            resourceGroupName = resourceId.ResourceGroupName;
            deploymentName = resourceId.Name;
        }

        #region Getters 

        public string OperationId
        {
            get
            {
                return Inner.OperationId;
            }
        }

        public string ProvisioningState
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.ProvisioningState;
            }
        }

        public DateTime? Timestamp
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Timestamp;
            }
        }

        public string StatusCode
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.StatusCode;
            }
        }

        public object StatusMessage
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.StatusMessage;
            }
        }

        public TargetResource TargetResource
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.TargetResource;
            }
        }

        #endregion

        #region Implementation of IRefreshable interface

        public override IDeploymentOperation Refresh()
        {
            var inner = client.Get(resourceGroupName, deploymentName, OperationId);
            SetInner(inner);
            return this;
        }

        #endregion
    }
}
