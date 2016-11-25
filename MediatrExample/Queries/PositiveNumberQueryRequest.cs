using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatrExample.Queries
{
    public class PositiveNumberQueryRequest : IRequest<PositiveNumberQueryResult>
    {
        public bool ReturnPositiveNumber { get; private set; }

        public PositiveNumberQueryRequest(bool returnPositiveNumber)
        {
            this.ReturnPositiveNumber = returnPositiveNumber;
        }
    }
}
