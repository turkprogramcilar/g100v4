

all:
	make clean || true
	make build
	echo "\n\n"
	make run

build:
	g++ main.cpp -o main -lsfml-graphics -lsfml-window -lsfml-system

clean:
	rm *.o main

run:
	./main