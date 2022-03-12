#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

int vertices, aristas, u, v;
vector<int> grafo[105];
int tiempo = 0;
int cont = 1;
bool visitados[105];
int pi[105];
int componentes_conexas[105];
int d[105];
int f[105];
int hijos[105];
int resp = 0;

void actualizar_hijos(int elemento)
{
    int a = pi[elemento];
    hijos[a] -= (hijos[elemento] + 1);
}

void DFS_Visit(int elemento)
{
    visitados[elemento] = true;
    tiempo++;
    d[elemento] = tiempo;

    for(int i = 0; i < grafo[elemento].size(); i++)
    {
        int temp = grafo[elemento][i];

        if(!visitados[temp])
        {
            pi[temp] = elemento;
            DFS_Visit(temp);
        }
    }

    tiempo++;
    f[elemento] = tiempo;
    componentes_conexas[elemento] = cont;
    hijos[elemento] = (f[elemento] - d[elemento]) / 2;

    if(((hijos[elemento] + 1) % 2 == 0) && pi[elemento] != -1)
    {
        resp++;
        actualizar_hijos(elemento);
    }
}

void DFS()
{
    for(int i = 1; i <= vertices; i++)
    {
        if(!visitados[i])
        {
            pi[i] = -1;
            DFS_Visit(i);
            cont++;
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
        cin >> u >> v;

        grafo[u].push_back(v);
        grafo[v].push_back(u);
    }

    DFS();
    cout << resp << endl;
}
