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

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    internal class FileInfoCollection : BaseFileInfoCollection
    {
        internal const string FileSet = "Files";

        private readonly DataServiceContext _dataContext;
        private readonly Lazy<IQueryable<IFileInfo>> _fileInfoQuery;

        internal FileInfoCollection(DataServiceContext dataContext)
        {
            _dataContext = dataContext;
            _fileInfoQuery = new Lazy<IQueryable<IFileInfo>>(() => dataContext.CreateQuery<FileInfoData>(FileSet));
        }

        protected override IQueryable<IFileInfo> Queryable
        {
            get { return _fileInfoQuery.Value; }
        }

        public override void Update(IFileInfo file)
        {
            VerifyFileInfo(file);
            _dataContext.UpdateObject(file);
            _dataContext.SaveChanges();
        }
    }
}
