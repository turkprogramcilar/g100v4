import string
import random

length = int(input("How many digits should your password be:"))

symbols_q = input("Do you want symbols (y for yes):")
symbols = "!*+-{}"
characters = string.ascii_letters + string.digits

if symbols_q.lower() == "y":
    characters += symbols

password = ""

for i in range(length):
    password = password + random.choice(characters)

print("Password:", password)
