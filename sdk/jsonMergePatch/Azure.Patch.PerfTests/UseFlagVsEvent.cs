// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Azure.Patch.PerfTests
{
    public class UseFlagVsEvent
    {
        public void Run()
        {
            BenchmarkRunner.Run<UseFlagVsEventPerf>();
        }
    }

    [MemoryDiagnoser]
    public class UseFlagVsEventPerf
    {
        [Benchmark]
        public void CallNestedWithEvent()
        {
            var model = new NestedWithEvent();
            model.InnerModel = new InnerModelWithEvent();
            model.InnerModel.Property1 = 2;
        }

        [Benchmark]
        public void CallNestedWithFlag()
        {
            var model = new NestedWithFlag();
            model.InnerModel = new InnerModelWithFlag();
            model.InnerModel.Property1 = 2;
        }
    }

    public class NestedWithEvent
    {
        private InnerModelWithEvent _innerModel;
        private bool _innerModelChanged = false;
        public InnerModelWithEvent InnerModel
        {
            get => _innerModel;
            set
            {
                if (_innerModel != null)
                {
                    _innerModel.PropertyChanged -= HandlePropertyChangeEvent;
                }

                _innerModelChanged = true;
                _innerModel = value;
                _innerModel.PropertyChanged += HandlePropertyChangeEvent;
            }
        }

        private void HandlePropertyChangeEvent(object sender, PropertyChangedEventArgs args)
        {
            Changed = true;
        }

        internal bool Changed { get; private set; } = false;
    }

    public class NestedWithFlag
    {
        private InnerModelWithFlag _innerModel;
        private bool _innerModelChanged = false;
        public InnerModelWithFlag InnerModel
        {
            get => _innerModel;
            set
            {
                _innerModelChanged = true;
                _innerModel = value;
                _changed = true;
            }
        }

        private bool _changed = false;
        internal bool Changed => _changed || _innerModel.Changed; //granularity: model
    }

    public class InnerModelWithEvent
    {
        internal event PropertyChangedEventHandler PropertyChanged; // Very likely it has to be public
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int? _property1;
        private bool _property1changed = false;
        public int? Property1
        {
            get => _property1;
            set
            {
                _property1 = value;
                _property1changed = true;
                Changed = true;
                NotifyPropertyChanged();
            }
        }

        private int? _property2;
        private bool _property2changed = false;
        public int? Property2
        {
            get => _property2;
            set
            {
                _property2 = value;
                _property2changed = true;
                Changed = true;
                NotifyPropertyChanged();
            }
        }

        internal bool Changed { get; private set; } = false;
    }

    public class InnerModelWithFlag
    {
        private int? _property1;
        private bool _property1changed = false;
        public int? Property1
        {
            get => _property1;
            set
            {
                _property1 = value;
                _property1changed = true;
                Changed = true;
            }
        }

        private int? _property2;
        private bool _property2changed = false;
        public int? Property2
        {
            get => _property2;
            set
            {
                _property2 = value;
                _property2changed = true;
                Changed = true;
            }
        }

        internal bool Changed { get; private set; } = false;
    }
}
