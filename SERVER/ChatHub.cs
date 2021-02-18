using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using Microsoft.Owin;
//using Owin;

using Microsoft.AspNet.SignalR;

namespace SERVER
{
    // Jeder Dienst den der Server zur Verfügung stellen will
    // muss von der Klasse Hub abgeleitet sein!
    // Diese Klasse implementiert dann die Methoden die von den Clients
    // aus aufgerufen werden können um Nachrihcten zu Verteilen.
    public class ChatHub : Hub
    {
        // Funktion die von den Clients aus aufgerufen werden kann!
        // Parameter und Rückgabewert sind beliebig! Wie bei jeder
        // normalen Funktion auch!
        public void Broadcast(string text)
        {
            // Rufe für ALLE Clients die ReceiveMessage Funktion auf!
            // ReceiveMessage ist eine Funktion die im Client-Code
            // implementiert sein muss.
            // ReceiveMessage wird als dynamic behandelt, d. h. es wird
            // zur Laufzeit ausgewertet ob es diese Funktion überhaupt gibt!
            // Der Kompiler kann noch nicht wissen ob es diese Funktion gibt.
            // Clients ist ein Object das in der Hub-Klasse zur Verfügung gestellt wird.
            Clients.All.ReceiveMessage(text);

            // Weitere Möglichkeiten zum Versenden der Nachrichten sind:
            // Clients.All.ReceiveMessage --> Rufe Methode bei allen angeschlossenen Clients auf.
            // Clients.Caller.ReceiveMessage --> Rufe nur Methode von Client auf der den Server kontaktiert hat.
            // Clients.Others.ReceiveMessage --> Rufe die Methode bei allen Clients auf außer bei demjenigen der den Server kontaktiert hat.
        }
    }
}
