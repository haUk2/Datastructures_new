namespace MyStackTest
{
    public class MyStackTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Push_ThreeElements_StackOrderOK()
        {
            MyStack.MyStack stack = new MyStack.MyStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(stack.ToString(), "| 1 | 2 | 3 |");
        }

        [Test]
        public void PushAndPop_PushThreeTimesPoPonce_TwoElementsInStackLastOneRemoved()
        {
            MyStack.MyStack stack = new MyStack.MyStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var last = stack.Pop();
            Assert.AreEqual(last.data, 3);
            Assert.AreEqual(stack.ToString(), "| 1 | 2 |");
        }
    }
}