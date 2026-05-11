// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests.Utilities
{
    public class InputServiceMethodExtensionsTests
    {
        [SetUp]
        public void SetUp()
        {
            ManagementMockHelpers.LoadMockPlugin();
        }

        [TestCase]
        public void GetResponseBodyType_ReturnsTypedCreatedResponseForNonLroPatch()
        {
            var responseModel = InputFactory.Model("PartnerTopicData");
            var method = InputFactory.BasicServiceMethod(
                "update",
                InputFactory.Operation(
                    "update",
                    responses:
                    [
                        InputFactory.OperationResponse([200]),
                        InputFactory.OperationResponse([201], responseModel)
                    ],
                    httpMethod: "PATCH"));

            var responseBodyType = method.GetResponseBodyType();

            Assert.That(responseBodyType, Is.Not.Null);
            Assert.That(responseBodyType!.Name, Is.EqualTo("PartnerTopicData"));
        }

        [TestCase]
        public void GetResponseBodyType_ReturnsVoidForLroPatchWithNoContentOkResponse()
        {
            var responseModel = InputFactory.Model("TopicData");
            var operation = InputFactory.Operation(
                "update",
                responses:
                [
                    InputFactory.OperationResponse([200]),
                    InputFactory.OperationResponse([201], responseModel)
                ],
                httpMethod: "PATCH");
            var method = InputFactory.LongRunningServiceMethod(
                "update",
                operation,
                longRunningServiceMetadata: InputFactory.LongRunningServiceMetadata(
                    1,
                    InputFactory.OperationResponse([201], responseModel),
                    null));

            var responseBodyType = method.GetResponseBodyType();

            Assert.That(responseBodyType, Is.Null);
        }
    }
}
