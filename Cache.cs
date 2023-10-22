using System;

class Node
{
    public int value;
    public Node? next;
    public Node? prev;

    public Node(int item, Node? prev=null, Node? next=null)
    {
        this.value = item; 
        this.prev = prev;
        this.next = next;
    }
}

class LRUCache : IQueue
{
    private int SIZE;
    private int MAX_SIZE;
    private Node? root;

    public LRUCache(int size = 5)
    {
        this.SIZE = 0;
        this.MAX_SIZE = size;
    }

    public int getSize()
    {
        return SIZE;
    }

    public int getCapacity()
    {
        return MAX_SIZE;
    }

    public bool isFull()
    {
        return SIZE == MAX_SIZE; 
    }

    public bool isEmpty()
    {
        return SIZE == 0;
    }

    public int Enqueue(int value)
    {
        if (root == null)
        {
            root = new Node(value);
            return value;
        }

        if (SIZE == MAX_SIZE)
            Dequeue();

        Node? newNode = new Node(item: value, next:root);
        root.prev = newNode;

        root = newNode;
        SIZE++;

        return root.value;
    }

    public int? Dequeue()
    {
        if (SIZE == 0) 
            return null;
        
        if (SIZE == 1)
        {
            SIZE--;
            return root!.value;
        }

        Node curr = root!;

        while (curr.next != null)
        {
            curr = curr.next;
        }
        curr.prev!.next = null;
        SIZE--;

        return curr.value;
    }

    public int? Seek(int value)
    {
        if (root == null)
            return null;

        Node curr = root;
        bool found = false;

        while (curr.next != null)
        {
            if (curr.value == value)
            {
                found = true;
                break;
            }
            curr = curr.next;
        }

        // Restructure the Queue to make the Most recently called element as root.
        if (found)
        {
            if (curr.prev == null)
                return curr.value;

            // Suppose we have x <-> y <-> z
            // And we what to move y to the top position
            if (curr.next != null)
                curr.next.prev = curr.prev; // x <- z

            curr.prev.next = curr.next; // x <-> z
            curr.next = root;           // y -> x <-> z
            root.prev = curr;           // y <-> x <-> z
            root = curr;
            return root.value;
        }

        return -1;
    }

    public void Print()
    {
        Node? curr = root;
        while (curr != null)
        {
            Console.Write($"{curr.value} -> "); 
            curr = curr.next;
        }
        Console.Write("\n");
    }
}
