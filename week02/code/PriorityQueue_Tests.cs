using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue an item and then dequeue it
    // Expected Result: The same item that is added should be dequeued
    // Defect(s) Found: 
    public void TestPriorityQueue_EnDe_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First Item", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First Item", result, "The dequeued item should be 'First Item'.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items and dequeue the one with the highest priority.
    // Expected Result: The item with the highest priority should be dequeued.
    // Defect(s) Found: 
    public void TestPriorityQueue_EnDe_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First Item, Low Priority", 1);
        priorityQueue.Enqueue("Second Item, Second Priority", 2);
        priorityQueue.Enqueue("Third Item, Highest Priority", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Third Item, Highest Priority", result, "The dequeued item should be 'Third Item, Highest Priority' with the highest priority.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and ensure FIFO.
    // Expected Result: The first item added with the highest priority should be dequeued first.
    // Defect(s) Found:
    public void TestPriorityQueue_EnDe_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First Item", 3);
        priorityQueue.Enqueue("Second Item", 3);
        priorityQueue.Enqueue("Third Item", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First Item", result, "The dequeued item should be 'First Item' because it was added first with the highest priority.");

        result = priorityQueue.Dequeue();
        Assert.AreEqual("Second Item", result, "The dequeued item should be 'Second Item' after 'First Item'.");
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found:
    public void TestPriorityQueue_De_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "An exception should be thrown when dequeuing from an empty queue.");
    }

    [TestMethod]
    // Scenario: Enqueue items with decreasing priority and ensure correct item is dequeued.
    // Expected Result: The item with the highest priority should be dequeued.
    // Defect(s) Found:
    public void TestPriorityQueue_EnDe_DecreasingPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First Item", 5);
        priorityQueue.Enqueue("Second Item", 4);
        priorityQueue.Enqueue("Third Item", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First Item", result, "The dequeued item should be 'First Item' with the highest priority of 5.");
    }
}