alfabe = "abcdefghijklmnopqrstuvwxyz"
text = input("Metninizi girin:")
result = ""
for i in text:
    #Kullanıcı saçma karakterler girebilir.
    try:
        sayi = alfabe.index(i)
        result+=alfabe[(sayi+13)%len(alfabe)]
    except:
        result+=str(i)
print(result)
