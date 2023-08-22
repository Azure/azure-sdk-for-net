// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    internal class PatchModelHelper
    {
        // TODO: Move this into the public interface as a separate PR
        public static void ValidateFormat<T>(IModelSerializable<T> model, ModelSerializerFormat format)
        {
            bool isValidPatchFormat = model is IModelJsonSerializable<T> && format == "P";
            if (!isValidPatchFormat)
            {
                ModelSerializerHelper.ValidateFormat(model, format);
            }
        }
    }
}
