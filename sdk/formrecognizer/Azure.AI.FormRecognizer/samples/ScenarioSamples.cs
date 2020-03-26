// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Samples
{
    class ReceiptSamples
    {
        IReadOnlyList<UnitedStatesReceipt> RecognizeUSReceipts(Uri uri)
        {
            // LOW: Perhaps I am not sufficiently familiar with async/LRO design patterns, but I had to do quite a bit of documentation lookup to write the following code.
            var client = new FormRecognizerClient(...);
            var task = await client.StartRecognizeUSReceipts(uri).WaitForCompletionAsync();
            return task.IsCompletedSuccessfully ? task.Result : Array.Empty<UnitedStatesReceipt>();

            // LOW: I would really like to write the following and use exceptions for failures.
            //      IReadOnlyList<UnitedStatesReceipt> usReceipts = client.RecognizeUSReceipts(uri);
        }

        void AssistedDataEntryForReceipt()
        {
            var usReceipts = RecognizeUSReceipts(..., includeTextElements: true);
            foreach (var usReceipt in usReceipts)
            {
                // Extract merchant value with confidence for visual highlighting.
                var merchantStr = usReceipt.MerchantName;
                var merchantConfidence = usReceipt.Fields["MerchantName"].ValueText.Confidence ?? 0;

                // We need page index and bounding box to highlight the value on the receipt.
                var merchantPageIndex = usReceipt.PageNumber - 1;
                var merchantBoundingBox = usReceipt.Fields["MerchantName"].ValueText.BoundingBox;

                // DETAIL: When a field value spans across page boundary, the current design (REST/SDK) doesn't really work.
                //         Original intent is to introduce a helper method that process the individual elements to return a set of bounding boxes across pages.
                //         FormField.ValueText.TextElements.GroupBy(e => e.PageNumber).Select(g => new { PageIndex = g.Key - 1, BoundingBox = BoundingBox.Union(g => g.Select(e => e.BoundingBox))});
                //         Note that this requires FormTextElement.PagNumber.  FormField.PageNumber is insufficient when the field spans across pages.
                //         Sorry I let this slip through the REST API because it feels so much easier to have FormField.BoundingBox, when it doesn't generalize.
                // IEnumerable<Tuple<int pageIndex, BoundingBox boundingBox>> fieldPositions = 
                //    usReceipt.Fields["MerchantName"].GetFieldPositions();

                ShowMerchant(merchantStr, merchantConfidence, merchantPageIndex, merchantBoundingBox)
    
            // Similarly for other select fields: Date, Total
            }
        }

        void ExpenseAuditing()
        {
            var usReceipts = RecognizeUSReceipts(...);
            foreach (var usReceipt in usReceipts)
            {
                // Extract features for ML model for expense auditing.
                var merchantStr = usReceipt.MerchantName;
                var merchantConfidence = usReceipt.Fields["MerchantName"].ValueText.Confidence ?? 0;
                var total = usReceipt.Total;
                var totalConfidence = usReceipt.Fields["Total"].ValueText.Confidence ?? 0;
                // ...
                var featureVector = GenerateFeatureVector(merchantStr, merchantConfidence, total, totalConfidence, ...);
            }
        }

        void PurchasingBehaviorModeling()
        {
            var usReceipts = RecognizeUSReceipts(...);
            foreach (var usReceipt in usReceipts)
            {
                var date = usReceipt.TransactionDate;
                foreach (var item in usReceipt.Items)
                {
                    var itemName = item.Name;
                    var itemPrice = item.Price;
                    var confidence = // No way to do this from usReceipt.Items or usReceipt.Fields["Items"] right now because we haven't implemented FieldValue.AsArray().

                    AddProductPrice(date, itemName, itemPrice, confidence);
                }
            }
        }
    }

    class UnsupervisedSamples
    {
        IReadOnlyList<RecognizedCustomForm> RecognizeCustomForms(Uri uri)
        {
            // Same as ReceiptSamples.RecognizeReceipts()
        }

        void HighlightKeyValues()
        {
            var customForms = RecognizeCustomForms(...);
            foreach (var customForm in customForms)
            {
                // We need the label filter otherwise field.Name will be null.  This is not obvious.
                foreach (var field in customForm.Fields.Where(f => f.Label == null))
                {
                    // Although both Name and ValueText are FieldText, they are not named consistently.
                    var key = field.Name;
                    var value = field.ValueText;
                    var confidence = field.ValueText.Confidence;  // field.Confidence
                    Highlight(key, value, confidence);
                }
            }
        }

        void FindCustomerName()
        {
            var customForms = RecognizeCustomForms(...);
            foreach (var customForm in customForms)
            {
                // Robustly extract a unsupervised field.
                var field = customForm.Fields.First(f =>
                    f.Label == null &&  // We wouldn't need this if we separate keyValuePairs.  Can also test f.Name != null, which is equally annoying
                    IsSimilarText(f.Name.Text, "Name:", nameSimilarityThreshold) &&  // Need to accommodate some OCR errors
                    IsNear(f.Name.BoundingBox[0], expectedCustomerNamePosition, nearnessThreshold));  // Need to distinguish between CustomerName and SupplierName, both with the key "Name:".

                if (field != null)
                    HighlightCustomerName(field)
            }
        }

        void FindEulaCheckbox()
        {
            var customForms = RecognizeCustomForms(...);
            foreach (var customForm in customForms)
            {
                // Extract a checkbox approximately by position.  This is not robust since it is very sensitive to subtle shifts.
                // I don't recommend using this technique to access a checkbox.  Conceptually, we should think of RecognizedCustomForm.Checkboxes as additional "words" that we recognized on the page.  In fact, we were debating internally for a while whether we should just encode detected checkboxes as a TextWord whose Text is ☐ or ☑.
                // LOW: Slightly annoying that .NET already uses CheckBox instead of Checkbox.  Unicode, Wiki, Merriam-Webster define checkbox as a single word.
                var checkBox = customForm.CheckBoxes.First(c =>
                    IsNear(f.Name.BoundingBox[0], expectedCheckBoxPosition, nearnessThreshold));

                if (field != null)
                    HighlightEulaCheckbox(checkBox);
            }
        }
    }

    class SupervisedSamples
    {
        void PopulateDatabase()
        {
            var customForms = RecognizeCustomForms(...);
            foreach (var customForm in customForms)
            {
                var dataRow = new ...;
                foreach (var field in customForm.Fields.Where(f => f.Label != null))
                {
                    // As the supervised field names are predefined, we can define them to match the data table column names so SetValue() always succeeds.
                    var fieldName = field.Label;
                    switch (field.Value.Type)
                    {
                        case FieldValueType.StringType:
                            dataRow.SetValue(fieldName, field.Value.AsString());
                            break;
                        case FieldValueType.IntegerType:
                            dataRow.SetValue(fieldName, field.Value.AsInteger());
                            break;
                    }
                }

                // There is no easy way to directly populate databases from unsupervised result.  The closest is variations of UnsupervisedSamples.FindCustomerName().
                AddDataRow(dataRow);
            }
        }

        void FindEulaCheckbox()
        {
            var customForms = RecognizeCustomForms(...);
            foreach (var customForm in customForms)
            {
                // Extract a predefined/labeled checkbox, which internally considers the neighboring text/context, not just absolute position.
                if (customForm.TryGetFieldValue("EulaCheckbox", out var eulaCheckbox))
                    HighlightEulaConsentCheckbox(eulaCheckBox);

                // LOW: I personally find it less awkward to use customForm.Fields.TryGetValue(), where Fields only contains supervised results as a Dictionary.
            }
        }
    }

}
