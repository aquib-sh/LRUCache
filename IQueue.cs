using System;

public interface IQueue
{
    public int Enqueue(int value);
    public int? Dequeue();
    public bool isFull();
    public bool isEmpty();
}
