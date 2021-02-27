using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
   public class ColorDetailsDto:IDto
    {
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public decimal DailyPrice  { get; set; }
    }
}
