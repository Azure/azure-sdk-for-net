// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Test.HttpRecorder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RequestResponseInfo
    {
        public RecordEntry InternalRecordEntry { get; internal set; }

        public LongRunningOperationInfo LroInfo { get; internal set; }

        public RequestResponseInfo(RecordEntry entry)
        {
            InternalRecordEntry = entry;
            LroInfo = new LongRunningOperationInfo(entry);
        }
    }


    public class LongRunningOperationInfo
    {
        #region Private fields
        const string perfImpactKey = "RecordPlaybackPerfImpact";
        const string operationKey = "LroOperation";

        #endregion

        public string OperationVerb { get; internal set; }

        public bool IsPlaybackPerfImpacted { get; internal set; }

        public LROHeaderInfo LroHeader { get; internal set; }

        public LroInfoId LroId { get; internal set; }

        public LongRunningOperationInfo(RecordEntry entry)
        {  
            IsPlaybackPerfImpacted = false;

            LroHeader = new LROHeaderInfo(entry.RequestHeaders);
            InitDataFromHeaders(entry.RequestHeaders);
            LroId = new LroInfoId(entry.RequestHeaders);
        }

        void InitDataFromHeaders(Dictionary<string, List<string>> headers)
        {
            foreach(KeyValuePair<string, List<string>> kv in headers)
            {
                if (kv.Key.Equals(operationKey, StringComparison.OrdinalIgnoreCase))
                {
                    OperationVerb = kv.Value?.SingleOrDefault<string>();
                }

                if (kv.Key.Equals(perfImpactKey, StringComparison.OrdinalIgnoreCase))
                {
                    IsPlaybackPerfImpacted = Convert.ToBoolean(kv.Value?.SingleOrDefault<string>());
                }
            }
        }
    }


    public class LroInfoId
    {
        #region Private fields
        const string sessionIdKey = "LroSessionId";
        const string sessionPollingIdKey = "LroPollingId";
        const string perfImpactKey = "RecordPlaybackPerfImpact";
        const string operationKey = "LroOperation";

        string _internalSessionPollingId { get; set; }

        #endregion

        public long SessionId { get; internal set; }
        public long PollingId { get; internal set; }

        public int PollingCount { get; internal set; }


        public LroInfoId(Dictionary<string, List<string>> headers)
        {
            SessionId = 0;
            PollingId = 0;
            PollingCount = 0;
            DeconstructSessionPollingId(headers);
        }

        void DeconstructSessionPollingId(Dictionary<string, List<string>> headers)
        {
            foreach (KeyValuePair<string, List<string>> kv in headers)
            {
                if (kv.Key.Equals(sessionIdKey, StringComparison.OrdinalIgnoreCase))
                {
                    SessionId = Convert.ToInt64(kv.Value?.SingleOrDefault<string>());
                }

                if (kv.Key.Equals(sessionPollingIdKey, StringComparison.OrdinalIgnoreCase))
                {
                    _internalSessionPollingId = kv.Value?.Single<string>();
                }
            }

            if (!string.IsNullOrEmpty(_internalSessionPollingId))
            {
                string[] sessionPollingTokens = _internalSessionPollingId.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

                if (sessionPollingTokens != null)
                {
                    if (sessionPollingTokens.Length == 3)
                    {
                        PollingId = Convert.ToInt64(sessionPollingTokens[1]);
                        PollingCount = Convert.ToInt32(sessionPollingTokens[2]);
                    }
                }
            }
        }

        #region operator overloaded
        public static bool operator >(LroInfoId lhId, LroInfoId rhId)
        {
            bool greaterThan = false;

            if ((lhId.SessionId > rhId.SessionId) &&
                    (lhId.PollingId > rhId.PollingId) &&
                    (lhId.PollingCount > rhId.PollingCount))
            {
                greaterThan = true;
            }
            else if ((lhId.SessionId == rhId.SessionId) &&
                (lhId.PollingId > rhId.PollingId) &&
                (lhId.PollingCount > rhId.PollingCount))
            {
                greaterThan = true;
            }
            else if ((lhId.SessionId == rhId.SessionId) &&
                (lhId.PollingId == rhId.PollingId) &&
                (lhId.PollingCount > rhId.PollingCount))
            {
                greaterThan = true;
            }
            else
                greaterThan = false;

            return greaterThan;
        }

        public static bool operator <(LroInfoId lhId, LroInfoId rhId)
        {
            bool lessThan = false;

            if ((lhId.SessionId < rhId.SessionId) &&
                    (lhId.PollingId < rhId.PollingId) &&
                    (lhId.PollingCount < rhId.PollingCount))
            {
                lessThan = true;
            }
            else if((lhId.SessionId == rhId.SessionId) &&
                (lhId.PollingId < rhId.PollingId) &&
                (lhId.PollingCount < rhId.PollingCount))
            {
                lessThan = true;
            }
            else if((lhId.SessionId == rhId.SessionId) &&
                (lhId.PollingId == rhId.PollingId) &&
                (lhId.PollingCount < rhId.PollingCount))
            {
                lessThan = true;
            }
            else
                lessThan = false;

            return lessThan;
        }

        #endregion

        public override string ToString()
        {
            return _internalSessionPollingId;
        }
    }


    public class LROHeaderInfo
    {
        const string LocHeaderKey = "Location";
        const string AzAsyncHeaderKey = "Azure-AsyncOperation";


        public string LocationHeader { get; private set; }

        public string AzureAsyncOperationHeader { get; private set; }

        LroHeaderKind HeaderKind { get; set; }

        public LROHeaderInfo(Dictionary<string, List<string>> headers)
        {
            LocationHeader = string.Empty;
            AzureAsyncOperationHeader = string.Empty;


            foreach (KeyValuePair<string, List<string>> kv in headers)
            {
                if (kv.Key.Equals(LocHeaderKey, StringComparison.OrdinalIgnoreCase))
                {
                    LocationHeader = kv.Value?.FirstOrDefault<string>();
                }

                if (kv.Key.Equals(AzAsyncHeaderKey, StringComparison.OrdinalIgnoreCase))
                {
                    AzureAsyncOperationHeader = kv.Value?.FirstOrDefault<string>();
                }
            }

            UpdateHeaderKind();
        }

        private void UpdateHeaderKind()
        {
            bool validLoc = false, validAzAsync = false;

            if (IsValidUri(LocationHeader))
            {
                validLoc = true;
                HeaderKind = LroHeaderKind.Location;
            }


            if (IsValidUri(AzureAsyncOperationHeader))
            {
                validAzAsync = true;
                HeaderKind = LroHeaderKind.AzureAsync;
            }


            if (validLoc && validAzAsync)
                HeaderKind = LroHeaderKind.Location_AzureAsync;
        }

        private Uri GetValidUri(string uriString)
        {
            Uri validUri = null;
            try
            {
                validUri = new Uri(uriString);
            }
            catch { }

            return validUri;
        }

        private bool IsValidUri(string uriString)
        {
            if (GetValidUri(uriString) == null)
                return false;
            else
                return true;
        }

        public enum LroHeaderKind
        {
            Location,
            AzureAsync,
            Location_AzureAsync
        }
    }

}
