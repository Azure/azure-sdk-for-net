
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The details about the specific stage of a job.
    /// </summary>
    public partial class JobStage
    {
        /// <summary>
        /// Initializes a new instance of the JobStage class.
        /// </summary>
        public JobStage() { }

        /// <summary>
        /// Initializes a new instance of the JobStage class.
        /// </summary>
        /// <param name="stageStatus">The stage status. Possible values
        /// include: 'Running', 'Succeeded', 'Failed', 'Canceled'</param>
        /// <param name="message">The message of the job stage.</param>
        /// <param name="detail">The details of the stage.</param>
        /// <param name="errorCode">The error code of the stage if any.</param>
        public JobStage(JobStatus stageStatus, string message = default(string), string detail = default(string), string errorCode = default(string))
        {
            Message = message;
            StageStatus = stageStatus;
            Detail = detail;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets or sets the message of the job stage.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the stage status. Possible values include: 'Running',
        /// 'Succeeded', 'Failed', 'Canceled'
        /// </summary>
        [JsonProperty(PropertyName = "stageStatus")]
        public JobStatus StageStatus { get; set; }

        /// <summary>
        /// Gets or sets the details of the stage.
        /// </summary>
        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; set; }

        /// <summary>
        /// Gets or sets the error code of the stage if any.
        /// </summary>
        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}

