#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

int vertices, aristas, a, b, u, v;
vector<int> grafo[10005];
vector<int> nodos_criticos;
int cant_puntos_articulacion;
int cant_hijos_raiz;
int tiempo;
int d[10005];
int f[10005];
int low[10005];
int pi[10005];
bool marcados[10005];
bool puntos_articulacion[10005];

void inicializar()
{
    cant_hijos_raiz = 0;
    cant_puntos_articulacion = 0;
    tiempo = 0;

    for(int i = 0; i <= vertices; i++)
    {
        marcados[i] = false;
        pi[i] = 0;
    }

    pi[1] = INT_MIN;
}

void DFS(int elemento)
{
    marcados[elemento] = true;
    tiempo++;
    d[elemento] = tiempo;
    low[elemento] = d[elemento];

    for(int i = 0; i < grafo[elemento].size(); i++)
    {
        int temp = grafo[elemento][i];

        if(!marcados[temp])
        {
            pi[temp] = elemento;

            if(elemento == 1)
                cant_hijos_raiz++;

            DFS(temp);
            low[elemento] = min(low[elemento], low[temp]);

            if(pi[elemento] != INT_MIN && low[temp] >= d[elemento])
            {
                if(!puntos_articulacion[elemento])
                {
                    cant_puntos_articulacion++;
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
        if(!marcados[i])
        {
            cant_hijos_raiz = 0;
            DFS(i);
        }
    }
}

void dame_puntos_articulacion()
{
    inicializar();
    DFS();

    if(cant_hijos_raiz >= 2)
    {
        cant_puntos_articulacion++;
        puntos_articulacion[1] = true;
    }
}

void inicializar_bfs(int origen)
{
    for(int i = 1; i <= vertices; i++)
    {
        marcados[i] = false;
    }
    marcados[origen] = true;
}

void BFS(int origen, int v)
{
    inicializar_bfs(origen);
    queue<int> cola;
    cola.push(origen);

    while(!cola.empty())
    {
        int elemento = cola.front();
        cola.pop();

        for(int i = 0; i < grafo[elemento].size(); i++)
        {
            int temp = grafo[elemento][i];

            if(!marcados[temp] && temp != v)
            {
                marcados[temp] = true;
                cola.push(temp);
            }
        }
    }
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> vertices >> aristas >> a >> b;

    for(int i = 0; i < aristas; i++)
    {
        cin >> u >> v;

        grafo[u].push_back(v);
        grafo[v].push_back(u);
    }

    dame_puntos_articulacion();

    for(int i = 1; i <= vertices; i++)
    {
        if(puntos_articulacion[i] && i != a && i != b)
        {
            BFS(a, i);
            if(!marcados[b])
                nodos_criticos.push_back(i);
        }
    }

    if(nodos_criticos.size() != 0)
    {
        cout << nodos_criticos.size() << endl;
        for(int i = 0; i < nodos_criticos.size(); i++)
        {
            if(i == nodos_criticos.size() - 1)
                cout << nodos_criticos[i] << endl;
            else
                cout << nodos_criticos[i] << " ";
        }
    }
    else
        cout << "-1" << endl;
}
