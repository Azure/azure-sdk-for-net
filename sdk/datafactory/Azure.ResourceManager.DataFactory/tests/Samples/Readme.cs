// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.DataFactory.Models;
using NUnit.Framework;
using DataFactoryLinkedServiceReference = Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference;
using DataFactoryLinkedServiceReferenceKind = Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind;

#nullable enable

namespace Azure.ResourceManager.DataFactory.Tests.Samples
{
    internal class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DataFactoryElementFromLiteralInt()
        {
            #region Snippet:Readme_DataFactoryElementInt
            var policy = new PipelineActivityPolicy
            {
                Retry = DataFactoryElement<int>.FromLiteral(1),
            };
            #endregion Snippet:Readme_DataFactoryElementInt
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DataFactoryElementFromLiteralBoolean()
        {
            #region Snippet:Readme_DataFactoryElementBoolean
            var service = new AmazonS3CompatibleLinkedService
            {
                ForcePathStyle = DataFactoryElement<bool>.FromLiteral(true),
            };
            #endregion Snippet:Readme_DataFactoryElementBoolean
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DataFactoryElementFromLiteralList()
        {
            #region Snippet:Readme_DataFactoryElementList
            var source = new Office365Source()
            {
                AllowedGroups = DataFactoryElement<IList<string>>.FromLiteral(new List<string> { "a", "b" }),
            };
            #endregion Snippet:Readme_DataFactoryElementList
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DataFactoryElementFromLiteralDictionary()
        {
            #region Snippet:Readme_DataFactoryElementDictionary
            Dictionary<string, string> DictionaryValue = new()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };
            var activity = new AzureMLExecutePipelineActivity("name")
            {
                MLPipelineParameters = DataFactoryElement<IDictionary<string, string>?>.FromLiteral(DictionaryValue),
            };
            #endregion Snippet:Readme_DataFactoryElementDictionary
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DataFactoryElementFromLiteralBianryData()
        {
            #region Snippet:Readme_DataFactoryElementBinaryData
            var varActivity = new SetVariableActivity("name")
            {
                Value = DataFactoryElement<BinaryData>.FromLiteral(BinaryData.FromString("a")),
            };
            #endregion Snippet:Readme_DataFactoryElementBinaryData
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DataFactoryFromExpression()
        {
            #region Snippet:Readme_DataFactoryElementFromExpression
            var service = new AmazonRdsForOracleLinkedService(DataFactoryElement<string>.FromExpression("foo/bar-@{pipeline().TriggerTime}"));
            #endregion Snippet:Readme_DataFactoryElementFromExpression
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DataFactoryFromMaskedString()
        {
            #region Snippet:Readme_DataFactoryElementFromMaskedString
            var service = new AmazonS3CompatibleLinkedService()
            {
                ServiceUri = DataFactoryElement<string>.FromSecretString("some/secret/path"),
            };
            #endregion Snippet:Readme_DataFactoryElementFromMaskedString
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void DataFactoryFromKeyVaultSecretReference()
        {
            #region Snippet:Readme_DataFactoryElementFromKeyVaultSecretReference
            var store = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference,
                "referenceName");
            var keyVaultReference = new DataFactoryKeyVaultSecret(store, "secretName");
            var service = new AmazonS3CompatibleLinkedService()
            {
                AccessKeyId = DataFactoryElement<string>.FromKeyVaultSecret(keyVaultReference),
            };
            #endregion Snippet:Readme_DataFactoryElementFromKeyVaultSecretReference
        }
    }
}
