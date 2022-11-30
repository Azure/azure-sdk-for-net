// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

[assembly:CodeGenSuppressType("DataBoxEdgeSkuName")]
namespace Azure.ResourceManager.DataBoxEdge.Models
{
    /// <summary> The Sku name. </summary>
    public readonly partial struct DataBoxEdgeSkuName : IEquatable<DataBoxEdgeSkuName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeSkuName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DataBoxEdgeSkuName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string GatewayValue = "Gateway";
        private const string EdgeValue = "Edge";
        private const string Tea1NodeValue = "TEA_1Node";
        private const string Tea1NodeUpsValue = "TEA_1Node_UPS";
        private const string Tea1NodeHeaterValue = "TEA_1Node_Heater";
        private const string Tea1NodeUpsHeaterValue = "TEA_1Node_UPS_Heater";
        private const string Tea4NodeHeaterValue = "TEA_4Node_Heater";
        private const string Tea4NodeUpsHeaterValue = "TEA_4Node_UPS_Heater";
        private const string TmaValue = "TMA";
        private const string TdcValue = "TDC";
        private const string TcaSmallValue = "TCA_Small";
        private const string GpuValue = "GPU";
        private const string TcaLargeValue = "TCA_Large";
        private const string EdgePBaseValue = "EdgeP_Base";
        private const string EdgePHighValue = "EdgeP_High";
        private const string EdgePRBaseValue = "EdgePR_Base";
        private const string EdgePRBaseUpsValue = "EdgePR_Base_UPS";
#pragma warning disable CA1707
        private const string EP2_64_1VpuWValue = "EP2_64_1VPU_W";
        private const string EP2_128_1T4Mx1WValue = "EP2_128_1T4_Mx1_W";
        private const string EP2_256_2T4WValue = "EP2_256_2T4_W";
        private const string EdgeMRMiniValue = "EdgeMR_Mini";
        private const string RcaSmallValue = "RCA_Small";
        private const string RcaLargeValue = "RCA_Large";
        private const string RdcValue = "RDC";
        private const string ManagementValue = "Management";
        private const string EP2_64_Mx1WValue = "EP2_64_Mx1_W";
        private const string EP2_128Gpu1Mx1WValue = "EP2_128_GPU1_Mx1_W";
        private const string EP2_256Gpu2Mx1Value = "EP2_256_GPU2_Mx1";
        private const string EdgeMRTcpValue = "EdgeMR_TCP";

