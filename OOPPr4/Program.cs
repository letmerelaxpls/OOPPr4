using System;
using System.Collections.Generic;
using System.Threading;



//Task 1 start
//class CustomEventBus
//{
//    private Dictionary<Type, List<Delegate>> eventHandlers = new Dictionary<Type, List<Delegate>>();

//    private Dictionary<Type, DateTime> lastEventTimes = new Dictionary<Type, DateTime>();

//    private int throttleInterval;

//    public CustomEventBus(int throttleInterval)
//    {
//        this.throttleInterval = throttleInterval;
//    }

//    public void RegisterHandler<TEvent>(Action<TEvent> handler)
//    {
//        Type eventType = typeof(TEvent);

//        if (!eventHandlers.ContainsKey(eventType))
//        {
//            eventHandlers[eventType] = new List<Delegate>();
//            lastEventTimes[eventType] = DateTime.MinValue;
//        }

//        eventHandlers[eventType].Add(handler);
//    }

//    public void UnregisterHandler<TEvent>(Action<TEvent> handler)
//    {
//        Type eventType = typeof(TEvent);

//        if (eventHandlers.ContainsKey(eventType))
//        {
//            eventHandlers[eventType].Remove(handler);
//        }
//    }

//    public void Dispatch<TEvent>(TEvent ev)
//    {
//        Type eventType = typeof(TEvent);

//        DateTime lastEventTime = lastEventTimes[eventType];
//        DateTime currentTime = DateTime.Now;
//        TimeSpan elapsedTime = currentTime - lastEventTime;
//        if (elapsedTime.TotalMilliseconds < throttleInterval)
//        {
//            return;
//        }
//        lastEventTimes[eventType] = currentTime;

//        if (eventHandlers.ContainsKey(eventType))
//        {
//            foreach (Delegate handler in eventHandlers[eventType])
//            {
//                if (handler is Action<TEvent> typedHandler)
//                {
//                    typedHandler(ev);
//                }
//            }
//        }
//    }
//}
//Task 1 end



//Task 2 start
//public class Publisher<T>
//{
//    private Dictionary<int, List<Action<T>>> subscribersByPriority = new Dictionary<int, List<Action<T>>>();

//    public void Publish(T message, int priority)
//    {
//        if (subscribersByPriority.TryGetValue(priority, out List<Action<T>> subscribers))
//        {
//            foreach (var subscriber in subscribers)
//            {
//                subscriber(message);
//            }
//        }
//    }

//    public void Subscribe(Action<T> subscriber, int priority)
//    {
//        if (!subscribersByPriority.TryGetValue(priority, out List<Action<T>> subscribers))
//        {
//            subscribers = new List<Action<T>>();
//            subscribersByPriority.Add(priority, subscribers);
//        }

//        subscribers.Add(subscriber);
//    }

//    public void Unsubscribe(Action<T> subscriber, int priority)
//    {
//        if (subscribersByPriority.TryGetValue(priority, out List<Action<T>> subscribers))
//        {
//            subscribers.Remove(subscriber);

//            if (subscribers.Count == 0)
//            {
//                subscribersByPriority.Remove(priority);
//            }
//        }
//    }
//}
//Task 2 end




//Task 3 start
//public class Publisher<T>
//{
//    private Dictionary<int, List<Action<T>>> subscribersByPriority = new Dictionary<int, List<Action<T>>>();

//    public void PublishWithRetry(T message, int priority, Func<int> retryPolicy, int initialDelayMilliseconds, int maxDelayMilliseconds)
//    {
//        if (subscribersByPriority.TryGetValue(priority, out List<Action<T>> subscribers))
//        {
//            foreach (var subscriber in subscribers)
//            {
//                int retriesLeft = retryPolicy();
//                int delayMilliseconds = initialDelayMilliseconds;

//                while (retriesLeft > 0)
//                {
//                    try
//                        {
//                        subscriber(message);
//                        break;
//                        }
//                        catch (Exception ex)
//                        {
//                        retriesLeft--;

//                        if (retriesLeft == 0)
//                        {
//                            throw ex;
//                        }

//                        delayMilliseconds = Math.Min(delayMilliseconds * 2, maxDelayMilliseconds);
//                        int randomizedDelayMilliseconds = (int)(delayMilliseconds * (new Random().NextDouble() + 0.5));
//                        System.Threading.Thread.Sleep(randomizedDelayMilliseconds);
//                    }
//                }
//            }
//        }
//    }

//    public void Subscribe(Action<T> subscriber, int priority)
//    {
//        if (!subscribersByPriority.TryGetValue(priority, out List<Action<T>> subscribers))
//        {
//            subscribers = new List<Action<T>>();
//            subscribersByPriority.Add(priority, subscribers);
//        }

