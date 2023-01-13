namespace MyStackTests
{
    public class MyStackTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Push_ThreeElements_StackOrderOK()
        {
            MyStack.MyStacks stack = new MyStack.MyStacks();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(stack.ToString(), "| 1 | 2 | 3 |");
        }

        [Test]
        public void PushAndPop_PushThreeTimesPoPonce_TwoElementsInStackLastOneRemoved()
        {
            MyStack.MyStacks stack = new MyStack.MyStacks();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(stack.ToString(), "| 1 | 2 | 3 |");
            stack.Pop();
            Assert.AreEqual(stack.ToString(), "| 1 | 2 |");
        }
    }
}