// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    internal class BlobTransferSpeedCalculator
    {
        private readonly int _capacity;
        private readonly Queue<long> _bytesUploadQueue;
        private readonly Queue<long> _timeUploadQueue;

        public BlobTransferSpeedCalculator(int capacity)
        {
            _capacity = capacity;
            _bytesUploadQueue = new Queue<long>(_capacity);
            _timeUploadQueue = new Queue<long>(_capacity); 
        }

        public double UpdateCountersAndCalculateSpeed(long bytesSent)
        {
            lock (_timeUploadQueue)
            {
                double speed = 0;

                if (_timeUploadQueue.Count >= 80)
                {
                    _timeUploadQueue.Dequeue();
                    _bytesUploadQueue.Dequeue();
                }

                _timeUploadQueue.Enqueue(DateTime.Now.Ticks);
                _bytesUploadQueue.Enqueue(bytesSent);

                if (_timeUploadQueue.Count > 2)
                {
                    speed = (_bytesUploadQueue.Max() - _bytesUploadQueue.Min()) / TimeSpan.FromTicks(_timeUploadQueue.Max() - _timeUploadQueue.Min()).TotalSeconds;
                }

                return speed;
            }
        }

        
    }
}
