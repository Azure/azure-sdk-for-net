using OpenTelemetry.Metrics;
using System.Diagnostics.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class PerformanceCounter
    {
        private readonly MeterProvider _meterProvider;
        private readonly Meter _perfCounterMeter;

        // Gauge instruments
        private readonly ObservableGauge<double> _exceptionRateGauge;
        private readonly ObservableGauge<double> _requestRateGauge;
        private readonly ObservableGauge<double> _processCpuGauge;
        private readonly ObservableGauge<double> _processCpuNormalizedGauge;
        private readonly ObservableGauge<double> _processPrivateBytesGauge;
        private readonly Process _process = Process.GetCurrentProcess();

        // state for counter calculations
        private DateTimeOffset _cachedCollectedTime = DateTimeOffset.MinValue;
        private long _cachedCollectedValue = 0;
        private readonly int _processorCount = Environment.ProcessorCount;

        public PerformanceCounter(MeterProvider meterProvider)
        {
            _meterProvider = meterProvider;
            _perfCounterMeter = new Meter(PerfCounterConstants.PerfCounterMeterName);

            // Create observable gauges for each constant
            _exceptionRateGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.ExceptionRateGauge,
                () => GetExceptionRate(),
                description: "Exception rate gauge");

            _requestRateGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.RequestRateGauge,
                () => GetRequestRate(),
                description: "Request rate gauge");

            _processCpuGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.ProcessCpuGauge,
                () => GetProcessCpu(),
                description: "Process CPU gauge");

            _processCpuNormalizedGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.ProcessCpuNormalizedGauge,
                () => GetProcessCpuNormalized(),
                description: "Process CPU normalized gauge");

            _processPrivateBytesGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.ProcessPrivateBytesGauge,
                () => GetProcessPrivateBytes(),
                description: "Process private bytes gauge");
        }

        // Placeholder methods for gauge callbacks
        private double GetExceptionRate() => 0.0;
        private double GetRequestRate() => 0.0;
        private double GetProcessCpu()
        {
            _process.Refresh();
            if (TryCalculateProcessCpu(out var calculatedValue))
            {
                return calculatedValue;
            }

            return 0.0;
        }
        private double GetProcessCpuNormalized() => 0.0;
        private double GetProcessPrivateBytes()
        {
            return _process.PrivateMemorySize64;
        }

        private bool TryCalculateProcessCpu(out double calculatedValue)
        {
            var previousCollectedValue = _cachedCollectedValue;
            var previousCollectedTime = _cachedCollectedTime;

            var recentCollectedValue = _cachedCollectedValue = _process.TotalProcessorTime.Ticks;
            var recentCollectedTime = _cachedCollectedTime = DateTimeOffset.UtcNow;

            double calculatedValue;

            if (previousCollectedTime == DateTimeOffset.MinValue)
            {
                Debug.WriteLine($"{nameof(TryCalculateProcessCpu)} DateTimeOffset.MinValue");
                calculatedValue = default;
                return false;
            }

            var period = recentCollectedTime.Ticks - previousCollectedTime.Ticks;
            if (period < 0)
            {
                Debug.WriteLine($"{nameof(TryCalculateProcessCpu)} period less than zero");
                calculatedValue = default;
                return false;
            }

            var diff = recentCollectedValue - previousCollectedValue;
            if (diff < 0)
            {
                Debug.WriteLine($"{nameof(TryCalculateProcessCpu)} diff less than zero");
                calculatedValue = default;
                return false;
            }

            period = period != 0 ? period : 1;
            calculatedValue = diff * 100.0 / period;
            return true;
        }
    }
}
