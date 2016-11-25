using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrExample.Commands
{
    public class CauseExceptionCommandRequest : IRequest
    {
        public bool ToThrow { get; set; }

        public CauseExceptionCommandRequest(bool toThrow)
        {
            ToThrow = toThrow;
        }
    }
}
