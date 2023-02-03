using Array;

namespace MyArray_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Quicksort_Test()
        {
            var mc = new Array_Sort();
            int[] array = { 5, 2, 19, 6, 0 };
            int start = 0;
            int end= array.Length;
            mc.Sort(array, start, end);
            
            Assert.That(array.ToString(),Is.EqualTo("0,2,5,6,19"));
        }
    }
}