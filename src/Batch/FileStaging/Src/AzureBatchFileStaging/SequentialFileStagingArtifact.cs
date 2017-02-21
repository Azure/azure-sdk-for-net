// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatchFS=Microsoft.Azure.Batch.FileStaging;

namespace Microsoft.Azure.Batch.FileStaging
{
    /// <summary>
    /// The file staging artifact payload for this file staging provider
    /// </summary>
    public sealed class SequentialFileStagingArtifact : IFileStagingArtifact
    {
        private string _namingFragment;

        /// <summary>
        /// The name of any blob container created.  
        /// 
        /// A blob container is created if there is at least one file 
        /// to be uploaded that does not have an explicit container specified.
        /// </summary>
        public string BlobContainerCreated { get; internal set;}

        /// <summary>
        /// Optionally set by caller.  Optionally used by implementation. A name fragment that can be used when constructing default names.
        /// 
        /// Can only be set once.
        /// </summary>
        public string NamingFragment
        {
            get { return _namingFragment;}

            set
            {
                if (null != _namingFragment)
                {
                    throw new ArgumentException(string.Format(BatchFS.ErrorMessages.FileStagingPropertyCanBeSetOnlyOnce, "NamingFragment"));
                }

                _namingFragment = value;
            }
        }

        /// <summary>
        /// Holds the SAS for the default container after it is created.
        /// </summary>
        internal string DefaultContainerSAS { get; set;}
    }
}
