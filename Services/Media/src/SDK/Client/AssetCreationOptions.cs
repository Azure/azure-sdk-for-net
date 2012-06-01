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
    /// Specifies the the different options that an <see cref="IAsset"/> can be created with.
    /// </summary>
    /// <remarks>This is a flags enum.</remarks>
    [Flags]
    public enum AssetCreationOptions
    {
        /// <summary>
        /// Specifies no Asset creation options.
        /// </summary>
        /// <remarks>This is the default value.</remarks>
        None = 0x0,
        /// <summary>
        /// Specifies that an Asset's files should be encrypted on for upload and storage when creating the Asset.
        /// </summary>
        StorageEncrypted = 0x1,
        /// <summary>
        /// Specifies that an Assets files are protected using a common encryption method (such as Play Ready.)
        /// </summary>
        CommonEncryptionProtected = 0x2
    }
}
