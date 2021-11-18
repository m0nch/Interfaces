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
            List<IMessage> message = generate.GetMessages();


            for (int i = 0; i < message.Count; i++)
            {
                Notification notification = new Notification(message[i]);
                if (message[i] is Email)
                {
                    notification.Text = "Notification: You have a new e-mail";
                }
                else if (message[i] is Sms)
                {
                    notification.Text = "Notification: You have a new sms";
                }
                else if (message[i] is Mms)
                {
                    notification.Text = "Notification: You have a new mms";
                }
                notification.DoNotify();
            }

            Console.ReadKey();
        }
    }

    public interface IMessage
    {
        void SendMessage(string text);
    }

    public class Generate
    {
        //Random rnd = new Random();
        List<IMessage> _message = new List<IMessage>();

        public Generate(params IMessage[] message)
        {
            int maxCount = 20;
            for (int i = 0; i < message.Length; i++)
            {
                _message.Add(message[i]);
            }
            for (int i = message.Length; i < maxCount - message.Length; i+=3)
            {
                _message.Add(GenerateEmail());
                _message.Add(GenerateSms());
                _message.Add(GenerateMms());
            }
        }

        public IMessage GenerateEmail()
        {
            return new Email();
        }

        public IMessage GenerateSms()
        {
            return new Sms();
        }

        public IMessage GenerateMms()
        {
            return new Mms();
        }

        public List<IMessage> GetMessages()
        {
            return _message;
        }
    }
    public class Email : IMessage
    {
        public void SendMessage(string text)
        {
            Console.WriteLine(text);        
        }
    }

    public class Sms : IMessage
    {
        public void SendMessage(string text)
        {
            Console.WriteLine(text); ;
        }
    }

    public class Mms : IMessage
    {
        public void SendMessage(string text)
        {
            Console.WriteLine(text);        
        }
    }

    public class Notification
    {
        private IMessage _iMessage;
        public string Text { get; set; }
        public Notification(IMessage iMessage)
        {
            _iMessage = iMessage;
        }
        public void DoNotify()
        {
            _iMessage.SendMessage(Text);
        }
    }
}
