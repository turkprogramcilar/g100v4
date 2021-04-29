import string
import random

while True:
    try:
        length = input("How many digits should your password be:")
        if int(length)>0:
            length = int(length)
            break
        else:
            print("You should give a positive number.")
    except:
        print("You should give a positive number.")

symbols_q = input("Do you want symbols (y for yes):")
symbols = "!*+-{}"
characters = string.ascii_letters + string.digits

if symbols_q.lower() == "y":
    characters += symbols

password = ""

for i in range(length):
    password = password + random.choice(characters)

print("Password:", password)
