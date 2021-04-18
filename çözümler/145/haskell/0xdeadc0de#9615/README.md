Sisteminizde cabal yüklü olması gerekir. 
`cabal run` komutu ile çalıştırabilirsiniz.

`/usr/bin/ld.gold: error: cannot find -lgmp`
diye bir hata ile karşılaşırsanız önce vakvakda arama yapıp (duckduckgo.com) ilgili hata ile alakalı sonuçlara bakın. ben şu çözümü buldum:
`sudo apt-get install libgmp3-dev`

