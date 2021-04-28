import time
a = 0
while True:
    a += 1
    if a % 3 == a % 5 == 0:
        print(a, "FizzBuzz")
    elif a % 5 == 0:
        print(a, "Buzz")
    elif a % 3 == 0:
        print(a, "Fizz")
    else:
        print(a)
    time.sleep(0.2)
