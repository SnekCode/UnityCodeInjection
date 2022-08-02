
import socket
import time

host, port = "127.0.0.1", 25001
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
    print("Starting TCP Server")
    sock.bind((host,port))
    print(f"Socket bound to {host}:{port}")
    while True:
        time.sleep(0.5)
        sock.listen()
        print("socket listening")
        conn, addr = sock.accept()
        with conn:
            print(f"Connected by {addr}")
            while True:
                data = conn.recv(1024).decode("UTF-8")
                if not data:
                    raise Exception("Null received, Connection closed")
                print(data)
