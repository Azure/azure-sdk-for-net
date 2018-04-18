namespace Microsoft.Azure.CognitiveServices.Search.VisualSearch.TestModels
{
    using Newtonsoft.Json;

    public partial class KnowledgeRequest
    {
        /// <summary>
        /// Initializes a new instance of the KnowledgeRequest class.
        /// </summary>
        public KnowledgeRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the KnowledgeRequest class.
        /// </summary>
        /// <param name="imageInfo">Holds information about the image.</param>
        public KnowledgeRequest(ImageInfo imageInfo = default(ImageInfo))
        {
            ImageInfo = imageInfo;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets information about the image
        /// </summary>
        [JsonProperty(PropertyName = "imageInfo")]
        public ImageInfo ImageInfo { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ImageInfo != null)
            {
                ImageInfo.Validate();
            }
        }
    }
}
