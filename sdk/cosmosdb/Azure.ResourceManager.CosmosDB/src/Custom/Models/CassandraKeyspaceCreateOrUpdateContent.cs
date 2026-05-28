// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Restore baseline public surface:
    // - ctor takes typed CassandraKeyspaceResourceInfo (not flattened string), which forces the
    //   inner Properties holder to be non-null after construction.
    // - Options has setter (delegates straight to Properties.Options now that Properties is
    //   guaranteed non-null after ctor).
    // - ResourceKeyspaceName has setter (passes through to Resource.KeyspaceName).
    //
    // Implicit-flatten in MPG only synthesizes a `set` on a wrapper-side flatten proxy when the
    // inner Properties model has a parameterless ctor; CassandraKeyspaceCreateUpdateProperties
    // has a required ctor arg, so the generator emits get-only proxies. We considered
    // @@usage(input|output, "csharp") in client.tsp on the inner model to coax the generator into
    // emitting setters here, but verified empirically that it does not affect implicit-flatten
    // emission for wrappers that use TrackedResource + OmitProperties.
    // TODO: revisit when https://github.com/Azure/azure-sdk-for-net/issues/59498 is fixed.
    //
    // We also suppress the (AzureLocation, string) ctor that the generator emits as a companion
    // to the typed (AzureLocation, CassandraKeyspaceResourceInfo) ctor below; ideally MPG should
    // keep BOTH ctor overloads when one is added via a Custom partial.
    // TODO: revisit when https://github.com/Azure/azure-sdk-for-net/issues/59500 is fixed.
    [CodeGenSuppress("CassandraKeyspaceCreateOrUpdateContent", typeof(AzureLocation), typeof(string))]
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("Options")]
    [CodeGenSuppress("ResourceKeyspaceName")]
    public partial class CassandraKeyspaceCreateOrUpdateContent
    {
        public CassandraKeyspaceCreateOrUpdateContent(AzureLocation location, CassandraKeyspaceResourceInfo resource) : base(location)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            Properties = new CassandraKeyspaceCreateUpdateProperties(resource.KeyspaceName);
        }

        [WirePath("properties")]
        internal CassandraKeyspaceCreateUpdateProperties Properties { get; set; }

        [WirePath("properties.options")]
        public CosmosDBCreateUpdateConfig Options
        {
            get => Properties.Options;
            set => Properties.Options = value;
        }

        [WirePath("properties.resource.id")]
        public string ResourceKeyspaceName
        {
            get => Properties?.ResourceKeyspaceName;
            set => Properties = new CassandraKeyspaceCreateUpdateProperties(value) { Options = Properties?.Options };
        }
    }
}
