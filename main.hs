import Data.Time.Clock

r1 :: Integer
r1 = 0x2
r2 :: Integer
r2 = 0x4
m1 :: Integer
m1 = 0x40
m2 :: Integer
m2 = 0x80
m3 :: Integer
m3 = 0x8
l1 :: Integer
l1 = 0x20
l2 :: Integer
l2 = 0x10

one :: Integer
one = r1 + r2
two :: Integer
two = m1 + m2 + m3 + r1 + l2
three :: Integer 
three = one + m1 + m2 + m3
four :: Integer 
four = one + m2 + l1
five :: Integer 
five = eight - (l1 + r2)
six :: Integer 
six = five + l2
seven :: Integer 
seven = one + m1
eight :: Integer 
eight = six + l1
nine :: Integer 
nine = four + m1
zero :: Integer 
zero = eight - m2



main :: IO ()
main = strTime >>= print where
    strTime = show <$> getCurrentTime