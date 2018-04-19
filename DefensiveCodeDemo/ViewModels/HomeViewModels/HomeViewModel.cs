using DefensiveCodeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefensiveCodeDemo.ViewModels.HomeViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Payment> Payments { get; set; }
    }
}
