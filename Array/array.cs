
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
    public class Array_Sort
    {
        public Array_Sort()
        {
            int[] array = null;
        }



        SortStrategy sortstrategy;
        
        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            sortstrategy = sortStrategy;
        }

       
        public void Sort(int[] array, int start, int end)
        {
            sortstrategy.Sort(array, start, end);
        }

        public void SortDesc(int[] array, int start, int end)
        {
            sortstrategy.SortDesc(array, start, end);
        }
    }
}