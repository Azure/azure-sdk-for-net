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

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Error List, point to "Suppress Message(s)", and click 
// "In Project Suppression File".
// You do not need to add suppressions to this file manually.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1824:MarkAssembliesWithNeutralResourcesLanguage", Justification = "Don't need this. We're not going to be localized for now - will revisit when we do localize.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2002:DoNotLockOnObjectsWithWeakIdentity", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.BlobTransferClient.#ReadResponseStream(Microsoft.Cloud.Media.Common.Encryption.FileEncryption,System.UInt64,System.IO.FileStream,System.Byte[],System.Net.HttpWebResponse,System.Collections.Generic.KeyValuePair`2<System.Int64,System.Int32>,System.Int64&)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.BulkIngest.BulkIngestAssetCollection.#Create(System.String[],System.String,Microsoft.Cloud.Media.SDK.Client.AssetCreationOptions,System.Boolean)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.BulkIngest.BulkIngestAssetData.#AccountId")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.BulkIngest.BulkIngestAssetData.#AccountId")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.BulkIngest.BulkIngestAssetData.#Options")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.BulkIngest.BulkIngestAssetData.#UserId")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.BulkIngest.BulkIngestAssetData.#UserId")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Microsoft.Cloud.Media.SDK.Client.BulkIngest.ContentKeyWriter")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Microsoft.Cloud.Media.SDK.Client.BulkIngest.FileInfoWriter")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.TaskData.#Progress")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.LocatorData.#AccessPolicy")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.Cloud.Media.SDK.Client.LocatorData.#Asset")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2002:DoNotLockOnObjectsWithWeakIdentity", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.BlobTransferClient.#ReadResponseStream(Microsoft.Cloud.Media.Common.Encryption.FileEncryption,System.UInt64,System.IO.FileStream,System.Byte[],System.Net.HttpWebResponse,System.Collections.Generic.KeyValuePair`2<System.Int64,System.Int32>,System.Int64&)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Microsoft.WindowsAzure.MediaServices.Client.BulkIngest.ContentKeyWriter")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Microsoft.WindowsAzure.MediaServices.Client.BulkIngest.FileInfoWriter")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.BulkIngest.BulkIngestAssetCollection.#Create(System.String[],System.String,Microsoft.WindowsAzure.MediaServices.Client.AssetCreationOptions,System.Boolean)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.BulkIngest.BulkIngestAssetData.#Options")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.TaskData.#Progress")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.LocatorData.#AccessPolicy")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.TaskData.#TaskInputs")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.TaskData.#TaskInputs")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.TaskData.#TaskOutputs")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.TaskData.#TaskOutputs")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.AssetPlaceholderToInstanceResolver.#EnsureSizeAndGetElement`1(System.Collections.Generic.List`1<!!0>,System.Int32,System.Func`1<!!0>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inputAssets", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.AssetPlaceholderToInstanceResolver.#EnsureInListsAndFindAsset(System.Collections.Generic.List`1<Microsoft.WindowsAzure.MediaServices.Client.IAsset>,System.Collections.Generic.List`1<Microsoft.WindowsAzure.MediaServices.Client.IAsset>,System.Collections.Generic.List`1<Microsoft.WindowsAzure.MediaServices.Client.IAsset>,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.AssetPlaceholderToInstanceResolver.#EnsureInListsAndFindAsset(System.Collections.Generic.List`1<Microsoft.WindowsAzure.MediaServices.Client.IAsset>,System.Collections.Generic.List`1<Microsoft.WindowsAzure.MediaServices.Client.IAsset>,System.Collections.Generic.List`1<Microsoft.WindowsAzure.MediaServices.Client.IAsset>,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.AssetPlaceholderToInstanceResolver.#ParseAssetName(System.String,Microsoft.WindowsAzure.MediaServices.Client.AssetPlaceholderToInstanceResolver+TemplateAssetType&,System.Int32&)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.AssetPlaceholderToInstanceResolver.#CreateOrGetOutputAsset(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.AssetPlaceholderToInstanceResolver.#CreateOrGetInputAsset(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.OutputAsset.#ParentAssets")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Microsoft.WindowsAzure.MediaServices.Client.MediaProcessorData")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1701:ResourceStringCompoundWordsShouldBeCasedCorrectly", MessageId = "readonly", Scope = "resource", Target = "Microsoft.WindowsAzure.MediaServices.Client.StringTable.resources")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.OutputAsset.#Id")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "obj", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.CriticalSection.#CheckCurrentThreadHoldsLock(System.Object)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "obj", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.CriticalSection.#Enter(System.Object)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.CriticalSection+DependentLockInfo.#CallStacks")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1821:RemoveEmptyFinalizers", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.CriticalSection+ExitOnDispose.#Finalize()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.CriticalSection.#Enter(System.Object)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Cryptographic.Standard", "CA5350:MD5CannotBeUsed", Scope = "member", Target = "Microsoft.WindowsAzure.MediaServices.Client.BlobTransferClient.#GetMd5HashFromStream(System.Byte[])",Justification = "MD5 used for checksum, not for encryption.")]
