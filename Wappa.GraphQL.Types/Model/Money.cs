using System;
using System.Collections.Generic;
using System.Text;

namespace Wappa.GraphQL.Types.Model
{
    public class Money
    {
        public float Amount { get; set; }
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string Formatted { get; set; }
    }
}
