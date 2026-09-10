// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    // AutoRest exposed the flattened validation details as IReadOnlyList<T>, while the TypeSpec
    // emitter exposes IList<T>. Keep the inner generated model mutable and preserve the GA accessor.
    [CodeGenSuppress("ValidationDetail")]
    public partial class LinkerValidateOperationResult
    {
        /// <summary> The detail of validation result. </summary>
        public IReadOnlyList<LinkerValidationResultItemInfo> ValidationDetail
        {
            get
            {
                return Properties is null ? null : (IReadOnlyList<LinkerValidationResultItemInfo>)Properties.ValidationDetail;
            }
        }
    }
}
