// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// A class which defines sorting options
    /// used in listing all document statuses for a certain translation operation.
    /// </summary>
    public class DocumentFilterOrder
    {
        /// <summary>
        /// Initializes an instance of <see cref="DocumentFilterOrder"/>.
        /// </summary>
        public DocumentFilterOrder(DocumentFilterProperty property, bool ascending = true)
        {
            Property = property;
            Ascending = ascending;
        }
        /// <summary>
        /// Sort results ascendingly if true, or descendingly if false.
        /// Default value is true.
        /// </summary>
        public bool Ascending { get; set; } = true;

        /// <summary>
        /// See <see cref="DocumentFilterProperty"/> for list of properties supported.
        /// </summary>
        public DocumentFilterProperty Property { get; set; }
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
                case DocumentFilterProperty.CreatedOn:
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
