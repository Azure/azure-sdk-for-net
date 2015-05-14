//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Net.Http;
using Hyak.Common;
using Microsoft.Azure.Management.DataFactories.Core;

namespace Microsoft.Azure.Management.DataFactories
{

    /// <summary>
    /// Client for interacting with the Azure Data Factory service.
    /// </summary>
    public class DataFactoryManagementClient : ServiceClient<DataFactoryManagementClient>, IDataFactoryManagementClient
    {
        /// <summary>
        /// The URI used as the base for all Service Management requests.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// When you create a Windows Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management
        /// API. The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure. No anonymous requests are
        /// allowed.
        /// </summary>
        public SubscriptionCloudCredentials Credentials { get; set; }

#if ADF_INTERNAL
        /// <summary>
        /// Operations for managing data factory ActivityTypes.
        /// </summary>
        public virtual ActivityTypeOperations ActivityTypes { get; private set; }
        
        /// <summary>
        /// Operations for managing data factory ComputeTypes.
        /// </summary>
        public virtual ComputeTypeOperations ComputeTypes { get; private set; }
#endif

        /// <summary>
        /// Operations for managing data factories.
        /// </summary>
        public virtual IDataFactoryOperations DataFactories { get; private set; }

        /// <summary>
        /// Operations for managing data slices.
        /// </summary>
        public virtual IDataSliceOperations DataSlices { get; private set; }

        /// <summary>
        /// Operations for managing data slice runs.
        /// </summary>
        public virtual IDataSliceRunOperations DataSliceRuns { get; private set; }

        /// <summary>
        /// Operations for managing data factory gateways.
        /// </summary>
        public virtual IGatewayOperations Gateways { get; private set; }

        /// <summary>
        /// Operations for managing hubs.
        /// </summary>
        public virtual IHubOperations Hubs { get; private set; }

        /// <summary>
        /// Operations for managing data factory linkedServices.
        /// </summary>
        public virtual LinkedServiceOperations LinkedServices { get; private set; }

        /// <summary>
        /// Operations for managing pipelines.
        /// </summary>
        public virtual PipelineOperations Pipelines { get; private set; }

        /// <summary>
        /// Operations for managing pipeline runs.
        /// </summary>
        public virtual IPipelineRunOperations PipelineRuns { get; private set; }

        /// <summary>
        /// Operations for managing tables.
        /// </summary>
        public virtual TableOperations Tables { get; private set; }

