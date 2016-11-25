using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrExample.Commands
{
    public class CauseExceptionCommandHandler : RequestHandler<CauseExceptionCommandRequest>
    {
        protected override void HandleCore(CauseExceptionCommandRequest message)
        {
            if (message.ToThrow)
                throw new Exception("We threw!");

        }
    }
}
