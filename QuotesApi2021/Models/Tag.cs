using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuotesApi2021.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public TagType Type { get; set; }
        [JsonIgnore]
        public ICollection<Quote> Quotes { get; set; }
    }
}
