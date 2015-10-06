namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Thrown when an error occurs during cluster create.
    /// </summary>
    [Serializable]
    public class HDInsightClusterCreateException : Exception
    {
        private const string DefaultExceptionMessage = "An unknown error occurred during cluster create";

        private const string ClusterDetailsSerializationKey = "CLUSTERDETAILS";

        private ClusterDetails hdiClusterDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="HDInsightClusterCreateException"/> class.
        /// </summary>
        public HDInsightClusterCreateException()
            : this(DefaultExceptionMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HDInsightClusterCreateException"/> class.
        /// </summary>
        /// <param name="clusterDetails">The <see cref="ClusterDetails" /> that contains contextual information about the cluster create attempt.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Taken care of inline.")]
        public HDInsightClusterCreateException(ClusterDetails clusterDetails)
            : this(clusterDetails != null ? string.Format(CultureInfo.InvariantCulture,
                                  "Unable to complete the cluster create operation. Operation failed with code '{0}'. Cluster left behind state: '{1}'. Message: '{2}'.",
                                  clusterDetails.Error.HttpCode,
                                  clusterDetails.StateString ?? "NULL",
                                  clusterDetails.Error.Message ?? "NULL") : DefaultExceptionMessage, 
                null)
        {
            this.hdiClusterDetails = clusterDetails;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HDInsightClusterCreateException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected HDInsightClusterCreateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HDInsightClusterCreateException"/> class.
        /// </summary>
        /// <param name="exceptionMessage">The <see cref="T:System.string" /> that holds the exception message thrown.</param>
        public HDInsightClusterCreateException(string exceptionMessage)
            : this(exceptionMessage, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HDInsightClusterCreateException"/> class.
        /// </summary>
        /// <param name="message">The <see cref="T:System.string" /> that holds the exception message thrown.</param>
        /// <param name="innerException">The <see cref="T:System.Exception" /> that holds the inner exception thrown.</param>
        public HDInsightClusterCreateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets the cluster details of the cluster that did not create successfully.
        /// </summary>
        /// <value>
        /// The cluster details.
        /// </value>
        public ClusterDetails ClusterDetails
        {
            get { return this.hdiClusterDetails; }
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue(ClusterDetailsSerializationKey, this.hdiClusterDetails ?? null);

            // MUST call through to the base class to let it save its own state
            base.GetObjectData(info, context);
        }
    }
}