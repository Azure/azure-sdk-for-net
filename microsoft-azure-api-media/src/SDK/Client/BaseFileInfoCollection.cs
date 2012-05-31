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

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Provides a base class for all <see cref="IFileInfo"/> Collections
    /// </summary>
    public abstract class BaseFileInfoCollection : BaseCollection<IFileInfo>
    {
        /// <summary>
        /// Updates the provided <paramref name="file"/>. 
        /// </summary>
        /// <param name="file">The file information to be updated.</param>
        public abstract void Update(IFileInfo file);
        
        internal static void VerifyFileInfo(IFileInfo file)
        {
            if (!(file is FileInfoData))
            {
                throw new InvalidCastException(StringTable.ErrorInvalidFileInfoType);
            }
        }
    }
}
