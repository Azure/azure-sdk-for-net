// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.ApiManagement;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // Contextual wrapper: same wire shape as UserContractData but with a distinct type name
    // for group user operations. The old SDK returned ApiManagementGroupUserData from
    // group-specific user endpoints. Not spec-fixable: TypeSpec has no concept of "same model,
    // different name per operation context."
    // Tracking: https://github.com/Azure/azure-sdk-for-net/issues/60083

    /// <summary> User data returned from group user operations. </summary>
    public partial class ApiManagementGroupUserData : UserContractData, IJsonModel<ApiManagementGroupUserData>, IPersistableModel<ApiManagementGroupUserData>
    {
        /// <summary> Initializes a new instance of <see cref="ApiManagementGroupUserData"/>. </summary>
        public ApiManagementGroupUserData()
        {
        }

        internal ApiManagementGroupUserData(UserContractData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, default)
        {
        }

        void IJsonModel<ApiManagementGroupUserData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<UserContractData>)this).Write(writer, options);

        ApiManagementGroupUserData IJsonModel<ApiManagementGroupUserData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            UserContractData data = ((IJsonModel<UserContractData>)new UserContractData()).Create(ref reader, options);
            return data is null ? null : new ApiManagementGroupUserData(data);
        }

        BinaryData IPersistableModel<ApiManagementGroupUserData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<UserContractData>)this).Write(options);

        ApiManagementGroupUserData IPersistableModel<ApiManagementGroupUserData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            UserContractData value = ((IPersistableModel<UserContractData>)new UserContractData()).Create(data, options);
            return value is null ? null : new ApiManagementGroupUserData(value);
        }

        string IPersistableModel<ApiManagementGroupUserData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<UserContractData>)new UserContractData()).GetFormatFromOptions(options);
    }
}
