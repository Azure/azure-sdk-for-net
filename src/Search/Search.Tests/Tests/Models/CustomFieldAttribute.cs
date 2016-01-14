// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;

    public class CustomFieldAttribute : Attribute
    {
        public CustomFieldAttribute(string fieldName)
        {
            FieldName = fieldName;
            ShouldIgnore = false;
        }

        public CustomFieldAttribute(bool shouldIgnore)
        {
            FieldName = null;
            ShouldIgnore = shouldIgnore;
        }

        public string FieldName { get; private set; }

        public bool ShouldIgnore { get; private set; }
    }
}
