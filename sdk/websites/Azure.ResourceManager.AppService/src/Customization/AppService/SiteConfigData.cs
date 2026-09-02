// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService
{
    // ROOT CAUSE: The mgmt generator forwards SiteConfigProperties' collection properties to
    // SiteConfigData as getter-only because the underlying property bag emits them as init-only
    // collections. After we re-enable setters on SiteConfigProperties (CodeGenSuppress +
    // redeclaration), this partial mirrors the same change on the resource-data class so the GA
    // 1.5.0 `SiteConfigData.Foo = ...` surface keeps working. Setters route through the
    // Properties bag, instantiating it on demand to match the generated getter behavior.
    [CodeGenSuppress("AppSettings")]
    [CodeGenSuppress("AzureStorageAccounts")]
    [CodeGenSuppress("ConnectionStrings")]
    [CodeGenSuppress("DefaultDocuments")]
    [CodeGenSuppress("HandlerMappings")]
    [CodeGenSuppress("IPSecurityRestrictions")]
    [CodeGenSuppress("Metadata")]
    [CodeGenSuppress("ScmIPSecurityRestrictions")]
    [CodeGenSuppress("VirtualApplications")]
    public partial class SiteConfigData
    {
        // Add this property back to avoid breaking change with the fix for issue #56828
        /// <summary>
        /// The URL of the API definition.
        /// </summary>
        [WirePath("properties.apiDefinition.url")]
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
        [WirePath("properties.appSettings")]
        public IList<AppServiceNameValuePair> AppSettings
        {
            get => EnsureProperties().AppSettings;
            set => EnsureProperties().AppSettings = value;
        }

        /// <summary> List of Azure Storage Accounts. </summary>
        [WirePath("properties.azureStorageAccounts")]
        public IDictionary<string, AppServiceStorageAccessInfo> AzureStorageAccounts
        {
            get => EnsureProperties().AzureStorageAccounts;
            set => EnsureProperties().AzureStorageAccounts = value;
        }

        /// <summary> Connection strings. </summary>
        [WirePath("properties.connectionStrings")]
        public IList<ConnStringInfo> ConnectionStrings
        {
            get => EnsureProperties().ConnectionStrings;
            set => EnsureProperties().ConnectionStrings = value;
        }

        /// <summary> Default documents. </summary>
        [WirePath("properties.defaultDocuments")]
        public IList<string> DefaultDocuments
        {
            get => EnsureProperties().DefaultDocuments;
            set => EnsureProperties().DefaultDocuments = value;
        }

        /// <summary> Handler mappings. </summary>
        [WirePath("properties.handlerMappings")]
        public IList<HttpRequestHandlerMapping> HandlerMappings
        {
            get => EnsureProperties().HandlerMappings;
            set => EnsureProperties().HandlerMappings = value;
        }

        /// <summary> IP security restrictions for main. </summary>
        [WirePath("properties.ipSecurityRestrictions")]
        public IList<AppServiceIPSecurityRestriction> IPSecurityRestrictions
        {
            get => EnsureProperties().IPSecurityRestrictions;
            set => EnsureProperties().IPSecurityRestrictions = value;
        }

        /// <summary> Application metadata. This property cannot be retrieved, since it may contain secrets. </summary>
        [WirePath("properties.metadata")]
        public IList<AppServiceNameValuePair> Metadata
        {
            get => EnsureProperties().Metadata;
            set => EnsureProperties().Metadata = value;
        }

        /// <summary> IP security restrictions for scm. </summary>
        [WirePath("properties.scmIpSecurityRestrictions")]
        public IList<AppServiceIPSecurityRestriction> ScmIPSecurityRestrictions
        {
            get => EnsureProperties().ScmIPSecurityRestrictions;
            set => EnsureProperties().ScmIPSecurityRestrictions = value;
        }

        /// <summary> Virtual applications. </summary>
        [WirePath("properties.virtualApplications")]
        public IList<VirtualApplication> VirtualApplications
        {
            get => EnsureProperties().VirtualApplications;
            set => EnsureProperties().VirtualApplications = value;
        }

        private SiteConfigProperties EnsureProperties()
        {
            if (Properties is null)
            {
                Properties = new SiteConfigProperties();
            }
            return Properties;
        }
    }
}
