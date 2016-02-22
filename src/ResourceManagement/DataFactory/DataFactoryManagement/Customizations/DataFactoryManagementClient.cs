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

using Hyak.Common;
using System;
using System.Net.Http;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Client for interacting with the Azure Data Factory service.
    /// </summary>
    public partial class DataFactoryManagementClient : ServiceClient<DataFactoryManagementClient>, IDataFactoryManagementClient
    {
        /// <summary>
        /// The URI used as the base for all Service Management requests.
        /// </summary>
        public Uri BaseUri
        {
            get
            {
                return this.InternalClient.BaseUri;
            }

            set
            {
                this.InternalClient.BaseUri = value;
            }
        }

        /// <summary>
        /// When you create a Windows Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management
        /// API. The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure. No anonymous requests are
        /// allowed.
        /// </summary>
        public SubscriptionCloudCredentials Credentials
        {
            get
            {
                return this.InternalClient.Credentials;
            }

            set
            {
                this.InternalClient.Credentials = value;
            }
        }

        /// <summary>
        /// Operations for managing data factory ActivityTypes.
        /// </summary>
        public virtual IActivityTypeOperations ActivityTypes { get; private set; }

        /// <summary>
        /// Operations for managing activity windows.
        /// </summary>
        public virtual IActivityWindowOperations ActivityWindows { get; private set; }

        /// <summary>
        /// Operations for managing data factory ComputeTypes.
        /// </summary>
        public virtual IComputeTypeOperations ComputeTypes { get; private set; }

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
        public virtual ILinkedServiceOperations LinkedServices { get; private set; }

        /// <summary>
        /// Operations for managing pipelines.
        /// </summary>
        public virtual IPipelineOperations Pipelines { get; private set; }

        /// <summary>
        /// Operations for managing Datasets.
        /// </summary>
        public virtual IDatasetOperations Datasets { get; private set; }

        /// <summary>
        /// Operations for OAuth authorization.
        /// </summary>
        public virtual IOAuthOperations OAuth { get; private set; }

        /// <summary>
        /// Gets or sets the initial timeout for Long Running Operations (in seconds).
        /// </summary>
        public int LongRunningOperationInitialTimeout
        {
            get
            {
                return this.InternalClient.LongRunningOperationInitialTimeout;
            }

            set
            {
                this.InternalClient.LongRunningOperationInitialTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the retry timeout for Long Running Operations (in seconds).
        /// </summary>
        public int LongRunningOperationRetryTimeout
        {
            get
            {
                return this.InternalClient.LongRunningOperationRetryTimeout;
            }

            set
            {
                this.InternalClient.LongRunningOperationRetryTimeout = value;
            }
        }

        internal Core.DataFactoryManagementClient InternalClient { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFactoryManagementClient"/> class. 
        /// </summary>
        public DataFactoryManagementClient()
        {
            this.PreInitialize();
            this.PostInitialize();
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
            : this()
        {
            Ensure.IsNotNull(credentials, "credentials");
            Ensure.IsNotNull(baseUri, "baseUri");

            this.InternalClient = new Core.DataFactoryManagementClient(credentials, baseUri);

            this.Credentials.InitializeServiceClient(this);
            this.PostInitialize();
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

            this.InternalClient = new Core.DataFactoryManagementClient(credentials);

            this.Credentials.InitializeServiceClient(this);
            this.PostInitialize();
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
            this.PreInitialize();
            this.InternalClient = new Core.DataFactoryManagementClient(httpClient);
            this.PostInitialize();
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
            : this(httpClient)
        {
            Ensure.IsNotNull(credentials, "credentials");
            Ensure.IsNotNull(baseUri, "baseUri");

            this.InternalClient = new Core.DataFactoryManagementClient(credentials, baseUri, httpClient);

            this.Credentials.InitializeServiceClient(this);
            this.PostInitialize();
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

            this.InternalClient = new Core.DataFactoryManagementClient(credentials, httpClient);

            this.Credentials.InitializeServiceClient(this);
            this.PostInitialize();
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
                clonedClient.LongRunningOperationRetryTimeout = this.LongRunningOperationRetryTimeout;
                clonedClient.LongRunningOperationInitialTimeout = this.LongRunningOperationInitialTimeout;

                clonedClient.Credentials.InitializeServiceClient(clonedClient.InternalClient);
                clonedClient.Credentials.InitializeServiceClient(clonedClient);
            }
        }

        protected override DataFactoryManagementClient WithHandler(ServiceClient<DataFactoryManagementClient> newClient,
            DelegatingHandler handler)
        {
            DataFactoryManagementClient client = base.WithHandler(newClient, handler);
            client.InternalClient.HttpClient = client.HttpClient;
            return client;
        }

        private void PreInitialize()
        {
            this.ActivityTypes = new ActivityTypeOperations(this);
            this.ActivityWindows = new ActivityWindowOperations(this);
            this.ComputeTypes = new ComputeTypeOperations(this);
            this.DataFactories = new DataFactoryOperations(this);
            this.DataSlices = new DataSliceOperations(this);
            this.DataSliceRuns = new DataSliceRunOperations(this);
            this.Gateways = new GatewayOperations(this);
            this.Hubs = new HubOperations(this);
            this.LinkedServices = new LinkedServiceOperations(this);
            this.OAuth = new OAuthOperations(this);
            this.Pipelines = new PipelineOperations(this);
            this.Datasets = new DatasetOperations(this);
        }

        private void PostInitialize()
        {
            if (this.InternalClient == null)
            {
                this.InternalClient = new Core.DataFactoryManagementClient();
            }

            this.HttpClient.Timeout = this.InternalClient.HttpClient.Timeout;
        }
    }
}
