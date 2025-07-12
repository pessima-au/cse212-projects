using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

namespace PriorityQueueTestsNamespace
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        // Scenario: Enqueue three items with different priorities, then dequeue all.
        // Expected Result: Items are dequeued in order of highest to lowest priority.
        // Defect(s) Found: 
        public void TestPriorityQueue_1()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("A", 1);
            priorityQueue.Enqueue("B", 3);
            priorityQueue.Enqueue("C", 2);

            Assert.AreEqual("B", priorityQueue.Dequeue());
            Assert.AreEqual("C", priorityQueue.Dequeue());
            Assert.AreEqual("A", priorityQueue.Dequeue());
        }

        [TestMethod]
        // Scenario: Enqueue multiple items with the same highest priority.
        // Expected Result: The first enqueued item with the highest priority is dequeued first (FIFO for ties).
        // Defect(s) Found:  
        public void TestPriorityQueue_2()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("A", 2);
            priorityQueue.Enqueue("B", 5);
            priorityQueue.Enqueue("C", 5);
            priorityQueue.Enqueue("D", 1);

            Assert.AreEqual("B", priorityQueue.Dequeue());
            Assert.AreEqual("C", priorityQueue.Dequeue());
            Assert.AreEqual("A", priorityQueue.Dequeue());
            Assert.AreEqual("D", priorityQueue.Dequeue());
        }

        // Add more test cases as needed below.
        // Scenario: Dequeue from an empty queue.
        // Expected Result: Exception is thrown.
        // Defect(s) Found: 
        [TestMethod]
        public static void TestPriorityQueue_EmptyThrows()
        {
            var priorityQueue = new PriorityQueue();
            Assert.ThrowsException<InvalidOperationException>(priorityQueue.Dequeue);
        }

        // Scenario: Enqueue items, dequeue one, enqueue another with higher priority, dequeue all.
        // Expected Result: New highest priority item is dequeued first, then remaining in order.
        // Defect(s) Found: 
        [TestMethod]
        public static void TestPriorityQueue_3()
        {
            var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("A", 1);
            priorityQueue.Enqueue("B", 2);
            Assert.AreEqual("B", priorityQueue.Dequeue());
            priorityQueue.Enqueue("C", 3);
            Assert.AreEqual("C", priorityQueue.Dequeue());
            Assert.AreEqual("A", priorityQueue.Dequeue());
        }

    }
}