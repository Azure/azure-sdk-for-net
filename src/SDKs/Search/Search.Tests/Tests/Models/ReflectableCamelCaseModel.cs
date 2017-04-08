// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Azure.Search.Models;

    [SerializePropertyNamesAsCamelCase]
    public class ReflectableCamelCaseModel
    {
        [Key]
        public int Id { get; set; }

        public string MyProperty { get; set; }
    }
}
