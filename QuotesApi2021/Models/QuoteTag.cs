using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi2021.Models
{
    public class QuoteTag
    {
        public int QuoteId  { get; set; }
        public int TagId { get; set; }
        public Quote Quote { get; set; }
        public Tag Tag { get; set; }
    }
}
