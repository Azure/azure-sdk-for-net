// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService.Models
{
    // ROOT CAUSE: The mgmt generator emits IList<T> / IDictionary<TKey,TValue> collection properties
    // as read-only auto-properties (get-only, initialized inline via ChangeTrackingList<T>). GA 1.5.0
    // exposed these with public setters, so reassignment with a new collection was a supported
    // workflow. Adding @@usage(SiteConfig, input|output, "csharp") does not change emitter behavior
    // for collection-typed properties. CodeGenSuppress + redeclaration restores the GA-compatible
    // setter on SiteConfigProperties; SiteConfigData has matching forwarder shims.
    [CodeGenSuppress("AppSettings")]
    [CodeGenSuppress("AzureStorageAccounts")]
    [CodeGenSuppress("ConnectionStrings")]
    [CodeGenSuppress("DefaultDocuments")]
    [CodeGenSuppress("HandlerMappings")]
    [CodeGenSuppress("IPSecurityRestrictions")]
    [CodeGenSuppress("Metadata")]
    [CodeGenSuppress("ScmIPSecurityRestrictions")]
    [CodeGenSuppress("VirtualApplications")]
    public partial class SiteConfigProperties
    {
        // Add this property back to avoid breaking change with the fix for issue #56828
        /// <summary>
        /// The URL of the API definition.
        /// </summary>
        [WirePath("apiDefinition.url")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri ApiDefinitionUri
        {
            get
            {
                if (ApiDefinitionUriStringValue is null)
                    return null;
                return Uri.TryCreate(ApiDefinitionUriStringValue, UriKind.Absolute, out var uri) ? uri : null;
            }
            set => ApiDefinitionUriStringValue = value?.AbsoluteUri;
        }

        /// <summary> Application settings. </summary>
        [WirePath("appSettings")]
        public IList<AppServiceNameValuePair> AppSettings { get; set; } = new ChangeTrackingList<AppServiceNameValuePair>();

        /// <summary> List of Azure Storage Accounts. </summary>
        [WirePath("azureStorageAccounts")]
        public IDictionary<string, AppServiceStorageAccessInfo> AzureStorageAccounts { get; set; } = new ChangeTrackingDictionary<string, AppServiceStorageAccessInfo>();

        /// <summary> Connection strings. </summary>
        [WirePath("connectionStrings")]
        public IList<ConnStringInfo> ConnectionStrings { get; set; } = new ChangeTrackingList<ConnStringInfo>();

        /// <summary> Default documents. </summary>
        [WirePath("defaultDocuments")]
        public IList<string> DefaultDocuments { get; set; } = new ChangeTrackingList<string>();

        /// <summary> Handler mappings. </summary>
        [WirePath("handlerMappings")]
        public IList<HttpRequestHandlerMapping> HandlerMappings { get; set; } = new ChangeTrackingList<HttpRequestHandlerMapping>();

        /// <summary> IP security restrictions for main. </summary>
        [WirePath("ipSecurityRestrictions")]
        public IList<AppServiceIPSecurityRestriction> IPSecurityRestrictions { get; set; } = new ChangeTrackingList<AppServiceIPSecurityRestriction>();

        /// <summary> Application metadata. This property cannot be retrieved, since it may contain secrets. </summary>
        [WirePath("metadata")]
        public IList<AppServiceNameValuePair> Metadata { get; set; } = new ChangeTrackingList<AppServiceNameValuePair>();

        /// <summary> IP security restrictions for scm. </summary>
        [WirePath("scmIpSecurityRestrictions")]
        public IList<AppServiceIPSecurityRestriction> ScmIPSecurityRestrictions { get; set; } = new ChangeTrackingList<AppServiceIPSecurityRestriction>();

        /// <summary> Virtual applications. </summary>
        [WirePath("virtualApplications")]
        public IList<VirtualApplication> VirtualApplications { get; set; } = new ChangeTrackingList<VirtualApplication>();
    }
}
