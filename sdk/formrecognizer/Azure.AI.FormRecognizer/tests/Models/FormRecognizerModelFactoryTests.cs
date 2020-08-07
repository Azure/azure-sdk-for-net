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
            var modelId = "18910691-1896-0619-1896-091118961109";
            var status = CustomFormModelStatus.Ready;
            var trainingStartedOn = DateTimeOffset.Parse("1723-07-31T23:29:31Z");
            var trainingCompletedOn = DateTimeOffset.Parse("1933-09-11T19:13:43Z");
            var submodels = new List<CustomFormSubmodel>();
            var trainingDocuments = new List<TrainingDocumentInfo>();
            var errors = new List<FormRecognizerError>();

            var customFormModel = FormRecognizerModelFactory.CustomFormModel(modelId, status, trainingStartedOn, trainingCompletedOn, submodels, trainingDocuments, errors);

            Assert.AreEqual(modelId, customFormModel.ModelId);
            Assert.AreEqual(status, customFormModel.Status);
            Assert.AreEqual(trainingStartedOn, customFormModel.TrainingStartedOn);
            Assert.AreEqual(trainingCompletedOn, customFormModel.TrainingCompletedOn);
            Assert.AreEqual(submodels, customFormModel.Submodels);
            Assert.AreEqual(trainingDocuments, customFormModel.TrainingDocuments);
            Assert.AreEqual(errors, customFormModel.Errors);
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
            var trainingCompletedOn = DateTimeOffset.Parse("1949-03-19T07:41:47Z");
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
            var name = "Cardano";
            var labelData = new FieldData(default, default, default, default);
            var valueData = new FieldData(default, default, default, default);
            var value = new FieldValue(); // TODO
            var confidence = 0.8854f;

            var formField = FormRecognizerModelFactory.FormField(name, labelData, valueData, value, confidence);

            Assert.AreEqual(name, formField.Name);
            Assert.AreEqual(labelData, formField.LabelData);
            Assert.AreEqual(valueData, formField.ValueData);
            Assert.AreEqual(value, formField.Value);
            Assert.AreEqual(confidence, formField.Confidence);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormLine()
        {
            var boundingBox = new BoundingBox(ListOfPoints);
            var pageNumber = 389;
            var text = "Bhaskara";
            var words = new List<FormWord>();

            var formLine = FormRecognizerModelFactory.FormLine(boundingBox, pageNumber, text, words);

            Assert.AreEqual(boundingBox, formLine.BoundingBox);
            Assert.AreEqual(pageNumber, formLine.PageNumber);
            Assert.AreEqual(text, formLine.Text);
            Assert.AreEqual(words, formLine.Words);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormPage()
        {
            var pageNumber = 503;
            var width = 9.1094f;
            var height = 1.6726f;
            var textAngle = 29.9792f;
            var unit = LengthUnit.Inch;
            var lines = new List<FormLine>();
            var tables = new List<FormTable>();

            var formPage = FormRecognizerModelFactory.FormPage(pageNumber, width, height, textAngle, unit, lines, tables);

            Assert.AreEqual(pageNumber, formPage.PageNumber);
            Assert.AreEqual(width, formPage.Width);
            Assert.AreEqual(height, formPage.Height);
            Assert.AreEqual(textAngle, formPage.TextAngle);
            Assert.AreEqual(unit, formPage.Unit);
            Assert.AreEqual(lines, formPage.Lines);
            Assert.AreEqual(tables, formPage.Tables);
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
            var pageNumber = 659;
            var columnCount = 89;
            var rowCount = 97;
            var cells = new List<FormTableCell>();

            var formTable = FormRecognizerModelFactory.FormTable(pageNumber, columnCount, rowCount, cells);

            Assert.AreEqual(pageNumber, formTable.PageNumber);
            Assert.AreEqual(columnCount, formTable.ColumnCount);
            Assert.AreEqual(rowCount, formTable.RowCount);
            Assert.AreEqual(cells, formTable.Cells);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormTableCell()
        {
            var boundingBox = new BoundingBox(ListOfPoints);
            var pageNumber = 139;
            var text = "Leibniz";
            var columnIndex = 151;
            var rowIndex = 157;
            var columnSpan = 113;
            var rowSpan = 173;
            var isHeader = true;
            var isFooter = false;
            var confidence = 0.1257f;
            var fieldElements = new List<FormElement>();

            var formTable = FormRecognizerModelFactory.FormTableCell(boundingBox, pageNumber, text, columnIndex, rowIndex, columnSpan, rowSpan, isHeader, isFooter, confidence, fieldElements);

            CollectionAssert.AreEqual(ListOfPoints, formTable.BoundingBox.Points);
            Assert.AreEqual(pageNumber, formTable.PageNumber);
            Assert.AreEqual(text, formTable.Text);
            Assert.AreEqual(columnIndex, formTable.ColumnIndex);
            Assert.AreEqual(rowIndex, formTable.RowIndex);
            Assert.AreEqual(columnSpan, formTable.ColumnSpan);
            Assert.AreEqual(rowSpan, formTable.RowSpan);
            Assert.AreEqual(isHeader, formTable.IsHeader);
            Assert.AreEqual(isFooter, formTable.IsFooter);
            Assert.AreEqual(confidence, formTable.Confidence);
            Assert.AreEqual(fieldElements, formTable.FieldElements);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormWord()
        {
            var boundingBox = new BoundingBox(ListOfPoints);
            var pageNumber = 113;
            var text = "Newton";
            var confidence = 0.1602f;

            var formWord = FormRecognizerModelFactory.FormWord(boundingBox, pageNumber, text, confidence);

            Assert.AreEqual(boundingBox, formWord.BoundingBox);
            Assert.AreEqual(pageNumber, formWord.PageNumber);
            Assert.AreEqual(text, formWord.Text);
            Assert.AreEqual(confidence, formWord.Confidence);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateRecognizedForm()
        {
            var formType = "Turing";
            var pageRange = new FormPageRange(281, 349);
            var fields = new Dictionary<string, FormField>();
            var pages = new List<FormPage>();

            var recognizedForm = FormRecognizerModelFactory.RecognizedForm(formType, pageRange, fields, pages);

            Assert.AreEqual(formType, recognizedForm.FormType);
            Assert.AreEqual(pageRange, recognizedForm.PageRange);
            Assert.AreEqual(fields, recognizedForm.Fields);
            Assert.AreEqual(pages, recognizedForm.Pages);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateRecognizedFormCollection()
        {
            // TODO.
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateTrainingDocumentInfo()
        {
            var name = "Curie";
            var pageCount = 211;
            var errors = new List<FormRecognizerError>();
            var status = TrainingStatus.PartiallySucceeded;

            var trainingDocumentInfo = FormRecognizerModelFactory.TrainingDocumentInfo(name, pageCount, errors, status);

            Assert.AreEqual(name, trainingDocumentInfo.Name);
            Assert.AreEqual(pageCount, trainingDocumentInfo.PageCount);
            Assert.AreEqual(errors, trainingDocumentInfo.Errors);
            Assert.AreEqual(status, trainingDocumentInfo.Status);
        }
    }
}
