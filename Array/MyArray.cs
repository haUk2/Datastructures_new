
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public interface MyArray
    {
        
        void SetSortStrategy(SortStrategy sortStrategy);
        void Sort(int[] array, int start, int end);
        void SortDesc(int[] array, int start, int end);


    }

    public abstract class SortStrategy
    {
        public abstract void Sort(int[] array, int start, int end);
        public abstract void SortDesc(int[] array, int start, int end);

    }

  
    public class QuickSort : SortStrategy
    {
        public override void Sort(int[] array, int start, int end)
        {
            var i = start;
            var j = end;
            var pivot = array[start];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (start < j)
                Sort(array, start, j);

            if (i < end)
                Sort(array, i, end);

            
        }

        public override void SortDesc(int[] arr, int start, int end)
        {
            throw new NotImplementedException();
        }
    }
}