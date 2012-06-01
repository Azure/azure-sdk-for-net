// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Data.Services.Client;
using System.Linq;
using Microsoft.WindowsAzure.MediaServices.Client.OAuth;
using Microsoft.WindowsAzure.MediaServices.Client.Versioning;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Describes the context from which all entities in the Microsoft WindowsAzure Media Services platform can be accessed.
    /// </summary>
    public class CloudMediaContext : MediaContextBase
    {
        internal const string NimbusRestApiCertificateThumbprint = "AC24B49ADEF9D6AA17195E041D3F8D07C88EC145";
        internal const string NimbusRestApiCertificateSubject = "CN=NimbusRestApi";

        private static readonly Uri _mediaServicesUri = new Uri("https://wamsamsclus001rest-hs.cloudapp.net/");
        private const string _mediaServicesAccessScope = "urn:WindowsAzureMediaServices";
        private static readonly Uri _mediaServicesAcsBaseAdress = new Uri("https://mediaservices.accesscontrol.windows.net");

        private readonly DataServiceContext _dataContext;
        private readonly AssetCollection _assets;
        private readonly FileInfoCollection _files;
        private readonly AccessPolicyCollection _accessPolicies;
        private readonly ContentKeyCollection _contentKeys;
        private readonly JobCollection _jobs;
        private readonly MediaProcessorCollection _mediaProcessorContext;
        private readonly LocatorCollection _locatorsCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMediaContext"/>.
        /// </summary>
        /// <param name="accountName">The Microsoft WindowsAzure Media Services account name to authenticate with.</param>
        /// <param name="accountKey">The Microsoft WindowsAzure Media Services account key to authenticate with.</param>
        public CloudMediaContext(string accountName, string accountKey)
            : this(CloudMediaContext._mediaServicesUri, accountName, accountKey, CloudMediaContext._mediaServicesAccessScope, CloudMediaContext._mediaServicesAcsBaseAdress.AbsoluteUri)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMediaContext"/>.
        /// </summary>
        /// <param name="apiServer">A <see cref="Uri"/> representing a the API endpoint.</param>
        /// <param name="accountName">The Microsoft WindowsAzure Media Services account name to authenticate with.</param>
        /// <param name="accountKey">The Microsoft WindowsAzure Media Services account key to authenticate with.</param>
        public CloudMediaContext(Uri apiServer, string accountName, string accountKey)
            : this(apiServer, accountName, accountKey, scope: CloudMediaContext._mediaServicesAccessScope, acsBaseAddress: CloudMediaContext._mediaServicesAcsBaseAdress.AbsoluteUri)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMediaContext"/>.
        /// </summary>
        /// <param name="apiServer">A <see cref="Uri"/> representing a the API endpoint.</param>
        /// <param name="accountName">The Microsoft WindowsAzure Media Services account name to authenticate with.</param>
        /// <param name="accountKey">The Microsoft WindowsAzure Media Services account key to authenticate with.</param>
        /// <param name="scope">The scope of authorization.</param>
        /// <param name="acsBaseAddress">The access control endpoint to authenticate against.</param>
        public CloudMediaContext(Uri apiServer, string accountName, string accountKey, string scope, string acsBaseAddress)
        {
            ParallelTransferThreadCount = 10;
            NumberOfConcurrentTransfers = 2;

            var oAuthDataServiceAdapter =
                new OAuthDataServiceAdapter(
                    accountName, accountKey,
                    scope, acsBaseAddress,
                    NimbusRestApiCertificateThumbprint,
                    NimbusRestApiCertificateSubject);
            var versionAdapter = new ServiceVersionAdapter(KnownApiVersions.Current);

            var dataServiceContextFactory = new AzureMediaServicesDataServiceContextFactory(oAuthDataServiceAdapter, versionAdapter);
            _dataContext = dataServiceContextFactory.CreateDataServiceContext(apiServer);

            _dataContext.ReadingEntity += OnReadingEntity;
            _jobs = new JobCollection(this);
            _assets = new AssetCollection(this);
            _files = new FileInfoCollection(_dataContext);
            _accessPolicies = new AccessPolicyCollection(_dataContext);
            _contentKeys = new ContentKeyCollection(_dataContext);
            _mediaProcessorContext = new MediaProcessorCollection(_dataContext);
            _locatorsCollection = new LocatorCollection(this);
        }

        /// <summary>
        /// Gets or sets the number of threads to use to for each blob transfer.
        /// </summary>
        /// <remarks>The default value is 10.</remarks>
        public int ParallelTransferThreadCount { get; set; }

        /// <summary>
        /// Gets or sets the number of concurrent blob transfers allowed.
        /// </summary>
        /// <remarks>The default value is 2.</remarks>
        public int NumberOfConcurrentTransfers { get; set; }

        private void OnReadingEntity(object sender, ReadingWritingEntityEventArgs args)
        {
            ICloudMediaContextInit init = args.Entity as ICloudMediaContextInit;
            if (init != null)
            {
                init.InitCloudMediaContext(this);
            }
        }
        
        internal DataServiceContext DataContext
        {
            get
            {
                return _dataContext;
            }
        }
       
        /// <summary>
        /// Gets the collection of assets in the system.
        /// </summary>
        public override BaseAssetCollection Assets
        {
            get { return _assets; }
        }

        /// <summary>
        /// Gets the collection of files in the system.
        /// </summary>
        public override BaseFileInfoCollection Files
        {
            get { return _files; }
        }

        /// <summary>
        /// Gets the collection of access policies in the system.
        /// </summary>
        public override AccessPolicyCollection AccessPolicies
        {
            get { return _accessPolicies; }
        }

        /// <summary>
        /// Gets the collection of content keys in the system.
        /// </summary>
        public override BaseContentKeyCollection ContentKeys
        {
            get { return _contentKeys; }
        }

        /// <summary>
        /// Gets the collection of jobs available in the system.
        /// </summary>
        public override JobCollection Jobs 
        { 
            get { return _jobs; }
        }

        
        /// <summary>
        /// Gets the collection of media processors available in the system.
        /// </summary>
        public override MediaProcessorCollection MediaProcessors
        {
            get { return _mediaProcessorContext; }
        }

        /// <summary>
        /// Gets the collection of locators in the system.
        /// </summary>
        public LocatorCollection Locators
        {
            get { return _locatorsCollection; }
        }

        /// <summary>
        /// Stops tracking all of the links and entities retrieved from this media context.
        /// </summary>
        public void DetachAll()
        {
            //
            //  Clear the objects.
            //
            foreach (EntityDescriptor entity in DataContext.Entities.ToList())
            {
                Detach(entity.Entity);
            }
        }

        /// <summary>
        /// Detaches an object tracked by the media context.
        /// </summary>
        /// <param name="entity">The object to detach from this media context.</param>
        public void Detach(object entity)
        {
            //
            //  Detach will detach an object regardless of status.
            //  After detaching the entity, Detach will also detach any links.
            //
            DataContext.Detach(entity);
        }
    }
}
