using RadioFreeEroup.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioFreeEurop.Apllication.Service.DTO
{
    public class JsonItemDTO
    {
        [Required]
        public string Id { get; set; }

        public JsonItemEnum Position { get; set; }

        [Required]
        public string Data { get; set; }
    }
}

