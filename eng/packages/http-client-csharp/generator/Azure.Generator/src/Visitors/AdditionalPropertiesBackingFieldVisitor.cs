// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// When a user applies <c>[CodeGenMember("AdditionalProperties")]</c> to re-attach attributes
    /// (e.g. <c>[WirePath]</c>) to the synthesized additional-properties bag of a model that uses
    /// an additional-properties spread (e.g. <c>...Record&lt;unknown&gt;</c>), the custom property
    /// is merged into the model but its <see cref="PropertyProvider.BackingField"/> may not be
    /// populated. The MRW deserialization generator detects the model's additional-properties
    /// property by searching for one whose <c>BackingField?.Name</c> equals
    /// <c>_additionalBinaryDataProperties</c>; when the backing field is missing, that search
    /// fails and the generator emits a <c>Deserialize</c> method whose locally-declared variable
    /// name (derived from the property) does not match the catch-all add target (derived from the
    /// field), producing a CS0103 compile error.
    /// <para>
    /// This visitor reattaches the model's <c>_additionalBinaryDataProperties</c> field as the
    /// backing field for any additional-properties property that is missing one, keeping the two
    /// code paths in agreement.
    /// </para>
    /// </summary>
    internal class AdditionalPropertiesBackingFieldVisitor : ScmLibraryVisitor
    {
        private const string AdditionalBinaryDataPropsFieldName = "_additionalBinaryDataProperties";

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelProvider model)
            {
                var rawDataField = model.Fields.FirstOrDefault(f => f.Name == AdditionalBinaryDataPropsFieldName);
                if (rawDataField != null)
                {
                    foreach (var property in model.Properties)
                    {
                        if (property.IsAdditionalProperties && property.BackingField == null)
                        {
                            property.BackingField = rawDataField;
                        }
                    }
                }
            }

            return type;
        }
    }
}
