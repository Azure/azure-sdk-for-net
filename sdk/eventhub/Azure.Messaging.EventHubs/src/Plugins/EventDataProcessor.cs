namespace Azure.Messaging.EventHubs.Plugins
{
    using System.Threading.Tasks;

    /// <summary>
    ///   Serves as a processor of <see cref="EventData" />, allowing a pipeline of transformations
    ///   to occur in the context of an operation, such as before sending the data or after the data
    ///   is received.
    /// </summary>
    ///
    /// <remarks>
    ///   Processing is expeced to happen in-place, and each processor in the pipeline is free to mutate
    ///   the data that it receives.
    /// </remarks>
    ///
    public abstract class EventDataProcessor
    {
        /// <summary>
        ///   The name used to identify the this particular processor for informational
        ///   purposes.
        /// </summary>
        ///
        public abstract string Name { get; }

        /// <summary>
        ///   Determines whether a failure which occurs during processing should be considered fatal
        ///   for the operation which requested processing, such as sending and receiving, causing them to
        ///   abort.
        /// </summary>
        ///
        /// <value><c>true</c> if a failure should be considered fatal to the caller; otherwise, <c>false</c>.</value>
        ///
        /// <remarks>
        ///   Because processors are typically run in a sequential pipeline, where the updated event data is passed
        ///   from one processor to the next, any failure that leaves the data corrupted or an in inconsistent state could
        ///   poison the event.
        ///
        ///   It is very strongly recommended to consider all failures fatal unless it is absolutely certain that there is
        ///   no risk to integrity of the event data.  Please note that this is almost never the case when data is being modified
        ///   in any way.
        /// </remarks>
        ///
        public virtual bool ConsiderFailureFatal => true;

        /// <summary>
        ///   Performs any processing of <see cref="EventData" /> necessary for the associated operation.
        /// </summary>
        ///
        /// <param name="eventData">The <see cref="EventData" /> to be processed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <remarks>
        ///   Processing is expected to happen in-place, and is likely to directly mutate the <paramref name="eventData"/>
        ///   that was specified.
        /// </remarks>
        ///
        public abstract Task ProcessAsync(EventData eventData);
    }
}
