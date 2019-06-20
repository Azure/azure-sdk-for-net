// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Properties;

namespace Microsoft.Rest
{
    /// <summary>
    /// Defines set of validation rules.
    /// </summary>
    public static class ValidationRules
    {
        public static readonly string CannotBeNull = Resources.ValidationCannotBeNull;
        public static readonly string InclusiveMaximum = Resources.ValidationMaximum;
        public static readonly string ExclusiveMaximum = Resources.ValidationExclusiveMaximum;
        public static readonly string MaxLength = Resources.ValidationMaximumLength;
        public static readonly string MinLength = Resources.ValidationMinimumLength;
        public static readonly string Pattern = Resources.ValidationPattern;
        public static readonly string MaxItems = Resources.ValidationMaximumItems;
        public static readonly string MinItems = Resources.ValidationMinimumItems;
        public static readonly string UniqueItems = Resources.ValidationUniqueItems;
        public static readonly string Enum = Resources.ValidationEnum;
        public static readonly string MultipleOf = Resources.ValidationMultipleOf;
        public static readonly string InclusiveMinimum = Resources.ValidationMinimum;
        public static readonly string ExclusiveMinimum = Resources.ValidationExclusiveMinimum;
    }
}