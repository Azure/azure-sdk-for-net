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
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Data.Services.Common;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Microsoft.WindowsAzure.MediaServices.Client.OAuth;
using Microsoft.WindowsAzure.MediaServices.Client.Versioning;

namespace Microsoft.WindowsAzure.MediaServices.Client.BulkIngest
{
    /// <summary>
    /// Provides the ability to generate manifest files that describe Microsoft.Cloud.Media constructs.
    /// </summary>
    public class BulkIngestMediaContext : MediaContextBase
    {
        private readonly List<IAsset> _trackedAssets = new List<IAsset>();
        private readonly List<IContentKey> _trackedContentKeys = new List<IContentKey>();
        private readonly string _outputFolder;
        private readonly BulkIngestAssetCollection _assets;
        private readonly BulkIngestFileInfoCollection _fileInfos;
        private readonly BulkIngestContentKeyCollection _contentKeys;
        private readonly string[] _protectionKeyIds;

        /// <summary>
        /// Initializes a new instance of the <see cref="BulkIngestMediaContext"/>.
        /// </summary>
        /// <param name="apiServer">A <see cref="Uri"/> representing a the API endpoint.</param>
        /// <param name="clientId">The client id to authenticate with.</param>
        /// <param name="clientSecret">The client secret to authenticate with.</param>
        /// <param name="scope">The scope of authorization.</param>
        /// <param name="acsBaseAddress">The access control endpoint to authenticate against.</param>
        /// <param name="outputFolder">The folder in which generated content such as manifests and encrypted <see cref="IAsset"/> will be saved.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="outputFolder"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="outputFolder"/> does not exist.</exception>
        public BulkIngestMediaContext(Uri apiServer, string clientId, string clientSecret, string scope, string acsBaseAddress, string outputFolder)
        {
            if (outputFolder == null)
            {
                throw new ArgumentNullException("outputFolder");
            }

            if (!Directory.Exists(outputFolder))
            {
                throw new ArgumentException(StringTable.BulkIngestFolderDoesNotExist, "outputFolder");
            }
            _outputFolder = outputFolder;

            DataServiceContext dataContext = new DataServiceContext(apiServer, DataServiceProtocolVersion.V3)
            {
                IgnoreMissingProperties = true,
                IgnoreResourceNotFoundException = true
            };

            var oAuthDataServiceAdapter =
                new OAuthDataServiceAdapter(
                    clientId, clientSecret,
                    scope, acsBaseAddress,
                    CloudMediaContext.NimbusRestApiCertificateThumbprint,
                    CloudMediaContext.NimbusRestApiCertificateSubject);
            oAuthDataServiceAdapter.Adapt(dataContext);

            var versionAdapter = new ServiceVersionAdapter(KnownApiVersions.Current);
            versionAdapter.Adapt(dataContext);

            int[] values = (int[])Enum.GetValues(typeof(ContentKeyType));
            _protectionKeyIds = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                _protectionKeyIds[values[i]] = BaseContentKeyCollection.GetProtectionKeyIdForContentKey(dataContext, (ContentKeyType)values[i]);
            }

            _outputFolder = outputFolder;
            _assets = new BulkIngestAssetCollection(_protectionKeyIds, _trackedAssets, _trackedContentKeys, _outputFolder);
            _fileInfos = new BulkIngestFileInfoCollection(_trackedAssets);
            _contentKeys = new BulkIngestContentKeyCollection(_protectionKeyIds, _trackedContentKeys);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BulkIngestMediaContext"/>.
        /// </summary>
        /// <param name="protectionKeyIds">An array containing the key IDs to use for different possible encryption types for created assets. The index 
        /// of the array corresponds to the values of the enum type <see cref="Microsoft.WindowsAzure.MediaServices.Client.ContentKeyType"/>.</param>
        /// <param name="outputFolder">The folder in which generated content such as manifests and encrypted <see cref="IAsset"/> will be saved.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="outputFolder"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="outputFolder"/> does not exist.</exception>
        public BulkIngestMediaContext(string[] protectionKeyIds, string outputFolder)
        {
            if (outputFolder == null)
            {
                throw new ArgumentNullException("outputFolder");
            }

            if (!Directory.Exists(outputFolder))
            {
                throw new ArgumentException(StringTable.BulkIngestFolderDoesNotExist, "outputFolder");
            }

            _outputFolder = outputFolder;
            _assets = new BulkIngestAssetCollection(protectionKeyIds, _trackedAssets, _trackedContentKeys, _outputFolder);
            _fileInfos = new BulkIngestFileInfoCollection(_trackedAssets);
            _contentKeys = new BulkIngestContentKeyCollection(protectionKeyIds, _trackedContentKeys);
        }
        
