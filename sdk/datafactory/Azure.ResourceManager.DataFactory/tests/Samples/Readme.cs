// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Readme_AuthClient_Namespaces
using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.DataFactory.Models;
#endregion Snippet:Readme_AuthClient_Namespaces
using NUnit.Framework;

#nullable enable

namespace Azure.ResourceManager.DataFactory.Tests.Samples
{
    internal class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DataFactoryElementFromLiteral()
        {
            #region Snippet:Readme_DataFactoryElementInt
            var policy = new ActivityPolicy
            {
                Retry = DataFactoryElement<int>.FromLiteral(1),
            };
            #endregion Snippet:Readme_DataFactoryElementInt

            #region Snippet:Readme_DataFactoryElementBoolean
            var service = new AmazonS3CompatibleLinkedService
            {
                ForcePathStyle = DataFactoryElement<bool>.FromLiteral(true),
            };
            #endregion Snippet:Readme_DataFactoryElementBoolean

            #region Snippet:Readme_DataFactoryElementList
            var source = new Office365Source()
            {
                AllowedGroups = DataFactoryElement<IList<string>>.FromLiteral(new List<string> { "a", "b" }),
            };
            #endregion Snippet:Readme_DataFactoryElementList

            #region Snippet:Readme_DataFactoryElementDictionary
            Dictionary<string, string> DictionaryValue = new()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };
            var activity = new AzureMLExecutePipelineActivity("name")
            {
                MlPipelineParameters = DataFactoryElement<IDictionary<string, string>?>.FromLiteral(DictionaryValue),
            };
            #endregion Snippet:Readme_DataFactoryElementDictionary

            #region Snippet:Readme_DataFactoryElementBinaryData
            var varActivity = new SetVariableActivity("name")
            {
                Value = DataFactoryElement<BinaryData>.FromLiteral(BinaryData.FromString("a")),
            };
            #endregion Snippet:Readme_DataFactoryElementBinaryData
        }
    }
}
