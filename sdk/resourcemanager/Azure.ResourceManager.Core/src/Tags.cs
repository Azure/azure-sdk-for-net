using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core
{
    public class Tags : TagsOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tags"/> class for mocking.
        /// </summary>
        protected Tags()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tags"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="tagsData"> The data model representing the generic azure resource. </param>
        internal Tags(OperationsBase operations, TagsData tagsData)
            : base(operations, tagsData.Id)
        {
            Data = tagsData;
        }

        /// <summary>
        /// Gets the Tags data model.
        /// </summary>
        public virtual TagsData Data { get; }
    }
}
