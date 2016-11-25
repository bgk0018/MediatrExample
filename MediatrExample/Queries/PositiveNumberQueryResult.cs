using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatrExample.Queries
{
    public class PositiveNumberQueryResult
    {
        public int Number { get; private set; }

        public PositiveNumberQueryResult(int number)
        {
            this.Number = number;
        }
    }
}
