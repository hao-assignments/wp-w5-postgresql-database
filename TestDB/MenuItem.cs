using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float SellPrice { get; set; }
        public float CapitalPrice { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
