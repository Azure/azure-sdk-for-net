// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.IO;
using System.Text;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    internal class UploadFolderMetadataGenerator
    {

        #region Private

        private readonly UploadParameters _parameters;
        private readonly IFrontEndAdapter _frontend;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the UploadMetadataGenerator with the given parameters and the given maximum append length.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="frontend">The frontend used when generating fresh metadata.</param>
        public UploadFolderMetadataGenerator(UploadParameters parameters, IFrontEndAdapter frontend)
        {
            _parameters = parameters;
            _frontend = frontend;
        }

        #endregion

        #region Metadata Operations

        /// <summary>
        /// Attempts to load the metadata from an existing file in its canonical location.
        /// </summary>
        /// <param name="metadataFilePath">The metadata file path.</param>
        /// <returns></returns>
        public UploadFolderMetadata GetExistingMetadata(string metadataFilePath)
        {
            //load from file (based on input parameters)
            var metadata = UploadFolderMetadata.LoadFrom(metadataFilePath);
            metadata.ValidateConsistency();
            return metadata;
        }    

        /// <summary>
        /// Creates a new metadata based on the given input parameters, and saves it to its canonical location.
        /// </summary>
        /// <returns></returns>
        public UploadFolderMetadata CreateNewMetadata(string metadataFilePath)
        {
            //create metadata
            var metadata = new UploadFolderMetadata(metadataFilePath, _parameters, _frontend);

            //save the initial version
            metadata.Save();

            return metadata;
        }

        #endregion

    }
}