        /// <summary> Gateway. </summary>
        public static DataBoxEdgeSkuName Gateway { get; } = new DataBoxEdgeSkuName(GatewayValue);
        /// <summary> Edge. </summary>
        public static DataBoxEdgeSkuName Edge { get; } = new DataBoxEdgeSkuName(EdgeValue);
        /// <summary> TEA_1Node. </summary>
        public static DataBoxEdgeSkuName Tea1Node { get; } = new DataBoxEdgeSkuName(Tea1NodeValue);
        /// <summary> TEA_1Node_UPS. </summary>
        public static DataBoxEdgeSkuName Tea1NodeUps { get; } = new DataBoxEdgeSkuName(Tea1NodeUpsValue);
        /// <summary> TEA_1Node_Heater. </summary>
        public static DataBoxEdgeSkuName Tea1NodeHeater { get; } = new DataBoxEdgeSkuName(Tea1NodeHeaterValue);
        /// <summary> TEA_1Node_UPS_Heater. </summary>
        public static DataBoxEdgeSkuName Tea1NodeUpsHeater { get; } = new DataBoxEdgeSkuName(Tea1NodeUpsHeaterValue);
        /// <summary> TEA_4Node_Heater. </summary>
        public static DataBoxEdgeSkuName Tea4NodeHeater { get; } = new DataBoxEdgeSkuName(Tea4NodeHeaterValue);
        /// <summary> TEA_4Node_UPS_Heater. </summary>
        public static DataBoxEdgeSkuName Tea4NodeUpsHeater { get; } = new DataBoxEdgeSkuName(Tea4NodeUpsHeaterValue);
        /// <summary> TMA. </summary>
        public static DataBoxEdgeSkuName Tma { get; } = new DataBoxEdgeSkuName(TmaValue);
        /// <summary> TDC. </summary>
        public static DataBoxEdgeSkuName Tdc { get; } = new DataBoxEdgeSkuName(TdcValue);
        /// <summary> TCA_Small. </summary>
        public static DataBoxEdgeSkuName TcaSmall { get; } = new DataBoxEdgeSkuName(TcaSmallValue);
        /// <summary> GPU. </summary>
        public static DataBoxEdgeSkuName Gpu { get; } = new DataBoxEdgeSkuName(GpuValue);
        /// <summary> TCA_Large. </summary>
        public static DataBoxEdgeSkuName TcaLarge { get; } = new DataBoxEdgeSkuName(TcaLargeValue);
        /// <summary> EdgeP_Base. </summary>
        public static DataBoxEdgeSkuName EdgePBase { get; } = new DataBoxEdgeSkuName(EdgePBaseValue);
        /// <summary> EdgeP_High. </summary>
        public static DataBoxEdgeSkuName EdgePHigh { get; } = new DataBoxEdgeSkuName(EdgePHighValue);
        /// <summary> EdgePR_Base. </summary>
        public static DataBoxEdgeSkuName EdgePRBase { get; } = new DataBoxEdgeSkuName(EdgePRBaseValue);
        /// <summary> EdgePR_Base_UPS. </summary>
        public static DataBoxEdgeSkuName EdgePRBaseUps { get; } = new DataBoxEdgeSkuName(EdgePRBaseUpsValue);
        /// <summary> EP2_64_1VPU_W. </summary>
        public static DataBoxEdgeSkuName EP2_64_1VpuW { get; } = new DataBoxEdgeSkuName(EP2_64_1VpuWValue);
        /// <summary> EP2_128_1T4_Mx1_W. </summary>
        public static DataBoxEdgeSkuName EP2_128_1T4Mx1W { get; } = new DataBoxEdgeSkuName(EP2_128_1T4Mx1WValue);
        /// <summary> EP2_256_2T4_W. </summary>
        public static DataBoxEdgeSkuName EP2_256_2T4W { get; } = new DataBoxEdgeSkuName(EP2_256_2T4WValue);
        /// <summary> EdgeMR_Mini. </summary>
        public static DataBoxEdgeSkuName EdgeMRMini { get; } = new DataBoxEdgeSkuName(EdgeMRMiniValue);
        /// <summary> RCA_Small. </summary>
        public static DataBoxEdgeSkuName RcaSmall { get; } = new DataBoxEdgeSkuName(RcaSmallValue);
        /// <summary> RCA_Large. </summary>
        public static DataBoxEdgeSkuName RcaLarge { get; } = new DataBoxEdgeSkuName(RcaLargeValue);
        /// <summary> RDC. </summary>
        public static DataBoxEdgeSkuName Rdc { get; } = new DataBoxEdgeSkuName(RdcValue);
        /// <summary> Management. </summary>
        public static DataBoxEdgeSkuName Management { get; } = new DataBoxEdgeSkuName(ManagementValue);
        /// <summary> EP2_64_Mx1_W. </summary>
        public static DataBoxEdgeSkuName EP2_64_Mx1W { get; } = new DataBoxEdgeSkuName(EP2_64_Mx1WValue);
        /// <summary> EP2_128_GPU1_Mx1_W. </summary>
        public static DataBoxEdgeSkuName EP2_128Gpu1Mx1W { get; } = new DataBoxEdgeSkuName(EP2_128Gpu1Mx1WValue);
        /// <summary> EP2_256_GPU2_Mx1. </summary>
        public static DataBoxEdgeSkuName EP2_256Gpu2Mx1 { get; } = new DataBoxEdgeSkuName(EP2_256Gpu2Mx1Value);
#pragma warning restore CA1707
        /// <summary> EdgeMR_TCP. </summary>
        public static DataBoxEdgeSkuName EdgeMRTcp { get; } = new DataBoxEdgeSkuName(EdgeMRTcpValue);
        /// <summary> Determines if two <see cref="DataBoxEdgeSkuName"/> values are the same. </summary>
        public static bool operator ==(DataBoxEdgeSkuName left, DataBoxEdgeSkuName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DataBoxEdgeSkuName"/> values are not the same. </summary>
        public static bool operator !=(DataBoxEdgeSkuName left, DataBoxEdgeSkuName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DataBoxEdgeSkuName"/>. </summary>
        public static implicit operator DataBoxEdgeSkuName(string value) => new DataBoxEdgeSkuName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DataBoxEdgeSkuName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DataBoxEdgeSkuName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
