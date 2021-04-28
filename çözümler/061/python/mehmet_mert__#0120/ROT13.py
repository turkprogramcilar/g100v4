alfabe = "abcdefghijklmnopqrstuvwxyz"
text = input("Metninizi girin:")
result = ""
for i in text:
    sayı = alfabe.index(i)
    try:
        result += alfabe[sayı+13]
    except:
        result += alfabe[sayı - 13]
print(result)
