// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Specialized;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Azure.Patch.PerfTests
{
    public class BitVectorVsBooleanFlag
    {
        public void Run()
        {
            BenchmarkRunner.Run<BitVectorVsBooleanFlagPerf>();
        }
    }

    [MemoryDiagnoser]
    public class BitVectorVsBooleanFlagPerf
    {
        [Benchmark]
        public void CallUseBooleanFlag()
        {
            var model = new UseBooleanFlag();
            model.Property1 = 2;
            model.Property2 = 3;
            model.Nested2 = new UseBooleanFlag();
            model.Nested2.Property12 = 4;
            model.Nested2.Property13 = 5;
            model.Nested2.Nested2 = new UseBooleanFlag();
            model.Nested2.Nested2.Property7 = 6;
            model.Nested2.Nested2.Nested3 = new UseBooleanFlag();
            model.Nested2.Nested2.Nested3.Property8 = 7;
            model.Nested2.Nested2.Nested3.Property5 = 8;

            model.Serialize();
        }

        [Benchmark]
        public void CallUseBitVector()
        {
            var model = new UseBitVector();
            model.Property1 = 2;
            model.Property2 = 3;
            model.Nested2 = new UseBitVector();
            model.Nested2.Property12 = 4;
            model.Nested2.Property13 = 5;
            model.Nested2.Nested2 = new UseBitVector();
            model.Nested2.Nested2.Property7 = 6;
            model.Nested2.Nested2.Nested3 = new UseBitVector();
            model.Nested2.Nested2.Nested3.Property8 = 7;
            model.Nested2.Nested2.Nested3.Property5 = 8;

            model.Serialize();
        }
    }

    public class UseBooleanFlag
    {
        private int _property1;
        private bool _property1Changed = false;
        public int Property1
        {
            get => _property1;
            set
            {
                _property1 = value;
                _property1Changed = true;
            }
        }

        private int _property2;
        private bool _property2Changed = false;
        public int Property2
        {
            get => _property2;
            set
            {
                _property2 = value;
                _property2Changed = true;
            }
        }

        private int _property3;
        private bool _property3Changed = false;
        public int Property3
        {
            get => _property3;
            set
            {
                _property3 = value;
                _property3Changed = true;
            }
        }

        private int _property4;
        private bool _property4Changed = false;
        public int Property4
        {
            get => _property4;
            set
            {
                _property4 = value;
                _property4Changed = true;
            }
        }

        private int _property5;
        private bool _property5Changed = false;
        public int Property5
        {
            get => _property5;
            set
            {
                _property5 = value;
                _property5Changed = true;
            }
        }

        private int _property6;
        private bool _property6Changed = false;
        public int Property6
        {
            get => _property6;
            set
            {
                _property6 = value;
                _property6Changed = true;
            }
        }

        private int _property7;
        private bool _property7Changed = false;
        public int Property7
        {
            get => _property7;
            set
            {
                _property7 = value;
                _property7Changed = true;
            }
        }

        private int _property8;
        private bool _property8Changed = false;
        public int Property8
        {
            get => _property8;
            set
            {
                _property8 = value;
                _property8Changed = true;
            }
        }

        private int _property9;
        private bool _property9Changed = false;
        public int Property9
        {
            get => _property9;
            set
            {
                _property9 = value;
                _property9Changed = true;
            }
        }

        private int _property10;
        private bool _property10Changed = false;
        public int Property10
        {
            get => _property10;
            set
            {
                _property10 = value;
                _property10Changed = true;
            }
        }

        private int _property11;
        private bool _property11Changed = false;
        public int Property11
        {
            get => _property11;
            set
            {
                _property11 = value;
                _property11Changed = true;
            }
        }

        private int _property12;
        private bool _property12Changed = false;
        public int Property12
        {
            get => _property12;
            set
            {
                _property12 = value;
                _property12Changed = true;
            }
        }

        private int _property13;
        private bool _property13Changed = false;
        public int Property13
        {
            get => _property13;
            set
            {
                _property13 = value;
                _property13Changed = true;
            }
        }

        private int _property14;
        private bool _property14Changed = false;
        public int Property14
        {
            get => _property14;
            set
            {
                _property14 = value;
                _property14Changed = true;
            }
        }

        private int _property15;
        private bool _property15Changed = false;
        public int Property15
        {
            get => _property15;
            set
            {
                _property15 = value;
                _property15Changed = true;
            }
        }

        private int _property16;
        private bool _property16Changed = false;
        public int Property16
        {
            get => _property16;
            set
            {
                _property16 = value;
                _property16Changed = true;
            }
        }

        private UseBooleanFlag _nested1;
        private bool _nested1Changed = false;
        public UseBooleanFlag Nested1
        {
            get => _nested1;
            set
            {
                _nested1 = value;
                _nested1Changed = true;
            }
        }

        private UseBooleanFlag _nested2;
        private bool _nested2Changed = false;
        public UseBooleanFlag Nested2
        {
            get => _nested2;
            set
            {
                _nested2 = value;
                _nested2Changed = true;
            }
        }

        private UseBooleanFlag _nested3;
        private bool _nested3Changed = false;
        public UseBooleanFlag Nested3
        {
            get => _nested3;
            set
            {
                _nested3 = value;
                _nested3Changed = true;
            }
        }

        private UseBooleanFlag _nested4;
        private bool _nested4Changed = false;
        public UseBooleanFlag Nested4
        {
            get => _nested4;
            set
            {
                _nested4 = value;
                _nested4Changed = true;
            }
        }

        public void Serialize()
        {
            if (_property1Changed)
            {
                _ = _property1;
            }
            if (_property2Changed)
            {
                _ = _property2;
            }
            if (_property3Changed)
            {
                _ = _property3;
            }
            if (_property4Changed)
            {
                _ = _property4;
            }
            if (_property5Changed)
            {
                _ = _property5;
            }
            if (_property6Changed)
            {
                _ = _property6;
            }
            if (_property7Changed)
            {
                _ = _property7;
            }
            if (_property8Changed)
            {
                _ = _property8;
            }
            if (_property9Changed)
            {
                _ = _property9;
            }
            if (_property10Changed)
            {
                _ = _property10;
            }
            if (_property11Changed)
            {
                _ = _property11;
            }
            if (_property12Changed)
            {
                _ = _property12;
            }
            if (_property13Changed)
            {
                _ = _property13;
            }
            if (_property14Changed)
            {
                _ = _property14;
            }
            if (_property15Changed)
            {
                _ = _property15;
            }
            if (_property16Changed)
            {
                _ = _property16;
            }

            if (_nested1Changed)
            {
                _nested1.Serialize();
            }
            if (_nested2Changed)
            {
                _nested2.Serialize();
            }
            if (_nested3Changed)
            {
                _nested3.Serialize();
            }
            if (_nested4Changed)
            {
                _nested4.Serialize();
            }
        }
    }

    public class UseBitVector
    {
        private BitVector64 _changed;

        private int _property1;
        private const int _property1Count = 0;
        public int Property1
        {
            get => _property1;
            set
            {
                _property1 = value;
                _changed[_property1Count] = true;
            }
        }

        private int _property2;
        private const int _property2Count = 1;
        public int Property2
        {
            get => _property2;
            set
            {
                _property2 = value;
                _changed[_property2Count] = true;
            }
        }

        private int _property3;
        private const int _property3Count = 2;
        public int Property3
        {
            get => _property3;
            set
            {
                _property3 = value;
                _changed[_property3Count] = true;
            }
        }

        private int _property4;
        private const int _property4Count = 3;
        public int Property4
        {
            get => _property4;
            set
            {
                _property4 = value;
                _changed[_property4Count] = true;
            }
        }

        private int _property5;
        private const int _property5Count = 4;
        public int Property5
        {
            get => _property5;
            set
            {
                _property5 = value;
                _changed[_property5Count] = true;
            }
        }

        private int _property6;
        private const int _property6Count = 5;
        public int Property6
        {
            get => _property6;
            set
            {
                _property6 = value;
                _changed[_property6Count] = true;
            }
        }

        private int _property7;
        private const int _property7Count = 6;
        public int Property7
        {
            get => _property7;
            set
            {
                _property7 = value;
                _changed[_property7Count] = true;
            }
        }

        private int _property8;
        private const int _property8Count = 7;
        public int Property8
        {
            get => _property8;
            set
            {
                _property8 = value;
                _changed[_property8Count] = true;
            }
        }

        private int _property9;
        private const int _property9Count = 8;
        public int Property9
        {
            get => _property9;
            set
            {
                _property9 = value;
                _changed[_property9Count] = true;
            }
        }

        private int _property10;
        private const int _property10Count = 9;
        public int Property10
        {
            get => _property10;
            set
            {
                _property10 = value;
                _changed[_property10Count] = true;
            }
        }

        private int _property11;
        private const int _property11Count = 10;
        public int Property11
        {
            get => _property11;
            set
            {
                _property11 = value;
                _changed[_property11Count] = true;
            }
        }

        private int _property12;
        private const int _property12Count = 11;
        public int Property12
        {
            get => _property12;
            set
            {
                _property12 = value;
                _changed[_property12Count] = true;
            }
        }

        private int _property13;
        private const int _property13Count = 12;
        public int Property13
        {
            get => _property13;
            set
            {
                _property13 = value;
                _changed[_property13Count] = true;
            }
        }

        private int _property14;
        private const int _property14Count = 13;
        public int Property14
        {
            get => _property14;
            set
            {
                _property14 = value;
                _changed[_property14Count] = true;
            }
        }

        private int _property15;
        private const int _property15Count = 14;
        public int Property15
        {
            get => _property15;
            set
            {
                _property15 = value;
                _changed[_property15Count] = true;
            }
        }

        private int _property16;
        private const int _property16Count = 15;
        public int Property16
        {
            get => _property16;
            set
            {
                _property16 = value;
                _changed[_property16Count] = true;
            }
        }

        private UseBitVector _nested1;
        private const int _nested1Count = 16;
        public UseBitVector Nested1
        {
            get => _nested1;
            set
            {
                _nested1 = value;
                _changed[_nested1Count] = true;
            }
        }

        private UseBitVector _nested2;
        private const int _nested2Count = 17;
        public UseBitVector Nested2
        {
            get => _nested2;
            set
            {
                _nested2 = value;
                _changed[_nested2Count] = true;
            }
        }

        private UseBitVector _nested3;
        private const int _nested3Count = 18;
        public UseBitVector Nested3
        {
            get => _nested3;
            set
            {
                _nested3 = value;
                _changed[_nested3Count] = true;
            }
        }

        private UseBitVector _nested4;
        private const int _nested4Count = 19;
        public UseBitVector Nested4
        {
            get => _nested4;
            set
            {
                _nested4 = value;
                _changed[_nested4Count] = true;
            }
        }

        public void Serialize()
        {
            if (_changed[_property1Count])
            {
                _ = _property1;
            }
            if (_changed[_property2Count])
            {
                _ = _property2;
            }
            if (_changed[_property3Count])
            {
                _ = _property3;
            }
            if (_changed[_property4Count])
            {
                _ = _property4;
            }
            if (_changed[_property5Count])
            {
                _ = _property5;
            }
            if (_changed[_property6Count])
            {
                _ = _property6;
            }
            if (_changed[_property7Count])
            {
                _ = _property7;
            }
            if (_changed[_property8Count])
            {
                _ = _property8;
            }
            if (_changed[_property9Count])
            {
                _ = _property9;
            }
            if (_changed[_property10Count])
            {
                _ = _property10;
            }
            if (_changed[_property11Count])
            {
                _ = _property11;
            }
            if (_changed[_property12Count])
            {
                _ = _property12;
            }
            if (_changed[_property13Count])
            {
                _ = _property13;
            }
            if (_changed[_property14Count])
            {
                _ = _property14;
            }
            if (_changed[_property15Count])
            {
                _ = _property15;
            }
            if (_changed[_property16Count])
            {
                _ = _property16;
            }
            if (_changed[_nested1Count])
            {
                _nested1.Serialize();
            }
            if (_changed[_nested2Count])
            {
                _nested2.Serialize();
            }
            if (_changed[_nested3Count])
            {
                _nested3.Serialize();
            }
            if (_changed[_nested4Count])
            {
                _nested4.Serialize();
            }
        }
    }
}
