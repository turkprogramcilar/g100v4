import datetime
import time

zero = [
    "###",
    "# #",
    "# #",
    "# #",
    "###",
]
one = ["#",
    "#",
    "#",
    "#",
    "#"]
two = [
    "###",
    "  #",
    "###",
    "#  ",
    "###"]
three = [
    "###",
    "  #",
    "###",
    "  #",
    "###"]
four = [
    "# #",
    "# #",
    "###",
    "  #",
    "  #"]
five = [
    "###",
    "#  ",
    "###",
    "  #",
    "###"]
six = [
    "###",
    "#  ",
    "###",
    "# #",
    "###",
]
seven = [
    "###",
    "  #",
    " ##",
    "  #",
    "  #",

]
eight = [
    "###",
    "# #",
    "###",
    "# #",
    "###"
]
nine = [
    "###",
    "# #",
    "###",
    "  #",
    "  #",
]

convert = {
    0: zero,
    1: one,
    2: two,
    3: three,
    4: four,
    5: five,
    6: six,
    7: seven,
    8: eight,
    9: nine}
while True:
    now = datetime.datetime.now()
    saniye = now.second
    if (len(str(saniye)) == 1 and saniye < 10):
        saniye = "0"+str(saniye)
    zaman = str(now.hour) + str(now.minute) + str(saniye)
    print("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n")
    for i in range(5):
        print("\t\t\t", convert[int(zaman[0])][i], convert[int(zaman[1])][i], " ", convert[int(zaman[2])][i],
                  convert[int(zaman[3])][i], " ", convert[int(zaman[4])][i], convert[int(zaman[5])][i])
    time.sleep(1)