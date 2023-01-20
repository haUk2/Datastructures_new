
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Array
{
    public class array
    {
        public array()
        {
            int[] array = null;
        }

        SortStrategy sortstrategy;
        
        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            sortstrategy = sortStrategy;
        }

       
        public void Sort()
        {
            
        }

        public void SortDesc()
        {
            
        }
    }
}