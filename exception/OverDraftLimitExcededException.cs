using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_5.exception
{
    internal class OverDraftLimitExcededException:ApplicationException
    {
        public OverDraftLimitExcededException(string msg) : base(msg)
        {

        }
    }
}
