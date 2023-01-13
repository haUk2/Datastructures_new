using Queue;

namespace QueueTest
{
    public class QueueTests
    {
        class QueueObserver : IObserver
        {
            public int callCount = 0;
            public void Update(ISubject subject)
            {
                callCount++;
            }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Enqueue_ThreeElements_QueueOrderOK()
        {
            Queues queue = new Queues();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Assert.AreEqual(queue.ToString(), "| 1 | 2 | 3 |");
        }

        [Test]
        public void EnqueueAndDequeue_EnqueueThreeTimesPoPonce_TwoElementsInStackLastOneRemoved()
        {
            Queues queue = new Queues();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            var last = queue.Dequeue();
            Assert.AreEqual(last.data, 1);
            Assert.AreEqual(queue.ToString(), "| 2 | 3 |");
        }

        [Test]
        public void Observer_EnqueDeque2Times_UpdteIsCalledTwice()
        {
            Queues queue = new Queues();
            QueueObserver queueObserver = new QueueObserver();
            queue.Attach(queueObserver);
            queue.Enqueue(1);
            queue.Dequeue();

            Assert.AreEqual(queueObserver.callCount, 2);
        }

        [Test]
        public void Observer_Observing2Queus_UpdteIsCalledForEachQueue()
        {
            Queues queue1 = new Queues();
            Queues queue2 = new Queues();
            QueueObserver queueObserver = new QueueObserver();
            queue1.Attach(queueObserver);
            queue2.Attach(queueObserver);
            queue1.Enqueue(1);
            queue1.Dequeue();
            Assert.AreEqual(queueObserver.callCount, 2);
            queue1.Enqueue(1);
            Assert.AreEqual(queueObserver.callCount, 3);
        }
    }
}