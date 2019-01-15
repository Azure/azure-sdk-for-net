using Azure.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Configuration
{
    public class ConfigurationWatcher
    {
        readonly ConfigurationClient _client;
        readonly List<string> _keysToWatch = new List<string>();
        readonly Dictionary<string, ConfigurationSetting> _lastPolled = new Dictionary<string, ConfigurationSetting>();
        Task _watching;
        CancellationTokenSource _cancel;
        object _sync = new object();

        // TODO (pri 2): should we be using passed in client? the retry policy and logging is pretty bad for watching
        public ConfigurationWatcher(ConfigurationClient client, params string[] keysToWatch)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            _keysToWatch.AddRange(keysToWatch);
            _client = client;
        }

        public TimeSpan Interval { get; set; } = TimeSpan.FromSeconds(1);
        public Task Task => _watching;

        public void Start(CancellationToken token = default)
        {
            lock (_sync) {
                if (_watching != null) throw new InvalidOperationException("watcher already started");
                _cancel = (token == default) ? new CancellationTokenSource() : CancellationTokenSource.CreateLinkedTokenSource(token);
                _watching = WatchChangesAsync(_cancel.Token);
            }
        }

        public async Task Stop()
        {
            Task watching;
            lock (_sync) {
                if (_watching == null) throw new InvalidOperationException("watcher has not been started");
                watching = _watching;
                _cancel.Cancel();
                _cancel = null;
                _watching = null;
            }
            Debug.Assert(watching != null);
            await watching.ConfigureAwait(false);
        }

        public event EventHandler<SettingChangedEventArgs> SettingChanged;
        public event EventHandler<Exception> Error;

        protected virtual bool HasChanged(ConfigurationSetting left, ConfigurationSetting right)
        {
            if (left == null && right != null) return true;
            if (right == null && left != null) return true;
            if (!string.Equals(left.Value, right.Value, StringComparison.Ordinal)) return true;
            if (!string.Equals(left.Label, right.Label, StringComparison.Ordinal)) return true;
            if (!string.Equals(left.ContentType, right.ContentType, StringComparison.Ordinal)) return true;
            if (!left.LastModified.Equals(right.LastModified)) return true;
            // TODO (pri 2): how do we compare the tags?
            return false;
        }

        private async Task WatchChangesAsync(CancellationToken cancellationToken)
        {
            // record current values
            await Snapshot(cancellationToken).ConfigureAwait(false);

            while (!cancellationToken.IsCancellationRequested) {
                try {
                    await PollAsync(cancellationToken).ConfigureAwait(false);
                    await Task.Delay(Interval, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception e) {
                    if (e is OperationCanceledException) return;
                    Error?.Invoke(this, e);
                }
            }
        }

        private async Task Snapshot(CancellationToken cancellationToken)
        {
            try {
                for (int i = 0; i < _keysToWatch.Count; i++) {

                    var response = await _client.GetAsync(_keysToWatch[i], null, cancellationToken).ConfigureAwait(false);
                    if (response.Status == 200) {
                        var setting = response.Result;
                        _lastPolled[setting.Key] = setting;
                    }
                    // TODO (pri 2): what should we do when the request fails?
                }
            }
            catch (Exception e) {
                if (e is OperationCanceledException) return;
                Error?.Invoke(this, e);
            }
        }

        private async Task PollAsync(CancellationToken cancellationToken)
        {
            var callback = SettingChanged;
            if (callback == null) return;

            var tasks = new Task<Response<ConfigurationSetting>>[_keysToWatch.Count];
            for (int i = 0; i < _keysToWatch.Count; i++) {
                tasks[i] = _client.GetAsync(_keysToWatch[i], null, cancellationToken);
            }
            await Task.WhenAll(tasks);

            foreach(var task in tasks) {
                var response = task.Result;
                if (response.Status == 200) {
                    ConfigurationSetting current = response.Result;
                    _lastPolled.TryGetValue(current.Key, out var previous);
                    if (HasChanged(current, previous)) {
                        if (current == null) _lastPolled.Remove(current.Key);
                        else _lastPolled[current.Key] = current;
                        var e = new SettingChangedEventArgs(previous, current);
                        callback(this, e); // TODO (pri 2): should this be synchronized to the UI thread?
                    }
                }
                // TODO (pri 2): should we return for some error status codes?
            }
        }

        public struct SettingChangedEventArgs
        {
            public SettingChangedEventArgs(ConfigurationSetting older, ConfigurationSetting newer)
            {
                Older = older;
                Newer = newer;
            }

            public ConfigurationSetting Older { get; }
            public ConfigurationSetting Newer { get; }
        }
    }
}
