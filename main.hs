import Data.Time.Clock ( getCurrentTime )
import Data.Bits

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
five = three + l1 - r1
six :: Integer
six = five + l2
seven :: Integer
seven = one + m1
eight :: Integer
eight = six + r1
nine :: Integer
nine = four + m1
zero :: Integer
zero = eight - m2

on :: Char
on = '#'
off :: Char
off = ' '

emptyLayer :: String
emptyLayer = replicate 3 off
leftOn :: String
leftOn = on : replicate 2 off
rightOn :: String
rightOn = replicate 2 off ++ [on]
middleOn :: String
middleOn = [off, on, off]
sidesOn :: String
sidesOn = [on, off, on]
fullLayer :: String
fullLayer = replicate 3 on

renderMiddlelayer :: Integer -> String
renderMiddlelayer x
    | x .&. m2 == m2 = fullLayer
    | x .&. (l1 + r1) == l1 + r1 = sidesOn
    | x .&. (l2 + r2) == l2 + r2 = sidesOn
    | x .&. l1 == l1 = leftOn
    | x .&. r1 == r1 = rightOn
    | x .&. l2 == l2 = leftOn
    | x .&. r2 == r2 = rightOn
    | otherwise = emptyLayer

renderLayer :: Integer -> Integer -> Integer -> Integer -> String
renderLayer x l r m
    | x .&. m == m = fullLayer
    | x .&. (l + r) == l + r = sidesOn
    | x .&. l == l = leftOn
    | x .&. r == r = rightOn
    | otherwise = emptyLayer

renderLayerNoMiddle :: Integer -> Integer -> Integer -> String
renderLayerNoMiddle x l r = renderLayer x l r 0xFF

render1stLayer :: Integer -> String
render1stLayer x = renderLayer x l1 r1 m1
render2ndLayer :: Integer -> String
render2ndLayer x = renderLayerNoMiddle x l1 r1
render3rdLayer :: Integer -> String
render3rdLayer = renderMiddlelayer
render4thLayer :: Integer -> String
render4thLayer x = renderLayerNoMiddle x l2 r2
render5thLayer :: Integer -> String
render5thLayer x = renderLayer x l2 r2 m3

getCode :: Char -> Integer
getCode x = case x of
    '1' -> one
    '2' -> two
    '3' -> three
    '4' -> four
    '5' -> five
    '6' -> six
    '7' -> seven
    '8' -> eight
    '9' -> nine
    '0' -> zero
    _   -> 0x0

newLine :: Char 
newLine = '\n'

renderAscii :: String -> String 
renderAscii text = foldl go "" layers where
    layers = [render1stLayer, render2ndLayer, render3rdLayer, render4thLayer, render5thLayer]
    go b a = b ++ concatMap ((++" ") . a . getCode) text ++ [newLine]

main :: IO ()
main = putStrLn (renderAscii "0123456789") >> getCurrentTime >>= putStrLn . (\x -> x ++ [newLine] ++ renderAscii x) . show