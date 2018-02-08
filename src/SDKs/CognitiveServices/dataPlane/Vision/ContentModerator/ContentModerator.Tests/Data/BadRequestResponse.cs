using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentModeratorTests.Data
{

   // [Serializable]
    public class BadRequestResponse
    {
        public BadRequestResponse(){}
        public string Message { get; set; }
        public string TrackingId { get; set; }

        public  List<Error> Errors { get;set;}

    }

   // [Serializable]
    public class Error
    {
        public string Title { get; set; }
        public string Message { get; set; }

    }

}