        internal Core.DataFactoryManagementClient InternalClient { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFactoryManagementClient"/> class. 
        /// </summary>
        public DataFactoryManagementClient()
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFactoryManagementClient"/> class. 
        /// </summary>
        /// <param name='credentials'>
        /// Required. When you create a Windows Azure subscription, it is
        /// uniquely identified by a subscription ID. The subscription ID
        /// forms part of the URI for every call that you make to the Service
        /// Management API. The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure. No anonymous requests are
        /// allowed.
        /// </param>
        /// <param name='baseUri'>
        /// The URI used as the base for all Service Management requests.
        /// </param>
        public DataFactoryManagementClient(SubscriptionCloudCredentials credentials, Uri baseUri)
            : this(credentials)
        {
            Ensure.IsNotNull(baseUri, "baseUri");
            this.BaseUri = baseUri;
            this.InternalClient.BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFactoryManagementClient"/> class. 
        /// </summary>
        /// <param name='credentials'>
        /// Required. When you create a Windows Azure subscription, it is
        /// uniquely identified by a subscription ID. The subscription ID
        /// forms part of the URI for every call that you make to the Service
        /// Management API. The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure. No anonymous requests are
        /// allowed.
        /// </param>
        public DataFactoryManagementClient(SubscriptionCloudCredentials credentials)
            : this()
        {
            Ensure.IsNotNull(credentials, "credentials");

            this.InternalClient.Credentials = credentials;
            this.Credentials = credentials;
            this.BaseUri = new Uri("https://management.azure.com");
            
            this.Credentials.InitializeServiceClient(this.InternalClient);
            this.Credentials.InitializeServiceClient(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFactoryManagementClient"/> class. 
        /// </summary>
        /// <param name="httpClient">
        /// The Http client
        /// </param>
        public DataFactoryManagementClient(HttpClient httpClient)
            : base(httpClient)
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFactoryManagementClient"/> class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. When you create a Windows Azure subscription, it is
        /// uniquely identified by a subscription ID. The subscription ID
        /// forms part of the URI for every call that you make to the Service
        /// Management API. The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure. No anonymous requests are
        /// allowed.
        /// </param>
        /// <param name='baseUri'>
        /// Optional. The URI used as the base for all Service Management
        /// requests.
        /// </param>
        /// <param name='httpClient'>
        /// The Http client
        /// </param>
        public DataFactoryManagementClient(
            SubscriptionCloudCredentials credentials,
            Uri baseUri,
            HttpClient httpClient)
            : this(credentials, httpClient)
        {
            Ensure.IsNotNull(baseUri, "baseUri");
            this.BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFactoryManagementClient"/> class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. When you create a Windows Azure subscription, it is
        /// uniquely identified by a subscription ID. The subscription ID
        /// forms part of the URI for every call that you make to the Service
        /// Management API. The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure. No anonymous requests are
        /// allowed.
        /// </param>
        /// <param name='httpClient'>
        /// The Http client
        /// </param>
        public DataFactoryManagementClient(SubscriptionCloudCredentials credentials, HttpClient httpClient)
            : this(httpClient)
        {
            Ensure.IsNotNull(credentials, "credentials");

            this.Credentials = credentials;
            this.BaseUri = new Uri("https://management.azure.com");

            this.Credentials.InitializeServiceClient(this.InternalClient);
            this.Credentials.InitializeServiceClient(this);
        }

        /// <summary>
        /// Clones properties from current instance to another DataFactoryManagementClient instance.
        /// </summary>
        /// <param name='client'>
        /// Instance of DataFactoryManagementClient to clone to
        /// </param>
        protected override void Clone(ServiceClient<DataFactoryManagementClient> client)
        {
            base.Clone(client);

            DataFactoryManagementClient managementClient = client as DataFactoryManagementClient;
            if (managementClient != null)
            {
                DataFactoryManagementClient clonedClient = managementClient;

                clonedClient.Credentials = this.Credentials;
                clonedClient.BaseUri = this.BaseUri;

                clonedClient.InternalClient.Credentials = this.Credentials;
                clonedClient.InternalClient.BaseUri = this.BaseUri;

                clonedClient.Credentials.InitializeServiceClient(clonedClient.InternalClient);
                clonedClient.Credentials.InitializeServiceClient(clonedClient);
            }
        }

        private void Initialize()
        {
            this.InternalClient = new Core.DataFactoryManagementClient();

#if ADF_INTERNAL
            this.ActivityTypes = new ActivityTypeOperations(this);
            this.ComputeTypes = new ComputeTypeOperations(this);
#endif
            this.DataFactories = this.InternalClient.DataFactories;
            this.DataSlices = this.InternalClient.DataSlices;
            this.DataSliceRuns = this.InternalClient.DataSliceRuns;
            this.Gateways = this.InternalClient.Gateways;
            this.Hubs = this.InternalClient.Hubs;
            this.LinkedServices = new LinkedServiceOperations(this);
            this.Pipelines = new PipelineOperations(this);
            this.PipelineRuns = this.InternalClient.PipelineRuns;
            this.Tables = new TableOperations(this);
            this.HttpClient.Timeout = this.InternalClient.HttpClient.Timeout;
            this.Credentials = this.InternalClient.Credentials;
            this.BaseUri = this.InternalClient.BaseUri;
        }
    }
}
