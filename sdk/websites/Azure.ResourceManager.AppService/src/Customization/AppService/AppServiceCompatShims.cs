// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// Internal helpers for the ProxyResource-to-flat compatibility shims:
    /// converts between the newly-generated `*Data` types (resources) and the
    /// GA-shipped plain models that customizations recreate in
    /// <see cref="Azure.ResourceManager.AppService.Models"/>.
    /// </summary>
    internal static class AppServiceCompatShims
    {
        public static SiteAuthSettingsV2 ConvertAuth(SiteAuthSettingsV2Data data)
        {
            if (data == null)
            {
                return null;
            }
            BinaryData json = ModelReaderWriter.Write(data, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
            return ModelReaderWriter.Read<SiteAuthSettingsV2>(json, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
        }

        public static SiteAuthSettingsV2Data ConvertAuthBack(SiteAuthSettingsV2 model)
        {
            if (model == null)
            {
                return null;
            }
            BinaryData json = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
            return ModelReaderWriter.Read<SiteAuthSettingsV2Data>(json, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
        }

        public static CsmDeploymentStatus ConvertCsm(CsmDeploymentStatusData data)
        {
            if (data == null)
            {
                return null;
            }
            BinaryData json = ModelReaderWriter.Write(data, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
            return ModelReaderWriter.Read<CsmDeploymentStatus>(json, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
        }

        public static AppServiceEnvironmentAddressResult ConvertAddress(AppServiceEnvironmentAddressData data)
        {
            if (data == null)
            {
                return null;
            }
            BinaryData json = ModelReaderWriter.Write(data, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
            return ModelReaderWriter.Read<AppServiceEnvironmentAddressResult>(json, ModelReaderWriterOptions.Json, AzureResourceManagerAppServiceContext.Default);
        }

        /// <summary>
        /// Wraps an <see cref="ArmOperation{TIn}"/> as an <see cref="ArmOperation{TOut}"/> by projecting the completed value
        /// through a converter. The GA SDK exposed a plain ArmOperation&lt;CsmDeploymentStatus&gt; while the new SDK
        /// returns ArmOperation&lt;CsmSiteDeploymentStatusResource&gt;; this preserves the old contract.
        /// </summary>
        public static ArmOperation<TOut> ProjectOperation<TIn, TOut>(ArmOperation<TIn> inner, Func<TIn, TOut> convert)
        {
            return new ProjectedArmOperation<TIn, TOut>(inner, convert);
        }

        public static Pageable<TOut> ProjectPageable<TIn, TOut>(Pageable<TIn> inner, Func<TIn, TOut> convert)
        {
            return new ProjectedPageable<TIn, TOut>(inner, convert);
        }

        public static AsyncPageable<TOut> ProjectAsyncPageable<TIn, TOut>(AsyncPageable<TIn> inner, Func<TIn, TOut> convert)
        {
            return new ProjectedAsyncPageable<TIn, TOut>(inner, convert);
        }
    }
}
