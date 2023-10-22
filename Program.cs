class Program
{
    public static void Main(string[] args)
    {
        LRUCache cache = new LRUCache(5);

        Console.WriteLine($"[+] Created a Cache with capacity for {cache.getCapacity()} items");
        Console.WriteLine("Adding a bunch of elements into Cache to fill it up");

        int e = 10;

        for (int i = 0; i < cache.getCapacity(); i++, e += 10)
            cache.Enqueue(e);

        cache.Print();

        Console.WriteLine("\nAdding more elements to overflow the Cache so it can discard items");
        e = 100;
        while (e <= 400)
        {
            cache.Enqueue(e);
            e += 100;
        }
        cache.Print();

        Console.WriteLine("\nFetching some elements to reorder the cache");
        cache.Seek(400);
        cache.Seek(200);
        cache.Seek(100);
        cache.Print();
    }
}
