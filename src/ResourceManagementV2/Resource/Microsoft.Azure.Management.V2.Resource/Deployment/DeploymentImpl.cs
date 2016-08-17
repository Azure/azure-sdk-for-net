using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using Microsoft.Azure.Management.V2.Resource.Deployment.Update;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Deployment.Definition;
using Newtonsoft.Json;
using System.Linq;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class DeploymentImpl :
        CreatableUpdatable<IDeployment, DeploymentExtendedInner, DeploymentImpl, IDeployment, Deployment.Update.IUpdate>,
        IDeployment,
        Deployment.Definition.IDefinition,
        Deployment.Update.IUpdate
    {
        private IDeploymentsOperations client;
        private IDeploymentOperationsOperations deploymentOperationsClient;
        private IResourceManager resourceManager;
        private string resourceGroupName;
        private ICreatable<IResourceGroup> creatableResourceGroup;

        internal DeploymentImpl(DeploymentExtendedInner innerModel,
            IDeploymentsOperations client,
            IDeploymentOperationsOperations deploymentOperationsClient,
            IResourceManager resourceManager) : base(innerModel.Name, innerModel)
        {
            this.client = client;
            this.deploymentOperationsClient = deploymentOperationsClient;
            resourceGroupName = ResourceUtils.GroupFromResourceId(innerModel.Id);
            this.resourceManager = resourceManager;
        }

        #region Getters

        public string ResourceGroupName
        {
            get
            {
                return resourceGroupName;
            }
        }

        public string Name
        {
            get
            {
                return Inner.Name;
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

        public string CorrelationId
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.CorrelationId;
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

        public object Outputs
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Outputs;
            }
        }

        public IList<IProvider> Providers
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return (from providerInner in Inner.Properties.Providers
                        select new ProviderImpl(providerInner)).ToList<IProvider>();
            }
        }

        public IList<Dependency> Dependencies
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Dependencies;
            }
        }

        public object Template
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Template;
            }
        }

        public TemplateLink TemplateLink
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.TemplateLink;
            }
        }

        public object Parameters
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Parameters;
            }
        }

        public ParametersLink ParametersLink
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.ParametersLink;
            }
        }

        public DeploymentMode? Mode
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Mode;
            }
        }

        public IDeploymentOperations DeploymentOperations
        {
            get
            {
                return new DeploymentOperationsImpl(deploymentOperationsClient, this);
            }
        }

        #endregion

        #region Setters

        #region Definition Setters

        public Deployment.Definition.IWithTemplate WithNewResourceGroup(string resourceGroupName, Region region)
        {
            creatableResourceGroup = resourceManager.ResourceGroups
                .Define(resourceGroupName)
                .WithRegion(region);
            this.resourceGroupName = resourceGroupName;
            return this;
        }

        public Deployment.Definition.IWithTemplate WithNewResourceGroup(ICreatable<IResourceGroup> groupDefinition)
        {
            creatableResourceGroup = groupDefinition;
            resourceGroupName = creatableResourceGroup.Key; // TODO Add support for Name in ICreatable
            return this;
        }

        public Deployment.Definition.IWithTemplate WithExistingResourceGroup(string resourceGroupName)
        {
            this.resourceGroupName = resourceGroupName;
            return this;
        }

        public Deployment.Definition.IWithTemplate WithExistingResourceGroup(IResourceGroup group)
        {
            resourceGroupName = group.Name;
            return this;
        }

        public Deployment.Definition.IWithParameters WithTemplate(object template)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }

            Inner.Properties.Template = template;
            Inner.Properties.TemplateLink = null;
            return this;
        }

        public Deployment.Definition.IWithParameters WithTemplate(string templateJson)
        {
            return WithTemplate(JsonConvert.DeserializeObject(templateJson));
        }

        public Deployment.Definition.IWithParameters WithTemplateLink(string uri, string contentVersion)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }
            Inner.Properties.TemplateLink = new TemplateLink(uri, contentVersion);
            Inner.Properties.Template = null;
            return this;
        }

        public Deployment.Definition.IWithMode WithParameters(object parameters)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }
            Inner.Properties.Parameters = parameters;
            Inner.Properties.ParametersLink = null;
            return this;
        }

        public Deployment.Definition.IWithMode WithParameters(string parametersJson)
        {
            return WithParameters(JsonConvert.DeserializeObject(parametersJson));
        }

        public Deployment.Definition.IWithMode WithParametersLink(string uri, string contentVersion)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }
            Inner.Properties.ParametersLink = new ParametersLink(uri, contentVersion);
            Inner.Properties.Parameters = null;
            return this;
        }

        public IWithCreate WithMode(DeploymentMode mode)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }
            Inner.Properties.Mode = mode;
            return this;
        }

        #endregion

        #region Update Setters

        IUpdate Deployment.Update.IWithTemplate.WithTemplate(object template)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }

            Inner.Properties.Template = template;
            Inner.Properties.TemplateLink = null;
            return this;
        }

        IUpdate Deployment.Update.IWithTemplate.WithTemplate(string templateJson)
        {
            var that = (IUpdate)this;
            return that.WithTemplate(JsonConvert.DeserializeObject(templateJson));
        }

        IUpdate Deployment.Update.IWithTemplate.WithTemplateLink(string uri, string contentVersion)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }
            Inner.Properties.TemplateLink = new TemplateLink(uri, contentVersion);
            Inner.Properties.Template = null;
            return this;
        }

        IUpdate Deployment.Update.IWithParameters.WithParameters(object parameters)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }
            Inner.Properties.Parameters = parameters;
            Inner.Properties.ParametersLink = null;
            return this;
        }

        IUpdate Deployment.Update.IWithParameters.WithParameters(string parametersJson)
        {
            var that = (IUpdate)this;
            return that.WithParameters(JsonConvert.DeserializeObject(parametersJson));
        }

        IUpdate Deployment.Update.IWithParameters.WithParametersLink(string uri, string contentVersion)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }
            Inner.Properties.ParametersLink = new ParametersLink(uri, contentVersion);
            Inner.Properties.Parameters = null;
            return this;
        }

        IUpdate Deployment.Update.IWithMode.WithMode(DeploymentMode mode)
        {
            if (Inner.Properties == null)
            {
                Inner.Properties = new DeploymentPropertiesExtended();
            }
            Inner.Properties.Mode = mode;
            return this;
        }

        #endregion

        #endregion

        #region actions 

        public void Cancel()
        {
            client.Cancel(resourceGroupName, Name);
        }

        public IDeploymentExportResult ExportTemplate
        {
            get
            {
                DeploymentExportResultInner inner = client.ExportTemplate(ResourceGroupName, Name);
                return new DeploymentExportResultImpl(inner);
            }
        }

        public IDeployment BeginCreate()
        {
            DeploymentInner inner = new DeploymentInner()
            {
                Properties = new DeploymentProperties
                {
                    Mode = Mode,
                    Template = Template,
                    TemplateLink = TemplateLink,
                    Parameters = Parameters,
                    ParametersLink = ParametersLink
                }
            };
            client.BeginCreateOrUpdate(resourceGroupName, Name, inner);
            return this;
        }

        #endregion

        #region Implementation of IRefreshable interface

        public async override Task<IDeployment> Refresh()
        {
            DeploymentExtendedInner inner = await client.GetAsync(ResourceGroupName, Name);
            SetInner(inner);
            return this;
        }

        #endregion

        #region Implementation of ICreatable interface 

        public new IDeployment Create()
        {
            if (creatableResourceGroup != null)
            {
                creatableResourceGroup.Create();
            }
            CreateResource();
            return this;
        }

        public async new Task<IDeployment> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            if (creatableResourceGroup != null)
            {
                await creatableResourceGroup.CreateAsync(cancellationToken);
            }
            return await CreateResourceAsync(cancellationToken);
        }

        #endregion

        #region Implementation of IResourceCreator interface

        public override async Task<IDeployment> CreateResourceAsync(CancellationToken cancellationToken)
        {
            DeploymentInner inner = new DeploymentInner
            {
                Properties = new DeploymentProperties
                {
                    Mode = Mode,
                    Template = Template,
                    TemplateLink = TemplateLink,
                    Parameters = Parameters,
                    ParametersLink = ParametersLink
                }
            };
            await client.CreateOrUpdateAsync(ResourceGroupName, Name, inner);
            return this;
        }

        public override IDeployment CreateResource()
        {
            DeploymentInner inner = new DeploymentInner
            {
                Properties = new DeploymentProperties
                {
                    Mode = Mode,
                    Template = Template,
                    TemplateLink = TemplateLink,
                    Parameters = Parameters,
                    ParametersLink = ParametersLink
                }
            };
            client.CreateOrUpdate(ResourceGroupName, Name, inner);
            return this;
        }

        #endregion

    }
}
