#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

int vertices, aristas, a, b;
vector<int> grafo[10005];
bool marcados[10005];
char conjuntos[10005];

bool TieneAristas(int temp, char c)
{
    for(int i = 0; i < grafo[temp].size(); i++)
    {
        if(conjuntos[grafo[temp][i]] == c)
            return true;
    }
    return false;
}

bool BFS()
{
    queue<int> cola;
    cola.push(1);
    conjuntos[1] = 'a';

    while(!cola.empty())
    {
        int current = cola.front();
        cola.pop();

        for(int i = 0; i < grafo[current].size(); i++)
        {
            int temp = grafo[current][i];
            if(!marcados[temp])
            {
                marcados[temp] = true;
                if(conjuntos[current] == 'a')
                {
                    if(!TieneAristas(temp, 'b'))
                        conjuntos[temp] = 'b';
                    else
                        return false;
                }
                if(conjuntos[current] == 'b')
                {
                    if(!TieneAristas(temp, 'a'))
                        conjuntos[temp] = 'a';
                    else
                        return false;
                }
                cola.push(temp);
            }
        }
    }
    return true;
}

int main()
{
	ios_base :: sync_with_stdio(0);
	cin.tie(0);

    cin >> vertices >> aristas;

    for(int i = 0; i < aristas; i++)
    {
        cin >> a >> b;

        grafo[a].push_back(b);
        grafo[b].push_back(a);
    }

    if(BFS())
    {
        cout << "True" << endl;
        for(int i = 1; i <= vertices; i++)
        {
            if(conjuntos[i] == 'a')
                cout << "0 ";
            else
                cout << "1 ";
        }
        cout << endl;
    }
    else
        cout << "False" << endl;
}

