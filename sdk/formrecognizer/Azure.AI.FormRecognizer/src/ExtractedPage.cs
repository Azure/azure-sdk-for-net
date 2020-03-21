// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    // Maps to PageResult
    public class CustomFormPage
    {
        // Unsupervised
        internal CustomFormPage(PageResult_internal pageResult, ReadResult_internal readResult)
        {
            PageNumber = pageResult.Page;
            FormTypeId = pageResult.ClusterId;
            Fields = ConvertFields(pageResult.KeyValuePairs, readResult);
            Tables = FormPageContent.ConvertTables(pageResult.Tables, readResult);

            if (readResult != null)
            {
                PageInfo = new FormPageInfo(readResult);

                if (readResult.Lines != null)
                {
                    TextElements = new FormPageText(readResult.Lines);
                }
            }
        }

        /// <summary>
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// </summary>
        public int? FormTypeId { get; }

        /// <summary>
        /// </summary>

        public IReadOnlyList<FormField> Fields { get; }

        /// <summary>
        /// </summary>

        public IReadOnlyList<FormTable> Tables { get; }

        /// <summary>
        /// </summary>
        public FormPageInfo PageInfo { get; }

        /// <summary>
        /// </summary>
        public FormPageText TextElements { get; }

        /// <summary>
        /// Return the field value text for a given fieldName.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public string GetFieldValue(string fieldName)
        {
            var field = Fields.Where(f => f.Name == fieldName).FirstOrDefault();
            if (field == default)
            {
                throw new FieldNotFoundException($"Field '{fieldName}' not found on form.");
            }

            return field.Value;
        }

        private static IReadOnlyList<FormField> ConvertFields(ICollection<KeyValuePair_internal> keyValuePairs, ReadResult_internal readResult)
        {
            List<FormField> fields = new List<FormField>();
            foreach (var kvp in keyValuePairs)
            {
                FormField field = new FormField(kvp, readResult);
                fields.Add(field);
            }
            return fields;
        }
    }
}
