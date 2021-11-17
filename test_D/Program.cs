using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_D
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate generate = new Generate(new Email(), new Sms(), new Mms());  
            generate.GetMessages();
            List<IMessenger> message = generate.GetMessages();

            Email email = new Email();
            Sms sms = new Sms();
            Mms mms = new Mms();
            message.Add(email);
            message.Add(sms);
            message.Add(mms);

            for (int i = 0; i < message.Count; i++)
            {
                Notification notification = new Notification(message[i]);
                notification.DoNotify();
            }

            Console.ReadKey();
        }
    }

    public interface IMessenger
    {
        void SendMessage();
    }

    public class Generate
    {
        Random rnd = new Random();
        //int count = rnd.Next(1, 100);
        List<IMessenger> message = new List<IMessenger>();
        public Generate(params IMessenger[] messenger)
        {            
            for (int i = 0; i < messenger.Length; i++)
            {
                message.Add(messenger[i]);
            }
            while (message.Count < 6)
            {
                message.Add(GenerateMessage());
            }
        }

        public IMessenger GenerateMessage()
        {
            int r = rnd.Next(1, 5);

            switch (r)
            {
                case 1: return new Email();
                case 2: return new Sms();
                case 3: return new Mms();
            }
            return new Sms();
        }

        public IMessenger GetMessages()
        {
            return message;
        }
    }
    public class Email : IMessenger
    {
        public void SendMessage()
        {
            Console.WriteLine("Send e-mail");        
        }
    }

    public class Sms : IMessenger
    {
        public void SendMessage()
        {
            Console.WriteLine("Send sms"); ;
        }
    }

    public class Mms : IMessenger
    {
        public void SendMessage()
        {
            Console.WriteLine("Send mms");        
        }
    }

    public class Notification
    {
        private IMessenger _iMessenger;
        public Notification(IMessenger iMessenger)
        {
            _iMessenger = iMessenger;
        }
        public void DoNotify()
        {
            _iMessenger.SendMessage();
        }
    }
}
