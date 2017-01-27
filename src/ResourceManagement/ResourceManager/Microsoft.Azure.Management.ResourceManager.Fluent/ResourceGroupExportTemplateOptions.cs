// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Resource.Fluent
{
    public enum ResourceGroupExportTemplateOptions
    {
        [EnumName("IncludeParameterDefaultValue")]
        IncludeParameterDefaultValue,
        [EnumName("IncludeComments")]
        IncludeComments,
        [EnumName("IncludeParameterDefaultValue, IncludeComments")]
        IncludeBoth
    }
}