        /// <summary>
        /// Initializes a new instance of <see cref="BulkIngestMediaContext"/>.
        /// </summary>
        public BulkIngestMediaContext(string[] protectionKeyIds)
        {
            _assets = new BulkIngestAssetCollection(protectionKeyIds, _trackedAssets, _trackedContentKeys, _outputFolder);
            _fileInfos = new BulkIngestFileInfoCollection(_trackedAssets);
            _contentKeys = new BulkIngestContentKeyCollection(protectionKeyIds, _trackedContentKeys);
        }

        /// <summary>
        /// Gets a collection to operate on Assets.
        /// </summary>
        public override BaseAssetCollection Assets
        {
            get { return _assets; }
        }

        /// <summary>
        /// Gets the collection of files in this ingest operation.
        /// </summary>
        public override BaseFileInfoCollection Files
        {
            get { return _fileInfos; }
        }

        /// <summary>
        /// This operation is not supported.
        /// </summary>
        public override AccessPolicyCollection AccessPolicies
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Gets the list of content keys used in this ingest operation.
        /// </summary>
        public override BaseContentKeyCollection ContentKeys
        {
            get { return _contentKeys; }
        }

        /// <summary>
        /// Getting a list of jobs is not supported.
        /// </summary>
        public override JobCollection Jobs
        {
            get { throw new NotSupportedException(); }
        }

       
        /// <summary>
        /// Getting the list of media processors is not supported.
        /// </summary>
        public override MediaProcessorCollection MediaProcessors
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Saves the bulk ingest output manifest to the provided output folder.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the instance of <see cref="Microsoft.WindowsAzure.MediaServices.Client.BulkIngest.BulkIngestMediaContext"/> was created without supplying an outputFolder."/></exception>
        public void SaveChanges()
        {
            if (string.IsNullOrEmpty(_outputFolder))
            {
                throw new InvalidOperationException(StringTable.ErrorNoOutputFolderSpecified);
            }

            Guid ingestIdentifier = Guid.NewGuid();
            OutputManifest = string.Format(CultureInfo.InvariantCulture, "Manifest-{0:N}.xml", ingestIdentifier);
            var outputSettings =
                new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = true
                };

            var manifestFile = Path.Combine(_outputFolder, OutputManifest);

            using (FileStream outputFile = File.Create(manifestFile))
            {
                XmlWriter output = XmlWriter.Create(outputFile, outputSettings);
                SaveTo(ingestIdentifier, output);
            }

            _trackedAssets.Clear();
        }

        /// <summary>
        /// Gets the bulk ingest output manifest.
        /// </summary>
        public string OutputManifest { get; private set; }

        /// <summary>
        /// Saves the ingest manifest to an output.
        /// </summary>
        /// <param name="output">The <see cref="System.Xml.XmlWriter"/> object used to write the output to.</param>
        /// <returns>The ID of this bulk ingest operation.</returns>
        public Guid SaveTo(XmlWriter output)
        {
            return SaveTo(Guid.NewGuid(), output);
        }

        private Guid SaveTo(Guid ingestIdentifier, XmlWriter output)
        {
            var manifest = new ManifestWriter(ingestIdentifier, _trackedAssets, _trackedContentKeys);
            manifest.WriteTo(output);
            return ingestIdentifier;
        }
    }
}
