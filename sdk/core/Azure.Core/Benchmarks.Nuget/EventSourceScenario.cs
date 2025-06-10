using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using Azure.Core.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Nuget
{
    public class EventSourceScenario
    {
        private AzureEventSourceListener _sourceListener;
        private EventSource _eventSource; // Use the custom EventSource below
        private string _sanitizedUri;
        private byte[] _headersBytes;
        private int _iteration;

        public EventSourceScenario(string sanitizedUri, byte[] headersBytes)
        {
            _sourceListener = new AzureEventSourceListener(_ => { }, EventLevel.LogAlways);
            _eventSource = new EventSource();
            _sourceListener.EnableEvents(_eventSource, EventLevel.LogAlways);
            _sanitizedUri = sanitizedUri;
            _headersBytes = headersBytes;
        }


        public void RunOld(string uri, byte[] headers)
        {
            _eventSource.RequestOld(uri, _iteration++, _iteration, headers);
        }

        public void RunNew(string uri, byte[] headers)
        {
            _eventSource.RequestNew(uri, _iteration++, _iteration, headers);
        }

        public void RunNewPreformatted()
        {
            _eventSource.RequestNew(_sanitizedUri, _iteration++, _iteration, _headersBytes);
        }

        public void Dispose()
        {
            _sourceListener.Dispose();
            _eventSource.Dispose();
        }
    }

    // Move this outside and make it internal
    internal class EventSource : System.Diagnostics.Tracing.EventSource
    {
        public EventSource() : base("Azure-Core") { }

        [Event(1, Level = EventLevel.Informational)]
        public void RequestOld(string strParam, int intParam, double doubleParam, byte[] bytesParam)
        {
            WriteEvent(1, strParam, intParam, doubleParam, bytesParam);
        }

        [Event(2, Level = EventLevel.Informational)]
        public void RequestNew(string strParam, int intParam, double doubleParam, byte[] bytesParam)
        {
            WriteEventNew(2, strParam, intParam, doubleParam, bytesParam);
        }

        [NonEvent]
        private unsafe void WriteEventNew(int eventId, string arg0, int intParam, double doubleParam, byte[] bytesParam)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            {
                EventData* data = stackalloc EventData[5];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&intParam);
                data[1].Size = 4;
                data[2].DataPointer = (IntPtr)(&doubleParam);
                data[2].Size = 8;

                var blobSize = bytesParam.Length;
                fixed (byte* blob = &bytesParam[0])
                {
                    data[3].DataPointer = (IntPtr)(&blobSize);
                    data[3].Size = 4;
                    data[4].DataPointer = (IntPtr)blob;
                    data[4].Size = blobSize;
                    WriteEventCore(eventId, 4, data);
                }
            }
        }
    }
}
