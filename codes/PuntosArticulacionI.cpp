#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

int vertices, aristas, u, v;
vector<int> grafo[200005];
int cant_puntos;
int cant_puntos_raiz;
int tiempo;
bool visitados[200005];
int d[200005];
int f[200005];
int pi[200005];
int low[200005];
bool puntos_articulacion[200005];

void inicializar()
{
    cant_puntos = 0;
    cant_puntos_raiz = 0;
    tiempo = 0;
    pi[1] = INT_MIN;
}

void DFS_Visit(int elemento)
{
    visitados[elemento] = true;
    tiempo++;
    d[elemento] = tiempo;
    low[elemento] = d[elemento];

    for(int i = 0; i < grafo[elemento].size(); i++)
    {
        int temp = grafo[elemento][i];

        if(!visitados[temp])
        {
            pi[temp] = elemento;

            if(elemento == 1)
                cant_puntos_raiz++;

            DFS_Visit(temp);
            low[elemento] = min(low[elemento], low[temp]);

            if(pi[elemento] != INT_MIN && low[temp] >= d[elemento])
            {
                if(!puntos_articulacion[elemento])
                {
                    cant_puntos++;
                    puntos_articulacion[elemento] = true;
                }
            }
        }
        else if(pi[temp] != elemento)
            low[elemento] = min(low[elemento], d[temp]);
    }

    tiempo++;
    f[elemento] = tiempo;
}

void DFS()
{
    for(int i = 1; i <= vertices; i++)
    {
        if(!visitados[i])
        {
            cant_puntos_raiz = 0;
            DFS_Visit(i);
        }
    }
}

void dame_puntos_articulacion()
{
    inicializar();
    DFS();

    if(cant_puntos_raiz >= 2)
    {
        puntos_articulacion[1] = true;
        cant_puntos++;
    }
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> vertices >> aristas;

    for(int i = 0; i < aristas; i++)
    {
        cin >> u >> v;

        grafo[u].push_back(v);
        grafo[v].push_back(u);
    }

    dame_puntos_articulacion();
    cout << cant_puntos << endl;

    for(int i = 1; i <= vertices; i++)
    {
        if(puntos_articulacion[i])
            cout << i << " ";
    }
    cout << endl;
}
