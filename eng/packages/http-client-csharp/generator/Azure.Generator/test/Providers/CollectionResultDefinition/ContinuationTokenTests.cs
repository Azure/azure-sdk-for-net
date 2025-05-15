// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Generator.Tests.Providers.CollectionResultDefinition
{
    public class ContinuationTokenTests
    {
        //[Test]
        //public void ContinuationTokenInBody()
        //{
        //    CreatePagingOperation(InputResponseLocation.Body);

        //    var collectionResultDefinition = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
        //        t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResult");
        //    Assert.IsNotNull(collectionResultDefinition);

        //    var writer = new TypeProviderWriter(collectionResultDefinition!);
        //    var file = writer.Write();
        //    Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        //}

        //[Test]
        //public void ContinuationTokenInBodyAsync()
        //{
        //    CreatePagingOperation(InputResponseLocation.Body);

        //    var collectionResultDefinition = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
        //        t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResult");
        //    Assert.IsNotNull(collectionResultDefinition);

        //    var writer = new TypeProviderWriter(collectionResultDefinition!);
        //    var file = writer.Write();
        //    Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        //}

        //[Test]
        //public void ContinuationTokenInHeader()
        //{
        //    CreatePagingOperation(InputResponseLocation.Header);

        //    var collectionResultDefinition = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
        //        t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResult");
        //    Assert.IsNotNull(collectionResultDefinition);

        //    var writer = new TypeProviderWriter(collectionResultDefinition!);
        //    var file = writer.Write();
        //    Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        //}

        //[Test]
        //public void ContinuationTokenInHeaderAsync()
        //{
        //    CreatePagingOperation(InputResponseLocation.Header);

        //    var collectionResultDefinition = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
        //        t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResult");
        //    Assert.IsNotNull(collectionResultDefinition);

        //    var writer = new TypeProviderWriter(collectionResultDefinition!);
        //    var file = writer.Write();
        //    Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        //}

        //[Test]
        //public void ContinuationTokenInBodyOfT()
        //{
        //    CreatePagingOperation(InputResponseLocation.Body);

        //    var collectionResultDefinition = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
        //        t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResultOfT");
        //    Assert.IsNotNull(collectionResultDefinition);

        //    var writer = new TypeProviderWriter(collectionResultDefinition!);
        //    var file = writer.Write();
        //    Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        //}

        //[Test]
        //public void ContinuationTokenInBodyOfTAsync()
        //{
        //    CreatePagingOperation(InputResponseLocation.Body);

        //    var collectionResultDefinition = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
        //        t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResultOfT");
        //    Assert.IsNotNull(collectionResultDefinition);

        //    var writer = new TypeProviderWriter(collectionResultDefinition!);
        //    var file = writer.Write();
        //    Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        //}

        //[Test]
        //public void ContinuationTokenInHeaderOfT()
        //{
        //    CreatePagingOperation(InputResponseLocation.Header);

        //    var collectionResultDefinition = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
        //        t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsCollectionResultOfT");
        //    Assert.IsNotNull(collectionResultDefinition);

        //    var writer = new TypeProviderWriter(collectionResultDefinition!);
        //    var file = writer.Write();
        //    Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        //}

        //[Test]
        //public void ContinuationTokenInHeaderOfTAsync()
        //{
        //    CreatePagingOperation(InputResponseLocation.Header);

        //    var collectionResultDefinition = ScmCodeModelGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(
        //        t => t is CollectionResultDefinition && t.Name == "CatClientGetCatsAsyncCollectionResultOfT");
        //    Assert.IsNotNull(collectionResultDefinition);

        //    var writer = new TypeProviderWriter(collectionResultDefinition!);
        //    var file = writer.Write();
        //    Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        //}

        //private static void CreatePagingOperation(InputResponseLocation responseLocation)
        //{
        //    var inputModel = InputFactory.Model("cat", properties:
        //    [
        //        InputFactory.Property("color", InputPrimitiveType.String, isRequired: true),
        //    ]);
        //    var parameter = InputFactory.Parameter("myToken", InputPrimitiveType.String, isRequired: true, location: InputRequestLocation.Query);
        //    var paging = InputFactory.ContinuationTokenPagingMetadata(parameter, "cats", "nextPage", responseLocation);
        //    var response = InputFactory.OperationResponse(
        //        [200],
        //        InputFactory.Model(
        //            "page",
        //            properties: [InputFactory.Property("cats", InputFactory.Array(inputModel)), InputFactory.Property("nextPage", InputPrimitiveType.Url)]));
        //    var operation = InputFactory.Operation("getCats", parameters: [parameter], responses: [response]);
        //    var inputServiceMethod = InputFactory.PagingServiceMethod("getCats", operation, pagingMetadata: paging);
        //    var client = InputFactory.Client("catClient", methods: [inputServiceMethod]);

        //    MockHelpers.LoadMockGenerator(inputModels: () => [inputModel], clients: () => [client]);
        //}
    }
}
