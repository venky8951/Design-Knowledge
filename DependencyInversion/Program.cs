namespace ConsoleApp2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            TaskManager tObj = new TaskManager();
            TaskScheduler tsObj = new TaskScheduler(new PriorityQueue());
            tsObj.Schedule();
            tObj._queueObj = new CircularQueue();
            tObj.CustomEnqueue(10);
        }
    }
}
