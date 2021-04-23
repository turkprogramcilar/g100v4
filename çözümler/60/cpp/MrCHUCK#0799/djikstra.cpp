#include <iostream>
#include <map>
#include <utility>
#include <vector>
#include "fstream"
using namespace std;

struct Node
{
public:
    bool is_used = false,is_first = false,is_last = false;
    map<Node*,int> connection;
};

pair<map<Node*,int>*,pair<Node*,int>>* Node_Maker_2D(vector<vector<int>> * map_2d_int,pair<int,int> start,pair<int,int> finish)
{
    // Fazla takma sadece Nodelari birlestiriyorum
    auto * table = new map<Node*,int>;
    static auto* node_map = new pair<map<Node*,int>*,pair<Node*,int>>;
    node_map->first = table;
    vector<Node*> temp;
    unsigned int height = (*map_2d_int).size(),width = (*map_2d_int)[0].size();
    for (auto x = 0; x < height; x++)
    {
        for (auto y = 0; y < width; y++)
        {
            Node *temp_node = new Node();
            temp.push_back(temp_node);
            (*node_map).first ->insert({temp_node,numeric_limits<int>::max()});
            if(start.first == x && start.second == y)
            {
                node_map->second.first = temp_node;
                node_map->second.second = (*map_2d_int)[start.first][start.second];
            }
            if(finish.first == x && finish.second == y)
            {
                temp_node->is_last = true;
            }
        }

    }
    int count = 0;
    for(auto &temp_pair : temp)
    {
        //Burasi baglama kurallarini koydugumuz yer
        int  x = count /width, y = count % width;
        bool is_can_up = x + 1 < height;
        bool is_can_down = x - 1 >= 0;
        bool is_can_right = y + 1 < width;
        bool is_can_left = y - 1 >= 0;
        if(is_can_up)
            temp_pair->connection[temp[count + width]] = (*map_2d_int)[x + 1][y];
        if(is_can_down)
            temp_pair->connection[temp[count - width]] = (*map_2d_int)[x - 1][y];
        if(is_can_right)
            temp_pair->connection[temp[count + 1]] = (*map_2d_int)[x][y + 1];
        if(is_can_left)
            temp_pair->connection[temp[count - 1]] = (*map_2d_int)[x][y - 1];
        count++;
    }
    return node_map;
};

vector<vector<int>> * read_as_int(const string& path)
{
    string sum;
    char text;
    ifstream file(path);
    static vector<vector<int>> temp_t;
    vector<int> temp;
    while (file.get(text))
    {
        if ((int)text > 47) // Gelen eger ki bir sayi ise
        {
            sum += text;// Onceden gelen string sayi ile birlestir
        }

        else
        {
            temp.push_back(stoi(sum));//Eger gelen sayi ise int olarak vectore at
            sum = "";// Yeni sayilar icin temizle

            if((int)text == 10)// Eger ki gelen \n ise vectoru ekle ve sonra bosalt
            {
                temp_t.push_back(temp);
                temp.clear();
            }
        }


    }
    file.close();// Dosya acik kalmasin
    return &temp_t;

}




int main()
{
    //map_2d.first = Tum nodelar ve hepsi sonsuz, map_2d.second = baslangic nodeu ve degeri
    pair<map<Node*,int>*,pair<Node*,int>>* map_2d = Node_Maker_2D(read_as_int("/home/mrchuck/Desktop/cpp/Djikstra/p083_matrix.txt"),{0,0},{79,79});
    map<Node*,int>* table = map_2d -> first;
    Node * current_node = map_2d->second.first; // Baslangic Node
    int current_value = map_2d->second.second; // Toplam deger
    (*table)[current_node] = 0;
    while (!current_node->is_last) // Son dugumde mi kontrol
    {
        current_node->is_used = true;
        Node * next; // En kucuk kullanilmamis baglanti temp
        int temp = numeric_limits<int>::max();
        for(auto x:current_node->connection)//o anki bulunan nodein bagli oldugu nodelara bakiyor
        {
            if(!x.first->is_used) // Baktigi node kullanilmamissa
            {
                if(current_value + x.second < (*table)[x.first])// Eger kullanilmamis ve sonsuz ise veya daha dusuk ulasilabiliyorsa
                {
                    (*table)[x.first] = current_value + x.second; // Onu sonsuzdan cikariyoruz cunku ona ulastik veya kuculttuk
                }
            }
        }
        for(auto x:(*table))//Tabloda en kucuk kullanilmamis ariyoruz
        {
            if(!x.first->is_used) // Baktigi node kullanilmamissa
            {
                if(temp > (*table)[x.first])
                {
                    temp = (*table)[x.first];
                    next = x.first;
                }
            }
        }
        current_value = temp;
        current_node = next;
    }


    cout << (*table)[current_node] << endl;
}
