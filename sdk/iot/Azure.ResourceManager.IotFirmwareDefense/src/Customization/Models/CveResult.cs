// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> CVE analysis result resource. </summary>
    public partial class CveResult
    {
        ///// <summary> ID of the CVE result. </summary>
        //public string CveId { get; set; }
        /// <summary> The SBOM component for the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CveComponent Component {
            get
            {
                var r = new CveComponent();
                r.ComponentId = ComponentId;
                r.Name = ComponentName;
                r.Version = ComponentVersion;
                return r;
            }
            set
            {
                ComponentId = value.ComponentId;
                ComponentName = value.Name;
                ComponentVersion = value.Version;
            }
        }
        ///// <summary> Severity of the CVE. </summary>
        //public string Severity { get; set; }
        /// <summary> Name of the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NamePropertiesName
        {
            get => CveName;
            set => CveName = value;
        }
        /// <summary> A single CVSS score to represent the CVE. If a V3 score is specified, then it will use the V3 score. Otherwise if the V2 score is specified it will be the V2 score. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CvssScore
        {
            get
            {
                return EffectiveCvssScore.ToString();
            }
            set
            {
                EffectiveCvssScore = float.Parse(value);
            }
        }
        /// <summary> CVSS version of the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CvssVersion
        {
            get
            {
                return EffectiveCvssVersion.ToString();
            }
            set
            {
                EffectiveCvssVersion = int.Parse(value);
            }
        }
        private string GetCvssScore(int version)
        {
            for (var i = 0; i < CvssScores.Count; i++)
            {
                if (CvssScores[i].Version == version)
                {
                    return CvssScores[i].Score.ToString();
                }
            }
            return null;
        }
        private void SetCvssScore(int version, string newScore)
        {
            for (var i = 0; i < CvssScores.Count; i++)
            {
                if (CvssScores[i].Version == version)
                {
                    CvssScores[i].Score = float.Parse(newScore);
                    return;
                }
            }
            var newCvssScore = new CvssScore(version);
            newCvssScore.Score =  float.Parse(newScore);
            CvssScores.Add(newCvssScore);
        }
        /// <summary> CVSS V2 score of the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CvssV2Score
        {
            get
            {
                return GetCvssScore(2);
            }
            set
            {
                SetCvssScore(2, value);
            }
        }
        /// <summary> CVSS V3 score of the CVE. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CvssV3Score
        {
            get
            {
                return GetCvssScore(3);
            }
            set
            {
                SetCvssScore(3, value);
            }
        }
    }
}
