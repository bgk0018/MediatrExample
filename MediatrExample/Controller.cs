using MediatR;
using MediatrExample.Commands;
using MediatrExample.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrExample
{
    public class Controller
    {
        private readonly IMediator mediator;

        public Controller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public PositiveNumberQueryResult Get(PositiveNumberQueryRequest request)
        {
            PositiveNumberQueryResult result = null;

            try
            {
                result = mediator.Send(request);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return result;
        }

        public void Post(CauseExceptionCommandRequest request)
        {
            //taking out try catch to demo throw

            mediator.Send(request);
        }
    }
}
