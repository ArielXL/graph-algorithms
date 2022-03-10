#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

int vertices, aristas, a, b;
vector<int> grafo[10005];
int cantPuntos = 0;
int cantHijosRaiz = 0;
bool visitados[10005];
int pi[10005];
int tiempo = 0;
bool puntosArticulacion[10005];
int d[10005];
int low[10005];

void DFS_visit(int elemento)
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
                cantHijosRaiz++;

            DFS_visit(temp);
            low[elemento] = min(low[elemento], low[temp]);

            if(pi[elemento] != INT_MIN && low[temp] >= d[elemento])
            {
                if(!puntosArticulacion[elemento])
                    cantPuntos++;
                puntosArticulacion[elemento] = true;
            }
        }
        else if(pi[temp] != elemento)
            low[elemento] = min(low[elemento], d[temp]);
    }
}

void DFS()
{
    for(int i = 1; i <= vertices; i++)
    {
        if(!visitados[i])
        {
            cantHijosRaiz = 0;
            DFS_visit(i);
        }
    }
}

void dame_puntos_articulacion()
{
    pi[1] = INT_MIN;
    DFS();

    if(cantHijosRaiz >= 2)
    {
        cantPuntos++;
        puntosArticulacion[1] = true;
    }
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

    dame_puntos_articulacion();

    if(cantPuntos == 0)
        cout << -1 << endl;
    else
    {
        cout << cantPuntos << endl;
        for(int i = 0; i < 10005; i++)
        {
            if(puntosArticulacion[i])
                cout << i << " ";
        }
        cout << endl;
    }
}
