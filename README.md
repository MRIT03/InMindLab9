# Hello Andrea ! 

I hope you are well! This is my submission for lab 9. I have used SignalR to create a simple messaging app with a UI. To enable the application, I ran the main server on port 5118. and I ran two smaller messaging servers. Servers A and B will run on their respective ports. By going on ServerA/index.html and serverB/index.html, each server will establish a connection with the main server on the endpoint /chathub. This will give server A and B their connection IDs and it will allow them to message each other. The main server serves as a central broker betweent the two and allows the communication.
