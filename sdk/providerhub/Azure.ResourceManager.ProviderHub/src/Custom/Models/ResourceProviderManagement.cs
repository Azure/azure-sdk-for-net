// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ResourceProviderManagement. </summary>
    [CodeGenSerialization(nameof(ServiceTreeInfos), "serviceTreeInfos")]
    public partial class ResourceProviderManagement
    {
        // Preserve the released collection and its wire name. The internal setter keeps the
        // generator from treating this mutable collection as response-only.
        /// <summary> The service tree infos. </summary>
        public IList<ServiceTreeInfo> ServiceTreeInfos { get; internal set; } = new ChangeTrackingList<ServiceTreeInfo>();

        /// <summary>
        /// Gets the resource access roles
        /// <para>
        /// To assign an object to the element of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been deprecated, please use `ResourceAccessRoleList` instead.", false)]
        public IList<BinaryData> ResourceAccessRoles { get; }
    }
}
