import Data.Time.Clock







main :: IO ()
main = strTime >>= print where
    strTime = show <$> getCurrentTime