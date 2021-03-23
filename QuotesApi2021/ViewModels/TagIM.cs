using QuotesApi2021.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi2021.ViewModels
{
    public class TagIM
    {
        [Required]
        public string Text { get; set; }
        public TagType Type { get; set; }
    }
}
