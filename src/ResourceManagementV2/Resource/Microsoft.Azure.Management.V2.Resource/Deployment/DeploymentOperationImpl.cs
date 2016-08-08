using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class DeploymentOperationImpl :
        IndexableRefreshableWrapper<IDeploymentOperation, DeploymentOperationInner>,
        IDeploymentOperation
    {
        private string resourceGroupName;
        private string deploymentName;

        private IDeploymentOperationsOperations client;

        internal DeploymentOperationImpl(DeploymentOperationInner innerModel, IDeploymentOperationsOperations client) : base(innerModel.Id, innerModel)
        {
            this.client = client;
            resourceGroupName = ResourceUtils.GroupFromResourceId(innerModel.Id);
            deploymentName = ResourceUtils.ExtractFromResourceId(innerModel.Id, "deployments");
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

        public override async Task<IDeploymentOperation> Refresh()
        {
            var inner = await client.GetAsync(resourceGroupName, deploymentName, OperationId);
            SetInner(inner);
            return this;
        }

        #endregion
    }
}
