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


//
// DO NOT EDIT
// This class is auto generated. Edit ODataClasses.tt
//

using System;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    public partial interface IAsset
    {
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAsset.Id"]'/>
        string Id
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAsset.State"]'/>
        AssetState State
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAsset.Created"]'/>
        DateTime Created
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAsset.LastModified"]'/>
        DateTime LastModified
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAsset.Name"]'/>
        string Name
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAsset.AlternateId"]'/>
        string AlternateId
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAsset.Options"]'/>
        AssetCreationOptions Options
        {
            get;
        }
    }
    public partial interface IFileInfo
    {
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.Id"]'/>
        string Id
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.MimeType"]'/>
        string MimeType
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.Created"]'/>
        DateTime Created
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.LastModified"]'/>
        DateTime LastModified
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.IsPrimary"]'/>
        bool IsPrimary
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.ContentFileSize"]'/>
        long ContentFileSize
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.ContentChecksum"]'/>
        string ContentChecksum
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.Name"]'/>
        string Name
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.ParentAssetId"]'/>
        string ParentAssetId
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.EncryptionVersion"]'/>
        string EncryptionVersion
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.EncryptionScheme"]'/>
        string EncryptionScheme
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.IsEncrypted"]'/>
        bool IsEncrypted
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.EncryptionKeyId"]'/>
        string EncryptionKeyId
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IFileInfo.InitializationVector"]'/>
        string InitializationVector
        {
            get;
        }
    }
    public partial interface IContentKey
    {
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IContentKey.Id"]'/>
        string Id
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IContentKey.Created"]'/>
        DateTime Created
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IContentKey.LastModified"]'/>
        DateTime LastModified
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IContentKey.Name"]'/>
        string Name
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IContentKey.EncryptedContentKey"]'/>
        string EncryptedContentKey
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IContentKey.ContentKeyType"]'/>
        ContentKeyType ContentKeyType
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IContentKey.ProtectionKeyId"]'/>
        string ProtectionKeyId
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IContentKey.ProtectionKeyType"]'/>
        ProtectionKeyType ProtectionKeyType
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IContentKey.Checksum"]'/>
        string Checksum
        {
            get;
        }
    }
    public partial interface IAccessPolicy
    {
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAccessPolicy.Id"]'/>
        string Id
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAccessPolicy.Created"]'/>
        DateTime Created
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAccessPolicy.LastModified"]'/>
        DateTime LastModified
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAccessPolicy.Name"]'/>
        string Name
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IAccessPolicy.Permissions"]'/>
        AccessPermissions Permissions
        {
            get;
        }
    }
    public partial interface IJob
    {
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.Id"]'/>
        string Id
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.Priority"]'/>
        int Priority
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.State"]'/>
        JobState State
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.Name"]'/>
        string Name
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.Created"]'/>
        DateTime Created
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.LastModified"]'/>
        DateTime LastModified
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.StartTime"]'/>
        DateTime? StartTime
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.EndTime"]'/>
        DateTime? EndTime
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.RunningDuration"]'/>
        TimeSpan RunningDuration
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IJob.TemplateId"]'/>
        string TemplateId
        {
            get;
        }
    }
    public partial interface ITask
    {
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.Id"]'/>
        string Id
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.Name"]'/>
        string Name
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.MediaProcessorId"]'/>
        string MediaProcessorId
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.State"]'/>
        JobState State
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.PerfMessage"]'/>
        string PerfMessage
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.Priority"]'/>
        int Priority
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.StartTime"]'/>
        DateTime? StartTime
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.EndTime"]'/>
        DateTime? EndTime
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.RunningDuration"]'/>
        TimeSpan RunningDuration
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.TaskBody"]'/>
        string TaskBody
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.Configuration"]'/>
        string Configuration
        {
            get;
            set;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.Options"]'/>
        TaskCreationOptions Options
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.InitializationVector"]'/>
        string InitializationVector
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.EncryptionVersion"]'/>
        string EncryptionVersion
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.EncryptionScheme"]'/>
        string EncryptionScheme
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ITask.EncryptionKeyId"]'/>
        string EncryptionKeyId
        {
            get;
        }
    }
    public partial interface ILocator
    {
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ILocator.Id"]'/>
        string Id
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ILocator.AssetId"]'/>
        string AssetId
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ILocator.StartTime"]'/>
        DateTime? StartTime
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ILocator.ExpirationDateTime"]'/>
        DateTime ExpirationDateTime
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ILocator.AccessPolicyId"]'/>
        string AccessPolicyId
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ILocator.Type"]'/>
        LocatorType Type
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="ILocator.Path"]'/>
        string Path
        {
            get;
        }
    }
    public partial interface IMediaProcessor
    {
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IMediaProcessor.Id"]'/>
        string Id
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IMediaProcessor.Created"]'/>
        DateTime Created
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IMediaProcessor.LastModified"]'/>
        DateTime LastModified
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IMediaProcessor.Name"]'/>
        string Name
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IMediaProcessor.Version"]'/>
        string Version
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IMediaProcessor.Sku"]'/>
        string Sku
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IMediaProcessor.Vendor"]'/>
        string Vendor
        {
            get;
        }
        /// <include file='Documentation.xml' path='Documentation/Member[@name="IMediaProcessor.Description"]'/>
        string Description
        {
            get;
        }
    }

}
