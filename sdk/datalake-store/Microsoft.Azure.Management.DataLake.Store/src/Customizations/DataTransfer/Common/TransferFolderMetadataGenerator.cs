// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;

namespace Microsoft.Azure.Management.DataLake.Store
{
    internal class TransferFolderMetadataGenerator
    {

        #region Private

        private readonly TransferParameters _parameters;
        private readonly IFrontEndAdapter _frontend;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the TransferFolderMetadataGenerator object with the given parameters and the given maximum append length.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="frontend">The frontend used when generating fresh metadata.</param>
        public TransferFolderMetadataGenerator(TransferParameters parameters, IFrontEndAdapter frontend)
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
        public TransferFolderMetadata GetExistingMetadata(string metadataFilePath)
        {
            //load from file (based on input parameters)
            var metadata = TransferFolderMetadata.LoadFrom(metadataFilePath, _parameters.ConcurrentFileCount);
            metadata.ValidateConsistency();
            return metadata;
        }    

        /// <summary>
        /// Creates a new metadata based on the given input parameters, and saves it to its canonical location.
        /// </summary>
        /// <returns></returns>
        public TransferFolderMetadata CreateNewMetadata(string metadataFilePath)
        {
            //create metadata
            var metadata = new TransferFolderMetadata(metadataFilePath, _parameters, _frontend);

            //save the initial version
            metadata.Save();

            return metadata;
        }

        #endregion

    }
}
