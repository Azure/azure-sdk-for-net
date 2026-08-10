// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Marketplace.Models
{
    // Customization rationale
    // ------------------------
    // Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/58627
    //
    // The spec defines two server-side "Delete" workaround POSTs in routes.tsp
    // (PrivateStoreCollectionOperationGroup.post / PrivateStoreCollectionOfferOperationGroup.post)
    // whose body parameter is `payload?: Operation`, where `Operation` is an extensible-enum
    // union (Ping, DeletePrivateStoreOffer, DeletePrivateStoreCollection,
    // DeletePrivateStoreCollectionOffer). Via client.tsp these POSTs are renamed to `Delete`
    // and merged onto PrivateStoreCollectionInfo / PrivateStoreCollectionOffer to preserve the
    // existing public Delete(PrivateStoreOperation?) overload shipped on main.
    //
    // The MPG generator has a known codegen gap for non-MRW body types:
    //   * Microsoft.Generator.CSharp.ClientModel's ParameterContextRegistry emits
    //     `<BodyType>.ToRequestContent(payload)` for any non-primitive request body parameter;
    //   * SerializationVisitor only synthesizes the `ToRequestContent` helper on MRW model
    //     types (via the implicit-operator rename), so extensible-enum / union structs never
    //     receive it and the generated `Delete(PrivateStoreOperation? payload)` method fails
    //     to compile with CS0117.
    //
    // This partial bridges the gap by supplying the missing
    // `PrivateStoreOperation.ToRequestContent(PrivateStoreOperation?)` helper, so the
    // auto-generated Delete overload compiles unchanged while keeping the public API shape
    // (PrivateStoreOperation? parameter) identical to the main branch. Using a partial here
    // is preferred over `@@alternateType(..., string, "csharp")` because it preserves the
    // strongly-typed PrivateStoreOperation enum on the public surface.
    public readonly partial struct PrivateStoreOperation
    {
        internal static RequestContent ToRequestContent(PrivateStoreOperation? payload)
        {
            if (payload == null)
            {
                return null;
            }

            return RequestContent.Create(payload.Value.ToString());
        }
    }
}
