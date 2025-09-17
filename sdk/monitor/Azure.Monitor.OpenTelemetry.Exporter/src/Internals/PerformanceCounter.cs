using OpenTelemetry.Metrics;
using System.Diagnostics.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class PerformanceCounter : IDisposable
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

        // state for cpu counter calculations
        private DateTimeOffset _cachedCollectedTime = DateTimeOffset.MinValue;
        private long _cachedCollectedValueTicks = 0;
        private double _currentCpuPercentage = 0;
        private readonly int _processorCount = Environment.ProcessorCount;

        // state for telemetry item related counts
        private readonly PerfCounterItemCounts _itemCounts;
        private long _lastExceptionRateCount = 0;
        private DateTimeOffset _lastExceptionRateTime = DateTimeOffset.UtcNow;
        private long _lastRequestRateCount = 0;
        private DateTimeOffset _lastRequestRateTime = DateTimeOffset.UtcNow;

        private bool _disposed;

        public PerformanceCounter(MeterProvider meterProvider, PerfCounterItemCounts itemCounts)
        {
            _meterProvider = meterProvider;
            _perfCounterMeter = new Meter(PerfCounterConstants.PerfCounterMeterName);
            _itemCounts = itemCounts;

            // Create observable gauges for perf counter
            _exceptionRateGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.ExceptionRateInstrumentName,
                () => GetExceptionRate(),
                description: "Exception rate gauge (ex/sec)");

            _requestRateGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.RequestRateInstrumentName,
                () => GetRequestRate(),
                description: "Request rate gauge (req/sec)");

            _processCpuGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.ProcessCpuInstrumentName,
                () => GetProcessCpu(),
                description: "Process CPU gauge (percent)");

            _processCpuNormalizedGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.ProcessCpuNormalizedInstrumentName,
                () => GetProcessCpuNormalized(),
                description: "Process CPU normalized gauge (percent)");

            _processPrivateBytesGauge = _perfCounterMeter.CreateObservableGauge(
                PerfCounterConstants.ProcessPrivateBytesInstrumentName,
                () => GetProcessPrivateBytes(),
                description: "Process private bytes gauge");
        }

        // Placeholder methods for gauge callbacks
        private double GetExceptionRate()
        {
            var currentTime = DateTimeOffset.UtcNow;
            var totalExceptions = _itemCounts.ReadExceptionCount();
            var intervalData = totalExceptions - _lastExceptionRateCount;
            var elapsedSeconds = (currentTime - _lastExceptionRateTime).TotalSeconds;

            double dataPerSec = 0.0;
            if (elapsedSeconds > 0)
            {
                dataPerSec = intervalData / elapsedSeconds;
            }

            _lastExceptionRateCount = totalExceptions;
            _lastExceptionRateTime = currentTime;

            return dataPerSec;
        }
        private double GetRequestRate()
        {
            var currentTime = DateTimeOffset.UtcNow;
            var totalRequests = _itemCounts.ReadRequestCount();
            var intervalRequests = totalRequests - _lastRequestRateCount;
            var elapsedSec = (currentTime - _lastRequestRateTime).TotalSeconds;

            double requestsPerSec = 0.0;
            if (elapsedSec > 0)
            {
                requestsPerSec = intervalRequests / elapsedSec;
            }

            _lastRequestRateCount = totalRequests;
            _lastRequestRateTime = currentTime;

            return requestsPerSec;
        }
        private double GetProcessCpu()
        {
            UpdateCpuValuesIfNeeded();
            return _currentCpuPercentage;
        }
        private double GetProcessCpuNormalized()
        {
            UpdateCpuValuesIfNeeded();
            return _currentCpuPercentage / _processorCount;
        }
        private double GetProcessPrivateBytes()
        {
            return _process.PrivateMemorySize64;
        }

        private void UpdateCpuValuesIfNeeded()
        {
            var now = DateTimeOffset.UtcNow;
            if ((now - _cachedCollectedTime).TotalSeconds > 59) // the default interval is set to a minute
            {
                _process.Refresh();
                if (TryCalculateProcessCpu(out var cpuValue))
                {
                    _currentCpuPercentage = cpuValue;
                }
            }
        }

        private bool TryCalculateProcessCpu(out double calculatedValue)
        {
            var previousCollectedValue = _cachedCollectedValueTicks;
            var previousCollectedTime = _cachedCollectedTime;

            var recentCollectedValue = _cachedCollectedValueTicks = _process.TotalProcessorTime.Ticks;
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

        public void Dispose()
        {
            if (_disposed) return;
            try
            {
                _perfCounterMeter?.Dispose(); // Do NOT dispose _meterProvider (shared elsewhere)
            }
            catch { }
            _disposed = true;
        }
    }
}
