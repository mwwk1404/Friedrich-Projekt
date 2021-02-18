using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Client;

namespace CLIENT
{
    class CLIENT
    {
        static void DoIt(string text)
        {
            Console.WriteLine("Empfangen: {0}", text);
        }

        static void Main(string[] args)
        {
            // Die Klasse HubConnection ist dafür verantwortlich eine Verbindung zum Server
            // herzustellen.
            HubConnection hubConnection = new HubConnection("http://localhost:24529");

            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("ChatHub");
            // chatHubProxy.On("ReceiveMessage", (text) => Console.WriteLine("Empfangen: {0}", text) );

            // Template Parameter sind Methoden-Parameter Typen!
            Action<string> targetFunc = DoIt; // Action ist ein Delegate!
            chatHubProxy.On("ReceiveMessage", targetFunc);

            hubConnection.Start().Wait();

            // Erweiterung 1: Schleife!
            while (true)
            {
                string s = Console.ReadLine();
                chatHubProxy.Invoke("Broadcast", s).Wait();
            }
        }
    }
}
