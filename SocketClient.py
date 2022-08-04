import socket
import time

HOST = "127.0.0.1"  # The server's hostname or IP address
# PORT = 25001  # The port used by the server
PORT = 1302

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.connect((HOST, PORT))
    try:
        while True:
            data = s.recv(1024).decode("UTF-8")
            print(data)
    except Exception as e:
        print("Connection closed")
        print(e)
        s.close()
        exit()
    finally:
        s.close()