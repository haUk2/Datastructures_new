using LinkedList;

namespace SortierAlgorithmenTests
{
    public class SortierAlgorithmenTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Insertsort_UnorderdNummbers_CorrectOrderOfNumbers()
        {
            var myList = new SingleLinkedList();
            myList.SetSortStrategy(new InsertionSort());
            myList.insert_AtTheEnd(1);
            myList.insert_AtTheEnd(6);
            myList.insert_AtTheEnd(2);
            myList.insert_AtTheEnd(4);
            myList.insert_AtTheEnd(3);
            myList.insert_AtTheEnd(5);

            Assert.That(myList.ToString, Is.EqualTo("| 1 | 6 | 2 | 4 | 3 | 5 |"));

            myList.Sort();

            Assert.That(myList.ToString, Is.EqualTo("| 1 | 2 | 3 | 4 | 5 | 6 |"));
        }

        [Test]

        public void Insertsort_SomeNummberDouble_CorrectOrderOfNumbersAndNoError()
        {
            var myList = new SingleLinkedList();
            myList.SetSortStrategy(new InsertionSort());
            myList.insert_AtTheEnd(1);
            myList.insert_AtTheEnd(6);
            myList.insert_AtTheEnd(2);
            myList.insert_AtTheEnd(4);
            myList.insert_AtTheEnd(3);
            myList.insert_AtTheEnd(4);
            myList.insert_AtTheEnd(5);

            myList.Sort();

            Assert.That(myList.ToString, Is.EqualTo("| 1 | 2 | 3 | 4 | 4 | 5 | 6 |"));
        }

        [Test]
        public void InsertsortReverse_UnorderdNummbers_CorrectOrderOfNumbers()
        {
            var myList = new SingleLinkedList();
            myList.SetSortStrategy(new ReverseInsertionSort());
            myList.insert_AtTheEnd(1);
            myList.insert_AtTheEnd(6);
            myList.insert_AtTheEnd(2);
            myList.insert_AtTheEnd(4);
            myList.insert_AtTheEnd(3);
            myList.insert_AtTheEnd(5);

            Assert.That(myList.ToString, Is.EqualTo("| 1 | 6 | 2 | 4 | 3 | 5 |"));

            myList.Sort();

            Assert.That(myList.ToString, Is.EqualTo("| 6 | 5 | 4 | 3 | 2 | 1 |"));
        }

        [Test]
        public void InsertsortReverse_SomeNummberDouble_CorrectOrderOfNumbersAndNoError()
        {
            var myList = new SingleLinkedList();
            myList.SetSortStrategy(new ReverseInsertionSort());
            myList.insert_AtTheEnd(1);
            myList.insert_AtTheEnd(6);
            myList.insert_AtTheEnd(2);
            myList.insert_AtTheEnd(6);
            myList.insert_AtTheEnd(3);
            myList.insert_AtTheEnd(4);
            myList.insert_AtTheEnd(5);

            Assert.That(myList.ToString, Is.EqualTo("| 1 | 6 | 2 | 6 | 3 | 4 | 5 |"));

            myList.Sort();

            Assert.That(myList.ToString, Is.EqualTo("| 6 | 6 | 5 | 4 | 3 | 2 | 1 |"));
        }
        [Test]
        public void BubbleSort_UnorderdNummbers_CorrectOrderOfNumbers()
        {
            var myList = new SingleLinkedList();
            myList.SetSortStrategy(new BubbleSort());
            myList.insert_AtTheEnd(1);
            myList.insert_AtTheEnd(6);
            myList.insert_AtTheEnd(2);
            myList.insert_AtTheEnd(4);
            myList.insert_AtTheEnd(3);
            myList.insert_AtTheEnd(5);

            Assert.That(myList.ToString, Is.EqualTo("| 1 | 6 | 2 | 4 | 3 | 5 |"));

            myList.Sort();

            Assert.That(myList.ToString, Is.EqualTo("| 1 | 2 | 3 | 4 | 5 | 6 |"));
        }

        [Test]
        public void RverseBubbleSort_UnorderdNummbers_CorrectOrderOfNumbers()
        {
            var myList = new SingleLinkedList();
            myList.SetSortStrategy(new BubbleSort());
            myList.insert_AtTheEnd(1);
            myList.insert_AtTheEnd(6);
            myList.insert_AtTheEnd(2);
            myList.insert_AtTheEnd(4);
            myList.insert_AtTheEnd(3);
            myList.insert_AtTheEnd(5);

            Assert.That(myList.ToString, Is.EqualTo("| 1 | 6 | 2 | 4 | 3 | 5 |"));

            myList.SortDesc();

            Assert.That(myList.ToString, Is.EqualTo("| 6 | 5 | 4 | 3 | 2 | 1 |"));
        }

        [Test]
        public void RverseBubbleSort_SomeNummberDouble_CorrectOrderOfNumbers()
        {
            var myList = new SingleLinkedList();
            myList.SetSortStrategy(new BubbleSort());
            myList.insert_AtTheEnd(1);
            myList.insert_AtTheEnd(6);
            myList.insert_AtTheEnd(3);
            myList.insert_AtTheEnd(4);
            myList.insert_AtTheEnd(3);
            myList.insert_AtTheEnd(5);

            Assert.That(myList.ToString, Is.EqualTo("| 1 | 6 | 3 | 4 | 3 | 5 |"));

            myList.SortDesc();

            Assert.That(myList.ToString, Is.EqualTo("| 6 | 5 | 4 | 3 | 3 | 1 |"));
        }
    }
}