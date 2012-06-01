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

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.MediaServices.Client.BulkIngest
{
    internal class BulkIngestFileInfoCollection : BaseFileInfoCollection
    {
        private readonly List<IAsset> _trackedAssets;

        internal BulkIngestFileInfoCollection(List<IAsset> trackedAssets)
        {
            _trackedAssets = trackedAssets;
        }

        protected override IQueryable<IFileInfo> Queryable
        {
            get { return _trackedAssets.SelectMany(a => a.Files).AsQueryable(); }
        }

        /// <summary>
        /// Marks the provided <paramref name="file"/> as updated.
        /// </summary>
        /// <param name="file">The file information to mark as updated.</param>
        /// <remarks>throws NotSupportedException.</remarks>
        public override void Update(IFileInfo file)
        {
            throw new System.NotSupportedException();
        }
    }
}
