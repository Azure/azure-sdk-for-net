// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.FileStaging
{
    /// <summary>
    /// Provides basic file staging features.
    /// </summary>
    public interface IFileStagingProvider
    {
        /// <summary>
        /// Begins an asynchronous operation to stage all of the files in the given collection.
        /// When file staging begins, all instances of IFileStagingProvider are bucketized by their implementation type.
        /// This produces one collection of instances per implementation.
        /// Each implmentation of IFileStagingProvider has a StageFilesAsync() method.  That method is called once with the 
        /// collection produced by the bucketization step oulined above.
        /// </summary>
        /// <param name="filesToStage">Collection of all file staging objects to be staged.  All instances must have the same implementation type.</param>
        /// <param name="fileStagingArtifact">IFileStagingProvider specific staging artifacts including error/progress.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        System.Threading.Tasks.Task StageFilesAsync(List<IFileStagingProvider> filesToStage, IFileStagingArtifact fileStagingArtifact);

        /// <summary>
        /// Returns an instance of IFileStagingArtifact with whatever values the implementation requires.
        /// This will be called during file staging whenever a staging artifact has not been otherwise provided.
        /// </summary>
        /// <returns>An instance of IFileStagingArtifact with whatever values the implementation requires.</returns>
        IFileStagingArtifact CreateStagingArtifact();

        /// <summary>
        /// Performs client-side validation on the current object.
        /// </summary>
        void Validate();

        /// <summary>
        /// The collection of ResourceFile objects that are the result of file staging.   
        /// Must be set by the IFileStagingProvider.StageFilesAsync() method.
        /// </summary>
        IEnumerable<ResourceFile> StagedFiles { get; }
    }
}
