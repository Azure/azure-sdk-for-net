// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System.Collections.Generic;
//using System.Linq;

//namespace Azure.AI.FormRecognizer.Models
//{
//    /// <summary>
//    /// </summary>
//    // Maps to PageResult
//    public class CustomFormPage
//    {
//        // Unsupervised
//        internal CustomFormPage(PageResult_internal pageResult, ReadResult_internal readResult)
//        {
//            PageTypeId = pageResult.ClusterId;
//            Fields = ConvertFields(pageResult.KeyValuePairs, readResult);
//            Tables = FormPageContent.ConvertTables(pageResult.Tables, readResult);

//            // TODO: Set CheckBoxes

//            if (readResult != null)
//            {
//                PageNumber = readResult.Page;
//                TextElements = new FormPageElements(readResult);
//            }
//        }

//        /// <summary> The 1-based page number in the input document. </summary>
//        public int PageNumber { get; set; }

//        /// <summary>
//        /// </summary>
//        public int? PageTypeId { get; }

//        /// <summary>
//        /// </summary>
//        public IReadOnlyList<FormField> Fields { get; }

//        /// <summary>
//        /// </summary>
//        public IReadOnlyList<FormTable> Tables { get; }

//        /// <summary>
//        /// </summary>
//        public IReadOnlyList<FormCheckBox> CheckBoxes { get; }

//        /// <summary>
//        /// </summary>
//        public FormPageElements PageText { get; }

//        /// <summary>
//        /// Return the field value text for a given fieldName.
//        /// </summary>
//        /// <param name="fieldName"></param>
//        /// <returns></returns>
//        public string GetFieldValue(string fieldName)
//        {
//            var field = Fields.Where(f => f.Name == fieldName).FirstOrDefault();
//            if (field == default)
//            {
//                throw new FieldNotFoundException($"Field '{fieldName}' not found on form.");
//            }

//            return field.Value;
//        }

//        private static IReadOnlyList<FormField> ConvertFields(ICollection<KeyValuePair_internal> keyValuePairs, ReadResult_internal readResult)
//        {
//            List<FormField> fields = new List<FormField>();
//            foreach (var kvp in keyValuePairs)
//            {
//                FormField field = new FormField(kvp, readResult);
//                fields.Add(field);
//            }
//            return fields;
//        }
//    }
//}