//        subscribers.Add(subscriber);
//    }

//    public void Unsubscribe(Action<T> subscriber, int priority)
//    {
//        if (subscribersByPriority.TryGetValue(priority, out List<Action<T>> subscribers))
//        {
//            subscribers.Remove(subscriber);

//            if (subscribers.Count == 0)
//            {
//                subscribersByPriority.Remove(priority);
//            }
//        }
//    }
//}
//Task 3 end



//Task 4 start
//class Workflow
//{
//    private readonly List<Func<WorkflowAction>> _actions = new List<Func<WorkflowAction>>();

//    public event EventHandler WorkflowCompleted;

//    public void AddAction(Func<WorkflowAction> createAction)
//    {
//        _actions.Add(createAction);
//    }

//    public void Start()
//    {
        
//        var actions = new List<WorkflowAction>();
//        foreach (var createAction in _actions)
//        {
//            var action = createAction();
//            action.ActionCompleted += OnActionCompleted;
//            actions.Add(action);
//        }

        
//        actions[0].Start();
//    }

//    private void OnActionCompleted(object sender, EventArgs e)
//    {
//        var completedAction = (WorkflowAction)sender;

        
//        var index = _actions.FindIndex(a => a().GetType() == completedAction.GetType()) + 1;

        
//        if (index < _actions.Count)
//        {
//            var nextAction = _actions[index]();
//            nextAction.ActionCompleted += OnActionCompleted;
//            nextAction.Start();
//        }
//        else
//        {
           
//            WorkflowCompleted?.Invoke(this, EventArgs.Empty);
//        }
//    }
//}
//abstract class WorkflowAction
//{
//    public event EventHandler ActionCompleted;

//    public abstract void Start();

//    protected void OnActionCompleted()
//    {
//        ActionCompleted?.Invoke(this, EventArgs.Empty);
//    }
//}

//class FirstAction : WorkflowAction
//{
//    public override void Start()
//    {
//        Console.WriteLine("Starting first action...");
        
//        Console.WriteLine("First action completed.");
//        OnActionCompleted();
//    }
//}

//class SecondAction : WorkflowAction
//{
//    public override void Start()
//    {
//        Console.WriteLine("Starting second action...");
        
//        Console.WriteLine("Second action completed.");
//        OnActionCompleted();
//    }
//}
//Start 4 end
class Program
{
    static void Main(string[] args)
    {
        //Task 1
        //CustomEventBus eventBus = new CustomEventBus(1000);

        //eventBus.RegisterHandler<string>(s => Console.WriteLine("Received string event: " + s));
        //eventBus.RegisterHandler<int>(i => Console.WriteLine("Received int event: " + i));

        //eventBus.Dispatch("hello");
        //eventBus.Dispatch(42);
        //eventBus.Dispatch("world");
        //eventBus.Dispatch(123);

        //Thread.Sleep(3000);

        //eventBus.Dispatch("bye");
        //eventBus.Dispatch(99);

        //eventBus.UnregisterHandler<int>(i => Console.WriteLine("Received int event: " + i));
        //Task 1



        //Task 2
        //    Publisher<string> publisher = new Publisher<string>();

        //    publisher.Subscribe((message) => Console.WriteLine("Low priority subscriber received message: " + message), 1);
        //    publisher.Subscribe((message) => Console.WriteLine("High priority subscriber received message: " + message), 10);
        //    publisher.Subscribe((message) => Console.WriteLine("Medium priority subscriber received message: " + message), 5);

        //    publisher.Publish("test message 1", 1);
        //    publisher.Publish("test message 2", 5);
        //    publisher.Publish("test message 3", 10);
        //    publisher.Publish("test message 4", 5);
        //    publisher.Publish("test message 5", 1);

        //    publisher.Unsubscribe((message) => Console.WriteLine("High priority subscriber received message: " + message), 10);
        //    publisher.Publish("test message 6", 10);
        //Task 2



        //Task 3
        //Publisher<string> publisher = new Publisher<string>();

        //publisher.Subscribe((message) => {
        //    Console.WriteLine("Low priority subscriber received message: " + message);
        //    throw new Exception("Simulated error");
        //}, 1);

        //publisher.Subscribe((message) => Console.WriteLine("High priority subscriber received message: " + message), 10);

        //publisher.PublishWithRetry("test message 1", 1, () => 3, 1000, 10000);
        //publisher.PublishWithRetry("test message 2", 5, () => 5, 1000, 10000);
        //publisher.PublishWithRetry("test message 3", 10, () => 2, 1000, 10000);
        //Task 3



        //Task 4
        var workflow = new Workflow();

        
        workflow.AddAction(() => new FirstAction());
        workflow.AddAction(() => new SecondAction());

       
        workflow.Start();
        //Task 4
        


    }



}








