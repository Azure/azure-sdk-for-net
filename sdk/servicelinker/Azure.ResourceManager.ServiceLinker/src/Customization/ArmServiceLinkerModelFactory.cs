// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    // The spec-defined overload only reorders the GA parameters and makes all-optional calls ambiguous.
    // Keep the auto-generated overload without Browsable.Never.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(
        "LinkerValidateOperationResult",
        typeof(string),
        typeof(bool?),
        typeof(DateTimeOffset?),
        typeof(DateTimeOffset?),
        typeof(ResourceIdentifier),
        typeof(ResourceIdentifier),
        typeof(LinkerAuthType?),
        typeof(IEnumerable<LinkerValidationResultItemInfo>),
        typeof(ResourceIdentifier),
        typeof(string))]
    public static partial class ArmServiceLinkerModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.LinkerValidateOperationResult"/>. </summary>
        /// <param name="resourceId"> Validated linker id. </param>
        /// <param name="status"> Validation operation status. </param>
        /// <param name="linkerName"> The linker name. </param>
        /// <param name="isConnectionAvailable"> A boolean value indicating whether the connection is available or not. </param>
        /// <param name="reportStartOn"> The start time of the validation report. </param>
        /// <param name="reportEndOn"> The end time of the validation report. </param>
        /// <param name="sourceId"> The resource id of the linker source application. </param>
        /// <param name="targetId"> The resource Id of target service. </param>
        /// <param name="authType"> The authentication type. </param>
        /// <param name="validationDetail"> The detail of validation result. </param>
        /// <returns> A new <see cref="Models.LinkerValidateOperationResult"/> instance for mocking. </returns>
        public static LinkerValidateOperationResult LinkerValidateOperationResult(ResourceIdentifier resourceId = default, string status = default, string linkerName = default, bool? isConnectionAvailable = default, DateTimeOffset? reportStartOn = default, DateTimeOffset? reportEndOn = default, ResourceIdentifier sourceId = default, ResourceIdentifier targetId = default, LinkerAuthType? authType = default, IEnumerable<LinkerValidationResultItemInfo> validationDetail = default)
        {
            return new LinkerValidateOperationResult(linkerName is null && isConnectionAvailable is null && reportStartOn is null && reportEndOn is null && sourceId is null && targetId is null && authType is null && validationDetail is null ? default : new ValidateResult(
                linkerName,
                isConnectionAvailable,
                reportStartOn,
                reportEndOn,
                sourceId,
                targetId,
                authType,
                (validationDetail ?? new ChangeTrackingList<LinkerValidationResultItemInfo>()).ToList(),
                default), resourceId, status, default);
        }
    }
}
