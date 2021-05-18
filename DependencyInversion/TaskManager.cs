namespace ConsoleApp2
{
    class TaskManager
    {
        public IQueueDataStructure _queueObj { get; set; }
        public void CustomEnqueue(int item)
        {
            _queueObj.Enqueue(item);
        }
    }
}
