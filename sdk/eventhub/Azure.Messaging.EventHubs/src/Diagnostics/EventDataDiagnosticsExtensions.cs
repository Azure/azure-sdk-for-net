using System.Diagnostics;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    internal static class EventDataDiagnosticsExtensions
    {
        public static Activity ExtractActivity(this EventData eventData, string activityName = null)
        {
            static TrackOne.EventData TransformEvent(EventData eventData) =>
                new TrackOne.EventData(eventData.Body.ToArray())
                {
                    Properties = eventData.Properties
                };

            return TrackOne.EventDataDiagnosticExtensions.ExtractActivity(TransformEvent(eventData), activityName);
        }
    }
}
