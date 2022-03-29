// // Copyright (c) .NET Foundation. All rights reserved.
// // Licensed under the MIT License. See License.txt in the project root for license information.
//
// using System;
// using Azure.Data.Tables;
// using NUnit.Framework;
//
// namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
// {
//     public class PocoEntityValueBinderTests
//     {
//         [Test]
//         public void HasChanged_ReturnsFalse_IfValueHasNotChanged()
//         {
//             // Arrange
//             TableEntityContext entityContext = new TableEntityContext();
//             SimpleTableEntity value = new SimpleTableEntity { Item = "Foo" };
//             PocoEntityValueBinder<SimpleTableEntity> product = new PocoEntityValueBinder<SimpleTableEntity>(
//                 entityContext, new TableEntity()
//                 {
//                     ["Item"] = "Foo"
//                 }, value);
//             // Act
//             bool hasChanged = product.HasChanged;
//             // Assert
//             Assert.False(hasChanged);
//         }
//
//         [Test]
//         public void HasChanged_ReturnsTrue_IfValueHasChanged()
//         {
//             // Arrange
//             TableEntityContext entityContext = new TableEntityContext();
//             SimpleTableEntity value = new SimpleTableEntity { Item = "Foo" };
//             PocoEntityValueBinder<SimpleTableEntity> product = new PocoEntityValueBinder<SimpleTableEntity>(
//                 entityContext, new TableEntity()
//                 {
//                     ["Item"] = "Foo"
//                 }, value);
//             value.Item = "Bar";
//             // Act
//             bool hasChanged = product.HasChanged;
//             // Assert
//             Assert.True(hasChanged);
//         }
//
//         private class SimpleTableEntity
//         {
//             public string Item { get; set; }
//         }
//     }
// }