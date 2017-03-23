// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
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