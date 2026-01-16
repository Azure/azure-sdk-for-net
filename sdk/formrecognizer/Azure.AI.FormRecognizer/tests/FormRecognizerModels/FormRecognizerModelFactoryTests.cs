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
        /// Assists in <see cref="FieldBoundingBox"/> creation.
        /// </summary>
        private readonly IReadOnlyList<PointF> ListOfPoints = new List<PointF>() { new PointF(3.1415f, 1.6180f), new PointF(6.6740f, 8.9876f) };

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateAccountProperties()
        {
            var customModelCount = 439;
            var customModelLimit = 647;

            var accountProperties = FormRecognizerModelFactory.AccountProperties(customModelCount, customModelLimit);

            Assert.That(accountProperties.CustomModelCount, Is.EqualTo(customModelCount));
            Assert.That(accountProperties.CustomModelLimit, Is.EqualTo(customModelLimit));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldBoundingBox()
        {
            var boundingBox = FormRecognizerModelFactory.FieldBoundingBox(ListOfPoints);

            Assert.That(boundingBox.Points, Is.EqualTo(ListOfPoints).AsCollection);
        }

        [Test]
        public void FormRecognizerModelFactoryInstantiatesEmptyBoundingBoxWhenPointsListIsNull()
        {
            var boundingBox = FormRecognizerModelFactory.FieldBoundingBox(null);

            Assert.That(boundingBox.Points, Is.Not.Null);
            Assert.That(boundingBox.Points, Is.Empty);
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateCustomFormModel()
        {
            var customFormSubmodel = new CustomFormSubmodel(default, (float?)default, default, default);
            var trainingDocumentInfo = new TrainingDocumentInfo(default, default, default, default, default);
            var formRecognizerError = new FormRecognizerError("", "");

            var modelId = "18910691-1896-0619-1896-091118961109";
            var modelName = "My model";
            var properties = new CustomFormModelProperties();
            var status = CustomFormModelStatus.Ready;
            var trainingStartedOn = DateTimeOffset.Parse("1723-07-31T23:29:31Z");
            var trainingCompletedOn = DateTimeOffset.Parse("1933-09-11T19:13:43Z");
            var submodels = new List<CustomFormSubmodel>() { customFormSubmodel };
            var trainingDocuments = new List<TrainingDocumentInfo>() { trainingDocumentInfo };
            var errors = new List<FormRecognizerError>() { formRecognizerError };

            var customFormModel = FormRecognizerModelFactory.CustomFormModel(modelId, status, trainingStartedOn, trainingCompletedOn, submodels, trainingDocuments, errors, modelName, properties);

            Assert.That(customFormModel.ModelId, Is.EqualTo(modelId));
            Assert.That(customFormModel.ModelName, Is.EqualTo(modelName));
            Assert.That(customFormModel.Status, Is.EqualTo(status));
            Assert.That(customFormModel.TrainingStartedOn, Is.EqualTo(trainingStartedOn));
            Assert.That(customFormModel.TrainingCompletedOn, Is.EqualTo(trainingCompletedOn));
            Assert.That(customFormModel.Properties, Is.EqualTo(properties));
            Assert.That(customFormModel.Submodels, Is.Not.SameAs(submodels));
            Assert.That(customFormModel.Submodels, Is.EqualTo(submodels));
            Assert.That(customFormModel.TrainingDocuments, Is.Not.SameAs(trainingDocuments));
            Assert.That(customFormModel.TrainingDocuments, Is.EqualTo(trainingDocuments));
            Assert.That(customFormModel.Errors, Is.Not.SameAs(errors));
            Assert.That(customFormModel.Errors, Is.EqualTo(errors));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateCustomFormModelField()
        {
            var name = "Leonhard";
            var label = "Euler";
            var accuracy = 0.2718f;

            var customFormModelField = FormRecognizerModelFactory.CustomFormModelField(name, label, accuracy);

            Assert.That(customFormModelField.Name, Is.EqualTo(name));
            Assert.That(customFormModelField.Label, Is.EqualTo(label));
            Assert.That(customFormModelField.Accuracy, Is.EqualTo(accuracy));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateCustomFormModelInfo()
        {
            var modelId = "10001112-2233-3444-5556-667778889991";
            var modelName = "My model";
            var properties = new CustomFormModelProperties();
            var trainingStartedOn = DateTimeOffset.Parse("1933-05-17T11:59:02Z");
            var trainingCompletedOn = DateTimeOffset.Parse("1949-03-19T07:41:47Z");
            var status = CustomFormModelStatus.Ready;

            var customFormModelInfo = FormRecognizerModelFactory.CustomFormModelInfo(modelId, trainingStartedOn, trainingCompletedOn, status, modelName, properties);

            Assert.That(customFormModelInfo.ModelId, Is.EqualTo(modelId));
            Assert.That(customFormModelInfo.ModelName, Is.EqualTo(modelName));
            Assert.That(customFormModelInfo.Properties, Is.EqualTo(properties));
            Assert.That(customFormModelInfo.TrainingStartedOn, Is.EqualTo(trainingStartedOn));
            Assert.That(customFormModelInfo.TrainingCompletedOn, Is.EqualTo(trainingCompletedOn));
            Assert.That(customFormModelInfo.Status, Is.EqualTo(status));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateCustomFormModelProperties()
        {
            var isComposedModel = true;

            var customFormModelProperties = FormRecognizerModelFactory.CustomFormModelProperties(isComposedModel);

            Assert.That(customFormModelProperties.IsComposedModel, Is.EqualTo(isComposedModel));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateCustomFormSubmodel()
        {
            var customFormModelField = new CustomFormModelField("", default);

            var modelId = "10001112-2233-3444-5556-667778889991";
            var formType = "Pythagoras";
            var accuracy = 0.1414f;
            var fields = new Dictionary<string, CustomFormModelField>() { { "", customFormModelField } };

            var customFormSubmodel = FormRecognizerModelFactory.CustomFormSubmodel(formType, accuracy, fields, modelId);

            Assert.That(customFormSubmodel.ModelId, Is.EqualTo(modelId));
            Assert.That(customFormSubmodel.FormType, Is.EqualTo(formType));
            Assert.That(customFormSubmodel.Accuracy, Is.EqualTo(accuracy));
            Assert.That(customFormSubmodel.Fields, Is.Not.SameAs(fields));
            Assert.That(customFormSubmodel.Fields, Is.EqualTo(fields));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldData()
        {
            var formElement = new FormWord(default, default, default, default);

            var boundingBox = new FieldBoundingBox(ListOfPoints);
            var pageNumber = 109;
            var text = "Poincare";
            var fieldElements = new List<FormElement>() { formElement };

            var fieldData = FormRecognizerModelFactory.FieldData(boundingBox, pageNumber, text, fieldElements);

            Assert.That(fieldData.BoundingBox, Is.EqualTo(boundingBox));
            Assert.That(fieldData.PageNumber, Is.EqualTo(pageNumber));
            Assert.That(fieldData.Text, Is.EqualTo(text));
            Assert.That(fieldData.FieldElements, Is.Not.SameAs(fieldElements));
            Assert.That(fieldData.FieldElements, Is.EqualTo(fieldElements));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithStringValueType()
        {
            string value = "Lovelace";

            var fieldValue = FormRecognizerModelFactory.FieldValueWithStringValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.String));
            Assert.That(fieldValue.AsString(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsPhoneNumber());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsList());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDictionary());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsCountryRegion());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithInt64ValueType()
        {
            long value = 1709;

            var fieldValue = FormRecognizerModelFactory.FieldValueWithInt64ValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Int64));
            Assert.That(fieldValue.AsInt64(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsString());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsPhoneNumber());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsList());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDictionary());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsCountryRegion());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithFloatValueType()
        {
            float value = 6.0221f;

            var fieldValue = FormRecognizerModelFactory.FieldValueWithFloatValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Float));
            Assert.That(fieldValue.AsFloat(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsString());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsPhoneNumber());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsList());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDictionary());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsCountryRegion());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithDateValueType()
        {
            DateTime value = DateTime.UtcNow;

            var fieldValue = FormRecognizerModelFactory.FieldValueWithDateValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Date));
            Assert.That(fieldValue.AsDate(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsString());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsPhoneNumber());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsList());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDictionary());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsCountryRegion());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithTimeValueType()
        {
            TimeSpan value = TimeSpan.FromSeconds(104717);

            var fieldValue = FormRecognizerModelFactory.FieldValueWithTimeValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Time));
            Assert.That(fieldValue.AsTime(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsString());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsPhoneNumber());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsList());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDictionary());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsCountryRegion());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithPhoneNumberValueType()
        {
            string value = "1500450271";

            var fieldValue = FormRecognizerModelFactory.FieldValueWithPhoneNumberValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.PhoneNumber));
            Assert.That(fieldValue.AsPhoneNumber(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsString());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsList());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDictionary());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsCountryRegion());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithListValueType()
        {
            var formField = new FormField(default, default, default, default, default);

            List<FormField> value = new List<FormField>() { formField };

            var fieldValue = FormRecognizerModelFactory.FieldValueWithListValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.List));
            Assert.That(fieldValue.AsList(), Is.Not.SameAs(value));
            Assert.That(fieldValue.AsList(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsString());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsPhoneNumber());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDictionary());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsCountryRegion());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithDictionaryValueType()
        {
            var formField = new FormField(default, default, default, default, default);

            Dictionary<string, FormField> value = new Dictionary<string, FormField>() { { "", formField } };

            var fieldValue = FormRecognizerModelFactory.FieldValueWithDictionaryValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Dictionary));
            Assert.That(fieldValue.AsDictionary(), Is.Not.SameAs(value));
            Assert.That(fieldValue.AsDictionary(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsString());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsPhoneNumber());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsList());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsCountryRegion());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithSelectionMarkValueType()
        {
            var value = SelectionMarkState.Selected;
            var fieldValue = FormRecognizerModelFactory.FieldValueWithSelectionMarkValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.SelectionMark));
            Assert.That(fieldValue.AsSelectionMarkState(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsString());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsList());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsPhoneNumber());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDictionary());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsCountryRegion());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFieldValueWithCountryRegionValueType()
        {
            var value = "BRA";
            var fieldValue = FormRecognizerModelFactory.FieldValueWithCountryRegionValueType(value);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.CountryRegion));
            Assert.That(fieldValue.AsCountryRegion(), Is.EqualTo(value));

            Assert.Throws<InvalidOperationException>(() => fieldValue.AsString());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsList());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsPhoneNumber());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDictionary());
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormField()
        {
            var name = "Cardano";
            var labelData = new FieldData(default, default, default, default);
            var valueData = new FieldData(default, default, default, default);
            var value = new FieldValue(1);
            var confidence = 0.8854f;

            var formField = FormRecognizerModelFactory.FormField(name, labelData, valueData, value, confidence);

            Assert.That(formField.Name, Is.EqualTo(name));
            Assert.That(formField.LabelData, Is.EqualTo(labelData));
            Assert.That(formField.ValueData, Is.EqualTo(valueData));
            Assert.That(formField.Value, Is.EqualTo(value));
            Assert.That(formField.Confidence, Is.EqualTo(confidence));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormLine()
        {
            var formWord = new FormWord(default, default, default, default);

            var boundingBox = new FieldBoundingBox(ListOfPoints);
            var pageNumber = 389;
            var text = "Bhaskara";
            var words = new List<FormWord>() { formWord };
            var appearance = new TextAppearance(default, default);

            var formLine = FormRecognizerModelFactory.FormLine(boundingBox, pageNumber, text, words, appearance);

            Assert.That(formLine.BoundingBox, Is.EqualTo(boundingBox));
            Assert.That(formLine.PageNumber, Is.EqualTo(pageNumber));
            Assert.That(formLine.Text, Is.EqualTo(text));
            Assert.That(formLine.Words, Is.Not.SameAs(words));
            Assert.That(formLine.Words, Is.EqualTo(words));
            Assert.That(formLine.Appearance, Is.EqualTo(appearance));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormPage()
        {
            var formLine = new FormLine(default, default, default, default, default);
            var formTable = new FormTable(default, default, default, default, default);
            var formSelectionMark = new FormSelectionMark(default, default, default, default, default);

            var pageNumber = 503;
            var width = 9.1094f;
            var height = 1.6726f;
            var textAngle = 29.9792f;
            var unit = LengthUnit.Inch;
            var lines = new List<FormLine>() { formLine };
            var tables = new List<FormTable>() { formTable };
            var selectionMarks = new List<FormSelectionMark>() { formSelectionMark };

            var formPage = FormRecognizerModelFactory.FormPage(pageNumber, width, height, textAngle, unit, lines, tables, selectionMarks);

            Assert.That(formPage.PageNumber, Is.EqualTo(pageNumber));
            Assert.That(formPage.Width, Is.EqualTo(width));
            Assert.That(formPage.Height, Is.EqualTo(height));
            Assert.That(formPage.TextAngle, Is.EqualTo(textAngle));
            Assert.That(formPage.Unit, Is.EqualTo(unit));
            Assert.That(formPage.Lines, Is.Not.SameAs(lines));
            Assert.That(formPage.Lines, Is.EqualTo(lines));
            Assert.That(formPage.Tables, Is.Not.SameAs(tables));
            Assert.That(formPage.Tables, Is.EqualTo(tables));
            Assert.That(formPage.SelectionMarks, Is.Not.SameAs(selectionMarks));
            Assert.That(formPage.SelectionMarks, Is.EqualTo(selectionMarks));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormPageCollection()
        {
            var formPage = new FormPage(default, default, default, default, default, default, default, default);

            var list = new List<FormPage>() { formPage };

            var formPageCollection = FormRecognizerModelFactory.FormPageCollection(list);

            Assert.That(formPageCollection, Is.Not.SameAs(list));
            Assert.That(formPageCollection, Is.EqualTo(list));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormPageRange()
        {
            var firstPageNumber = 269;
            var lastPageNumber = 271;

            var formPageRange = FormRecognizerModelFactory.FormPageRange(firstPageNumber, lastPageNumber);

            Assert.That(formPageRange.FirstPageNumber, Is.EqualTo(firstPageNumber));
            Assert.That(formPageRange.LastPageNumber, Is.EqualTo(lastPageNumber));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormRecognizerError()
        {
            var errorCode = "Carl";
            var message = "Gauss";

            var formRecognizerError = FormRecognizerModelFactory.FormRecognizerError(errorCode, message);

            Assert.That(formRecognizerError.ErrorCode, Is.EqualTo(errorCode));
            Assert.That(formRecognizerError.Message, Is.EqualTo(message));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormSelectionMark()
        {
            var boundingBox = new FieldBoundingBox(ListOfPoints);
            var pageNumber = 113;
            var text = "selected";
            var confidence = 0.1602f;
            var state = SelectionMarkState.Selected;

            var formSelectionMark = FormRecognizerModelFactory.FormSelectionMark(boundingBox, pageNumber, text, confidence, state);

            Assert.That(formSelectionMark.BoundingBox, Is.EqualTo(boundingBox));
            Assert.That(formSelectionMark.PageNumber, Is.EqualTo(pageNumber));
            Assert.That(formSelectionMark.Text, Is.EqualTo(text));
            Assert.That(formSelectionMark.Confidence, Is.EqualTo(confidence));
            Assert.That(formSelectionMark.State, Is.EqualTo(state));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormTable()
        {
            var formTableCell = new FormTableCell(default, default, default, default, default, default, default, default, default, default, default);

            var pageNumber = 659;
            var columnCount = 89;
            var rowCount = 97;
            var cells = new List<FormTableCell>() { formTableCell };
            var boundingBox = new FieldBoundingBox(ListOfPoints);

            var formTable = FormRecognizerModelFactory.FormTable(pageNumber, columnCount, rowCount, cells, boundingBox);

            Assert.That(formTable.PageNumber, Is.EqualTo(pageNumber));
            Assert.That(formTable.ColumnCount, Is.EqualTo(columnCount));
            Assert.That(formTable.RowCount, Is.EqualTo(rowCount));
            Assert.That(formTable.Cells, Is.Not.SameAs(cells));
            Assert.That(formTable.Cells, Is.EqualTo(cells));
            Assert.That(formTable.BoundingBox, Is.EqualTo(boundingBox));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormTableCell()
        {
            var formElement = new FormWord(default, default, default, default);

            var boundingBox = new FieldBoundingBox(ListOfPoints);
            var pageNumber = 139;
            var text = "Leibniz";
            var columnIndex = 151;
            var rowIndex = 157;
            var columnSpan = 113;
            var rowSpan = 173;
            var isHeader = true;
            var isFooter = false;
            var confidence = 0.1257f;
            var fieldElements = new List<FormElement>() { formElement };

            var formTable = FormRecognizerModelFactory.FormTableCell(boundingBox, pageNumber, text, columnIndex, rowIndex, columnSpan, rowSpan, isHeader, isFooter, confidence, fieldElements);

            Assert.That(formTable.BoundingBox.Points, Is.EqualTo(ListOfPoints).AsCollection);
            Assert.That(formTable.PageNumber, Is.EqualTo(pageNumber));
            Assert.That(formTable.Text, Is.EqualTo(text));
            Assert.That(formTable.ColumnIndex, Is.EqualTo(columnIndex));
            Assert.That(formTable.RowIndex, Is.EqualTo(rowIndex));
            Assert.That(formTable.ColumnSpan, Is.EqualTo(columnSpan));
            Assert.That(formTable.RowSpan, Is.EqualTo(rowSpan));
            Assert.That(formTable.IsHeader, Is.EqualTo(isHeader));
            Assert.That(formTable.IsFooter, Is.EqualTo(isFooter));
            Assert.That(formTable.Confidence, Is.EqualTo(confidence));
            Assert.That(formTable.FieldElements, Is.Not.SameAs(fieldElements));
            Assert.That(formTable.FieldElements, Is.EqualTo(fieldElements));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateFormWord()
        {
            var boundingBox = new FieldBoundingBox(ListOfPoints);
            var pageNumber = 113;
            var text = "Newton";
            var confidence = 0.1602f;

            var formWord = FormRecognizerModelFactory.FormWord(boundingBox, pageNumber, text, confidence);

            Assert.That(formWord.BoundingBox, Is.EqualTo(boundingBox));
            Assert.That(formWord.PageNumber, Is.EqualTo(pageNumber));
            Assert.That(formWord.Text, Is.EqualTo(text));
            Assert.That(formWord.Confidence, Is.EqualTo(confidence));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateRecognizedForm()
        {
            var formField = new FormField(default, default, default, default, default);
            var formPage = new FormPage(default, default, default, default, default, default, default, default);

            var formType = "Turing";
            var modelId = "10001112-2233-3444-5556-667778889991";
            float confidence = 0.94f;
            var pageRange = new FormPageRange(281, 349);
            var fields = new Dictionary<string, FormField>() { { "", formField } };
            var pages = new List<FormPage>() { formPage };

            var recognizedForm = FormRecognizerModelFactory.RecognizedForm(formType, pageRange, fields, pages, modelId, confidence);

            Assert.That(recognizedForm.FormType, Is.EqualTo(formType));
            Assert.That(recognizedForm.ModelId, Is.EqualTo(modelId));
            Assert.That(recognizedForm.FormTypeConfidence.Value, Is.EqualTo(confidence));
            Assert.That(recognizedForm.PageRange, Is.EqualTo(pageRange));
            Assert.That(recognizedForm.Fields, Is.Not.SameAs(fields));
            Assert.That(recognizedForm.Fields, Is.EqualTo(fields));
            Assert.That(recognizedForm.Pages, Is.Not.SameAs(pages));
            Assert.That(recognizedForm.Pages, Is.EqualTo(pages));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateRecognizedFormCollection()
        {
            var recognizedForm = new RecognizedForm(default, default, default, default, default, default);

            var list = new List<RecognizedForm>() { recognizedForm };

            var recognizedFormCollection = FormRecognizerModelFactory.RecognizedFormCollection(list);

            Assert.That(recognizedFormCollection, Is.Not.SameAs(list));
            Assert.That(recognizedFormCollection, Is.EqualTo(list));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateTextAppearance()
        {
            var name = TextStyleName.Handwriting;
            var confidence = 0.299792f;

            var textAppearance = FormRecognizerModelFactory.TextAppearance(name, confidence);

            Assert.That(textAppearance.StyleName, Is.EqualTo(name));
            Assert.That(textAppearance.StyleConfidence, Is.EqualTo(confidence));
        }

        [Test]
        public void FormRecognizerModelFactoryCanInstantiateTrainingDocumentInfo()
        {
            var formRecognizerError = new FormRecognizerError("", "");

            var name = "Curie";
            var pageCount = 211;
            IEnumerable<FormRecognizerError> errors = new List<FormRecognizerError>() { formRecognizerError };
            var status = TrainingStatus.PartiallySucceeded;

            var trainingDocumentInfo = FormRecognizerModelFactory.TrainingDocumentInfo(name, pageCount, errors, status);

            Assert.That(trainingDocumentInfo.Name, Is.EqualTo(name));
            Assert.That(trainingDocumentInfo.PageCount, Is.EqualTo(pageCount));
            Assert.That(trainingDocumentInfo.Errors, Is.Not.SameAs(errors));
            Assert.That(trainingDocumentInfo.Errors, Is.EqualTo(errors));
            Assert.That(trainingDocumentInfo.Status, Is.EqualTo(status));
        }
    }
}
