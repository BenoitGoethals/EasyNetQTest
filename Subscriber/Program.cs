using System;
using EasyNetQ;
using Messages;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=192.168.0.163;username=test;password=test"))
            {
                bus.Receive("queke", x => x.Add<TextMessage>(m => { Console.WriteLine(m.Text);
                 
                }));
                bus.Subscribe<TextMessage>("test", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        private static void Reiver(object obj)
        {
            throw new NotImplementedException();
        }

        static void HandleTextMessage(TextMessage textMessage)
        {
            Console.WriteLine("Got message: {0}", textMessage.Text);
        }
    }
}