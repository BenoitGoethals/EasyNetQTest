using System;
using EasyNetQ;
using Messages;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=192.168.0.163;username=test;password=test"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    bus.Send("queke",new TextMessage() { Text="dfsf"+i });
                    bus.PublishAsync(new TextMessage()
                    {
                        Text = "sdfsdfs" + i
                    }).ContinueWith(task =>
                    {
                        if(task.IsCompleted && !task.IsFaulted)
                        {
                            Console.WriteLine("task Compled");
                        }
                    });
                }
                   
                }
            Console.ReadLine();
            }
        }
    }
