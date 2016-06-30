using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files
{
    /// <summary>
    /// Represents a tracked save, in which a background operation periodically copies appends
    /// to a file to the corresponding append blob in Azure Storage.
    /// </summary>
    /// <seealso cref="TaskOutputStorage.SaveTrackedAsync(TaskOutputKind, string, string, TimeSpan)"/>
    public interface ITrackedSaveOperation : IDisposable
    {
        /// <summary>
        /// Occurs when there is an error while performing a background append to the blob in Azure Storage.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If an error occurs while appending, the 'last position' is not updated, so the data that
        /// could not be appended will be included in the next flush.
        /// </para>
        /// <para>
        /// This event is not raised if an error occurs during <see cref="IDisposable.Dispose"/>; instead,
        /// the Dispose method method re-throws the exception directly. In this case, the background
        /// appends are no longer running, so it is up to the calling code to decide whether and how to
        /// save the unflushed data (for example, re-saving the file using the non-tracking methods).
        /// </para>
        /// </remarks>
        event EventHandler<Exception> FlushError;
    }
}
