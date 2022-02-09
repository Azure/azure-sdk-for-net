// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> Response of an event operation </summary>
    public class EventResponse : Response
    {
        private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        /// <summary> Initializes a new instance of EventResponse. </summary>
        /// <param name="status"> Status of the response. </param>
        /// <param name="reasonPhrase"> Reason phrase of the response </param>
        public EventResponse(int status, string reasonPhrase = null)
        {
            Status = status;
            ReasonPhrase = reasonPhrase;
        }

        /// <summary> Status </summary>
        public override int Status { get; }

        /// <summary> Reason phrase </summary>
        public override string ReasonPhrase { get; }

        /// <summary> Content stream </summary>
        public override Stream ContentStream { get; set; }

        /// <summary> Client reqauest id </summary>
        public override string ClientRequestId { get; set; }

        /// <summary> Dispose </summary>
        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary> Contains the header </summary>
        protected override bool ContainsHeader(string name)
        {
            return TryGetHeaderValues(name, out _);
        }

        /// <summary> Enumerate the headers </summary>
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => _headers.Select(h => new HttpHeader(h.Key, string.Join(",", h.Value)));

        /// <summary> Try to get the header </summary>
        protected override bool TryGetHeader(string name, out string value)
        {
            if (_headers.TryGetValue(name, out List<string> values))
            {
                value = string.Join(",", values);
                return true;
            }

            value = null;
            return false;
        }

        /// <summary> Try to get the header values </summary>
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
        {
            var result = _headers.TryGetValue(name, out List<string> valuesList);
            values = valuesList;
            return result;
        }
    }
}
