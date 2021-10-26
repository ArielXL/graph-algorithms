#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

typedef pair<long long, int> pli;

int vertices, aristas, u, v;
long long costo;
vector<pli> grafo[100005];
long long d[100005];
int pi[100005];
int cantidad_caminos_minimo[100005];
set<pli> avl;

void inicializar(int origen)
{
    for(int i = 0; i <= vertices; i++)
    {
        d[i] = INT_MAX;
        pi[i] = INT_MAX;
        cantidad_caminos_minimo[i] = INT_MAX;
    }

    d[origen] = 0;
    cantidad_caminos_minimo[origen] = 1;
    pi[origen] = -1;
}

bool Relax(int a, int b, long w)
{
    if(d[b] > d[a] + w)
    {
        d[b] = d[a] + w;
        pi[b] = a;
        cantidad_caminos_minimo[b] = cantidad_caminos_minimo[a];
        return true;
    }
    else if(d[b] == d[a] + w)
    {
        cantidad_caminos_minimo[b] += cantidad_caminos_minimo[a];
        return true;
    }
    else
        return false;
}

void Dijkstra(int origen)
{
    inicializar(origen);
    avl.insert(make_pair(0, origen));

    while(!avl.empty())
    {
        pli elemento = *avl.begin();
        avl.erase(avl.begin());

        for(int i = 0; i < grafo[elemento.second].size(); i++)
        {
            pli temp = grafo[elemento.second][i];

            if(Relax(elemento.second, temp.second, temp.first))
            {
                set<pli>:: iterator iterador = avl.find(make_pair(d[temp.second], temp.second));
                if(iterador != avl.end())
                    avl.erase(iterador);

                avl.insert(make_pair(d[temp.second], temp.second));
            }
        }
    }
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> vertices >> aristas;

    for(int i = 0; i < aristas; i++)
    {
        cin >> u >> v >> costo;

        grafo[u].push_back(make_pair(costo, v));
    }

    Dijkstra(1);

    // imprimiendo d
    for(int i = 1; i <= vertices; i++)
    {
        cout << d[i] << " ";
    }
    cout << endl;

    // imprimiendo cantidad_caminos_minomos
    for(int i = 1; i <= vertices; i++)
    {
        cout << cantidad_caminos_minimo[i] << " ";
    }
    cout << endl;

    // imprimiendo pi
    for(int i = 1; i <= vertices; i++)
    {
        cout << pi[i] << " ";
    }
    cout << endl;
}
