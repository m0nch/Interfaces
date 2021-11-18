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
            List<IMessenger> message = generate.GetMessages();


            for (int i = 0; i < message.Count; i++)
            {
                Notification notification = new Notification(message[i]);
                if ((IMessenger)message[i] is Email)
                {
                    notification.Text = "Notification: You have a new e-mail";
                }
                else if ((IMessenger)message[i] is Sms)
                {
                    notification.Text = "Notification: You have a new sms";
                }
                else if ((IMessenger)message[i] is Mms)
                {
                    notification.Text = "Notification: You have a new mms";
                }
                notification.DoNotify();
            }

            Console.ReadKey();
        }
    }

    public interface IMessenger
    {
        void SendMessage(string text);
    }

    public class Generate
    {
        //Random rnd = new Random();
        List<IMessenger> message = new List<IMessenger>();

        public Generate(params IMessenger[] messenger)
        {
            int maxCount = 20;
            for (int i = 0; i < messenger.Length; i++)
            {
                message.Add(messenger[i]);
            }
            for (int i = messenger.Length; i < maxCount - messenger.Length; i+=3)
            {
                message.Add(GenerateEmail());
                message.Add(GenerateSms());
                message.Add(GenerateMms());
            }
        }

        public IMessenger GenerateEmail()
        {
            return new Email();
        }

        public IMessenger GenerateSms()
        {
            return new Sms();
        }

        public IMessenger GenerateMms()
        {
            return new Mms();
        }

        public List<IMessenger> GetMessages()
        {
            return message;
        }
    }
    public class Email : IMessenger
    {
        public void SendMessage(string text)
        {
            Console.WriteLine(text);        
        }
    }

    public class Sms : IMessenger
    {
        public void SendMessage(string text)
        {
            Console.WriteLine(text); ;
        }
    }

    public class Mms : IMessenger
    {
        public void SendMessage(string text)
        {
            Console.WriteLine(text);        
        }
    }

    public class Notification
    {
        private IMessenger _iMessenger;
        public string Text { get; set; }
        public Notification(IMessenger iMessenger)
        {
            _iMessenger = iMessenger;
        }
        public void DoNotify()
        {
            _iMessenger.SendMessage(Text);
        }
    }
}
