// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// A class which defines sorting options used in listing all submitted translation operations.
    /// </summary>
    public class TranslationFilterOrder
    {
        /// <summary>
        /// Initializes an instance of <see cref="TranslationFilterOrder"/>.
        /// </summary>
        public TranslationFilterOrder(TranslationFilterProperty property, bool ascending = true)
        {
            Ascending = ascending;
            Property = property;
        }
        /// <summary>
        /// Sort results ascendingly if true, or descendingly if false.
        /// Default value is true.
        /// </summary>
        public bool Ascending { get; set; } = true;

        /// <summary>
        /// See <see cref="TranslationFilterProperty"/> for list of properties supported.
        /// </summary>
        public TranslationFilterProperty Property { get; set; }

        /// <summary>
        /// Convert the order filter to string.
        /// </summary>
        /// <returns></returns>
        internal string ToGenerated()
        {
            // convert enum property to corresponding <see cref="DocumentStatus"/> model attribute
            var property = string.Empty;
            switch (Property)
            {
                case TranslationFilterProperty.CreatedOn:
                    property = "createdDateTimeUtc";
                    break;
                default:
                    break;
            }

            // sorting direction
            var direction = Ascending ? "Asc" : "Desc";

            return $"{property} {direction}";
        }
    }
}
