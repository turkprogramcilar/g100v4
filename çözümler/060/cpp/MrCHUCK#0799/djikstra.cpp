#include <iostream>
#include <set>
#include "fstream"
#include <map>
#include <vector>
#include <sstream>
#include <algorithm>
using namespace std;

struct Node
{
public:
    int value;
    bool is_used = false,is_reachable = false;
    int reach_distance = 2147483645;
    set<Node*> connection;
    explicit Node(int value) :value(value){};
};

void read_as_int(const string& path,map<pair<int,int>,Node*> &node_map)
{
    string number;
    ifstream file(path);
    int x = 0;
    while(getline(file, number))//Dosyadan satir aliyorum
    {
        int y = 0;
        stringstream s(number);
        while(getline(s,number,','))//Virgulden virgule numara aliyorum
        {
            node_map[{x,y}] = new Node(stoi(number));//Node olusturuyorum
            y++;
        }
        x++;
    }
    file.close();
}


void connect_node(map<pair<int,int>,Node*> &node_map,int x, int y, int acc_x)
{
    if(acc_x > x)
    {
        for(auto i = 0; i < y ; i++)
        {
            node_map[{x,i}]->connection.insert(node_map[{x,i + 1}]);
            node_map[{x,i + 1}]->connection.insert(node_map[{x,i}]);
            node_map[{acc_x ,i}]->connection.insert(node_map[{acc_x ,i + 1}]);
            node_map[{acc_x,i + 1}]->connection.insert(node_map[{acc_x,i}]);
            node_map[{acc_x ,i}]->connection.insert(node_map[{acc_x - 1,i}]);
            node_map[{acc_x - 1 ,i}]->connection.insert(node_map[{acc_x,i}]);
            node_map[{x ,i}]->connection.insert(node_map[{x + 1,i}]);
            node_map[{x + 1 ,i}]->connection.insert(node_map[{x,i}]);
        }

        node_map[{acc_x ,y}]->connection.insert(node_map[{acc_x - 1,y}]);
        node_map[{acc_x - 1 ,y}]->connection.insert(node_map[{acc_x,y}]);
        node_map[{x ,y}]->connection.insert(node_map[{x + 1,y}]);
        node_map[{x + 1 ,y}]->connection.insert(node_map[{x,y}]);
        return connect_node(node_map,++x,y,--acc_x);
    }

}


int main() {
    map<pair<int, int>, Node *> table;
    read_as_int("/home/mrchuck/Desktop/cpp/my_node_project/p083_matrix.txt", table);//Dosyayi okuyorum ve nodelari olusturuyorum
    connect_node(table, 0, 79, 79);// Nodelari bagliyorum
    auto *current_node = table[{0, 0}];//Ilk node
    current_node->reach_distance = current_node->value;//Ilk node oldugu icin ulastigimiz mesafe kendi degeri oluyor
    auto *finish = table[{79, 79}];//Ulasilmasi gereken node
    vector<Node *> un_used_sorted_list{current_node};//Kesfettigimiz ve kullanmadigimiz nodelari burada sirali sekilde tutuyoruz

    while (current_node != finish)//SOn node'a kadar donduruyoruz
    {
        current_node ->is_used = true;//Kullandigimizi belirtiyoruz
        un_used_sorted_list.pop_back();//Ve listeden siliyoruz
        for(auto &_node : current_node->connection)//O anki nodedn bagli oldugu nodlari kesfediyoruz
        {
            if(!_node->is_used)//Eger ki kullanilmamissa
            {
                int temp_distance = current_node->reach_distance + _node->value;//Ona daha kisa mesafeden ulasabiliyorsak guncelliyoruz
                if (_node->reach_distance > temp_distance )
                {
                    _node->reach_distance = temp_distance;
                    if(!_node->is_reachable)//Egerki kesfedilmemisse kesfedildigini belirtiyoruz, kullanilmamislar listesine atiyoruz
                    {
                        un_used_sorted_list.push_back(_node);
                        _node->is_reachable = true;
                    }
                }
            }
        }
        //Buyukten kucuge siraliyoruz
        sort(un_used_sorted_list.begin(),un_used_sorted_list.end(),[](Node* node1, Node* node2){return node1->reach_distance > node2 -> reach_distance;});
        //Sondakini seciyoruz
        current_node = un_used_sorted_list.back();



    }
    cout << finish->reach_distance << endl;
    return 0;
}
