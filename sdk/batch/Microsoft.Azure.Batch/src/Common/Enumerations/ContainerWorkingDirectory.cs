// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Specifies the location of the container working directory.
    /// </summary>
    public enum ContainerWorkingDirectory
    {
        /// <summary>
        ///  Use the standard Batch service task working directory, which will contain the Task Resource Files populated by Batch.
        /// </summary>
        TaskWorkingDirectory,

        /// <summary>
        /// Use the working directory defined in the container image. Beware
        /// that this directory will not contain the Resource Files downloaded
        /// by Batch.
        /// </summary>
        ContainerImageDefault
    }
}
