// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FormRecognizerModelFactory"/> class.
    /// </summary>
    public class FormRecognizerModelFactoryTests
    {
        /// <summary>
        /// Assists in <see cref="BoundingBox"/> creation.
        /// </summary>
        private readonly IReadOnlyList<PointF> ListOfPoints = new List<PointF>() { new PointF(3.1415f, 1.6180f), new PointF(6.6740f, 8.9876f) };

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
        public void FormRecognizerModelFactoryCanInstantiateBoundingBox()
        {
            var boundingBox = FormRecognizerModelFactory.BoundingBox(ListOfPoints);

            CollectionAssert.AreEqual(ListOfPoints, boundingBox.Points);
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
            var fields = new Dictionary<string, CustomFormModelField>();

            var customFormSubmodel = FormRecognizerModelFactory.CustomFormSubmodel(formType, accuracy, fields);

            Assert.AreEqual(formType, customFormSubmodel.FormType);
            Assert.AreEqual(accuracy, customFormSubmodel.Accuracy);
            Assert.AreEqual(fields, customFormSubmodel.Fields);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldData()
        {
            var boundingBox = new BoundingBox(ListOfPoints);
            var pageNumber = 109;
            var text = "Poincare";
            var fieldElements = new List<FormElement>();

            var fieldData = new FieldData(boundingBox, pageNumber, text, fieldElements);

            Assert.AreEqual(boundingBox, fieldData.BoundingBox);
            Assert.AreEqual(pageNumber, fieldData.PageNumber);
            Assert.AreEqual(text, fieldData.Text);
            Assert.AreEqual(fieldElements, fieldData.FieldElements);
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
