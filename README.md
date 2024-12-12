# Socket
This project demonstrates a basic client-server communication using TCP sockets in C#. It consists of two parts:

Client-side: A Windows Forms application that connects to the server, sends messages, and listens for responses from the server. The client displays incoming messages in a rich text box and sends messages via a text input box.

Server-side: A TCP server (not provided in this code, but assumed to be running on the same machine on port 8888) that accepts incoming client connections, receives messages, and sends responses back to the clients.

Features:

Establishes a connection between client and server using TCP sockets.
The client can send messages to the server.
The server's responses are displayed on the client side in real-time.
Handles disconnections and IOExceptions gracefully.
Technologies Used:

C#
.NET Framework
TCP Sockets
Windows Forms
This project is useful for learning basic socket programming and understanding client-server communication in a real-time application.
