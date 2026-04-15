// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HDInsight.Models
{
    // These ModelFactory overloads fix type mismatches in generated backward-compat methods.
    // The generator creates compat overloads with old SDK types (ManagedServiceIdentity, Uri, Guid?)
    // but the generated constructors use spec types (ClusterIdentity, string, string) because
    // armCommonTypesVersion is v3 which maps these as strings rather than strongly-typed values.
    //[CodeGenSuppress("HDInsightClusterData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ETag?), typeof(IEnumerable<string>), typeof(HDInsightClusterProperties), typeof(ManagedServiceIdentity))]
    //[CodeGenSuppress("HDInsightClusterAaddsDetail", typeof(string), typeof(bool?), typeof(bool?), typeof(string), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(Guid?))]
    //[CodeGenSuppress("RuntimeScriptActionDetail", typeof(string), typeof(Uri), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(long?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(string), typeof(IEnumerable<ScriptActionExecutionSummary>), typeof(string))]
    //public static partial class ArmHDInsightModelFactory
    //{
    //    /// <summary> Initializes a new instance of HDInsightClusterData. </summary>
    //    /// <param name="id"> The id. </param>
    //    /// <param name="name"> The name. </param>
    //    /// <param name="resourceType"> The resourceType. </param>
    //    /// <param name="systemData"> The systemData. </param>
    //    /// <param name="tags"> The tags. </param>
    //    /// <param name="location"> The location. </param>
    //    /// <param name="etag"> The ETag. </param>
    //    /// <param name="zones"> The availability zones. </param>
    //    /// <param name="properties"> The properties. </param>
    //    /// <param name="identity"> The identity. </param>
    //    /// <returns> A new <see cref="HDInsight.HDInsightClusterData"/> instance for mocking. </returns>
    //    [EditorBrowsable(EditorBrowsableState.Never)]
    //    public static HDInsightClusterData HDInsightClusterData(
    //        ResourceIdentifier id,
    //        string name,
    //        ResourceType resourceType,
    //        SystemData systemData,
    //        IDictionary<string, string> tags,
    //        AzureLocation location,
    //        ETag? etag,
    //        IEnumerable<string> zones,
    //        HDInsightClusterProperties properties,
    //        ManagedServiceIdentity identity)
    //    {
    //        tags ??= new ChangeTrackingDictionary<string, string>();
    //        zones ??= new ChangeTrackingList<string>();

    //        return new HDInsightClusterData(
    //            id,
    //            name,
    //            resourceType,
    //            systemData,
    //            additionalBinaryDataProperties: null,
    //            tags,
    //            location,
    //            properties,
    //            default,
    //            zones.ToList(),
    //            default);
    //    }

    //    /// <summary> Initializes a new instance of HDInsightClusterAaddsDetail. </summary>
    //    /// <param name="domainName"> The domain name. </param>
    //    /// <param name="isInitialSyncComplete"> Initial sync complete. </param>
    //    /// <param name="isLdapsEnabled"> LDAPS enabled. </param>
    //    /// <param name="ldapsPublicCertificateInBase64"> LDAPS certificate. </param>
    //    /// <param name="resourceId"> The resource id. </param>
    //    /// <param name="subnetId"> The subnet id. </param>
    //    /// <param name="tenantId"> The tenant id. </param>
    //    /// <returns> A new <see cref="Models.HDInsightClusterAaddsDetail"/> instance for mocking. </returns>
    //    [EditorBrowsable(EditorBrowsableState.Never)]
    //    public static HDInsightClusterAaddsDetail HDInsightClusterAaddsDetail(
    //        string domainName,
    //        bool? isInitialSyncComplete,
    //        bool? isLdapsEnabled,
    //        string ldapsPublicCertificateInBase64,
    //        ResourceIdentifier resourceId,
    //        ResourceIdentifier subnetId,
    //        Guid? tenantId)
    //    {
    //        return new HDInsightClusterAaddsDetail(
    //            domainName,
    //            default,
    //            default,
    //            ldapsPublicCertificateInBase64,
    //            resourceId?.ToString(),
    //            subnetId?.ToString(),
    //            tenantId?.ToString(),
    //            additionalBinaryDataProperties: null);
    //    }

    //    /// <summary> Initializes a new instance of RuntimeScriptActionDetail. </summary>
    //    /// <param name="name"> The name. </param>
    //    /// <param name="uri"> The URI. </param>
    //    /// <param name="parameters"> The parameters. </param>
    //    /// <param name="roles"> The roles. </param>
    //    /// <param name="applicationName"> The application name. </param>
    //    /// <param name="scriptExecutionId"> The script execution id. </param>
    //    /// <param name="startOn"> The start time. </param>
    //    /// <param name="endOn"> The end time. </param>
    //    /// <param name="status"> The status. </param>
    //    /// <param name="operation"> The operation. </param>
    //    /// <param name="executionSummary"> The execution summary. </param>
    //    /// <param name="debugInformation"> The debug information. </param>
    //    /// <returns> A new <see cref="Models.RuntimeScriptActionDetail"/> instance for mocking. </returns>
    //    [EditorBrowsable(EditorBrowsableState.Never)]
    //    public static RuntimeScriptActionDetail RuntimeScriptActionDetail(
    //        string name,
    //        Uri uri,
    //        string parameters,
    //        IEnumerable<string> roles,
    //        string applicationName,
    //        long? scriptExecutionId,
    //        DateTimeOffset? startOn,
    //        DateTimeOffset? endOn,
    //        string status,
    //        string operation,
    //        IEnumerable<ScriptActionExecutionSummary> executionSummary,
    //        string debugInformation)
    //    {
    //        roles ??= new ChangeTrackingList<string>();
    //        executionSummary ??= new ChangeTrackingList<ScriptActionExecutionSummary>();

    //        return new RuntimeScriptActionDetail(
    //            name,
    //            uri?.AbsoluteUri,
    //            parameters,
    //            roles.ToList(),
    //            applicationName,
    //            additionalBinaryDataProperties: null,
    //            scriptExecutionId,
    //            default,
    //            default,
    //            status,
    //            operation,
    //            executionSummary.ToList(),
    //            debugInformation);
    //    }
    //}
}
