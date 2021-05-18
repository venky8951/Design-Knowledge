namespace ConsoleApp2
{
    class TaskScheduler
    {
        IQueueDataStructure _queue;
        public TaskScheduler(IQueueDataStructure queue)
        {
            _queue = queue;
        }
        public void Schedule()
        {
            _queue.Dequeue();
        }
    }
}
