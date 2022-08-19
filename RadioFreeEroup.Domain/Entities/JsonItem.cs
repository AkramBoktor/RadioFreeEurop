using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RadioFreeEroup.Domain.Entities
{
    public class JsonItem
    {
        [Key]
        public int ItemIDKey { get; set; }
        public string Id { get; set; }

        public string Position { get; set; }

        public string Data { get; set; }

        

    }
}
