// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FormRecognizerModelFactory"/> class.
    /// </summary>
    public class FormRecognizerModelFactoryTests : ClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerModelFactoryTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormRecognizerModelFactoryTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateAccountProperties()
        {
            var customModelCount = 439;
            var customModelLimit = 647;

            var accountProperties = FormRecognizerModelFactory.AccountProperties(customModelCount, customModelLimit);

            Assert.AreEqual(customModelCount, accountProperties.CustomModelCount);
            Assert.AreEqual(customModelLimit, accountProperties.CustomModelLimit);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateCustomFormModel()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateCustomFormModelField()
        {
            var name = "Leonhard";
            var label = "Euler";
            var accuracy = 0.2718f;

            var customFormModelField = FormRecognizerModelFactory.CustomFormModelField(name, label, accuracy);

            Assert.AreEqual(name, customFormModelField.Name);
            Assert.AreEqual(label, customFormModelField.Label);
            Assert.AreEqual(accuracy, customFormModelField.Accuracy);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateCustomFormModelInfo()
        {
            var modelId = "10001112-2233-3444-5556-667778889991";
            var trainingStartedOn = DateTimeOffset.Parse("1933-05-17T11:59:02Z");
            var trainingCompletedOn = DateTimeOffset.Parse("1949-03-19T07:41:47");
            var status = CustomFormModelStatus.Ready;

            var customFormModelInfo = FormRecognizerModelFactory.CustomFormModelInfo(modelId, trainingStartedOn, trainingCompletedOn, status);

            Assert.AreEqual(modelId, customFormModelInfo.ModelId);
            Assert.AreEqual(trainingStartedOn, customFormModelInfo.TrainingStartedOn);
            Assert.AreEqual(trainingCompletedOn, customFormModelInfo.TrainingCompletedOn);
            Assert.AreEqual(status, customFormModelInfo.Status);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateCustomFormSubmodel()
        {
            var formType = "Pythagoras";
            var accuracy = 0.1414f;
            // TODO: dictionary of fields.

            var customFormSubmodel = FormRecognizerModelFactory.CustomFormSubmodel(formType, accuracy, null);

            Assert.AreEqual(formType, customFormSubmodel.FormType);
            Assert.AreEqual(accuracy, customFormSubmodel.Accuracy);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldData()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormField()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormLine()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormPage()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormPageCollection()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormPageRange()
        {
            var firstPageNumber = 269;
            var lastPageNumber = 271;

            var formPageRange = FormRecognizerModelFactory.FormPageRange(firstPageNumber, lastPageNumber);

            Assert.AreEqual(firstPageNumber, formPageRange.FirstPageNumber);
            Assert.AreEqual(lastPageNumber, formPageRange.LastPageNumber);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormRecognizerError()
        {
            var errorCode = "Carl";
            var message = "Gauss";

            var formRecognizerError = FormRecognizerModelFactory.FormRecognizerError(errorCode, message);

            Assert.AreEqual(errorCode, formRecognizerError.ErrorCode);
            Assert.AreEqual(message, formRecognizerError.Message);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormTable()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormTableCell()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormWord()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateRecognizedForm()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateRecognizedFormCollection()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateTrainingDocumentInfo()
        {
            // TODO.
        }
    }
}
