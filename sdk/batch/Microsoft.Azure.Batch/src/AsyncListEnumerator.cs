using Microsoft.Rest.Azure;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
    internal abstract class AsyncListEnumerator<EnumerationType, ProtocolType, ProtocolHeaders> : PagedEnumeratorBase<EnumerationType> where ProtocolType : class
    {
        internal abstract Task<AzureOperationResponse<IPage<ProtocolType>, ProtocolHeaders>> GetTaskResult(SkipTokenHandler skipHandler, CancellationToken cancellationToken);

        internal abstract EnumerationType Wrap(ProtocolType protocolObj);

        protected readonly BehaviorManager behaviorMgr;
        protected readonly DetailLevel detailLevel;

        public AsyncListEnumerator(BehaviorManager behaviorMgr, DetailLevel detailLevel)
            : base()
        {
            this.behaviorMgr = behaviorMgr;
            this.detailLevel = detailLevel;
        }

        public override EnumerationType Current  // for IPagedEnumerator<T> and IEnumerator<T>
        {
            get
            {
                // start with the current object off of base
                object curObj = base._currentBatch[base._currentIndex];

                // it must be a protocol object from previous call
                ProtocolType protocolObj = curObj as ProtocolType;

                Debug.Assert(null != protocolObj);

                // wrap protocol object
                EnumerationType wrapped = Wrap(protocolObj);

                return wrapped;
            }
        }

        /// <summary>
        /// fetch another batch of objects from the server
        /// </summary>
        protected async override Task GetNextBatchFromServerAsync(SkipTokenHandler skipHandler, CancellationToken cancellationToken)
        {
            do
            {
                // start the protocol layer call
                var asyncTask = GetTaskResult(skipHandler, cancellationToken);

                var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                // remember any skiptoken returned.  This also sets the bool
                skipHandler.SkipToken = response.Body.NextPageLink;

                // remember the protocol tasks returned
                _currentBatch = null;

                if (null != response.Body.GetEnumerator())
                {
                    _currentBatch = response.Body.ToArray();
                }
            }
            // it is possible for there to be no results so we keep trying
            while (skipHandler.ThereIsMoreData && ((null == _currentBatch) || _currentBatch.Length <= 0));
        }
    }
}