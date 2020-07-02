// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;
using KeyFieldAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/11166 is completed.
namespace Azure.Search.Documents.Samples.Tests
{
    [SerializePropertyNamesAsCamelCase]
    public class ReflectableInnerCamelCaseModel
    {
        public string Name { get; set; }
    }

    [SerializePropertyNamesAsCamelCase]
    public class ReflectableCamelCaseModel
    {
        [KeyField]
        public int Id { get; set; }

        public string MyProperty { get; set; }

        public ReflectableInnerCamelCaseModel Inner { get; set; }

        public ReflectableInnerCamelCaseModel[] InnerCollection { get; set; }
    }
}
