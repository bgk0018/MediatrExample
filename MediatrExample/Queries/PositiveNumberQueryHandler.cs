using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrExample.Queries
{
    public class PositiveNumberQueryHandler : IRequestHandler<PositiveNumberQueryRequest, PositiveNumberQueryResult>
    {
        public PositiveNumberQueryResult Handle(PositiveNumberQueryRequest message)
        {
            var result = message.ReturnPositiveNumber ? 1 : -1;

            return new PositiveNumberQueryResult(result);
        }
    }
}
