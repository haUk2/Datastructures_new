using LinkedList;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SwitchNodes_input1234_expected1324()
        {
            var myList = new SingleLinkedList();
            myList.insert_AtTheEnd(1);
            myList.insert_AtTheEnd(2);
            myList.insert_AtTheEnd(3);
            myList.insert_AtTheEnd(4);

            Node node1 = myList.GetNode(2);
            Node node2 = myList.GetNode(3);

            myList.SwitchNodes(node1, node2);

            Assert.AreEqual(myList.ToString(), "| 1 | 3 | 2 | 4 |");
        }
    }
}