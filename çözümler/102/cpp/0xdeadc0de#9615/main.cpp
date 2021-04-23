#include <SFML/Window.hpp>

int main()
{
    sf::ContextSettings s;
    s.depthBits = 24;
    s.stencilBits = 8;
    s.antialiasingLevel = 2;
    s.majorVersion = 3;
    s.minorVersion = 2;
    s.attributeFlags = sf::ContextSettings::Core;

    sf::Window window(sf::VideoMode(800,600), "SFML hello window", sf::Style::Close, s);

    for (;;) {
        sf::Event e;
        while (window.pollEvent(e)) {
            if (e.type == sf::Event::Closed) {
                return 0;
            }
        }
    }
    return 0;
}
