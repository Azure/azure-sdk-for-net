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
        public TranslationFilterOrder(TranslationFilterProperty property, bool asc = true)
        {
            Asc = asc;
            Property = property;
        }
        /// <summary>
        /// Sort results ascendingly if true, or descendingly if false.
        /// </summary>
        public bool Asc { get; set; }
        /// <summary>
        /// The <see cref="TranslationStatus"/> property to use in sorting.
        /// <see cref="TranslationFilterProperty"/> for list of properties supported.
        /// </summary>
        public TranslationFilterProperty Property { get; set; }

        /// <summary>
        /// Convert the order filter to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var direction = Asc ? "Asc" : "Desc";
            var property = ConvertDocumentFilterEnumPropertyToModelAttribute(Property);
            return $"{property} {direction}";
        }

        /// <summary>
        /// Converts enum property in <see cref="DocumentFilterProperty"/> to corresponding generated model property name <see cref="DocumentStatus"/>.
        /// </summary>
        /// <returns></returns>
        private static string ConvertDocumentFilterEnumPropertyToModelAttribute(TranslationFilterProperty enumProperty)
        {
            switch (enumProperty)
            {
                case TranslationFilterProperty.CreatedOn:
                    return "createdDateTimeUtc";
                default:
                    return string.Empty;
            }
        }
    }

    /// <summary>
    /// An enum listing the supported properties that can be used in sorting
    /// when listing all submitted translation operations.
    /// </summary>
    public enum TranslationFilterProperty
    {
        /// <summary>
        /// sorting property corresponds to <see cref="TranslationStatus.CreatedOn"/>.
        /// </summary>
        CreatedOn = 0,
    }
}
